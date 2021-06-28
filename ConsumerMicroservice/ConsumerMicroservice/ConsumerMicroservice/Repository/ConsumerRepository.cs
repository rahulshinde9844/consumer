using ConsumerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice.Repository
{
    public class ConsumerRepository : IConsumerRepository
    {

        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ConsumerRepository));
        public bool CreateBusinessProperty(BusinessProperty businessProperty)
        {
            Property property = new Property()
            {
                PropertyId = businessProperty.PropertyId,
                BuildingSqft = businessProperty.BuildingSqft,
                BuildingType = businessProperty.BuildingType,
                BuildingStoreys = businessProperty.BuildingStoreys,
                BuildingAge = businessProperty.BuildingAge
            };

            PropertyData.PropertyList.Add(property);
            return true;
        }

        public bool CreateConsumerBusiness(ConsumerBusiness consumerBusiness)
        {
            Consumer consumer = new Consumer()
            {
                ConsumerId = consumerBusiness.ConsumerId,
                ConsumerName = consumerBusiness.ConsumerName,
                DOB = consumerBusiness.DOB,
                Email = consumerBusiness.Email,
                Pan = consumerBusiness.Pan,
                BusinessOverview = consumerBusiness.BusinessOverview,
                ValidityofConsumer = consumerBusiness.ValidityofConsumer,
                AgentId = consumerBusiness.AgentId,
                AgentName = consumerBusiness.AgentName,
            };

            Business business = new Business()
            {
                BusinessId = consumerBusiness.BusinessId,
                BusinessType = consumerBusiness.BusinessType,
                AnnualTurnOver = consumerBusiness.AnnualTurnOver,
                TotalEmployees = consumerBusiness.TotalEmployees
            };

            ConsumerData.ConsumerList.Add(consumer);
            BusinessData.BusinessList.Add(business);

            _log4net.Info("Post : ConsumerBusiness created");

            return true;

        }

        public bool UpdateBusinessProperty(BusinessProperty businessProperty)
        {
            Property updateProperty = new Property()
            {
                PropertyId = businessProperty.PropertyId,
                BuildingSqft = businessProperty.BuildingSqft,
                BuildingType = businessProperty.BuildingType,
                BuildingStoreys = businessProperty.BuildingStoreys,
                BuildingAge = businessProperty.BuildingAge
            };

            Property deleteProperty = PropertyData.PropertyList.FirstOrDefault(p => p.PropertyId.Equals(businessProperty.PropertyId));

            PropertyData.PropertyList.Remove(deleteProperty);
            PropertyData.PropertyList.Add(updateProperty);
            return true;

        }

        public bool UpdateConsumerBusiness(ConsumerBusiness consumerBusiness)
        {

            Consumer updateConsumer = new Consumer()
            {
                ConsumerId = consumerBusiness.ConsumerId,
                ConsumerName = consumerBusiness.ConsumerName,
                DOB = consumerBusiness.DOB,
                Email = consumerBusiness.Email,
                Pan = consumerBusiness.Pan,
                BusinessOverview = consumerBusiness.BusinessOverview,
                ValidityofConsumer = consumerBusiness.ValidityofConsumer,
                AgentId = consumerBusiness.AgentId,
                AgentName = consumerBusiness.AgentName,
            };

            Business updatebusiness = new Business()
            {
                BusinessId = consumerBusiness.BusinessId,
                BusinessType = consumerBusiness.BusinessType,
                AnnualTurnOver = consumerBusiness.AnnualTurnOver,
                TotalEmployees = consumerBusiness.TotalEmployees
            };

            Consumer deleteConsumer = ConsumerData.ConsumerList.FirstOrDefault(c => c.ConsumerId.Equals(consumerBusiness.ConsumerId));
            Business deleteBusiness = BusinessData.BusinessList.FirstOrDefault(b => b.BusinessId.Equals(consumerBusiness.BusinessId));

            ConsumerData.ConsumerList.Remove(deleteConsumer);
            BusinessData.BusinessList.Remove(deleteBusiness);
            ConsumerData.ConsumerList.Add(updateConsumer);
            BusinessData.BusinessList.Add(updatebusiness);

            return true;
        }

        public ConsumerBusiness ViewConsumerBusiness(string ConsumerId, string BusinessId)
        {
            Consumer viewConsumer = ConsumerData.ConsumerList.FirstOrDefault(c => c.ConsumerId.Equals(ConsumerId));
            Business viewBusiness = BusinessData.BusinessList.FirstOrDefault(b => b.BusinessId.Equals(BusinessId));
            ConsumerBusiness consumerBusiness = new ConsumerBusiness()
            {
                ConsumerId = viewConsumer.ConsumerId,
                ConsumerName = viewConsumer.ConsumerName,
                DOB = viewConsumer.DOB,
                Email = viewConsumer.Email,
                Pan = viewConsumer.Pan,
                AgentId = viewConsumer.AgentId,
                AgentName = viewConsumer.AgentName,
                BusinessId = viewBusiness.BusinessId,
                BusinessOverview = viewConsumer.BusinessOverview,
                ValidityofConsumer = viewConsumer.ValidityofConsumer,
                BusinessType = viewBusiness.BusinessType,
                AnnualTurnOver = viewBusiness.AnnualTurnOver,
                TotalEmployees = viewBusiness.TotalEmployees

            };

            return consumerBusiness;
        }

        public BusinessProperty ViewConsumerProperty(string ConsumerId, string PropertyId)
        {

            Property viewProperty = PropertyData.PropertyList.FirstOrDefault(p => p.PropertyId.Equals(PropertyId));

            BusinessProperty businessProperty = new BusinessProperty()
            {
                ConsumerId = ConsumerId,
                PropertyId = viewProperty.PropertyId,
                BuildingSqft = viewProperty.BuildingSqft,
                BuildingType = viewProperty.BuildingType,
                BuildingStoreys = viewProperty.BuildingStoreys,
                BuildingAge = viewProperty.BuildingAge
            };

            return businessProperty;
        }

    }
}
