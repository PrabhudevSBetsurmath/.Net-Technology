using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace APIAssetManagementAuthenticationAndAuthorization.Models
{
    [Table("Book")]
    public  class Book
    {
        [Key]
        public int SerialNo { get; set; }
        [StringLength(255)]
        public string BookName { get; set; }
        [StringLength(255)]
        public string Author { get; set; }
        [StringLength(255)]
        public string Edition { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateOfPublish { get; set; }
        [Column("Assigned user")]
        [StringLength(10)]
        public string AssignedUser { get; set; }
    }
}
