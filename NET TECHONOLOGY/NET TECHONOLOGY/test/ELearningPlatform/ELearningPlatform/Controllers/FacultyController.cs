using ELearningPlatform.Interface;
using ELearningPlatform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace ELearningPlatform.Controllers
{

    [Authorize(Roles = "Faculty")]
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IRecievedMessages _recieveMessages;
        private readonly IFilesOfStudent _filesOfStudent;
        private readonly IFaculty _faculty;
        private readonly IUploadFiles _uploadFiles;
        private readonly UserManager<IdentityUser> _userManager;
        public FacultyController(IRecievedMessages recieveMessages, IFilesOfStudent filesOfStudent, IFaculty faculty, UserManager<IdentityUser> userManager,IUploadFiles uploadFiles)
        {
            _recieveMessages = recieveMessages;
            _filesOfStudent = filesOfStudent;
            _faculty = faculty;
            _userManager = userManager;
            _uploadFiles = uploadFiles;
        }

        
        [HttpPost]
        [Route("UploadFilesOfFaculty")]
        public IActionResult UploadFiles(EnumModel fileType, List<IFormFile> files)
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
          string userEmail=user.Email;
            return _uploadFiles.UploadTheFiles(fileType,files,user);
        }


        
        [HttpGet]
        [Route("GetFilesOfFaculty")]
        public IActionResult GetFilesOfFaculties()
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            return _faculty.GetFilesOfFaculties(user);
        }


       
        [HttpGet]
        [Route("GetFilesOfStudent")]
        public IActionResult GetFilesOfStudents(string studentName)
        {

            return _filesOfStudent.GetFilesOfStudent(studentName);
        }


       
        [HttpPost]
        [Route("CalenderEvents")]
        public IActionResult CalenderEvents(string StudentEmail,DateTime dateAndTime,string eventName)
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            string userEmail = user.Email;
            return _faculty.SetCalenderEvents(StudentEmail, dateAndTime, eventName, userEmail);
        }


       
        [HttpGet]
        [Route("ReceiveMessagesFromStudents")]
        public IActionResult RecieveMessage()
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            return _recieveMessages.RecieveMessage(user);
        }

       
        [HttpGet]
        [Route("SendMessageToStudent")]
        public IActionResult SendMessage(string receiverName, string message)
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            return _faculty.SendMessage(receiverName, message, user);
        }
    }
   
   

    
}

