using ConsumerMicroservice.Models;
using ConsumerMicroservice.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerController : Controller
    {
        private readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ConsumerController));
        private readonly IConsumerService _consumerService;
        
        public ConsumerController(IConsumerService consumerService)
        {
            _consumerService = consumerService;        
        }

        [HttpPost]
        [Route("CreateConsumerBusiness")]
        public IActionResult CreateConsumerBusiness(ConsumerBusiness consumerBusiness)
        {
            _log4net.Info("CreateConsumerBusiness Method Called");
            var result = _consumerService.CreateConsumerBusiness(consumerBusiness);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateConsumerBusiness")]
        public IActionResult UpdateConsumerBusiness(ConsumerBusiness consumerBusiness)
        {
            _log4net.Info("UpdateConsumerBusiness Method Called");
            var result = _consumerService.UpdateConsumerBusiness(consumerBusiness);
            return Ok(result);
        }


        [HttpPost]
        [Route("CreateBusinessProperty")]
        public IActionResult CreateBusinessProperty(BusinessProperty businessProperty)
        {
            _log4net.Info("CreateBusinessProperty Method Called");
            var result = _consumerService.CreateBusinessProperty(businessProperty);
            return Ok(result);
        }


        [HttpPut]
        [Route("UpdateBusinessProperty")]
        public IActionResult UpdateBusinessProperty(BusinessProperty businessProperty)
        {
            _log4net.Info("UpdateBusinessProperty Method Called");
            var result = _consumerService.UpdateBusinessProperty(businessProperty);
            return Ok(result);
        }

        [HttpGet]
        [Route("viewConsumerBusiness/{ConsumerId}/{BusinessId}")]
        public IActionResult ViewConsumerBusiness(string ConsumerId, string BusinessId)
        {
            _log4net.Info("ViewConsumerBusiness Method Called");
            var result = _consumerService.ViewConsumerBusiness(ConsumerId, BusinessId);
            if (result.Equals(null))
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("viewConsumerProperty/{ConsumerId}/{PropertyId}")]
        public IActionResult ViewConsumerProperty(string ConsumerId,string PropertyId)
        {
            _log4net.Info("ViewConsumerProperty Method Called");
            BusinessPropertyDetails result = _consumerService.ViewConsumerProperty(ConsumerId, PropertyId);
            if(result.Equals(null))
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
