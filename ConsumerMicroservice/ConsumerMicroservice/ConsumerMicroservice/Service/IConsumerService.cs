﻿using ConsumerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice.Service
{
    public interface IConsumerService
    {
        public bool CreateConsumerBusiness(ConsumerBusiness consumerBusiness);
        public bool UpdateConsumerBusiness(ConsumerBusiness consumerBusiness);

        public bool CreateBusinessProperty(BusinessProperty businessProperty);
        public bool UpdateBusinessProperty(BusinessProperty businessProperty);
        public ConsumerBusiness ViewConsumerBusiness(string ConsumerId, string BusinessId);
        public BusinessProperty ViewConsumerProperty(string ConsumerId, string PropertyId);
    }
}
