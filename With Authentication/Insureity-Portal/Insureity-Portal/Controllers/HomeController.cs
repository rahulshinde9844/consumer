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
        private readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(HomeController));
        private readonly IPolicyService policyService;
        public HomeController(IPolicyService _policyService)
        {
            policyService = _policyService;
        }

        public IActionResult Index()
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            ViewBag.Agent = HttpContext.Session.GetString("Username");
            return View();
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
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info("Agent entering details to create policy");
            return View();
        }

        /// <summary>
        /// Creating new policy post method
        /// </summary>
        /// <param name="createPolicy"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreatePolicyRequest(CreatePolicy createPolicy)
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            var response = policyService.CreatePolicy(createPolicy);
            if(!response.Equals(true))
            {
                return View("Error");
            }
            _log4net.Info($"Policy created successfully.");

            ViewBag.Result = "Policy created successfully.";
            return View("Result");          
        }
       
        /// <summary>
        /// Issue policy for consumer business
        /// </summary>
        /// <returns></returns>
        public IActionResult IssuePolicyRequest()
        {
            if (SessionToken == null)
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
        public IActionResult IssuePolicyRequest(IssuePolicy issuePolicy)
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            var response = policyService.IssuePolicy(issuePolicy);
            if (!response.Equals(true))
            {
                return View("Error");
            }
            _log4net.Info($"Policy issued successfully.");
            ViewBag.Result = "Policy issued successfully.";
            return View("Result");
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

        /// <summary>
        /// POst method of view policy
        /// </summary>
        /// <param name="viewPolicy"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ViewPolicyRequest(ViewPolicy viewPolicy)
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            _log4net.Info($"Fetching policy details.");
            PolicyDetails policyDetail = policyService.ViewPolicyDetails(viewPolicy);         
            if (policyDetail != null)
            {
                return View("PolicyDetail", policyDetail);
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
            if (SessionToken == null)
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
        public IActionResult GetQuotesRequest(GetQuotes getQuotes)
        {
            if (SessionToken == null)
            {
                _log4net.Info("Agent is not logged in");
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Index", "Login");
            }
            string quotes = policyService.GetQuotesDetails(getQuotes);          
            if (quotes != null)
            {
                ViewBag.quote = quotes;
                return View("quotesValue");
            }
            ViewBag.Message = "Unable to get quotes at the moment.";
            return View();
        }
        private string SessionToken { get => HttpContext.Session.GetString("token"); } 
    }
}
