using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insureity_Portal.Models
{
    public class PolicyDetails
    {
        public string ConsumerId { get; set; }
        public string PolicyId { get; set; }
        public string BusinessId { get; set; }
        public string ConsumerName { get; set; }
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public string AcceptedQuotes { get; set; }
        public string PolicyStatus { get; set; }
        public string PaymentDetails { get; set; }
        public string AcceptanceStatus { get; set; }
        public DateTime EffectiveDate { get; set; }


    }
}
