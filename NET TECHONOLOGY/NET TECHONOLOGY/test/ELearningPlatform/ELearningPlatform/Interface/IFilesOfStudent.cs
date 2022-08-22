using Microsoft.AspNetCore.Mvc;


namespace ELearningPlatform.Interface
{
  public  interface IFilesOfStudent
    {
        public IActionResult GetFilesOfStudent(string studentName);
    }
}
