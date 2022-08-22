using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningPlatform.Interface
{
   public interface IAccountRepository
    {
        public object Login(IdentityUser user, string password);
        public IdentityResult Register(string role,string userName, string email, string password);
    }
}
