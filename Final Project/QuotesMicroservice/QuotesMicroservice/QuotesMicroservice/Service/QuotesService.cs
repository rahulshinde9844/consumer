using QuotesMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesMicroservice.Service
{
    public class QuotesService : IQuotesService
    {
        private readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(QuotesService));

        private readonly IQuotesRepo _QuotesRepository;
        public QuotesService(IQuotesRepo QuotesRepository)
        {
            _QuotesRepository = QuotesRepository;

        }
        public string QuotesForPolicyService(int PropertyValue, int BusinessValue, string PropertyType)
        {
            _log4net.Info("QuotesForPolicyService is accessed with propertyValue=" + PropertyValue + " BusinessValue=" + BusinessValue + " PropertyType=" + PropertyType);
            return _QuotesRepository.QuotesForPolicy(PropertyValue, BusinessValue, PropertyType);
        }
    }
}
