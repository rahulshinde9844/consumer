using Insureity_Portal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Insureity_Portal.Services
{
    public class ConsumerService : IConsumerService
    {
        private readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(PolicyService));
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ConsumerService(IConfiguration _configuration, IHttpContextAccessor httpContextAccessor)
        {
            configuration = _configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Add consumer Business details 
        /// </summary>
        /// <param name="consumerBusiness"></param>
        /// <returns> true </returns>
        public bool CreateConsumerBusiness(ConsumerBusiness consumerBusiness)
        {
            string consumerBaseUri = configuration.GetValue<string>("ServiceURIs:Consumer");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(consumerBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _httpContextAccessor.HttpContext.Session.GetString("token"));
                StringContent content = new StringContent(JsonConvert.SerializeObject(consumerBusiness), Encoding.UTF8, "application/json");

                _log4net.Info($"Sending a request to [consumer] service to add consumer business details");

                var httpResponse = client.PostAsync($"/api/Consumer/CreateConsumerBusiness", content).Result;
                var responseString = httpResponse.Content.ReadAsStringAsync().Result;
                if (!httpResponse.IsSuccessStatusCode)
                {
                    _log4net.Error($"[consumer] service return with {httpResponse.StatusCode} status code");
                    throw new Exception("Unable to reach [Consumer] microservice.");
                }
                return true;
            }
        }

        /// <summary>
        /// View Consumer Business details
        /// </summary>
        /// <param name="ConsumerId"></param>
        /// <param name="BusinessId"></param>
        /// <returns></returns>
        public ConsumerBusinessDetails ViewConsumerBusinessDetail(string ConsumerId, string BusinessId)
        {
            string consumerBaseUri = configuration.GetValue<string>("ServiceURIs:Consumer");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(consumerBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _httpContextAccessor.HttpContext.Session.GetString("token"));
                using var httpResponse = client.GetAsync($"/api/Consumer/viewConsumerBusiness/{ConsumerId}/{BusinessId}").Result;
                var responseStr = httpResponse.Content.ReadAsStringAsync().Result;

                if (!httpResponse.IsSuccessStatusCode)
                {
                    _log4net.Error($"[Consumer] service returned with {httpResponse.StatusCode} status code");
                    throw new Exception("Unable to reach [Consumer] microservice.");
                }
                ConsumerBusinessDetails consumerBusiness = JsonConvert.DeserializeObject<ConsumerBusinessDetails>(responseStr);
                return consumerBusiness;
            }
        }

        /// <summary>
        /// Update consumer business details
        /// </summary>
        /// <param name="consumerBusiness"></param>
        /// <returns></returns>
        public bool UpdateConsumerBusiness(ConsumerBusiness consumerBusiness)
        {
            string consumerBaseUri = configuration.GetValue<string>("ServiceURIs:Consumer");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(consumerBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _httpContextAccessor.HttpContext.Session.GetString("token"));
                StringContent content = new StringContent(JsonConvert.SerializeObject(consumerBusiness), Encoding.UTF8, "application/json");
                using var httpResponse = client.PutAsync($"/api/Consumer/UpdateConsumerBusiness", content).Result;
                if (!httpResponse.IsSuccessStatusCode)
                {
                    _log4net.Error($"[Consumer] service returned with {httpResponse.StatusCode} status code.");
                    throw new Exception("Unable to reach [Consumer] microservice.");
                }
                return true;
            }
        }

        /// <summary>
        /// create business property
        /// </summary>
        /// <param name="businessProperty"></param>
        /// <returns></returns>
        public bool CreateBusinessProperty(BusinessProperty businessProperty)
        {
            string consumerBaseUri = configuration.GetValue<string>("ServiceURIs:Consumer");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(consumerBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _httpContextAccessor.HttpContext.Session.GetString("token"));
                StringContent content = new StringContent(JsonConvert.SerializeObject(businessProperty), Encoding.UTF8, "application/json");
                _log4net.Info($"Sending a request to [consumer] service to add business property details");
                using var httpResponse = client.PostAsync($"/api/Consumer/CreateBusinessProperty", content).Result;

                if (!httpResponse.IsSuccessStatusCode)
                {
                    _log4net.Error($"[consumer] service return with {httpResponse.StatusCode} status code");
                    throw new Exception("Unable to reach [Consumer] microservice.");
                }
                return true;
            }
        }

        /// <summary>
        /// Update business Property
        /// </summary>
        /// <param name="businessProperty"></param>
        /// <returns></returns>
        public bool UpdateBusinessProperty(BusinessProperty businessProperty)
        {
            string consumerBaseUri = configuration.GetValue<string>("ServiceURIs:Consumer");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(consumerBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _httpContextAccessor.HttpContext.Session.GetString("token"));
                StringContent content = new StringContent(JsonConvert.SerializeObject(businessProperty), Encoding.UTF8, "application/json");

                using var httpResponse = client.PutAsync($"/api/Consumer/UpdateBusinessProperty", content).Result;

                if (!httpResponse.IsSuccessStatusCode)
                {
                    _log4net.Error($"[Consumer] service returned with {httpResponse.StatusCode} status code.");
                    throw new Exception("Unable to reach [Consumer] microservice.");
                }
                return true;
            }
        }

        /// <summary>
        /// View Business property details
        /// </summary>
        /// <param name="ConsumerId"></param>
        /// <param name="PropertyId"></param>
        /// <returns></returns>
        public BusinessPropertyDetails ViewBusinessPropertyDetail(string ConsumerId, string PropertyId)
        {
            string consumerBaseUri = configuration.GetValue<string>("ServiceURIs:Consumer");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(consumerBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _httpContextAccessor.HttpContext.Session.GetString("token"));
                using var httpResponse =  client.GetAsync($"/api/Consumer/viewConsumerProperty/{ConsumerId}/{PropertyId}").Result;
                var responseStr =  httpResponse.Content.ReadAsStringAsync().Result;
                if (!httpResponse.IsSuccessStatusCode)
                {
                    _log4net.Error($"[Consumer] service returned with {httpResponse.StatusCode} status code");
                    return null;
                }
                BusinessPropertyDetails businessProperty = JsonConvert.DeserializeObject<BusinessPropertyDetails>(responseStr);
                return businessProperty;
            }
        }
    }
}
