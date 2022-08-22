using ELearningPlatform.Authentication;
using ELearningPlatform.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningPlatform.ImplementationLogic
{
    public class FilesOfStudent:ControllerBase,IFilesOfStudent
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        public FilesOfStudent(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
           
        }
        public IActionResult GetFilesOfStudent(string studentName)
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
            return BadRequest("Enter student name");
        }
    }
}
