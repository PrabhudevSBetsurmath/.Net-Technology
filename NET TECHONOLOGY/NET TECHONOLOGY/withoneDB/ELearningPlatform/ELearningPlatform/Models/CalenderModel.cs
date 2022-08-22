using System;
using System.ComponentModel.DataAnnotations;

namespace ELearningPlatform.Models
{
    public class CalenderModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
      public string StudentName { get; set; }
        [Required]
        public string FacultyName { get; set; }
        [Required]
        public DateTime DateAndTime { get; set; }
        [Required]
        public string EventName { get; set; }


    }
}
