using ELearningPlatform.Authentication;
using ELearningPlatform.Interface;
using ELearningPlatform.Models;
using System.Collections.Generic;
using System.Linq;


namespace ELearningPlatform.ImplementationLogic
{
    public class GetFilesOfStudentRepository:IFilesOfStudentRepository
    {
       
        private readonly ApplicationDbContext _context;
        public GetFilesOfStudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<FileModel> FetchFilesOfStudent(string studentEmail)
        {
            var fileExists = _context.Files.Where(x => x.UserEmail == studentEmail).ToList();
            return fileExists;

        }

    }
}
