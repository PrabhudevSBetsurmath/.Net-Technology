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
        
        private readonly IFaculty _faculty;
        private readonly UserManager<IdentityUser> _userManager;
        public FacultyController(IFaculty faculty, UserManager<IdentityUser> userManager)
        {
            _faculty = faculty;
            _userManager = userManager;
        }

        
        [HttpPost]
        [Route("UploadFilesOfFaculty")]
        public IActionResult UploadFiles(EnumModel fileType, List<IFormFile> files)
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            return _faculty.UploadFiles(fileType,files,user);
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

            return _faculty.GetFilesOfStudents(studentName);
        }


       
        [HttpPost]
        [Route("CalenderEvents")]
        public IActionResult CalenderEvents(string studentName,DateTime dateAndTime,string eventName)
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            return _faculty.CalenderEvents(studentName, dateAndTime, eventName, user);
        }


       
        [HttpGet]
        [Route("ReceiveMessagesFromStudents")]
        public IActionResult RecieveMessage()
        {
            IdentityUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            return _faculty.RecieveMessage(user);
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

