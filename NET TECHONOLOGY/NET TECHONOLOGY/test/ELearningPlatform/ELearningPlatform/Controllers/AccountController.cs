using ELearningPlatform.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;


        private readonly ApplicationDbContext _context;
        public AccountController(IConfiguration configuration, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _configuration = configuration;
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;

        }
        [HttpPost]
        [Route("RegisterStudentOrFaculty")]
        public async Task<IActionResult> Register(string role, string userName, string email, string password)
        {
            if (role != "Student" && role != "Faculty")
            {
                return BadRequest("Please provide Student or Faculty as role");
            }
            if (role == "Student")
            {
                IdentityUser userExist = await _userManager.FindByNameAsync(userName);
                if (userExist != null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Student Already Exists" });
                IdentityUser user = new()
                {
                    Email = email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = userName

                };
                IdentityResult result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "student creation failed" });
                }

                if (await _roleManager.RoleExistsAsync(UserRoles.Student))
                {
                    await _userManager.AddToRoleAsync(user, UserRoles.Student);
                }

                return Ok(new Response { Status = "Success", Message = "student created successfully" });
            }
            if (role == "Faculty")
            {
                IdentityUser userExist = await _userManager.FindByNameAsync(userName);
                if (userExist != null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Student Already Exists" });
                IdentityUser user = new()
                {
                    Email = email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = userName

                };
                IdentityResult result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "student creation failed" });
                }

                if (await _roleManager.RoleExistsAsync(UserRoles.Faculty))
                {
                    await _userManager.AddToRoleAsync(user, UserRoles.Faculty);
                }

                return Ok(new Response { Status = "Success", Message = "Faculty created successfully" });
            }

            return BadRequest("please enter all the fields");

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            IdentityUser user = await _userManager.FindByNameAsync(userName);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {

                IList<string> userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                     new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),

                };
                foreach (string userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                SymmetricSecurityKey authSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secretkey"]));
                JwtSecurityToken token = new(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(5),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256) //this is our signature algorithm
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                }
                );
            }
            return Unauthorized("please enter correct username and password");

        }



    }
}
