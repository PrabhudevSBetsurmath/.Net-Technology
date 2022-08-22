using ELearningPlatform.Authentication;
using ELearningPlatform.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningPlatform.ImplementationLogic
{
    public class RecievedMessages:ControllerBase,IRecievedMessages
    {
        private readonly ApplicationDbContext _context;

        public RecievedMessages(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult RecieveMessage(IdentityUser user)
        {

            var messages = _context.Chat.Where(x => x.ReceiverName == Convert.ToString(user)).Select(i => new { i.SenderName, i.DateAndTime, i.Message }).ToList();
            if (messages.Count == 0)
            {
                return BadRequest($"{user} has no messages");
            }

            return Ok(messages);
        }
    }
}
