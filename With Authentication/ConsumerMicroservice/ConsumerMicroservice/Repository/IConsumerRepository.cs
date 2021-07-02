using ConsumerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice.Repository
{
    public interface IConsumerRepository
    {
        public bool CreateConsumerBusiness(ConsumerBusiness consumerBusiness);
        public bool UpdateConsumerBusiness(ConsumerBusiness consumerBusiness);
        public bool CreateBusinessProperty(BusinessProperty businessProperty);
        public bool UpdateBusinessProperty(BusinessProperty businessProperty);
        public ConsumerBusinessDetails ViewConsumerBusiness(string ConsumerId, string BusinessId);
        public BusinessPropertyDetails ViewConsumerProperty(string ConsumerId, string PropertyId);

    }
}
