using PolicyMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice
{
    public class PolicyData
    {
        public static List<ConsumerPolicy> PolicyList = new List<ConsumerPolicy>()
        {

        new ConsumerPolicy()
            {
                Id = 1,
                ConsumerId ="C01",
                BusinessId ="B01",
                PolicyId = "P01",
                PolicyStatus = "Issued",
                AcceptedQuotes = "81000" ,
                PaymentDetails = "Success",
                AcceptanceStatus = "Accepted",
                EffectiveDate = new DateTime(2021, 05, 31)

    },

        new ConsumerPolicy()
            {
                Id = 2,
                ConsumerId ="C01",
                BusinessId ="B01",
                PolicyId= null,
                PolicyStatus = "Initiated",
                AcceptedQuotes = "81000" ,
                PaymentDetails = null,
                AcceptanceStatus = null

            },

        };
    }
}
