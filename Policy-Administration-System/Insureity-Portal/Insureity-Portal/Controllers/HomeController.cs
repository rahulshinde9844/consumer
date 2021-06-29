using Insureity_Portal.Models;
using Insureity_Portal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Insureity_Portal.Controllers
{
    public class HomeController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(HomeController));

        private IConfiguration configuration;
        
        public HomeController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }


        /// <summary>
        /// Logout
        /// </summary>
        /// <returns>Go to Index of Login controller</returns>
        public IActionResult Logout()
        {
            _log4net.Info(nameof(Logout) + " method invoked.");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

        
        /// <summary>
        /// Create policy for comsumer business
        /// </summary>
        /// <returns></returns>
        public IActionResult CreatePolicyRequest()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info("Agent entering details to create policy");
            return View();
        }


        /// <summary>
        /// Creating new policy
        /// </summary>
        /// <param name="createPolicy"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreatePolicyRequest(CreatePolicy createPolicy)
        {
            string policyBaseUri = configuration.GetValue<string>("ServiceURIs:Policy");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(policyBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");

                string bearerToken = $"Bearer {SessionToken}";
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", bearerToken);

                StringContent content = new StringContent(JsonConvert.SerializeObject(createPolicy), Encoding.UTF8, "application/json");

                _log4net.Info($"Sending a request to [Policy] service to add Policy details");

                using var httpResponse = await client.PostAsync($"/createPolicy", content);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    _log4net.Error($"[Policy] service return with {httpResponse.StatusCode} status code");

                    return View("Error");
                }
                _log4net.Info($"[Policy] service return with {httpResponse.StatusCode} status code");
                _log4net.Info($"Policy created successfully.");

                ViewBag.Result = "Policy created successfully.";
                return View("Result");
            }

            //return RedirectToAction("IssuePolicyRequest");
        }


        
        /// <summary>
        /// Issue policy for consumer business
        /// </summary>
        /// <returns></returns>
        public IActionResult IssuePolicyRequest()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info("Agent entering details to issue policy");
            return View();
        }


        /// <summary>
        /// Issue policy for consumer 
        /// </summary>
        /// <param name="issuePolicy"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> IssuePolicyRequest(IssuePolicy issuePolicy)
        {
            string policyBaseUri = configuration.GetValue<string>("ServiceURIs:Policy");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(policyBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");

                string bearerToken = $"Bearer {SessionToken}";
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", bearerToken);

                StringContent content = new StringContent(JsonConvert.SerializeObject(issuePolicy), Encoding.UTF8, "application/json");

                _log4net.Info($"Sending a request to [Policy] service to issue Policy");

                using var httpResponse = await client.PostAsync($"/issuePolicy", content);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    _log4net.Error($"[Policy] service return with {httpResponse.StatusCode} status code");
                    return View("Error");
                }
                _log4net.Info($"[Policy] service return with {httpResponse.StatusCode} status code");
                _log4net.Info($"Policy issued successfully.");
                ViewBag.Result = "Policy issued successfully.";
                return View("Result");

            }

            //return RedirectToAction("IssuePolicyRequest");
        }



        /// <summary>
        /// View policy 
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewPolicyRequest()
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info("Agent entering details to View Policy");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ViewPolicyRequest(ViewPolicy viewPolicy)
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }

            _log4net.Info($"Fetching policy details.");
            string policyBaseUri = configuration.GetValue<string>("ServiceURIs:Policy");

            string ConsumerId = viewPolicy.ConsumerId;
            string BusinessId = viewPolicy.BusinessId;
            string PolicyId = viewPolicy.PolicyId;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(policyBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");

                string bearerToken = $"Bearer {SessionToken}";
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", bearerToken);

                using var httpResponse = await client.GetAsync($"/viewPolicy/{ConsumerId},{BusinessId},{PolicyId}");

                var responseStr = await httpResponse.Content.ReadAsStringAsync();

                if (!httpResponse.IsSuccessStatusCode)
                {
                    _log4net.Error($"[Policy] service returned with {httpResponse.StatusCode} status code");
                    return View("Error");
                }
                PolicyDetails policyDetail = JsonConvert.DeserializeObject<PolicyDetails>(responseStr);
                if (policyDetail != null)
                {
                    return View("PolicyDetail", policyDetail);
                }
            }


            ViewBag.Message = "Unable to view details at the moment.";
            return View();
        }
            



        /// <summary>
        /// Get Quotes 
        /// </summary>
        /// <returns></returns>
        public IActionResult GetQuotesRequest()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info("Agent entering Quotes details");
            return View();
        }



        /// <summary>
        /// Get quotes amount
        /// </summary>
        /// <param name="getQuotes"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetQuotesRequest(GetQuotes getQuotes)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            string policyBaseUri = configuration.GetValue<string>("ServiceURIs:Policy");

            int PropertyValue = getQuotes.PropertyValue;
            int BusinessValue = getQuotes.BusinessValue;
            string PropertyType = getQuotes.PropertyType;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(policyBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");

                string bearerToken = $"Bearer {SessionToken}";
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", bearerToken);

                using var httpResponse = await client.GetAsync($"/getQuotes/{PropertyValue},{BusinessValue},{PropertyType}");

                var responseStr = await httpResponse.Content.ReadAsStringAsync();

                if (!httpResponse.IsSuccessStatusCode)
                {
                    ViewBag.statuscode = httpResponse.StatusCode;
                    _log4net.Error($"[Policy] service returned with {httpResponse.StatusCode} status code");
                    return View("Error");
                }
                var quotes = JsonConvert.DeserializeObject<string>(responseStr);
                if (quotes != null)
                {
                    ViewBag.quote = quotes;
                    return View("quotesValue");
                }

                ViewBag.Message = "Unable to get quotes at the moment.";
                return View();
            }
        }

        private string SessionToken { get => HttpContext.Session.GetString("token"); } 

    }
}
