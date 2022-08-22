using Microsoft.AspNetCore.Mvc;
using System;



namespace ELearningPlatform.Interface
{
   public  interface ICalenderEventsRepository
    {
      public void SetCalenderEvents(string studentName, DateTime dateAndTime, string eventName, string userEmail);

    }
}
