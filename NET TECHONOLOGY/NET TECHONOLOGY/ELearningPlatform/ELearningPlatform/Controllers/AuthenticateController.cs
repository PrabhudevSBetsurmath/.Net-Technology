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
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        public AuthenticateController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(string Role,string UserName,string Email,string Password)
        {
            if(Role=="Admin")
            {
                var userExist = await userManager.FindByNameAsync(UserName);
                if (userExist != null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Student Already Exists" });
                IdentityUser user = new IdentityUser()
                {
                    Email = Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = UserName

                };
                var result = await userManager.CreateAsync(user, Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "student creation failed" });
                }
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.Student))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Student));
                if (!await roleManager.RoleExistsAsync(UserRoles.Faculty))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Faculty));
                if (await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await userManager.AddToRoleAsync(user, UserRoles.Admin);
                }

                return Ok(new Response { Status = "Success", Message = "student created successfully" });

            }
            if(Role=="Student")
            {
                var userExist = await userManager.FindByNameAsync(UserName);
                if (userExist != null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Student Already Exists" });
                IdentityUser user = new IdentityUser()
                {
                    Email = Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = UserName

                };
                var result = await userManager.CreateAsync(user, Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "student creation failed" });
                }
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.Student))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Student));
                if (!await roleManager.RoleExistsAsync(UserRoles.Faculty))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Faculty));
                if (await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await userManager.AddToRoleAsync(user, UserRoles.Student);
                }

                return Ok(new Response { Status = "Success", Message = "student created successfully" });
            }
            if(Role=="Faculty")
            {
                var userExist = await userManager.FindByNameAsync(UserName);
                if (userExist != null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Student Already Exists" });
                IdentityUser user = new IdentityUser()
                {
                    Email = Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = UserName

                };
                var result = await userManager.CreateAsync(user, Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "student creation failed" });
                }
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.Student))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Student));
                if (!await roleManager.RoleExistsAsync(UserRoles.Faculty))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Faculty));
                if (await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await userManager.AddToRoleAsync(user, UserRoles.Faculty);
                }

                return Ok(new Response { Status = "Success", Message = "student created successfully" });
            }
            return BadRequest("please enter all the fields");
            
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string UserName,string Password)
        {
            var user = await userManager.FindByNameAsync(UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                     new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),

                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secretkey"]));
                var token = new JwtSecurityToken(
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
