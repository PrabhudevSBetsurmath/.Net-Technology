using ELearningPlatform.Authentication;
using ELearningPlatform.Interface;
using ELearningPlatform.Models;
using System;


namespace ELearningPlatform.ImplementationLogic
{
    public class SendMessageRepository : ISendMessageRepository
    {
        public readonly ApplicationDbContext _context;
        public SendMessageRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public void SendMessage(string email, string message, string userEmail)
        {

            ChatModel chatModel = new()
            {
                ReceiverEmail = email,
                SenderEmail = userEmail,
                Message = message,
                DateAndTime = DateTime.Now

            };
                    _context.Chat.Add(chatModel);
                    _context.SaveChanges();
        }
       
    }
}
