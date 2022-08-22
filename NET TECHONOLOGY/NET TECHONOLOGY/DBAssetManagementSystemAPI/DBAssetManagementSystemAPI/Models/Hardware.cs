using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DBAssetManagementSystemAPI.Models
{
    [Table("Hardware")]
    public partial class Hardware
    {
        [Key]
        public int SerialNo { get; set; }
        [StringLength(255)]
        public string HardwareName { get; set; }
        [StringLength(255)]
        public string Brand { get; set; }
        [Column(TypeName = "date")]
        public DateTime? InstallationDate { get; set; }
        public int? Amount { get; set; }
    }
}
