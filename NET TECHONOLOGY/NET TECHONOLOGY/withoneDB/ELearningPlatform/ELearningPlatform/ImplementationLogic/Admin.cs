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
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly ApplicationDbContext _context;
        public Admin(UserManager<IdentityUser> userManager, ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Register(string role, string userName, string email, string password)
        {
            if(role!="Student" && role!="Faculty")
            {
                return BadRequest("Please provide Student or Faculty as role");
            }
            if (role == "Student")
            {
                IdentityUser userExist = await _userManager.FindByNameAsync(userName);
                if (userExist != null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Student Already Exists" });
                IdentityUser user = new IdentityUser()
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
                IdentityUser user = new IdentityUser()
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


        public IActionResult GetFilesOfStudents(string studentName)
        {
            if (studentName != null)
            {
                IList<IdentityUser> StudentsList = _userManager.GetUsersInRoleAsync(UserRoles.Student).Result;
                string student = StudentsList.Where(i => i.UserName == studentName).Select(i => i.UserName).FirstOrDefault();
                if (student == null)
                {
                    return NotFound("student not found");
                }
                var FileExists = _context.Files.Where(x => x.Name == student).Select(i => new { i.Name, i.FileName, i.FileType }).ToList();
                if (FileExists.Count == 0)
                {
                    return BadRequest("students hasn't uploaded any files");
                }
                return Ok(FileExists);
            }
            return BadRequest("Enter student name");
        }


        public IActionResult DisplayMessage(string senderName,string recevierName)
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
