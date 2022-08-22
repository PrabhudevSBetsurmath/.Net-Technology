using System;
using System.ComponentModel.DataAnnotations;

namespace ELearningPlatform.Models
{
    public class CalenderModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
      public string StudentEmail { get; set; }
        [Required]
        public string FacultyEmail{ get; set; }
        [Required]
        public DateTime DateAndTime { get; set; }
        [Required]
        public string EventName { get; set; }


    }
}
