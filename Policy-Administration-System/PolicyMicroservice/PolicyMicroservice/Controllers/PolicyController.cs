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
    [ApiController]
    public class PolicyController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(PolicyController));
        private readonly IPolicyService _policyService;
        public PolicyController(IPolicyService PolicyService)
        {
            _policyService = PolicyService;
        }
        //create policy
        [HttpPost]
        [Route("createPolicy")]
        public IActionResult CreatePolicy(CreatePolicyRequest createPolicy)
        {
            _log4net.Info($"POST: /createPolicy endpoint invoked :");


            try
            {
                var result = _policyService.CreatePolicy(createPolicy);
                return Ok(result);
              
            }
            catch (Exception e)
            {
                _log4net.Error("Exception in PolicyCreate" + e.Message);
                return new NoContentResult();
            }

        }

        [HttpPost]
        [Route("issuePolicy")]
        public IActionResult IssuePolicy(IssuePolicyRequest issuePolicy)
        {
            _log4net.Info($"POST: /createPolicy endpoint invoked :");


            try
            {
                var result = _policyService.IssuePolicy(issuePolicy);
                return Ok(result);

            }
            catch (Exception e)
            {
                _log4net.Error("Exception in PolicyCreate" + e.Message);
                return new NoContentResult();
            }

        }


        [HttpGet]
        [Route("viewPolicy/{ConsumerId},{BusinessId},{PolicyId}")]
        public IActionResult ViewPolicy(string ConsumerId,string BusinessId, string PolicyId)
        {
            PolicyDetails policyDetails = _policyService.ViewPolicy(ConsumerId,BusinessId, PolicyId);
            return Ok(policyDetails);
        }


        [HttpGet]
        [Route("/getQuotes/{PropertyValue},{BusinessValue},{PropertyType}")]
        public IActionResult GetQuotes(int PropertyValue, int BusinessValue, string PropertyType)
        {
            var quotes = _policyService.GetQuotes(PropertyValue, BusinessValue, PropertyType);
            return Ok(quotes);
        }



    }
}
