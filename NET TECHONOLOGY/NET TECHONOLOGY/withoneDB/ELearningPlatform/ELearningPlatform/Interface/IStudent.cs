using ELearningPlatform.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace ELearningPlatform.Interface
{
  public interface IStudent
    {
        public IActionResult UploadFiles(EnumModel fileType, List<IFormFile> files,IdentityUser user);
        public IActionResult DownloadFile(IdentityUser user,string fileName);
        public IActionResult GetFilesOfStudents(IdentityUser user);
        public IActionResult GetEvents(IdentityUser user);
        public IActionResult SendMessage(string receiverName, string message, IdentityUser user);
        public IActionResult RecieveMessage(IdentityUser user);

    }
}
