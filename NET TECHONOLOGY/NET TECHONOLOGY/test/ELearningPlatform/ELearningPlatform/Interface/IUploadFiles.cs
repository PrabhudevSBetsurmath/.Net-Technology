using ELearningPlatform.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace ELearningPlatform.Interface
{
   public interface IUploadFiles
    {
        public IActionResult UploadTheFiles(EnumModel fileType, List<IFormFile> files, IdentityUser user);
    }
}
