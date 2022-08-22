using System;
using System.ComponentModel.DataAnnotations;
namespace AssetManagement.Models
{
    public class Book
    {
        [Required(ErrorMessage = "id is required")]
        public int id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Author name is required")]
        public string author { get; set; }

        [Required(ErrorMessage = "Edition is required")]
        public string edition { get; set; }
        [Required(ErrorMessage = "Dateofpublish is required")]
        public DateTime dateOfPublish { get; set; }
    }
}
