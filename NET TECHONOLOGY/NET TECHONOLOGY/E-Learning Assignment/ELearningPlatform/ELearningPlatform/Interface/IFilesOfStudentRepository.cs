using ELearningPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ELearningPlatform.Interface
{
  public  interface IFilesOfStudentRepository
    {
        public List<FileModel> FetchFilesOfStudent(string studentName);
    }
}
