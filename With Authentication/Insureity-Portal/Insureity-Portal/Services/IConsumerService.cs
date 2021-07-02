using Insureity_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insureity_Portal.Services
{
    public interface IConsumerService
    {
        bool CreateConsumerBusiness(ConsumerBusiness consumerBusiness);
        bool UpdateConsumerBusiness(ConsumerBusiness consumerBusiness);
        ConsumerBusinessDetails ViewConsumerBusinessDetail(string consumerId, string businessId);
        bool CreateBusinessProperty(BusinessProperty businessProperty);
        bool UpdateBusinessProperty(BusinessProperty businessProperty);
        BusinessPropertyDetails ViewBusinessPropertyDetail(string consumerId, string businessId);
    }
}
