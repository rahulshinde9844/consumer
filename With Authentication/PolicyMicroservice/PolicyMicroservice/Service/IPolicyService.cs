using PolicyMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Service
{   

    public interface IPolicyService
    {
        bool CreatePolicy(CreatePolicyRequest createPolicy);
        bool IssuePolicy(IssuePolicyRequest issuePolicy);
        PolicyDetails ViewPolicy(string consumerId, string BusinessId, string policyId);
        string GetQuotes(int PropertyValue, int BusinessValue, string PropertyType);
    }
}
