using Insureity_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insureity_Portal.Repository
{
    public interface IPolicyRepository
    {
        public void AddResponseconsumer (ConsumerBusiness consumerBusiness);
        public void AddResponseproperty (BusinessProperty businessProperty);
        public void Save();
    }
}
