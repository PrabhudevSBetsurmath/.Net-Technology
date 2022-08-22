using ELearningPlatform.Authentication;
using ELearningPlatform.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace ELearningPlatform.Repositories
{
    public class AccountRepository:IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;



        public AccountRepository(IConfiguration configuration, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _configuration = configuration;
            _roleManager = roleManager;
            _userManager = userManager;


        }

        public object Login(IdentityUser user, string password)
        {
            IList<string> userRoles = _userManager.GetRolesAsync(user).Result;
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
            return(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            }
            );
        }

        public IdentityResult Register(string role,string userName, string email, string password)
        {
            IdentityUser user = new()
            {
                Email = email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = userName

            };

            IdentityResult result =  _userManager.CreateAsync(user, password).Result;
            if(role=="Student")
            if ( _roleManager.RoleExistsAsync(UserRoles.Student).Result)
            {
                var roleAssignedToStudent= _userManager.AddToRoleAsync(user, UserRoles.Student).Result;
            }
            else if(role=="Faculty")
                {
                    if (_roleManager.RoleExistsAsync(UserRoles.Faculty).Result)
                    {
                        var roleAssignedToFaculty= _userManager.AddToRoleAsync(user, UserRoles.Faculty).Result;
                    }

                }
            return result;

        }
    }
}
