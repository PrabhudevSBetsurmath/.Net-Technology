using System.ComponentModel.DataAnnotations;

namespace ELearningPlatform.Models
{
    public class FileModel
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string UserEmail { set; get; }
        [Required]
        public string FileName { set; get; }
        [Required]
        public EnumModel FileType { set; get; }


    }
}
