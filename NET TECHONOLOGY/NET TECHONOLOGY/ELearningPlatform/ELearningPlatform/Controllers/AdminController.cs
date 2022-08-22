using ELearningPlatform.Authentication;
using ELearningPlatform.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
       
        private readonly ApplicationDbContext context;
        public AdminController(UserManager<IdentityUser> _userManager,ApplicationDbContext _context)
        {
            userManager = _userManager;
            context = _context;
        }
      
        [HttpPut]
        [Route("EditUserDetails")]
        public async Task<IActionResult> EditUsers(string Id,string UserName,string Email)
        {
            if(Id!=null&& UserName != null&& Email != null)
            {
                var user = await userManager.FindByIdAsync(Id);
                user.UserName = UserName;
                user.Email = Email;
                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Success", Message = "user Edited successfully" });
                }
            }
            return BadRequest("please enter all the fields");   


        }

        [HttpDelete]
        [Route("DeleteUser")]

        public async Task<IActionResult> DeleteUsers(string Id)
        {
            if (Id != null)
            {
                var userExists = await userManager.FindByIdAsync(Id);
                var UserDelete = await userManager.DeleteAsync(userExists);
                if (UserDelete.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Success", Message = "user deleted successfully" });
                }
            }
            return BadRequest("please provide proper ID");
        }

        [HttpGet]
        [Route("GetUserDetails")]
        public async Task<IActionResult> GetUsers(string Id)
        {
            if(Id==null)
            {
                return BadRequest("please fill the ID");
            }
            var userDetails = await userManager.FindByIdAsync(Id);
            return Ok(userDetails);
        }

        [HttpGet]
        [Route("GetFilesOfStudents")]
        public IActionResult GetFiles()
        {
            string[] filepaths = Directory.GetFiles(@"UploadedFilesOfStudents", "*", SearchOption.AllDirectories);
            List<FileModel> fileList = new List<FileModel>();
            foreach (string filepath in filepaths)
            {
                fileList.Add(new FileModel { FileName = Path.GetFileName(filepath) });
            }
            return Ok(fileList);
        }
        [HttpGet]
        [Route("DisplayMessages")]
        public IActionResult DisplayMessage()
        {
           return Ok(context.Chat.ToList());
        }

    }
}
