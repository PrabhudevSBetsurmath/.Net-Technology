using ELearningPlatform.Authentication;
using ELearningPlatform.Interface;
using ELearningPlatform.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;


namespace ELearningPlatform.ImplementationLogic
{
    public class UploadFilesRepository:IUploadFilesRepository
    {
        private readonly IWebHostEnvironment _webHostingEnvironment;
        private readonly ApplicationDbContext _context;

        public UploadFilesRepository(IWebHostEnvironment webHostingEnvironment, ApplicationDbContext context)
        {
            
            _webHostingEnvironment = webHostingEnvironment;
            _context = context;
        }
        public void UploadTheFiles(EnumModel fileType, List<IFormFile> files, string userEmail)
        {

            string directorypath = Path.Combine(_webHostingEnvironment.ContentRootPath, "UploadedFiles");
            foreach (IFormFile file in files)
            {
                string filePath = Path.Combine(directorypath, file.FileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    FileModel fileModel = new FileModel
                    {
                        UserEmail = userEmail,
                        FileName = file.FileName,
                        FileType = fileType,
                    };
                    file.CopyTo(stream);
                    _context.Files.Add(fileModel);
                    _context.SaveChanges();
                }

            }
            
        }
    }
}
