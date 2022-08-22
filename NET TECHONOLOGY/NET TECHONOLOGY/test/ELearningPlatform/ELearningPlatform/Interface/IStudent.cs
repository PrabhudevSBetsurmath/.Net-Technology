using ELearningPlatform.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace ELearningPlatform.Interface
{
  public interface IStudent
    {
        
        public IActionResult DownloadFile(IdentityUser user,string fileName);
        public IActionResult GetFilesOfStudent(IdentityUser user);
        public IActionResult GetEvents(string userEmail);
        public IActionResult SendMessage(string receiverName, string message, IdentityUser user);
      

    }
}
