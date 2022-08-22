using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningPlatform.Models
{
    public class FileModel
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string FacultyId { set; get; }
        [Required]
        public string FileName { set; get; }
        [Required]
        public string ContentType { set; get; }


    }
}
