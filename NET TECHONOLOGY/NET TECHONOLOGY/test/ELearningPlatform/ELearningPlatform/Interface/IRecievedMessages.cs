using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace ELearningPlatform.Interface
{
   public interface IRecievedMessages
    {
        public IActionResult RecieveMessage(IdentityUser user);
    }
}
