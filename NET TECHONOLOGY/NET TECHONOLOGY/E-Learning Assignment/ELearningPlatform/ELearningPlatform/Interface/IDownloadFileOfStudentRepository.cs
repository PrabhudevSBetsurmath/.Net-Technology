using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningPlatform.Interface
{
   public interface IDownloadFileOfStudentRepository
    {
        public byte[] DownloadFile(string userEmail, string fileName);
    }
}
