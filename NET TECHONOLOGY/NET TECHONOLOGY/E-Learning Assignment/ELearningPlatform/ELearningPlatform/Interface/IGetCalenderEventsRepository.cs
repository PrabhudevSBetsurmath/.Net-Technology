using ELearningPlatform.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace ELearningPlatform.Interface
{
  public interface IGetCalenderEventsRepository
    {  
      public List<CalenderModel> GetEvents(string userEmail);
    }
}
