using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ELearningPlatform.Interface
{
   public interface IAdminRepository
    {
       
        public object GetStudents(IList<IdentityUser> students);
        public object GetFaculties(IList<IdentityUser> faculties);
        public void DeleteUser(IdentityUser userExists);
       
    }
}
