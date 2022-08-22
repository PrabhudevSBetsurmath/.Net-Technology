using System;
using System.ComponentModel.DataAnnotations;


namespace ELearningPlatform.Models
{
    public class ChatModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SenderEmail { get; set; }
        [Required]
        public string ReceiverEmail { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime DateAndTime { get; set; }

    }
}
