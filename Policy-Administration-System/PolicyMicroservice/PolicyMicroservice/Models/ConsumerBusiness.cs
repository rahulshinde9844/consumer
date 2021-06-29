using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Models
{
    public class ConsumerBusiness
    {
        public string ConsumerId { get; set; }
        public string ConsumerName { get; set; }
        public string DOB { get; set; }
        public string Email { get; set; }
        public string Pan { get; set; }
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public string BusinessId { get; set; }
        public int ValidityofConsumer { get; set; }
        public string BusinessOverview { get; set; }
        public string BusinessType { get; set; }
        public int AnnualTurnOver { get; set; }
        public int TotalEmployees { get; set; }
        public int CapitalInvested { get; set; }
        public int BusinessValue { get; set; }
    }
}
