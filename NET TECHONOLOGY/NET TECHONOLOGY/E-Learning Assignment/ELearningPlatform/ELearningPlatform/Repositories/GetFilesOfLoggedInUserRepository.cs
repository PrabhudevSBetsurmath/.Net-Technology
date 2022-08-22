using ELearningPlatform.Authentication;
using ELearningPlatform.Interface;
using ELearningPlatform.Models;
using System.Collections.Generic;
using System.Linq;

namespace ELearningPlatform.ImplementationLogic
{
    public class GetFilesOfLoggedInUserRepository : IGetFilesRepository
    {
        private readonly ApplicationDbContext _context;
        public GetFilesOfLoggedInUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<FileModel> FetchTheFiles(string userEmail)
        {
            var fileExists = _context.Files.Where(x => x.UserEmail == userEmail).ToList();
            
            return fileExists;
        }
    }
}
