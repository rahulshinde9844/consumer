using ConsumerMicroservice.Models;
using ConsumerMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice.Service
{ 
    public class ConsumerService : IConsumerService
    {
        private IConsumerRepository _consumerRepository;

        public  ConsumerService(IConsumerRepository conrepo)
        {
            _consumerRepository = conrepo;
        }
        

        public bool CreateConsumerBusiness(ConsumerBusiness consumerBusiness)
        {
            _consumerRepository = new ConsumerRepository();
            return _consumerRepository.CreateConsumerBusiness(consumerBusiness);
        }



        public bool UpdateConsumerBusiness(ConsumerBusiness consumerBusiness)
        {
            _consumerRepository = new ConsumerRepository();
            return _consumerRepository.UpdateConsumerBusiness(consumerBusiness);
        }



        public bool CreateBusinessProperty(BusinessProperty businessProperty)
        {
            _consumerRepository = new ConsumerRepository();
            return _consumerRepository.CreateBusinessProperty(businessProperty);
        }



        public bool UpdateBusinessProperty(BusinessProperty businessProperty)
        {
            _consumerRepository = new ConsumerRepository();
            return _consumerRepository.UpdateBusinessProperty(businessProperty);
        }

        

        public ConsumerBusinessDetails ViewConsumerBusiness(string ConsumerId, string BusinessId)
        {
           
            return _consumerRepository.ViewConsumerBusiness(ConsumerId, BusinessId);
        }


        
        public BusinessPropertyDetails ViewConsumerProperty(string ConsumerId, string PropertyId)
        {
           
            return _consumerRepository.ViewConsumerProperty(ConsumerId, PropertyId);
        }

    

  
    }
}

