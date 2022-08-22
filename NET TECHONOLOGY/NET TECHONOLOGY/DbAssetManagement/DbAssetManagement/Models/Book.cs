using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DbAssetManagement.Models
{
    [Table("Book")]
    public partial class Book
    {
        [Key]
        [Required]
        public int SerialNo { get; set; }
        [Required]
        [StringLength(255)]
        public string BookName { get; set; }
        [Required]
        [StringLength(255)]
        public string Author { get; set; }
        [Required]
        [StringLength(255)]
        public string Edition { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime? DateOfPublish { get; set; }
    }
}
