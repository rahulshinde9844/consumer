using Insureity_Portal.Models;
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
    public class ConsumerController : Controller
    {

        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(HomeController));

        private IConfiguration configuration;
        public ConsumerController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        /// <summary>
        /// ViewConsumerBusiness
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewConsumerBusinessRequest()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info("Agent entering Details to View Consumer Business");
            return View();
        }



        /// <summary>
        /// View Consumer Business on a view 
        /// </summary>
        /// <param name="viewConsumerBusiness"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ViewConsumerBusinessRequest(ViewConsumerBusiness viewConsumerBusiness)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info($"Fetching Consumer Business details.");
            string consumerId = viewConsumerBusiness.ConsumerId;
            string businessId = viewConsumerBusiness.BusinessId;
            ConsumerBusinessDetails consumerBusinessDetail = await GetConsumerBusinessDetails(consumerId, businessId);

            if (consumerBusinessDetail != null)
            {
                return View("ConsumerBusinessDetail", consumerBusinessDetail);
            }

            ViewBag.Message = "Unable to view consumer business at the moment.";
            return View();
        }


        /// <summary>
        /// update consumer business
        /// </summary>
        /// <param name="viewConsumerBusiness"></param>
        /// <returns></returns>
        public async Task<IActionResult> UpdateConsumerBusiness(string consumerId, string businessId)
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }

            ConsumerBusinessDetails consumerBusiness = await GetConsumerBusinessDetails(consumerId, businessId);
            if (consumerBusiness != null)
            {
                return View(consumerBusiness);
            }
            else
            {
                ViewBag.Message = "Unable to update at the moment. Try later.";
                return View();
            }
        }


        [HttpPost]
        public async Task<IActionResult> UpdateConsumerBusiness(ConsumerBusiness consumerBusiness)
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            string consumerBaseUri = configuration.GetValue<string>("ServiceURIs:Consumer");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(consumerBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");

                string bearerToken = $"Bearer {SessionToken}";
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", bearerToken);

                StringContent content = new StringContent(JsonConvert.SerializeObject(consumerBusiness), Encoding.UTF8, "application/json");

                using var httpResponse = await client.PutAsync($"/UpdateConsumerBusiness", content);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    _log4net.Error($"[Consumer] service returned with {httpResponse.StatusCode} status code.");

                    return View("Error");
                }
                _log4net.Info($"[Consumer] service returned with {httpResponse.StatusCode} status code.");
                _log4net.Info($"Consumer Business details updated successfuly.");

                ViewBag.Result = "Consumer Business details Updated successfully";
                return View("Result");
            }

            //return RedirectToAction("ViewConsumerBusinessRequest");
        }

        /// <summary>
        /// Create consumer business
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateConsumerBusinessRequest()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info("Agent entering Details to create Consumer Business");
            return View();
        }


        /// <summary>
        /// add consumer business details
        /// </summary>
        /// <param name="consumerBusiness"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateConsumerBusinessRequest(ConsumerBusiness consumerBusiness)
        {
            string consumerBaseUri = configuration.GetValue<string>("ServiceURIs:Consumer");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(consumerBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");

                string bearerToken = $"Bearer {SessionToken}";
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", bearerToken);

                StringContent content = new StringContent(JsonConvert.SerializeObject(consumerBusiness), Encoding.UTF8, "application/json");

                _log4net.Info($"Sending a request to [consumer] service to add consumer business details");

                using var httpResponse = await client.PostAsync($"/createConsumerBusiness", content);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    _log4net.Error($"[consumer] service return with {httpResponse.StatusCode} status code");

                    return View("Error");
                }
                _log4net.Info($"[Consumer] service return with {httpResponse.StatusCode} status code");
                _log4net.Info($"Consumer Business created successfully.");
                ViewBag.Result = "Consumer Business created successfully";
                return View("Result");
            }
        }



        /// <summary>
        /// Get consumer business details by consumer ID
        /// </summary>
        /// <param name="consumerId"></param>
        /// <returns></returns>
        private async Task<ConsumerBusinessDetails> GetConsumerBusinessDetails(string ConsumerId, string BusinessId)
        {
            string consumerBaseUri = configuration.GetValue<string>("ServiceURIs:Consumer");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(consumerBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");

                string bearerToken = $"Bearer {SessionToken}";
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", bearerToken);

                using var httpResponse = await client.GetAsync($"/viewConsumerBusiness /{ConsumerId},{BusinessId}");

                var responseStr = await httpResponse.Content.ReadAsStringAsync();

                if (!httpResponse.IsSuccessStatusCode)
                {
                    _log4net.Error($"[Consumer] service returned with {httpResponse.StatusCode} status code");
                    return null;
                }
                ConsumerBusinessDetails consumerBusiness = JsonConvert.DeserializeObject<ConsumerBusinessDetails>(responseStr);
                return consumerBusiness;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewBusinessPropertyRequest()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info("Agent entering Details to View Business Property");
            return View();
        }


        /// <summary>
        /// View details of business property 
        /// </summary>
        /// <param name="viewBusinessProperty"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ViewBusinessPropertyRequest(ViewBusinessProperty viewBusinessProperty)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info($"Fetching Consumer Business details.");
            string consumerId = viewBusinessProperty.ConsumerId;
            string propertyId = viewBusinessProperty.PropertyId;
            BusinessPropertyDetails businessProperty = await GetBusinessProperty(consumerId, propertyId);

            if (businessProperty != null)
            {
                return View("BusinessPropertyDetail", businessProperty);
            }

            ViewBag.Message = "Unable to view business property details at the moment.";
            return View();
        }


        /// <summary>
        /// Update Business Property
        /// </summary>
        /// <param name="consumerId"></param>
        /// <param name="propertyId"></param>
        /// <returns></returns>
        public async Task<IActionResult> UpdateBusinessProperty(string consumerId, string propertyId)
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }

            BusinessPropertyDetails businessProperty = await GetBusinessProperty(consumerId, propertyId);
            if (businessProperty != null)
            {
                return View(businessProperty);
            }
            else
            {
                ViewBag.Message = "Unable to update at the moment. Try later.";
                return View();
            }
        }



        /// <summary>
        /// Update the business property values
        /// </summary>
        /// <param name="businessProperty"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateBusinessProperty(BusinessProperty businessProperty)
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            string consumerBaseUri = configuration.GetValue<string>("ServiceURIs:Consumer");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(consumerBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");

                string bearerToken = $"Bearer {SessionToken}";
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", bearerToken);

                StringContent content = new StringContent(JsonConvert.SerializeObject(businessProperty), Encoding.UTF8, "application/json");

                using var httpResponse = await client.PutAsync($"/updateBusinessProperty", content);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    _log4net.Error($"[Consumer] service returned with {httpResponse.StatusCode} status code.");
                    return View("Error");
                }
                _log4net.Info($"[Consumer] service returned with {httpResponse.StatusCode} status code.");
                _log4net.Info($"Business property details updated successfuly.");
                ViewBag.Result = "Business Property details updated successfuly.";
                return View("Result");
            }

            //return RedirectToAction("ViewBusinessPropertyRequest");
        }


        /// <summary>
        /// create business property 
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateBusinessPropertyRequest()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info("Agent entering Details to create Business Property");
            return View();
        }


        /// <summary>
        /// Add Business Property details consumer service
        /// </summary>
        /// <param name="businessProperty"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateBusinessPropertyRequest(BusinessProperty businessProperty)
        {
            string consumerBaseUri = configuration.GetValue<string>("ServiceURIs:Consumer");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(consumerBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");

                string bearerToken = $"Bearer {SessionToken}";
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", bearerToken);

                StringContent content = new StringContent(JsonConvert.SerializeObject(businessProperty), Encoding.UTF8, "application/json");

                _log4net.Info($"Sending a request to [consumer] service to add business property details");

                using var httpResponse = await client.PostAsync($"/CreateBusinessProperty", content);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    _log4net.Error($"[consumer] service return with {httpResponse.StatusCode} status code");

                    var responseStr = await httpResponse.Content.ReadAsStringAsync();
                    Dictionary<string, string> errorResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseStr);
                    string errorMessage = errorResponse.ContainsKey("Message") ? errorResponse["Message"] : null;

                    ViewBag.Success = false;
                    ViewBag.Message = errorMessage ?? "Something went wrong.";
                    return View();
                }
                _log4net.Info($"[Consumer] service return with {httpResponse.StatusCode} status code");
                _log4net.Info($"Business Property created successfully.");
                ViewBag.Result = "Business Property created successfully.";
                return View("Result");
            }

            //return RedirectToAction("ViewBusinessPropertyRequest");
        }


        private async Task<BusinessPropertyDetails> GetBusinessProperty(string consumerId, string propertyId)
        {
            string consumerBaseUri = configuration.GetValue<string>("ServiceURIs:Consumer");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(consumerBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");

                string bearerToken = $"Bearer {SessionToken}";
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", bearerToken);

                using var httpResponse = await client.GetAsync($"/viewConsumerProperty/{consumerId},{propertyId}");

                var responseStr = await httpResponse.Content.ReadAsStringAsync();

                if (!httpResponse.IsSuccessStatusCode)
                {
                    _log4net.Error($"[Consumer] service returned with {httpResponse.StatusCode} status code");
                    return null;
                }
                BusinessPropertyDetails businessProperty = JsonConvert.DeserializeObject<BusinessPropertyDetails>(responseStr);
                return businessProperty;
            }
        }

        private string SessionToken { get => HttpContext.Session.GetString("token"); }
    }
}
