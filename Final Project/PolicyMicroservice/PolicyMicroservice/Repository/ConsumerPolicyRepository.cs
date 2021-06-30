using PolicyMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;

namespace PolicyMicroservice.Repository
{
    public class ConsumerPolicyRepository : IConsumerPolicyRepository
    {
        public bool CreatePolicy(CreatePolicyRequest createPolicy)
        {
            var id = PolicyData.PolicyList.Count();
            ConsumerPolicy consumerPolicy = new ConsumerPolicy()
            {
                Id = id+1,
                ConsumerId = createPolicy.ConsumerId,
                BusinessId = createPolicy.BusinessId,
                AcceptedQuotes = createPolicy.AcceptedQuotes,
                PolicyStatus = "Initiated",
            };

            PolicyData.PolicyList.Add(consumerPolicy);
            return true;
        }

        public bool IssuePolicy(IssuePolicyRequest issuePolicy)
        {
            ConsumerPolicy consumerPolicy = PolicyData.PolicyList.FirstOrDefault(p => p.ConsumerId.Equals(issuePolicy.ConsumerId) && p.BusinessId.Equals(issuePolicy.BusinessId));
            int id = consumerPolicy.Id;
            string accquote = consumerPolicy.AcceptedQuotes;
            PolicyData.PolicyList.Remove(consumerPolicy);
            DateTime date = DateTime.Now;
            ConsumerPolicy addPolicy = new ConsumerPolicy()
            {
                Id = id,
                ConsumerId = issuePolicy.ConsumerId,
                BusinessId = issuePolicy.BusinessId,
                PolicyId = issuePolicy.PolicyId,
                AcceptedQuotes = accquote,
                PolicyStatus = "Issued",
                PaymentDetails = issuePolicy.PaymentDetails,
                AcceptanceStatus = issuePolicy.AcceptanceStatus,
                EffectiveDate = date
            };

            PolicyData.PolicyList.Add(addPolicy);
            return true;
        }

        public ConsumerPolicy GetPolicy(string ConsumerId, string PolicyId)
        {
            ConsumerPolicy consumer = PolicyData.PolicyList.FirstOrDefault(p => p.ConsumerId.Equals(ConsumerId) && p.PolicyId.Equals(PolicyId));
            return consumer;
        }
    }
    
}
