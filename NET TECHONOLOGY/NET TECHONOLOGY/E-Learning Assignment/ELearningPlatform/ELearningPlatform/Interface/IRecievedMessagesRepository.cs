using ELearningPlatform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ELearningPlatform.Interface
{
   public interface IRecievedMessagesRepository
    {
        public List<ChatModel> RecieveMessage(string email);
    }
}
