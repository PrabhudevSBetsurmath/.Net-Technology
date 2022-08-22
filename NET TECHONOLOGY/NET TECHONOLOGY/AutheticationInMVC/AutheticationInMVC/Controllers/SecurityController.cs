using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutheticationInMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private string GenerateJSONWebToken(string username)
        {
            SymmetricSecurityKey authSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Thisisasceretkey1234567"));
            var signingCredentials = new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256);
            var authClaims = new[]
                {
                    new Claim("Issuer","shiv"),
                     new Claim("Admin","true"),
                      new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                      new Claim(JwtRegisteredClaimNames.UniqueName,username)

                };
            JwtSecurityToken token = new("shiv",
                "shiv",
               expires: DateTime.Now.AddHours(5),
               claims: authClaims,
               signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256) //this is our signature algorithm
               );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
       
        // GET api/<SecurityController>/5
        [HttpGet]
        public string Get()
        {
            return GenerateJSONWebToken("shiv"); 
        }

        // POST api/<SecurityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SecurityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SecurityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
