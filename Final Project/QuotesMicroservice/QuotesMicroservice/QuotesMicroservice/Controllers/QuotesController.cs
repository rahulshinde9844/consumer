using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesMicroservice.Filters;
using QuotesMicroservice.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[TokenValidation]
    public class QuotesController : ControllerBase
    {
     
        private readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(QuotesController));
        private readonly IQuotesService _QuotesService;
        public QuotesController(IQuotesService QuotesService)
        {
            _QuotesService = QuotesService;
        }

        /// <summary>
        ///https://localhost:44305/api/Quotes/getQuotesForPolicy/3/3/Building
        /// </summary>
        /// <param name="PropertyValue"></param>
        /// <param name="BusinessValue"></param>
        /// <param name="PropertyType"></param>
        /// <returns>800000</returns>
        [HttpGet]
        [Route("getQuotesForPolicy/{PropertyValue}/{BusinessValue}/{PropertyType}")]
        public IActionResult getQuotesForPolicy(int PropertyValue, int BusinessValue, string PropertyType)
        {
            _log4net.Info("GetQuotesForPolicy action method started with PropertyValue="+PropertyValue+" BusinessValue="+BusinessValue+" PropertyType="+PropertyType);
            var Quote =_QuotesService.QuotesForPolicyService(PropertyValue, BusinessValue, PropertyType);            
            return Ok(Quote);

        }
    }
}
