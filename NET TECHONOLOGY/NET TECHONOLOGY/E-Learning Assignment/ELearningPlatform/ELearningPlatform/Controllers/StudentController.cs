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
    [Authorize(Roles = "Student")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IDownloadFileOfStudentRepository _downloadFileOfStudent;
        private readonly ApplicationDbContext _context;
        private readonly IGetFilesRepository _getFiles;
        private readonly ISendMessageRepository _sendMessage;
        private readonly IRecievedMessagesRepository _recieveMessages;
        private readonly IUploadFilesRepository _uploadFiles;
        private readonly IGetCalenderEventsRepository _student;
        private readonly UserManager<IdentityUser> _userManager;
        public StudentController(IDownloadFileOfStudentRepository downloadFileOfStudent, ApplicationDbContext context, IGetFilesRepository getFiles, ISendMessageRepository sendMessage, IRecievedMessagesRepository recieveMessages,  IGetCalenderEventsRepository student, UserManager<IdentityUser> userManager, IUploadFilesRepository uploadFiles)
        {
            _downloadFileOfStudent = downloadFileOfStudent;
            _context = context;
            _getFiles = getFiles;
            _sendMessage = sendMessage;
            _recieveMessages = recieveMessages;
            _student = student;
            _userManager = userManager;
            _uploadFiles = uploadFiles;
            
        }


       
        [HttpPost]
        [Route("UploadFilesOfStudent")]
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
        [Route("DownloadStudentFile")]
        public IActionResult DownloadFile(string fileName)
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            string userEmail = user.Email;
            string fileNameExists = _context.Files.Where(i => i.FileName == fileName && i.UserEmail == userEmail).Select(i => i.FileName).FirstOrDefault();
            if (fileName!=null && fileNameExists!=null)
            {
                byte[] file = _downloadFileOfStudent.DownloadFile(userEmail, fileName);
                return File(file, "application/octet-stream", fileName);
                
            }
            return BadRequest("file does not exists or enter the filename");
        }


       
        [HttpGet]
        [Route("GetFilesOfStudent")]
        public IActionResult GetFilesOfStudents()
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            string userEmail = user.Email;
           var fileExists= _getFiles.FetchTheFiles(userEmail);
            if (fileExists.Count == 0)
            {
                return BadRequest($"{user} hasn't uploaded any files");
            }
            return Ok(fileExists);
            
        }


        
        [HttpGet]
        [Route("CalenderOfEvents")]
        public IActionResult GetEvents()
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            string userEmail = user.Email;
          List<CalenderModel> eventExists= _student.GetEvents(userEmail);
            if (eventExists.Count == 0)
            {
                return BadRequest($"{userEmail}'s events has not been set");
            }
            return Ok(eventExists);


        }


       
        [HttpPost]
        [Route("SendMessageToFaculty")]
        public IActionResult SendMessageToFaculty(string email, string message)
        {
            IdentityUser userAdmin = _userManager.FindByNameAsync(User.Identity.Name).Result;
            string userEmail = userAdmin.Email;
            if (userEmail != null && email != null && message != null)
            {
                IList<IdentityUser> facultyList = _userManager.GetUsersInRoleAsync(UserRoles.Faculty).Result;
                string faculty = facultyList.Where(i => i.Email== email).Select(i => i.UserName).FirstOrDefault();
                if (faculty != null)
                {
                    _sendMessage.SendMessage(email, message, userEmail);
                    return Ok($"Message sent successfully to faculty");
                }
                return NotFound("faculty not found");

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


        [HttpGet]
        [Route("ReceiveMessageFromAdminAndFaculties")]
        public IActionResult RecieveMessage()
        {
            IdentityUser userAdmin = _userManager.FindByNameAsync(User.Identity.Name).Result;
            string userEmail = userAdmin.Email;
            var messages = _recieveMessages.RecieveMessage(userEmail);
            if (messages.Count == 0)
            {
                return BadRequest($"{userAdmin} has no messages");
            }
            return Ok(messages);
        }

      
    }
}
