using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insureity_Portal.Models
{
    public class ViewBusinessProperty
    {
        [Required(ErrorMessage = "Please Enter Consumer ID")]
        public string ConsumerId { get; set; }


        [Required(ErrorMessage = "Please Enter Property ID")]
        public string PropertyId { get; set; }

    }
}
