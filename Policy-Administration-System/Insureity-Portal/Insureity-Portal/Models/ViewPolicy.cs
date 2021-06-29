using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insureity_Portal.Models
{
    public class ViewPolicy
    {
        [Required(ErrorMessage = "please Enter Consumer Id")]
        public string ConsumerId { get; set; }

        [Required(ErrorMessage = "please Enter Business Id")]
        public string BusinessId { get; set; }

        [Required(ErrorMessage = "Please Enter Policy Id")]
        public string PolicyId { get; set; }
    }
}
