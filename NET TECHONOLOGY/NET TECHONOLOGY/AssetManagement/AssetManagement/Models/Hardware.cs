using System;
using System.ComponentModel.DataAnnotations;
namespace AssetManagement.Models
{
    public class Hardware
    {        
                 
        [Required(ErrorMessage="id is required")]
        public int id{get;set;}

        [Required(ErrorMessage="Name is required")]
        public string name{get;set;}
       
        [Required(ErrorMessage="Brand name is required")]
        public string brand{get;set;}
      
        [Required(ErrorMessage="Model is required")]
        public DateTime installationDate {get;set;}
        
        [Required(ErrorMessage="Amount is required")]
        public double amount {get;set;}
    }
}
