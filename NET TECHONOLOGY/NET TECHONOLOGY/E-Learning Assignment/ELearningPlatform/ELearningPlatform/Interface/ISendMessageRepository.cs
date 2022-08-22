using ELearningPlatform.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningPlatform.Interface
{
   public interface ISendMessageRepository
    {
        public void SendMessage(string email, string message, string userEmail);
    }
}
