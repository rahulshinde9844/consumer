using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesMicroservice.Models
{
    public class QuotesMaster
    {
        public int Id { get; set; }

        public int BusinessValue { get; set; }

        public int PropertyValue { get; set; }

        public string PropertyType { get; set; }
        
        public string Quotes { get; set; }

    }
}
