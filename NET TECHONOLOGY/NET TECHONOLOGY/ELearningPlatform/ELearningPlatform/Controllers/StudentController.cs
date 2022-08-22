using ELearningPlatform.Authentication;
using ELearningPlatform.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostingEnvironment;
        private readonly ApplicationDbContext context;
        public StudentController(IWebHostEnvironment _webHostingEnvironment,ApplicationDbContext _context)
        {
            webHostingEnvironment = _webHostingEnvironment;
            context = _context;
        }
        [HttpPost]
        [Route("FileUploadOfStudents")]
        public IActionResult UploadFiles(List<IFormFile> files)
        {
            if(files.Count==0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "file uploaded failed please add the file" });
            }
            string directorypath = Path.Combine(webHostingEnvironment.ContentRootPath, "UploadedFilesOfStudents");
            foreach(var file in files)
            {
                string filePath = Path.Combine(directorypath, file.FileName);
                using(var stream=new FileStream(filePath,FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Success", Message = "file uploaded successfully" });
        }
        [HttpGet]
        [Route("CalenderOfEvents")]
        public IActionResult GetEvents(string studentId)
        { 
            if(studentId==null)
            {
                return BadRequest("please provide the ID");
            }
            var Eventexits = context.CalenderEvents.Where(x => x.StudentId == studentId).Select(i=> new { i.StudentId,i.FacultyId,i.DateAndTime,i.EventName}).ToList();

            return Ok(Eventexits);
        }
       [HttpPost]
        [Route("SendMessages")]
        public IActionResult SendMessage(string studentId,string FacultyId,string Message)
        {
            if(studentId!=null && FacultyId!=null && Message!=null)
            {
                ChatModel chatModel = new ChatModel()
                {
                    StudentId = studentId,
                    FacultyId = FacultyId,
                    Message = Message,
                    DateAndTime = DateTime.Now

                };
                context.Chat.Add(chatModel);
                context.SaveChanges();

                return Ok(" Message sent successfully");
            }
            return BadRequest("Enter all the fields");
            
            
            
         }
           
    }
}
