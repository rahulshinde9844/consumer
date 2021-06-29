using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insureity_Portal.Models
{
    public class ConsumerBusiness
    {
        [Required(ErrorMessage = "Please Enter Consumer ID")]
        public string ConsumerId { get; set; }

        [Required(ErrorMessage = "Please Enter Consumer Name")]
        public string ConsumerName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DOB { get; set; }


        [Required(ErrorMessage = "Please Enter Email Id")]
        public string Email { get; set; }


        [Required]
        [RegularExpression(@"^[A-Za-z]{5}\d{4}[A-Za-z]$", ErrorMessage = "Invalid PAN")]
        public string Pan { get; set; }


        [Required(ErrorMessage = "Please Enter Agent Id")]
        public int AgentId { get; set; }

        [Required(ErrorMessage = "Please Enter Agent Name")]
        public string AgentName { get; set; }

        [Required(ErrorMessage = "Please Enter Business ID")]
        public string BusinessId { get; set; }

        [Required(ErrorMessage = "Please Enter Validity of Consumer")]
        public int ValidityofConsumer { get; set; }

        [Required(ErrorMessage = "Please Enter Business Overview")]
        public string BusinessOverview { get; set; }

        [Required(ErrorMessage = "Please Enter Business Type")]
        public string BusinessType { get; set; }


        [Required(ErrorMessage = "Please Enter Business Turnover")]
        public int AnnualTurnOver { get; set; }


        [Required(ErrorMessage = "Please Enter Total Employeees")]
        public int TotalEmployees { get; set; }

        [Required(ErrorMessage = "Please Enter CapitalInvested")]
        public int CapitalInvested { get; set; }

    }
}
