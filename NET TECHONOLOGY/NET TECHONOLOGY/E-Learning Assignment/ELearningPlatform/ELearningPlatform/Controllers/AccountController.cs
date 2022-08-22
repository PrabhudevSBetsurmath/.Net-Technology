using ELearningPlatform.Authentication;
using ELearningPlatform.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace ELearningPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepo;
        private readonly UserManager<IdentityUser> _userManager;
       


       
        public AccountController(IAccountRepository accountRepo, IConfiguration configuration, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _accountRepo = accountRepo;
            _userManager = userManager;
          

        }
        [HttpPost]
        [Route("RegisterStudentOrFaculty")]
        public async Task<IActionResult> Register(string role, string userName, string email, string password)
        {
                if (role == "Student" || role == "Faculty")
                {

                    if (role == "Student")
                    {
                        IdentityUser userExist = await _userManager.FindByNameAsync(userName);
                        if (userExist != null)
                            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Student Already Exists" });
                    var result = _accountRepo.Register(role,userName,email,password);
                        if (!result.Succeeded)
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "student creation failed" });
                        }
                        return Ok(new Response { Status = "Success", Message = "student created successfully" });
                    }
                    if (role == "Faculty")
                    {
                        IdentityUser userExist = await _userManager.FindByNameAsync(userName);
                        if (userExist != null)
                            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Student Already Exists" });
                    var result = _accountRepo.Register(role, userName, email, password);
                    if (!result.Succeeded)
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "student creation failed" });
                        }

                        return Ok(new Response { Status = "Success", Message = "Faculty created successfully" });
                    }
                }
                return Unauthorized("enter all fields correctly and please provide correct username or email or password or role");
            
            
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            try
            {
                IdentityUser user = await _userManager.FindByNameAsync(userName);
                if (user != null && await _userManager.CheckPasswordAsync(user, password))
                {
                   return Ok( _accountRepo.Login(user,password));
                }
                return Unauthorized("please enter correct username and password");
            }
            catch(Exception)
            {
                return BadRequest("enter all the fileds");
            }
        }



    }
}
