using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insureity_Portal.Models
{
    public class LoginDetails
    {
        [Required(ErrorMessage = "Please Enter Username ")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter Password ")]
        public string Password { get; set; }
    }
}
