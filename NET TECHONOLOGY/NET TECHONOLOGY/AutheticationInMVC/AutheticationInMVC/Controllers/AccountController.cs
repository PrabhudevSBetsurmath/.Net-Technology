using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AutheticationInMVC.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;

        public AccountController(IConfiguration config, UserManager<IdentityUser> userManager)
        {
            _config = config;
            _userManager = userManager;


        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(string userName, string email, string password)
        {
            if (ModelState.IsValid)
            {
                IdentityUser userExist = _userManager.FindByNameAsync(userName).Result;
                if (userExist != null)
                    return View("NotFound");
                IdentityUser user = new IdentityUser()
                {
                    Email = email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = userName

                };
                IdentityResult result = _userManager.CreateAsync(user, password).Result;
                if (!result.Succeeded)
                {
                    return View("Error");
                }


                return View("UserCreated");
            }
            return View("NotGet");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = _userManager.FindByNameAsync(userName).Result;
                if (user != null && _userManager.CheckPasswordAsync(user, password).Result)
                {


                    var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                     new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),

                };

                    SymmetricSecurityKey authSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secretkey"]));
                    JwtSecurityToken token = new JwtSecurityToken(
                        issuer: _config["JWT:ValidIssuer"],
                        audience: _config["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(5),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256) //this is our signature algorithm
                        );


                    var tokenGenerated = new JwtSecurityTokenHandler().WriteToken(token);
                    ViewBag.tokenGenerated = tokenGenerated;
                    return View("GetToken");
                }
            }
            return View("NotGet");

        }
    }
}
