using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolicyMicroservice.Models;

namespace PolicyMicroservice
{
    public class PolicyMasterData
    {
        public static List<PolicyMaster> policyMastersList = new List<PolicyMaster>()
        {
            
        new PolicyMaster()
            {
                PolicyId="P01",
                PropertyType="Building",
                ConsumerType="Owner",
                AssuredSum=20000000,
                Tenure=3,
                BusinessValue=5,
                PropertyValue=4,
                BaseLocation="Pune",
                Type="Replacement",
            },
            new PolicyMaster()
            {
               PolicyId="P02",
                PropertyType="Factory Equipment",
                ConsumerType="Owner",
                AssuredSum=40000000,
                Tenure=1,
                BusinessValue=9,
                PropertyValue=8,
                BaseLocation="Chennai",
                Type="Replacement"
            },
            new PolicyMaster()
            {
               PolicyId="P03",
                PropertyType="Property in Transit",
                ConsumerType="Owner",
                AssuredSum=20000000,
                Tenure=5,
                BusinessValue=7,
                PropertyValue=6,
                BaseLocation="Mumbai",
                Type="Pay Back"
            },
            
        };
    }
}
