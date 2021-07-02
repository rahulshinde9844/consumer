using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesMicroservice.Repository
{
    
    public class QuotesRepository : IQuotesRepository
    {
        private readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(QuotesRepository));
        public string QuotesForPolicy(int PropertyValue, int BusinessValue, string PropertyType)
        {
            _log4net.Info("Checking QuotesForPolicy with PropertyValue="+PropertyValue+" BusinessValue="+BusinessValue+" PropertyType="+PropertyType);

            if (PropertyValue >= 0 && PropertyValue <= 2 && BusinessValue >= 0 && BusinessValue <= 2 && PropertyType.ToLower() == "Factory Equipment".ToLower())
            {
                return "80000";
            }
            else if (PropertyValue >= 3 && PropertyValue <= 5 && BusinessValue >= 3 && BusinessValue <= 5 && PropertyType.ToLower() == "Factory Equipment".ToLower())
            {
                return "50000";
            }
            else if (PropertyValue >= 6 && PropertyValue <= 7 && BusinessValue >= 6 && BusinessValue <= 7 && PropertyType.ToLower() == "Factory Equipment".ToLower())
            {
                return "30000";
            }
            else if (PropertyValue >= 8 && PropertyValue <= 10 && BusinessValue >= 8 && BusinessValue <= 10 && PropertyType.ToLower() == "Factory Equipment".ToLower())
            {
                return "10000";
            }

            else if (PropertyValue >= 0 && PropertyValue <= 2 && BusinessValue >= 0 && BusinessValue <= 2 && PropertyType.ToLower() == "Property in transit".ToLower())
            {
                return "100000";
            }
            else if (PropertyValue >= 3 && PropertyValue <= 5 && BusinessValue >= 3 && BusinessValue <= 5 && PropertyType.ToLower() == "Property in transit".ToLower())
            {
                return "80000";
            }
            else if (PropertyValue >= 6 && PropertyValue <= 7 && BusinessValue >= 6 && BusinessValue <= 7 && PropertyType.ToLower() == "Property in transit".ToLower())
            {
                return "60000";
            }
            else if (PropertyValue >= 8 && PropertyValue <= 10 && BusinessValue >= 8 && BusinessValue <= 10 && PropertyType.ToLower() == "Property in transit".ToLower())
            {
                return "40000";
            }
            else if (PropertyValue >= 0 && PropertyValue <= 2 && BusinessValue >= 0 && BusinessValue <= 2 && PropertyType.ToLower() == "Building".ToLower())
            {
                return "1000000";
            }
            else if (PropertyValue >= 3 && PropertyValue <= 5 && BusinessValue >= 3 && BusinessValue <= 5 && PropertyType.ToLower() == "Building".ToLower())
            {
                return "800000";
            }
            else if (PropertyValue >= 6 && PropertyValue <= 7 && BusinessValue >= 6 && BusinessValue <= 7 && PropertyType.ToLower() == "Building".ToLower())
            {
                return "600000";
            }
            else if (PropertyValue >= 8 && PropertyValue <= 10 && BusinessValue >= 8 && BusinessValue <= 10 && PropertyType.ToLower() == "Building".ToLower())
            {
                return "400000";
            }
            else
            {
                return "No Quotes, Contact Insurance Provider";
            }
        }
    }
}
