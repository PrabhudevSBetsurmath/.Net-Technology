using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace APIAssetManagementAuthenticationAndAuthorization.Models
{
    [Table("SoftwareLicense")]
    public class SoftwareLicense
    {
        [Key]
        public int SerialNo { get; set; }
        [StringLength(255)]
        public string SoftwareName { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateOfPublish { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateOfExpiry { get; set; }
        [Column("price")]
        public int? Price { get; set; }
        [Column("Assigned User")]
        [StringLength(255)]
        public string AssignedUser { get; set; }
    }
}
