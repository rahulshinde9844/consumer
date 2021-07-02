using ConsumerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice
{
    public class BusinessData
    {
        public static List<Business> BusinessList = new List<Business>()

        {
           new Business()
            {
                BusinessId = "B01",
                BusinessType = "Pharmacy",
                AnnualTurnOver = 1000000,
                TotalEmployees = 100,
                CapitalInvested = 200000
            },
           new Business()
            {
                BusinessId = "B02",
                BusinessType = "Food",
                AnnualTurnOver = 2000000,
                TotalEmployees = 150,
                CapitalInvested = 1000000
            },
           new Business()
            {
                BusinessId = "B03",
                BusinessType = "Food",
                AnnualTurnOver = 1200000,
                TotalEmployees = 50,
                CapitalInvested = 200000
            }

        };
    }
}
