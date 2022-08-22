using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ELearningPlatform.Interface
{
   public interface IAdmin
    {
       
        public IActionResult GetStudents();
        public IActionResult GetFaculties();
        Task<IActionResult> DeleteUser(string userName);
        public IActionResult DisplayMessages(string senderName, string recevierName);
    }
}
