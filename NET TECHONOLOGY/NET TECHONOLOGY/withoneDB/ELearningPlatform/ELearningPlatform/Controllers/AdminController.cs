using ELearningPlatform.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ELearningPlatform.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _admin;
        private readonly UserManager<IdentityUser> _userManager;


        public AdminController(IAdmin admin, UserManager<IdentityUser> userManager)
        {
            _admin = admin;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("RegisterStudentOrFaculty")]
        public async Task<IActionResult> Register(string role, string userName, string email, string password)
        {
            return await _admin.Register( role,  userName, email, password);
        }

        [HttpGet]
        [Route("GetStudents")]
        public async Task<IActionResult> GetStudents()
        {
            IdentityUser userAdmin = await _userManager.FindByNameAsync(User.Identity.Name);
            return _admin.GetStudents();
        }

        [HttpGet]
        [Route("GetFaculties")]
        public async Task<IActionResult> GetFaculties()
        {
            IdentityUser userAdmin = await _userManager.FindByNameAsync(User.Identity.Name);
            return _admin.GetFaculties();
        }


        [HttpDelete]
        [Route("DeleteUser")]

        public async Task<IActionResult> DeleteUser(string userName)
        {
            IdentityUser userAdmin = await _userManager.FindByNameAsync(User.Identity.Name);
            return await _admin.DeleteUser(userName);
        }
      

        [HttpGet]
        [Route("GetFilesOfStudent")]
        public IActionResult GetFilesOfStudents(string studentName)
        {
           
            return _admin.GetFilesOfStudents(studentName);
        }


        [HttpGet]
        [Route("DisplayMessages")]
        public IActionResult DisplayMessage(string senderName, string recevierName)
        {
            return _admin.DisplayMessage(senderName,recevierName);
        }

    }
}
