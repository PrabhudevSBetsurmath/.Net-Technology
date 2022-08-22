using ELearningPlatform.Authentication;
using ELearningPlatform.Models;
using System.Collections.Generic;
using System.Linq;


namespace ELearningPlatform.Interface
{
    public class GetCalenderEventsRepository:IGetCalenderEventsRepository
    {
      
        private readonly ApplicationDbContext _context;
        
        public GetCalenderEventsRepository( ApplicationDbContext context)
        {
            
            _context = context;
        }


        public List<CalenderModel> GetEvents(string userEmail)
        {
          
            var eventExits = _context.CalenderEvents.Where(x => x.StudentEmail == userEmail).ToList();
            return eventExits;
        }

       

        
    }
}
