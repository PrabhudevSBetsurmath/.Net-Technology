using ELearningPlatform.Authentication;
using ELearningPlatform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;



namespace ELearningPlatform.Interface
{
    public class Faculty : ControllerBase, IFaculty
    {
       
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public Faculty(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            
            _context = context;
            _userManager = userManager;

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

      
        public IActionResult SetCalenderEvents(string studentEmail, DateTime dateAndTime, string eventName, string userEmail)
        {

            if (studentEmail != null && eventName != null)
            {
                IList<IdentityUser> studentList = _userManager.GetUsersInRoleAsync(UserRoles.Student).Result;
                string student = studentList.Where(i => i.Email == studentEmail).Select(i => i.UserName).FirstOrDefault();
                if (student != null)
                {
                    CalenderModel calenderModel = new()
                    {
                        StudentEmail = studentEmail,
                        FacultyEmail = userEmail,
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
