using QuotesMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesMicroservice.Service
{
    public class QuotesMasterService : IQuotesMasterService
    {
        private readonly IQuotesMasterRepo _QuotesMasterRepository;
        public QuotesMasterService(IQuotesMasterRepo QuotesMasterRepository)
        {
            _QuotesMasterRepository = QuotesMasterRepository;

        }
        public string QuotesForPolicyService(int PropertyValue, int BusinessValue, string PropertyType)
        {
            return _QuotesMasterRepository.QuotesForPolicy(PropertyValue, BusinessValue, PropertyType);
        }
    }
}
