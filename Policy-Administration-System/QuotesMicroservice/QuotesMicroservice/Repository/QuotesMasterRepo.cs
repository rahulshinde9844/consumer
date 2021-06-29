using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesMicroservice.Repository
{
    
    public class QuotesMasterRepo : IQuotesMasterRepo
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(QuotesMasterRepo));
        public string QuotesForPolicy(int PropertyValue, int BusinessValue, string PropertyType)
        {
            _log4net.Info("Checking for QuotesForPolicy Inputs");
            if (PropertyValue > 0 && BusinessValue <= 2 && PropertyType == "Factory Equipment" && PropertyValue <= 2 && BusinessValue > 0)
            {
                return "80000";
            }
            else if (PropertyValue >= 3 && PropertyValue <= 5 && BusinessValue >= 3 && BusinessValue <= 5 && PropertyType == "Factory Equipment")
            {
                return "50000";
            }
            else
            {
                var obj = QuotesMasterStaticData.QuotesLists.FirstOrDefault(a => a.PropertyValue == PropertyValue && a.BusinessValue == BusinessValue && a.PropertyType == PropertyType);
                if (obj == null)
                {
                    return "No Quotes, Contact Insurance Provider";
                }
                return obj.Quotes.ToString();
            }
        }
    }
}
