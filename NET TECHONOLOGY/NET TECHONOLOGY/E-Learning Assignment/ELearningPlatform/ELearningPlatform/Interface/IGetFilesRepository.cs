using ELearningPlatform.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningPlatform.Interface
{
   public interface IGetFilesRepository
    {
        public List<FileModel> FetchTheFiles(string userEmail);
    }
}
