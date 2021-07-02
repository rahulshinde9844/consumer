using Insureity_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insureity_Portal.Repository
{
    public class PolicyRepository : IPolicyRepository
    {
        private PolicyContext policyContext;

        public PolicyRepository(PolicyContext _policyContext)
        {
            policyContext = _policyContext;
        }
        public void AddResponseconsumer(ConsumerBusiness consumerBusiness)
        {
            policyContext.ConsumerBusinessesDb.Add(consumerBusiness);
        }
        public void AddResponseproperty(BusinessProperty businessProperty)
        {
            policyContext.BusinessPropertyDb.Add(businessProperty);
        }

        public void Save()
        {
            policyContext.SaveChanges();
        }
    }
}
