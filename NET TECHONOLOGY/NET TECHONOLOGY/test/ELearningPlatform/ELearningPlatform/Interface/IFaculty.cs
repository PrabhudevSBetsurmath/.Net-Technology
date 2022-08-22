using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;



namespace ELearningPlatform.Interface
{
   public  interface IFaculty
    {
       
        public IActionResult GetFilesOfFaculties(IdentityUser user);
       
        public IActionResult SetCalenderEvents(string studentName, DateTime dateAndTime, string eventName, string userEmail);
       
        public IActionResult SendMessage(string recieverName, string message, IdentityUser user);


    }
}
