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
    public class PolicyService : IPolicyService
    {
        private readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(PolicyService));
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PolicyService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Create policy
        /// </summary>
        /// <param name="policy"></param>
        /// <returns></returns>
        public bool CreatePolicy(CreatePolicy policy)
        {
            string policyBaseUri = _configuration.GetValue<string>("ServiceURIs:Policy");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(policyBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _httpContextAccessor.HttpContext.Session.GetString("token"));
                StringContent content = new StringContent(JsonConvert.SerializeObject(policy), Encoding.UTF8, "application/json");
                _log4net.Info($"Sending a request to [Policy] service to issue Policy");

                var httpResponse = client.PostAsync($"/api/Policy/createPolicy", content).Result;
                if (!httpResponse.IsSuccessStatusCode)
                {
                    _log4net.Error($"[Policy] service return with {httpResponse.StatusCode} status code");

                    throw new Exception("Unable to reach [Policy] microservice.");
                }
                return true;
            }
        }

        /// <summary>
        /// Issue policy for consumer
        /// </summary>
        /// <param name="policy"></param>
        /// <returns></returns>
        public bool IssuePolicy(IssuePolicy policy)
        {
            string policyBaseUri = _configuration.GetValue<string>("ServiceURIs:Policy");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(policyBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _httpContextAccessor.HttpContext.Session.GetString("token"));
                StringContent content = new StringContent(JsonConvert.SerializeObject(policy), Encoding.UTF8, "application/json");
                _log4net.Info($"Sending a request to [Policy] service to issue Policy");
                var httpResponse = client.PostAsync($"/api/Policy/issuePolicy", content).Result;
                if (!httpResponse.IsSuccessStatusCode)
                {
                    _log4net.Error($"[Policy] service return with {httpResponse.StatusCode} status code");

                    throw new Exception("Unable to reach [Policy] microservice.");
                }
                return true;
            }
        }

        /// <summary>
        /// View Issued policy details
        /// </summary>
        /// <param name="viewPolicy"></param>
        /// <returns></returns>
        public PolicyDetails ViewPolicyDetails(ViewPolicy viewPolicy)
        {
            string policyBaseUri = _configuration.GetValue<string>("ServiceURIs:Policy");

            string ConsumerId = viewPolicy.ConsumerId;
            string BusinessId = viewPolicy.BusinessId;
            string PolicyId = viewPolicy.PolicyId;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(policyBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _httpContextAccessor.HttpContext.Session.GetString("token"));
                var httpResponse = client.GetAsync($"/api/Policy/viewPolicy/{ConsumerId}/{BusinessId}/{PolicyId}").Result;
                var responseStr = httpResponse.Content.ReadAsStringAsync().Result;

                if (!httpResponse.IsSuccessStatusCode)
                {
                    _log4net.Error($"[Policy] service returned with {httpResponse.StatusCode} status code");
                    throw new Exception("Unable to reach [Policy] microservice.");
                }
                PolicyDetails policyDetail = JsonConvert.DeserializeObject<PolicyDetails>(responseStr);
                return policyDetail;
            }

        }

        /// <summary>
        /// Get quotes details
        /// </summary>
        /// <param name="getQuotes"></param>
        /// <returns></returns>
        public string GetQuotesDetails(GetQuotes getQuotes)
        {
            string policyBaseUri = _configuration.GetValue<string>("ServiceURIs:Policy");

            int PropertyValue = getQuotes.PropertyValue;
            int BusinessValue = getQuotes.BusinessValue;
            string PropertyType = getQuotes.PropertyType;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(policyBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _httpContextAccessor.HttpContext.Session.GetString("token"));
                using var httpResponse = client.GetAsync($"/getQuotes/{PropertyValue}/{BusinessValue}/{PropertyType}").Result;
                var responseStr = httpResponse.Content.ReadAsStringAsync().Result;
                if (!httpResponse.IsSuccessStatusCode)
                {
                    _log4net.Error($"[Policy] service returned with {httpResponse.StatusCode} status code");
                    throw new Exception("Unable to reach [Policy] microservice.");
                }
                var quotes = JsonConvert.DeserializeObject<string>(responseStr);
                return quotes;
            }
        }
    }
}
