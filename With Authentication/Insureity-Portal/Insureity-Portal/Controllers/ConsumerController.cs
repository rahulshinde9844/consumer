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
    public class ConsumerController : Controller
    {
        private readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(HomeController));
        private readonly IConsumerService consumerService;
        public ConsumerController(IConsumerService _consumerService)
        {
            consumerService = _consumerService;
        }

        /// <summary>
        /// ViewConsumerBusiness
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewConsumerBusinessRequest()
        {
            if (SessionToken == null)
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
        public IActionResult ViewConsumerBusinessRequest(ViewConsumerBusiness viewConsumerBusiness)
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            string consumerId = viewConsumerBusiness.ConsumerId;
            string businessId = viewConsumerBusiness.BusinessId;
            _log4net.Info($"Fetching Consumer Business details.");
            ConsumerBusinessDetails consumerBusinessDetail = consumerService.ViewConsumerBusinessDetail(consumerId, businessId);
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
        public IActionResult UpdateConsumerBusiness(string consumerId, string businessId)
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }          
            ConsumerBusinessDetails consumerBusiness = consumerService.ViewConsumerBusinessDetail(consumerId, businessId);
            if (consumerBusiness != null)
            {
                return View(consumerBusiness);
            }
            else
            {
                ViewBag.Message = "Unable to update at the moment. Try later.";
                return View("Error");
            }
        }

        /// <summary>
        /// Update consumer Business
        /// </summary>
        /// <param name="consumerBusiness"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateConsumerBusiness(ConsumerBusiness consumerBusiness)
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
            var response = consumerService.UpdateConsumerBusiness(consumerBusiness);
            if (!response.Equals(true))
            {
                return View("Error");
            }
            _log4net.Info($"Consumer Business details updated successfuly.");
            ViewBag.Result = "Consumer Business details Updated successfully";
            return View("Result");
        }

        /// <summary>
        /// Create consumer business
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateConsumerBusinessRequest()
        {
            if (SessionToken == null)
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
        public IActionResult CreateConsumerBusinessRequest(ConsumerBusiness consumerBusiness)
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            var reponse = consumerService.CreateConsumerBusiness(consumerBusiness);
            if (!reponse.Equals(true))
            {
                return View("Error");
            }
            _log4net.Info($"Consumer Business created successfully.");
            ViewBag.Result = "Consumer Business created successfully";
            return View("Result");
        }

        /// <summary>
        /// View Business Proverty View
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewBusinessPropertyRequest()
        {
            if (SessionToken == null)
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
        public IActionResult ViewBusinessPropertyRequest(ViewBusinessProperty viewBusinessProperty)
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info($"Fetching Business Property details.");
            string consumerId = viewBusinessProperty.ConsumerId;
            string propertyId = viewBusinessProperty.PropertyId;
            BusinessPropertyDetails businessProperty = consumerService.ViewBusinessPropertyDetail(consumerId, propertyId);
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
        public IActionResult UpdateBusinessProperty(string consumerId, string propertyId)
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            BusinessPropertyDetails businessProperty = consumerService.ViewBusinessPropertyDetail(consumerId, propertyId);
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
        public IActionResult UpdateBusinessProperty(BusinessProperty businessProperty)
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
            var reponse = consumerService.UpdateBusinessProperty(businessProperty);
            if (!reponse.Equals(true))
            {
                return View("Error");
            }
            _log4net.Info($"Business property details updated successfuly.");
            ViewBag.Result = "Business Property details updated successfuly.";
            return View("Result");
        }

        /// <summary>
        /// create business property 
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateBusinessPropertyRequest()
        {
            if (SessionToken == null)
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
        public IActionResult CreateBusinessPropertyRequest(BusinessProperty businessProperty)
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            var response = consumerService.CreateBusinessProperty(businessProperty);
            if (!response.Equals(true))
            {
                return View("Error");
            }
            _log4net.Info($"Business Property created successfully.");
            ViewBag.Result = "Business Property created successfully.";
            return View("Result");
                    
        }
        private string SessionToken { get => HttpContext.Session.GetString("token"); }
    }
}
