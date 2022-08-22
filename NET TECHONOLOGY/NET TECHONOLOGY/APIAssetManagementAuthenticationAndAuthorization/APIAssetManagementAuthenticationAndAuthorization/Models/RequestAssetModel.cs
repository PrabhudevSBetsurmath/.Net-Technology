using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIAssetManagementAuthenticationAndAuthorization.Models
{
    [Table("RequestAsset")]
    public class RequestAssetModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public int AssetId { get; set; }
        [StringLength(255)]
        public string AssetName { get; set; }
        [StringLength(255)]
        public string UserName { get; set; }
       
       
    }
}
