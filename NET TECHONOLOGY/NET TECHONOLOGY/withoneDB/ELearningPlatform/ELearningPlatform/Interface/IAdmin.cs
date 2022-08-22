using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ELearningPlatform.Interface
{
   public interface IAdmin
    {
        Task<IActionResult> Register(string role, string userName, string email, string password);
        public IActionResult GetStudents();
        public IActionResult GetFaculties();
        Task<IActionResult> DeleteUser(string userName);
        public IActionResult GetFilesOfStudents(string studentName);
        public IActionResult DisplayMessage(string senderName, string recevierName);
    }
}
