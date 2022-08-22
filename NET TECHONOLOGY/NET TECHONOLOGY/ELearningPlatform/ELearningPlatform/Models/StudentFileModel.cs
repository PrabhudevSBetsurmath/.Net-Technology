using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningPlatform.Models
{
    public class StudentFileModel
    {
        [Key]
        public int Id { set; get; }
        public string StudentName { set; get; }
        
        public string FileName { set; get; }
      
        public EnumModel FileType { set; get; }


    }
}
