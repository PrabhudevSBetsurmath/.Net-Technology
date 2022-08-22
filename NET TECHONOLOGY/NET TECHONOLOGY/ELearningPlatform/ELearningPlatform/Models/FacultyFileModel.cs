using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningPlatform.Models
{
    public class FacultyFileModel
    {
        [Key]
        public int Id { set; get; }
        public string FacultyName { set; get; }

        public string FileName { set; get; }

        public string ContentType { set; get; }

       
    }
}
