using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace ELearningPlatform.Interface
{
    public class AdminRepository:IAdminRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        

       
        public AdminRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            
           
        }


        public object GetStudents(IList<IdentityUser> students)
        {
            var studentList = students.Select(i => new { i.Id, i.UserName, i.Email });
            return studentList;
        }


        public object GetFaculties(IList<IdentityUser> faculties)
        {

            var facultiesList = faculties.Select(i => new { i.Id, i.UserName, i.Email });
            return facultiesList;
        }


        public void DeleteUser(IdentityUser userExists)
        {
            _userManager.DeleteAsync(userExists);

        }

    }
}
