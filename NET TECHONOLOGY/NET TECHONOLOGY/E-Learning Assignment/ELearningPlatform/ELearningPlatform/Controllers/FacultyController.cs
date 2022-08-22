using ELearningPlatform.Authentication;
using ELearningPlatform.Interface;
using ELearningPlatform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ELearningPlatform.Controllers
{

    [Authorize(Roles = "Faculty")]
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IGetFilesRepository _getFiles;
        private readonly ISendMessageRepository _sendMessage;
        private readonly IRecievedMessagesRepository _recieveMessages;
        private readonly IFilesOfStudentRepository _filesOfStudent;
        private readonly ICalenderEventsRepository _calenderEvents;
        private readonly IUploadFilesRepository _uploadFiles;
        private readonly UserManager<IdentityUser> _userManager;
        public FacultyController(ICalenderEventsRepository calenderEvents,IGetFilesRepository getFiles, ISendMessageRepository sendMessage, IRecievedMessagesRepository recieveMessages, IFilesOfStudentRepository filesOfStudent,UserManager<IdentityUser> userManager,IUploadFilesRepository uploadFiles)
        {
            _getFiles = getFiles;
            _sendMessage = sendMessage;
            _recieveMessages = recieveMessages;
            _filesOfStudent = filesOfStudent;
            _calenderEvents = calenderEvents;
            _userManager = userManager;
            _uploadFiles = uploadFiles;
        }

        
        [HttpPost]
        [Route("UploadFilesOfFaculty")]
        public IActionResult UploadFiles(EnumModel fileType, List<IFormFile> files)
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            string userEmail = user.Email;
            if (files.Count == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "file uploaded failed please add the file" });
            }
            _uploadFiles.UploadTheFiles(fileType, files, userEmail);

            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "file uploaded successfully" });
        }


        
        [HttpGet]
        [Route("GetFilesOfFaculty")]
        public IActionResult GetFilesOfFaculties()
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            string userEmail = user.Email;
            var fileExists = _getFiles.FetchTheFiles(userEmail);
            if (fileExists.Count == 0)
            {
                return BadRequest($"{user} hasn't uploaded any files");
            }
            return Ok(fileExists);
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


       
        [HttpPost]
        [Route("CalenderEvents")]
        public IActionResult CalenderEvents(string studentEmail,DateTime dateAndTime,string eventName)
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            string userEmail = user.Email;
            if (studentEmail != null && eventName != null)
            {
                IList<IdentityUser> studentList = _userManager.GetUsersInRoleAsync(UserRoles.Student).Result;
                string student = studentList.Where(i => i.Email == studentEmail).Select(i => i.UserName).FirstOrDefault();
                if (student != null)
                {
                    _calenderEvents.SetCalenderEvents(studentEmail, dateAndTime, eventName, userEmail);
                    return Ok("calender events has been set");
                }
                return Ok("calender events has been set");
            }
            return BadRequest("enter all the fields");

        }



        [HttpGet]
        [Route("ReceiveMessageFromAdminAndStudents")]
        public IActionResult RecieveMessage()
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            string userEmail = user.Email;
            var messages = _recieveMessages.RecieveMessage(userEmail);
            if (messages.Count ==0)
            {
                return BadRequest($"{user} has no messages");
            }
            return Ok(messages);
        }



        [HttpGet]
        [Route("SendMessageToStudent")]
        public IActionResult SendMessageToStudent(string email, string message)
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            string userEmail = user.Email;
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

        [HttpPost]
        [Route("SendMessageToAdmin")]
        public IActionResult SendMessageToAdmin(string email, string message)
        {
            IdentityUser userAdmin = _userManager.FindByNameAsync(User.Identity.Name).Result;
            string userEmail = userAdmin.Email;
            if (userEmail != null && email != null && message != null)
            {
                IList<IdentityUser> adminList = _userManager.GetUsersInRoleAsync(UserRoles.Admin).Result;
                string admin = adminList.Where(i => i.Email == email).Select(i => i.UserName).FirstOrDefault();
                if (admin != null)
                {
                    _sendMessage.SendMessage(email, message, userEmail);
                    return Ok($"Message sent successfully to admin");
                }
                return NotFound("admin not found");

            }
            return BadRequest("Enter all the fields");

        }
       
    }
   
   

    
}

