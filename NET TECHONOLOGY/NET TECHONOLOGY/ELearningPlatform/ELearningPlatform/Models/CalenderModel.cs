using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningPlatform.Models
{
    public class CalenderModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
      public string StudentId { get; set; }
        [Required]
        public string FacultyId { get; set; }
        [Required]
        public DateTime DateAndTime { get; set; }
        [Required]
        public string EventName { get; set; }


    }
}
