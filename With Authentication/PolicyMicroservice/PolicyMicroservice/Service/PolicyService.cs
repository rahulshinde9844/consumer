using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using PolicyMicroservice.Models;
using PolicyMicroservice.Repository;
using PolicyMicroservice.Filters;
using Microsoft.AspNetCore.Http;

namespace PolicyMicroservice.Service
{
    public class PolicyService : IPolicyService
    {
        private readonly IConsumerPolicyRepository _policyRepository;
        private readonly IConfiguration _configuration;
        public PolicyService(IConfiguration configuration, IConsumerPolicyRepository PolicyRepository)
        {
            _configuration = configuration;
            _policyRepository = PolicyRepository;
        }
        
        public bool CreatePolicy(CreatePolicyRequest createPolicy)
        {
            return _policyRepository.CreatePolicy(createPolicy);
        }

        public bool IssuePolicy(IssuePolicyRequest issuePolicy)
        {
            return _policyRepository.IssuePolicy(issuePolicy);
        }

        public PolicyDetails ViewPolicy(string ConsumerId, string BusinessId, string PolicyId)
        {
            ConsumerPolicy consumerPolicy =  _policyRepository.GetPolicy(ConsumerId, PolicyId);
            ConsumerBusiness consumerData = ConsumerDetail(ConsumerId, BusinessId);

            PolicyDetails policyDetails = new PolicyDetails()
            {
                ConsumerId = ConsumerId,
                PolicyId = PolicyId,
                BusinessId = BusinessId,
                ConsumerName = consumerData.ConsumerName,
                AgentId = consumerData.AgentId,
                AgentName = consumerData.AgentName,
                AcceptedQuotes = consumerPolicy.AcceptedQuotes,
                PolicyStatus = consumerPolicy.PolicyStatus,
                PaymentDetails = consumerPolicy.PaymentDetails,
                AcceptanceStatus = consumerPolicy.AcceptanceStatus,
                EffectiveDate = consumerPolicy.EffectiveDate
            };
            return policyDetails;
        }

        public string GetQuotes(int PropertyValue, int BusinessValue, string PropertyType)
        {
            string uriConn = _configuration.GetValue<string>("ServiceURIs:Quotes");
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(uriConn);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    client.DefaultRequestHeaders.Add("ContentType", "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", Convert.ToString(TokenValidation.token));
                    var httpResponse = client.GetAsync($"/api/Quotes/getQuotesForPolicy/{PropertyValue}/{BusinessValue}/{PropertyType}").Result;
                    var responseString = httpResponse.Content.ReadAsStringAsync().Result;

                    if (!httpResponse.IsSuccessStatusCode)
                    {
                        throw new Exception("Unable to reach [Consumer] microservice.");
                    }

                    string response = JsonConvert.DeserializeObject<string>(responseString);
                    return response;
                }
            }
            catch(Exception e)
            {
                return e.Message;
            }   
        }

        public ConsumerBusiness ConsumerDetail(string ConsumerId, string BusinessId)
        {
            string uriConn = _configuration.GetValue<string>("ServiceURIs:Consumer");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uriConn);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", Convert.ToString(TokenValidation.token));
                var httpResponse = client.GetAsync($"/api/Consumer/viewConsumerBusiness/{ConsumerId}/{BusinessId}").Result;
                var responseString = httpResponse.Content.ReadAsStringAsync().Result;

                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Unable to reach [Consumer] microservice.");
                }

                ConsumerBusiness response = JsonConvert.DeserializeObject<ConsumerBusiness>(responseString);
                return response;
            }    
            
        }
    }
}
