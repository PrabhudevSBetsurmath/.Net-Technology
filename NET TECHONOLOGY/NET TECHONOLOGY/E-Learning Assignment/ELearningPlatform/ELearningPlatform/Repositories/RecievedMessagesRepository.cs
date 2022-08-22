using ELearningPlatform.Authentication;
using ELearningPlatform.Interface;
using ELearningPlatform.Models;
using System.Collections.Generic;
using System.Linq;


namespace ELearningPlatform.ImplementationLogic
{
    public class RecievedMessagesRepository:IRecievedMessagesRepository
    {
        private readonly ApplicationDbContext _context;

        public RecievedMessagesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<ChatModel> RecieveMessage(string userEmail)
        {
            var messages = _context.Chat.Where(x => x.ReceiverEmail == userEmail).ToList();
            return messages;
        }
    }
}
