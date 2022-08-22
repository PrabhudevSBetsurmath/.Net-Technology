using ELearningPlatform.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace ELearningPlatform.Interface
{
   public  interface IFaculty
    {
        public IActionResult UploadFiles(EnumModel fileType,List<IFormFile> files, IdentityUser user);
        public IActionResult GetFilesOfFaculties(IdentityUser user);
        public IActionResult GetFilesOfStudents(string studentName);
        public IActionResult CalenderEvents(string studentName, DateTime dateAndTime, string eventName, IdentityUser user);
        public IActionResult RecieveMessage(IdentityUser user);
        public IActionResult SendMessage(string recieverName, string message, IdentityUser user);


    }
}
