using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DbAssetManagement.Models
{
    [Table("Hardware")]
    public partial class Hardware
    {
        [Required]
        [Key]
        public int SerialNo { get; set; }
        [Required]
        [StringLength(255)]
        public string HardwareName { get; set; }
        [Required]
        [StringLength(255)]
        public string Brand { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime? InstallationDate { get; set; }
        [Required]
        public int? Amount { get; set; }
    }
}
