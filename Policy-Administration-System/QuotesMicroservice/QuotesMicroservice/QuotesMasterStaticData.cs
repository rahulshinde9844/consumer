using QuotesMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesMicroservice
{
    public class QuotesMasterStaticData
    {
        public static List<QuotesMaster> QuotesLists = new List<QuotesMaster>()
        {
            
            new QuotesMaster()
            {
                Id = 3,
                BusinessValue = 6,
                PropertyValue = 6,
                PropertyType = "Factory Equipment",
                Quotes = 25000
            },
            new QuotesMaster()
            {
                Id = 4,
                BusinessValue = 8,
                PropertyValue = 8,
                PropertyType = "Factory Equipment",
                Quotes = 15000
            },
            new QuotesMaster()
            {
                Id = 5,
                BusinessValue = 9,
                PropertyValue = 10,
                PropertyType = "Factory Equipment",
                Quotes = 10000
            },
            new QuotesMaster()
            {
                Id = 6,
                BusinessValue = 1,
                PropertyValue = 2,
                PropertyType = "Building",
                Quotes = 35000
            },
            new QuotesMaster()
            {
                Id = 7,
                BusinessValue = 3,
                PropertyValue = 4,
                PropertyType = "Building",
                Quotes = 58000
            },
            new QuotesMaster()
            {
                Id = 8,
                BusinessValue = 7,
                PropertyValue = 6,
                PropertyType = "Buidling",
                Quotes = 79000
            },
            new QuotesMaster()
            {
                Id = 9,
                BusinessValue = 8,
                PropertyValue = 5,
                PropertyType = "Building",
                Quotes = 88000
            },
            new QuotesMaster()
            {
                Id = 10,
                BusinessValue = 10,
                PropertyValue = 10,
                PropertyType = "Building",
                Quotes = 105000
            },
            new QuotesMaster()
            {
                Id = 11,
                BusinessValue = 2,
                PropertyValue = 1,
                PropertyType = "Building",
                Quotes = 40000
            },
            new QuotesMaster()
            {
                Id = 12,
                BusinessValue = 3,
                PropertyValue = 3,
                PropertyType = "Property in Transit",
                Quotes = 60000
            },
            new QuotesMaster()
            {
                Id = 13,
                BusinessValue = 6,
                PropertyValue = 7,
                PropertyType = "Property in Transit",
                Quotes = 80000
            },
            new QuotesMaster()
            {
                Id = 14,
                BusinessValue = 7,
                PropertyValue = 8,
                PropertyType = "Property in Transit",
                Quotes = 100000
            },
            new QuotesMaster()
            {
                Id = 15,
                BusinessValue = 10,
                PropertyValue = 10,
                PropertyType = "Property in Transit",
                Quotes = 120000
            },
        };
    }
}
