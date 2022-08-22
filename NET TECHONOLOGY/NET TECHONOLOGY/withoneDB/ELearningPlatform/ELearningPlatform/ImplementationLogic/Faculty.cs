using ELearningPlatform.Authentication;
using ELearningPlatform.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace ELearningPlatform.Interface
{
    public class Faculty : ControllerBase, IFaculty
    {
        private readonly IWebHostEnvironment _webHostingEnvironment;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public Faculty(IWebHostEnvironment webHostingEnvironment, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _webHostingEnvironment = webHostingEnvironment;
            _context = context;
            _userManager = userManager;

        }
       



        public IActionResult UploadFiles(EnumModel fileType,List<IFormFile> files, IdentityUser user)
        {

            if (files.Count == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "file uploaded failed please add the file" });
            }
            string directorypath = Path.Combine(_webHostingEnvironment.ContentRootPath, "UploadedFilesOfFaculties");
            foreach (IFormFile file in files)
            {
                string filePath = Path.Combine(directorypath, file.FileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    FileModel fileModel = new()
                    {
                        Name = Convert.ToString(user),
                        FileName = file.FileName,
                        FileType = fileType
                    };
                    file.CopyTo(stream);
                    _context.Files.Add(fileModel);
                    _context.SaveChanges();
                }

            }

            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "file uploaded successfully" });
        }

        public IActionResult GetFilesOfFaculties(IdentityUser user)
        {

            var FileExists = _context.Files.Where(x => x.Name == Convert.ToString(user)).Select(i => new { i.Name, i.FileName, i.FileType }).ToList();
            if (FileExists.Count == 0)
            {
                return BadRequest($"{user} hasn't uploaded any files");
            }
            return Ok(FileExists);

        }

        public IActionResult GetFilesOfStudents(string studentName)
        {
            if (studentName != null)
            {
                IList<IdentityUser> StudentsList = _userManager.GetUsersInRoleAsync(UserRoles.Student).Result;
                string student = StudentsList.Where(i => i.UserName == studentName).Select(i => i.UserName).FirstOrDefault();
                if (student == null)
                {
                    return NotFound("student not found");
                }
                var FileExists = _context.Files.Where(x => x.Name == student).Select(i => new { i.Name, i.FileName, i.FileType }).ToList();
                if (FileExists.Count == 0)
                {
                    return BadRequest("students hasn't uploaded any files");
                }
                return Ok(FileExists);
            }
            return BadRequest("Enter the user name");
        }

        public IActionResult CalenderEvents(string studentName, DateTime dateAndTime, string eventName, IdentityUser user)
        {

            if (studentName != null && eventName != null)
            {
                IList<IdentityUser> studentList = _userManager.GetUsersInRoleAsync(UserRoles.Student).Result;
                string student = studentList.Where(i => i.UserName == studentName).Select(i => i.UserName).FirstOrDefault();
                if (student != null)
                {
                    CalenderModel calenderModel = new()
                    {
                        StudentName = studentName,
                        FacultyName = Convert.ToString(user),
                        DateAndTime = dateAndTime,
                        EventName = eventName

                    };
                    _context.CalenderEvents.Add(calenderModel);
                    _context.SaveChanges();
                    return Ok("calender events has been set");

                }
                return NotFound("The studentName which you have enter is not present");
            }
            return BadRequest("enter all the fields");
        }

        public IActionResult RecieveMessage(IdentityUser user)
        {
            var messages = _context.Chat.Where(x => x.ReceiverName == Convert.ToString(user)).Select(i => new { i.SenderName, i.DateAndTime, i.Message }).ToList();
            if (messages.Count == 0)
            {
                return BadRequest($"{user} doesn't have any message");
            }
            return Ok(messages);
        }

        public IActionResult SendMessage(string receiverName, string message, IdentityUser user)
        {

            if (user != null && receiverName != null && message != null)
            {
                IList<IdentityUser> studentList = _userManager.GetUsersInRoleAsync(UserRoles.Student).Result;
                string student = studentList.Where(i => i.UserName == receiverName).Select(i => i.UserName).FirstOrDefault();
                if (student != null)
                {
                    ChatModel chatModel = new()
                    {
                        ReceiverName = receiverName,
                        SenderName = Convert.ToString(user),
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
