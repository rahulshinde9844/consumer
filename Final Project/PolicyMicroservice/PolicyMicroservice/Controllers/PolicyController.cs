using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolicyMicroservice.Models;
using PolicyMicroservice.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(PolicyController));
        private readonly IPolicyService _policyService;
        public PolicyController(IPolicyService PolicyService)
        {
            _policyService = PolicyService;
        }
        
        /// <summary>
        /// Create Policy
        /// </summary>
        /// <param name="createPolicy"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("createPolicy")]
        public IActionResult CreatePolicy(CreatePolicyRequest createPolicy)
        {
            _log4net.Info($"POST: /createPolicy endpoint invoked :");

            try
            {
                _log4net.Info(" CreatePolicy Method Called");
                var result = _policyService.CreatePolicy(createPolicy);
                return Ok(result); 
            }
            catch (Exception e)
            {
                _log4net.Error("Exception in PolicyCreate" + e.Message);
                return new NoContentResult();
            }
        }
        
        /// <summary>
        /// Issue Policy
        /// </summary>
        /// <param name="issuePolicy"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("issuePolicy")]
        public IActionResult IssuePolicy(IssuePolicyRequest issuePolicy)
        {
            _log4net.Info($"POST: /createPolicy endpoint invoked :");

            try
            {
                _log4net.Info(" IssuePolicy Method Called");
                var result = _policyService.IssuePolicy(issuePolicy);
                return Ok(result);
            }
            catch (Exception e)
            {
                _log4net.Error("Exception in PolicyCreate" + e.Message);
                return new NoContentResult();
            }
        }
       
        /// <summary>
        /// Get Quotes
        /// </summary>
        /// <param name="ConsumerId"></param>
        /// <param name="BusinessId"></param>
        /// <param name="PolicyId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("viewPolicy/{ConsumerId}/{BusinessId}/{PolicyId}")]
        public IActionResult ViewPolicy(string ConsumerId,string BusinessId, string PolicyId)
        {
            _log4net.Info(" viewPolicy Method Called");
            PolicyDetails policyDetails = _policyService.ViewPolicy(ConsumerId,BusinessId, PolicyId);
            return Ok(policyDetails);
        }
        
        /// <summary>
        /// Get Quotes from Quote getQuote MicroService
        /// </summary>
        /// <param name="PropertyValue"></param>
        /// <param name="BusinessValue"></param>
        /// <param name="PropertyType"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/getQuotes/{PropertyValue}/{BusinessValue}/{PropertyType}")]
        public IActionResult GetQuotes(int PropertyValue, int BusinessValue, string PropertyType)
        {
            _log4net.Info("GetQuotes Method Called");
            var quotes = _policyService.GetQuotes(PropertyValue, BusinessValue, PropertyType);
            return Ok(quotes);
        }
    }
}
