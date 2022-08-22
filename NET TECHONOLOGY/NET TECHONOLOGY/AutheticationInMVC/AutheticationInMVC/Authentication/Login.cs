using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutheticationInMVC.Authentication
{
    public class Login
    {

        [Required(ErrorMessage = "username is requried")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is requried")]
        public string Password { get; set; }
    }
}
