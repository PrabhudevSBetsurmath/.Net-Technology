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
    public class FacultyController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostingEnvironment;
        private readonly ApplicationDbContext context;
        public FacultyController(IWebHostEnvironment _webHostingEnvironment,ApplicationDbContext _context)
        {
            webHostingEnvironment = _webHostingEnvironment;
            context = _context;

        }
        [HttpPost]
        [Route("FileUploadOfFaculties")]
        public IActionResult UploadFiles(string FacultyId,List<IFormFile> files)
        {
            if (files.Count == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "file uploaded failed please add the file" });
            }
            string directorypath = Path.Combine(webHostingEnvironment.ContentRootPath, "UploadedFilesOfFaculties");
            foreach (var file in files)
            {
                string filePath = Path.Combine(directorypath, file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    FileModel fileModel = new FileModel
                    {
                        FacultyId= FacultyId,
                        FileName=file.FileName,
                        ContentType=file.ContentType
                    };
                    file.CopyTo(stream);
                    context.Files.Add(fileModel);
                    context.SaveChanges();
                }

            }

            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "file uploaded successfully" });
        }
        [HttpGet]
        [Route("GetFilesOfFaculties")]
        public IActionResult GetFilesOfFaculties(string FacultyId)
        {

            var Fileexits = context.Files.Where(x => x.FacultyId == FacultyId).Select(i => new { i.FacultyId, i.FileName, i.ContentType}).ToList();
            return Ok(Fileexits);

        }
        [HttpGet]
        [Route("GetFilesOfStudents")]
        public IActionResult GetFilesOfStudents()
        {
            string[] filepaths = Directory.GetFiles(@"UploadedFilesOfStudents", "*", SearchOption.AllDirectories);
            List<FileModel> fileList = new List<FileModel>();
            foreach (string filepath in filepaths)
            {
                fileList.Add(new FileModel { FileName = Path.GetFileName(filepath) });
            }
            return Ok(fileList);
        }

        [HttpPost]
        [Route("CalenderEvents")]
        public IActionResult CalenderEvents(string StudentId,string FacultyId,DateTime DateAndTime,string EventName)
        {
            if(StudentId!=null&& FacultyId!=null && EventName!=null)
            {
                CalenderModel calenderModel = new CalenderModel()
                {
                    StudentId = StudentId,
                    FacultyId = FacultyId,
                    DateAndTime = DateAndTime,
                    EventName = EventName

                };
                context.CalenderEvents.Add(calenderModel);
                context.SaveChanges();
                return Ok("calender events has been set");
            }
            return BadRequest("enter all the fields");
        }
        [HttpGet]
        [Route("ReceiveMessages")]
        public IActionResult RecieveMessage(string FacultyId)
        {
            if (FacultyId == null)
            {
                return BadRequest("enter the ID");
            }
            var messages = context.Chat.Where(x => x.FacultyId == FacultyId).Select(i => new { i.StudentId, i.FacultyId, i.DateAndTime, i.Message }).ToList();

            return Ok(messages);
        }
    }
   
   

    
}

