using ELearningPlatform.Authentication;
using ELearningPlatform.Interface;
using ELearningPlatform.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningPlatform.ImplementationLogic
{
    public class UploadFiles:ControllerBase,IUploadFiles
    {
        private readonly IWebHostEnvironment _webHostingEnvironment;
        private readonly ApplicationDbContext _context;

        public UploadFiles(IWebHostEnvironment webHostingEnvironment, ApplicationDbContext context)
        {
            
            _webHostingEnvironment = webHostingEnvironment;
            _context = context;
        }
        public IActionResult UploadTheFiles(EnumModel fileType, List<IFormFile> files, IdentityUser user)
        {

            if (files.Count == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "file uploaded failed please add the file" });
            }
            string directorypath = Path.Combine(_webHostingEnvironment.ContentRootPath, "UploadedFiles");
            foreach (IFormFile file in files)
            {
                string filePath = Path.Combine(directorypath, file.FileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    FileModel fileModel = new FileModel
                    {
                        Name = Convert.ToString(user),
                        FileName = file.FileName,
                        FileType = fileType,
                    };
                    file.CopyTo(stream);
                    _context.Files.Add(fileModel);
                    _context.SaveChanges();
                }

            }
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "file uploaded successfully" });
        }
    }
}
