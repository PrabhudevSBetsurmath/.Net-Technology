using ELearningPlatform.Authentication;
using ELearningPlatform.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace ELearningPlatform.Interface
{
    public class Student:ControllerBase,IStudent
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _webHostingEnvironment;
        private readonly ApplicationDbContext _context;
        
        public Student(IWebHostEnvironment webHostingEnvironment, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _webHostingEnvironment = webHostingEnvironment;
            _context = context;
        }


        public IActionResult DownloadFile(IdentityUser user,string fileName)
        {
            if (fileName != null)
            {
                FileExtensionContentTypeProvider provider = new FileExtensionContentTypeProvider();
                string fileNameExists = _context.Files.Where(i => i.FileName == fileName && i.Name == Convert.ToString(user)).Select(i => i.FileName).FirstOrDefault();
                if (fileNameExists == null)
                {
                    return BadRequest("File Does Not Exists");
                }
                string file = Path.Combine(_webHostingEnvironment.ContentRootPath, "UploadedFiles", Convert.ToString(fileNameExists));
                string contentType;

                if (!provider.TryGetContentType(file, out contentType))
                {
                    contentType = "application/octet-stream";
                }


                byte[] fileBytes;
                if (System.IO.File.Exists(file))
                {
                    fileBytes = System.IO.File.ReadAllBytes(file);
                }
                else
                {
                    return NotFound("File Not Found");
                }
                return File(fileBytes, contentType, Convert.ToString(fileNameExists));
            }
            return BadRequest("Enter the fileName");
        }

        public IActionResult GetFilesOfStudent(IdentityUser user)
        {
            
            var FileExists = _context.Files.Where(x => x.Name == Convert.ToString(user)).Select(i => new { i.Name, i.FileName, i.FileType }).ToList();
            if (FileExists.Count == 0)
            {
                return BadRequest($"{user} hasn't uploaded any files");
            }
            return Ok(FileExists);
        }

        public IActionResult GetEvents(string userEmail)
        {
          
            var Eventexits = _context.CalenderEvents.Where(x => x.StudentEmail == userEmail).Select(i => new { i.StudentEmail, i.FacultyEmail, i.DateAndTime, i.EventName }).ToList();
            if(Eventexits.Count==0)
            {
                return BadRequest($"{userEmail}'s events has not been set");
            }
            return Ok(Eventexits);
        }

        public IActionResult SendMessage(string receiverName, string message, IdentityUser user)
        {

            if (user != null && receiverName != null && message != null)
            {
                IList<IdentityUser> facultyList = _userManager.GetUsersInRoleAsync(UserRoles.Faculty).Result;
                string faculty = facultyList.Where(i => i.UserName == receiverName).Select(i => i.UserName).FirstOrDefault();
                if (faculty != null)
                {
                    ChatModel chatModel = new()
                    {
                        SenderName = Convert.ToString(user),
                        ReceiverName = receiverName,
                        Message = message,
                        DateAndTime = DateTime.Now

                    };
                    _context.Chat.Add(chatModel);
                    _context.SaveChanges();

                    return Ok(" Message sent successfully");

                }
                return NotFound("The ReceiverName which you have enter is not present");

            }
            return BadRequest("Enter all the fields");



        }

        
    }
}
