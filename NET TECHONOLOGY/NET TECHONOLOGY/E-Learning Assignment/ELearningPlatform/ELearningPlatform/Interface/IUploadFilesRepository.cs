using ELearningPlatform.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace ELearningPlatform.Interface
{
   public interface IUploadFilesRepository
    {
        public void UploadTheFiles(EnumModel fileType, List<IFormFile> files, string userEmail);
    }
}
