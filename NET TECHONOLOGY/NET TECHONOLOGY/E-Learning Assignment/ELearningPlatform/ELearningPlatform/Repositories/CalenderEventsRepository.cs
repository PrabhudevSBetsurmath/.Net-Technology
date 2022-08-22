using ELearningPlatform.Authentication;
using ELearningPlatform.Models;
using System;



namespace ELearningPlatform.Interface
{
    public class CalenderEventsRepository : ICalenderEventsRepository
    {
       
        private readonly ApplicationDbContext _context;
      


        public CalenderEventsRepository(ApplicationDbContext context)
        {
            _context = context;
          
        }


        public void SetCalenderEvents(string studentEmail, DateTime dateAndTime, string eventName, string userEmail)
        {
            CalenderModel calenderModel = new()
            {
                StudentEmail = studentEmail,
                FacultyEmail = userEmail,
                DateAndTime = dateAndTime,
                EventName = eventName

            };
            _context.CalenderEvents.Add(calenderModel);
            _context.SaveChanges();

        }
       
    }
}
