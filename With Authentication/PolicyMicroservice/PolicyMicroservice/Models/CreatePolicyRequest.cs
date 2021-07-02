using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Models
{
    public class CreatePolicyRequest
    {
        public string ConsumerId { get; set; }
        public string BusinessId { get; set; }
        public string AcceptedQuotes { get; set; }
    }
}
