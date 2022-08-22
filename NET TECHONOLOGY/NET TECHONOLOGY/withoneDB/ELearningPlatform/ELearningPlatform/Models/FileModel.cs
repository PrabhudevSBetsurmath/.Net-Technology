using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ELearningPlatform.Models
{
    public  class FileModel
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public string FileName { set; get; }
        [Required]
        public EnumModel FileType { set; get; }


    }
}
