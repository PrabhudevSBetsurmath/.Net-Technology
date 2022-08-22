using ELearningPlatform.Authentication;
using ELearningPlatform.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningPlatform.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRecievedMessagesRepository _recievedMessages;
        private readonly ISendMessageRepository _sendMessage;
        private readonly IFilesOfStudentRepository _filesOfStudent;
        private readonly IAdminRepository _admin;
        private readonly UserManager<IdentityUser> _userManager;


        public AdminController(IRecievedMessagesRepository recievedMessages, ISendMessageRepository sendMessage, IFilesOfStudentRepository filesOfStudent, IAdminRepository admin, UserManager<IdentityUser> userManager)
        {
            _recievedMessages = recievedMessages;
            _sendMessage = sendMessage;
            _filesOfStudent = filesOfStudent;
            _admin = admin;
            _userManager = userManager;
        }



        [HttpGet]
        [Route("GetStudents")]
        public IActionResult GetStudents()
        {

            IList<IdentityUser> students = _userManager.GetUsersInRoleAsync(UserRoles.Student).Result;
            if (students.Count == 0)
            {
                return BadRequest("currently there are no students");
            }
            var getStudentList = _admin.GetStudents(students);
            if(getStudentList!=null)
            {
                return Ok(getStudentList);
            }
            return NotFound("currently students are not present in the list");
            
        }

        [HttpGet]
        [Route("GetFaculties")]
        public IActionResult GetFaculties()
        {

            IList<IdentityUser> faculties = _userManager.GetUsersInRoleAsync(UserRoles.Faculty).Result;
            if (faculties.Count == 0)
            {
                return BadRequest("currently there are no faculties");
            }
            var getFacultiesList = _admin.GetStudents(faculties);
            if (getFacultiesList != null)
            {
                return Ok(getFacultiesList);
            }
            return NotFound("currently faculties are not present in the list");
          
        }


        [HttpDelete]
        [Route("DeleteUser")]

        public async Task<IActionResult> DeleteUser(string userName)
        {
            if (userName != null)
            {
                var userExists = await _userManager.FindByNameAsync(userName);
                if (userExists == null)
                {
                    return NotFound("user not found");
                }
                else
                {
                    _admin.DeleteUser(userExists);
                    return Ok("user deleted successfully");
                }

            }
            return BadRequest("Enter the user name");

        }


        [HttpGet]
        [Route("GetFilesOfStudent")]
        public IActionResult GetFilesOfStudents(string studentEmail)
        {
            if (studentEmail != null)
            {
                IList<IdentityUser> StudentsList = _userManager.GetUsersInRoleAsync(UserRoles.Student).Result;
                string studentEmailExists = StudentsList.Where(i => i.Email == studentEmail).Select(i => i.Email).FirstOrDefault();
                if (studentEmailExists == null)
                {
                    return NotFound("student not found");
                }
                var fileExists = _filesOfStudent.FetchFilesOfStudent(studentEmailExists);
                if (fileExists.Count == 0)
                {
                    return BadRequest("students hasn't uploaded any files");
                }
                return Ok(fileExists);
            }
            return BadRequest("Enter student name");

        }

        [HttpGet]
        [Route("SendMessageToStudent")]
        public IActionResult SendMessageToStudent(string email, string message)
        {
            IdentityUser userAdmin = _userManager.FindByNameAsync(User.Identity.Name).Result;
            string userEmail = userAdmin.Email;
            if (userEmail != null && email != null && message != null)
            {
                IList<IdentityUser> studentList = _userManager.GetUsersInRoleAsync(UserRoles.Student).Result;
                string student = studentList.Where(i => i.Email == email).Select(i => i.UserName).FirstOrDefault();
                if (student != null)
                {
                    _sendMessage.SendMessage(email, message, userEmail);
                    return Ok($"Message sent successfully to student");
                }
                return NotFound("student not found");
                
            }
            return BadRequest("Enter all the fields");

        }

        [HttpGet]
        [Route("SendMessageToFaculty")]
        public IActionResult SendMessageToFaculty(string email, string message)
        {
            IdentityUser userAdmin = _userManager.FindByNameAsync(User.Identity.Name).Result;
            string userEmail = userAdmin.Email;
            if (userEmail != null && email != null && message != null)
            {
                IList<IdentityUser> facultyList = _userManager.GetUsersInRoleAsync(UserRoles.Faculty).Result;
                string faculty= facultyList.Where(i => i.Email == email).Select(i => i.UserName).FirstOrDefault();
                if (faculty != null)
                {
                    _sendMessage.SendMessage(email, message, userEmail);
                    return Ok($"Message sent successfully to faculty");
                }
                return NotFound("faculty not found");

            }
            return BadRequest("Enter all the fields");

        }

        [HttpGet]
        [Route("ReceiveMessageFromFacultiesAndStudents")]
        public IActionResult RecieveMessage()
        {
            IdentityUser userAdmin = _userManager.FindByNameAsync(User.Identity.Name).Result;
            string userEmail = userAdmin.Email;
            var messages = _recievedMessages.RecieveMessage(userEmail);
            if (messages.Count==0)
            {
                return BadRequest($"{userAdmin} has no messages");
            }
            return Ok(messages);
        }




    }
}
