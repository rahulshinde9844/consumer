using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Models
{
    public class IssuePolicyRequest
    {
        public string PolicyId { get; set; }
        public string ConsumerId { get; set; }
        public string BusinessId { get; set; }
        public string PaymentDetails { get; set; }
        public string AcceptanceStatus { get; set; }

    }
}
