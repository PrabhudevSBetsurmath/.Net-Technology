using ELearningPlatform.Authentication;
using ELearningPlatform.Interface;
using System.Linq;

namespace ELearningPlatform.ImplementationLogic
{
    public class DownloadFileOfStudentRepository:IDownloadFileOfStudentRepository
    {
        private readonly ApplicationDbContext _context;
       
        public DownloadFileOfStudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public byte[] DownloadFile(string userEmail, string fileName)
        {
            byte[] fileContent;
            string fileNameExists = _context.Files.Where(i => i.FileName == fileName && i.UserEmail == userEmail).Select(i => i.FileName).FirstOrDefault();
            fileContent = System.IO.File.ReadAllBytes($"UploadedFiles\\{fileNameExists}");
            return fileContent;
        }


    }
}
