using PolicyMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Repository
{
   public interface IConsumerPolicyRepository
    {
        bool CreatePolicy(CreatePolicyRequest createPolicy);

        bool IssuePolicy(IssuePolicyRequest issuePolicy);

        ConsumerPolicy GetPolicy(string ConsumerId, string PolicyId);
    }
}
