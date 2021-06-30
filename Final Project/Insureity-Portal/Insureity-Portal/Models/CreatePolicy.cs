using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insureity_Portal.Models
{
    public class CreatePolicy
    {
        [Required(ErrorMessage = "Please Enter Consumer ID ")]
        public string ConsumerId { get; set; }

        [Required(ErrorMessage = "Please Enter BusinessId ID ")]
        public string BusinessId { get; set; }

        [Required(ErrorMessage = "Please Enter Accepted Quotes")]
        public string AcceptedQuotes { get; set; }
    }
}
