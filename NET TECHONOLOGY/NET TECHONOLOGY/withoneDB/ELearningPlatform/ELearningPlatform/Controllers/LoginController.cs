using ELearningPlatform.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.Controllers
{

    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
      
        private readonly IConfiguration configuration;
        public LoginController(UserManager<IdentityUser> _userManager,IConfiguration _configuration)
        {
            userManager = _userManager;
            configuration = _configuration;
        }
        
        [HttpPost]
        [Route("api/Login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            IdentityUser user = await userManager.FindByNameAsync(userName);
            if (user != null && await userManager.CheckPasswordAsync(user, password))
            {
                
                IList<string> userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                     new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),

                };
                foreach (string userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                SymmetricSecurityKey authSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secretkey"]));
                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: configuration["JWT:ValidIssuer"],
                    audience: configuration["JWT:ValidAudience"],
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
