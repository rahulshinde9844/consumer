using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesMicroservice.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesMicroservice.Controllers
{
    [ApiController]
    public class QuotesMasterController : ControllerBase
    {
      
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(QuotesMasterController));

        private readonly IQuotesMasterService _QuotesMasterService;
        public QuotesMasterController(IQuotesMasterService QuotesMasterService)
        {
            _QuotesMasterService = QuotesMasterService;
        }
        [HttpGet]
        [Route("getQuotesForPolicy/{PropertyValue},{BusinessValue},{PropertyType}")]
        
        public IActionResult getQuotesForPolicy(int PropertyValue, int BusinessValue, string PropertyType)
        {
            _log4net.Info("QuotesMaster started");
            var Quote =_QuotesMasterService.QuotesForPolicyService(PropertyValue, BusinessValue, PropertyType);
            
            return Ok(Quote);

        }
    }
}
