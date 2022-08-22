using ELearningPlatform.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningPlatform.Interface
{
    public class Admin:ControllerBase,IAdmin
    {
        private readonly UserManager<IdentityUser> _userManager;
        

        private readonly ApplicationDbContext _context;
        public Admin(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
           
        }

       


        public IActionResult GetStudents()
        {
            IList<IdentityUser> students = _userManager.GetUsersInRoleAsync(UserRoles.Student).Result;
            if(students.Count==0)
            {
                return BadRequest("currently there are no students");
            }
            var studentList = students.Select(i => new { i.Id, i.UserName, i.Email }).ToList();
            return Ok(studentList);
        }


        public IActionResult GetFaculties()
        {
            IList<IdentityUser> faculties = _userManager.GetUsersInRoleAsync(UserRoles.Faculty).Result;
            if (faculties.Count == 0)
            {
                return BadRequest("currently there are no faculties");
            }
            var facultiesList = faculties.Select(i => new { i.Id, i.UserName, i.Email}).ToList();
            return Ok(facultiesList);
        }


        public async Task<IActionResult> DeleteUser(string userName)
        {
            if(userName!=null)
            {
                IdentityUser userExists = await _userManager.FindByNameAsync(userName);
                if (userExists == null)
                {
                    return NotFound("user not found");
                }
                IdentityResult UserDelete = await _userManager.DeleteAsync(userExists);
                if (UserDelete.Succeeded)
                    return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "user deleted successfully" });
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "error occured in deleting" });

            }
            return BadRequest("Enter the user name");

        }



        public IActionResult DisplayMessages(string senderName,string recevierName)
        {
            if (senderName != null && recevierName != null)
            {
                var chatMessages = _context.Chat.Where(i => i.SenderName == senderName && i.ReceiverName == recevierName).Select(x => new { x.SenderName, x.ReceiverName, x.Message }).ToList();
                if (chatMessages == null)
                {
                    return NotFound("No chats are available");
                }
                return Ok(chatMessages);
            }
            return BadRequest("Enter all the fields");
        }
    }
}
