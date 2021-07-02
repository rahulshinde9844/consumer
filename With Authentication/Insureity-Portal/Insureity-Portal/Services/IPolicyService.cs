using Insureity_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insureity_Portal.Services
{
    public interface IPolicyService
    {
        bool CreatePolicy(CreatePolicy policy);
        bool IssuePolicy(IssuePolicy policy);
        PolicyDetails ViewPolicyDetails(ViewPolicy policy);
        string GetQuotesDetails(GetQuotes getQuotes);
    }
}
