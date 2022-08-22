using System;
using System.ComponentModel.DataAnnotations;
namespace AssetManagement.Models
{
    public class Software
    {        
          
        [Required(ErrorMessage="id is required")]
        public int id{get;set;}

        [Required(ErrorMessage="Name is required")]
        public string name{get;set;}
    
        [Required(ErrorMessage= "dateOfPublish is required")]
        public DateTime dateOfPublish{get;set;}
      
        [Required(ErrorMessage= "dateOfExpiry is required")]
        public DateTime dateOfExpiry{get;set;}
        
        [Required(ErrorMessage="Price is required")]
        public double price{get;set;}
    }
}
