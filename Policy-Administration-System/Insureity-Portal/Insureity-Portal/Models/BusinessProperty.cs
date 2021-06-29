using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insureity_Portal.Models
{
    public class BusinessProperty
    {

        [Required(ErrorMessage = "Please Enter Consumer ID")]
        public string ConsumerId { get; set; }

        [Required(ErrorMessage = "Please Enter Property ID")]
        public string PropertyId { get; set; }

        [Required(ErrorMessage = "Please Enter Building Sqft")]
        public int BuildingSqft { get; set; }

        [Required(ErrorMessage = "Please Enter Building Type")]
        public string BuildingType { get; set; }

        [Required(ErrorMessage = "Please Enter Building Storeys")]
        public int BuildingStoreys { get; set; }

        [Required(ErrorMessage = "Please Enter Building Age")]
        public int BuildingAge { get; set; }

        [Required(ErrorMessage = "Please Enter Cost of the Asset")]
        public int CostOfTheAsset { get; set; }

        [Required(ErrorMessage = "Please Enter Salvage Value")]
        public int SalvageValue { get; set; }

        [Required(ErrorMessage = "Please Enter Useful Life Of The Asset")]
        public int UsefulLifeOfTheAsset { get; set; }
    }
}
