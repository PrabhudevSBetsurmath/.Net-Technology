using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DbAssetManagement.Models
{
    [Table("SoftwareLicense")]
    public partial class SoftwareLicense
    {
        [Required]
        [Key]
        public int SerialNo { get; set; }
        [Required]
        [StringLength(255)]
        public string SoftwareName { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime? DateOfPublish { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime? DateOfExpiry { get; set; }
        [Required]
        [Column("price")]
        public int? Price { get; set; }
    }
}
