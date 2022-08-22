using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIAssetManagementAuthenticationAndAuthorization.Authentication
{
    public class RegisterModel
    {
        [Required( ErrorMessage ="username is requried")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is requried")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is requried")]
        public string Password { get; set; }
    }
}
