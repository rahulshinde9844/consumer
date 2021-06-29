using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insureity_Portal.Models
{
    public class GetQuotes
    {
        [Range(0,10)]
        [Required(ErrorMessage = "Please Enter Business Value between 0-10 ")]
        public int BusinessValue { get; set; }

        [Range(0, 10)]
        [Required(ErrorMessage = "Please Enter Property Value between 0-10 ")]
        public int PropertyValue { get; set; }

        [Required(ErrorMessage = "Please Enter Property Type ")]
        public string PropertyType { get; set; }

    }
}
