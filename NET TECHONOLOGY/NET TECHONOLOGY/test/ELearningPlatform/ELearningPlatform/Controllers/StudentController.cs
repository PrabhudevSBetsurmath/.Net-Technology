using ELearningPlatform.Interface;
using ELearningPlatform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ELearningPlatform.Controllers
{
    [Authorize(Roles = "Student")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IRecievedMessages _recieveMessages;
       
        private readonly IUploadFiles _uploadFiles;
        private readonly IStudent _student;
        private readonly UserManager<IdentityUser> _userManager;
        public StudentController(IRecievedMessages recieveMessages,  IStudent student, UserManager<IdentityUser> userManager, IUploadFiles uploadFiles)
        {
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
            return _uploadFiles.UploadTheFiles(fileType, files, user);

        }
        

        [HttpGet]
        [Route("DownloadStudentFile")]
        public IActionResult DownloadFile(string fileName)
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            return _student.DownloadFile(user,fileName);

        }


       
        [HttpGet]
        [Route("GetFilesOfStudent")]
        public IActionResult GetFilesOfStudents()
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            return _student.GetFilesOfStudent(user);
        }


        
        [HttpGet]
        [Route("CalenderOfEvents")]
        public IActionResult GetEvents()
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            string userEmail = user.Email;
            return _student.GetEvents(userEmail);
        }


       
        [HttpPost]
        [Route("SendMessageToFaculty")]
        public IActionResult SendMessage(string receiverName, string message)
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            return _student.SendMessage(receiverName, message, user); 
         }

       
        [HttpGet]
        [Route("ReceiveMessageFromFaculties")]
        public IActionResult RecieveMessage()
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            return _recieveMessages.RecieveMessage(user);
        }

    }
}
