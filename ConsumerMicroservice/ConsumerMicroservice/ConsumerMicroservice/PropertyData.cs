using ConsumerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice
{
    public class PropertyData
    {
        public static List<Property> PropertyList = new List<Property>()

        {
           new Property()
            {

                PropertyId = "P01",
                BuildingSqft = 2000,
                BuildingType = "Owner",
                BuildingStoreys = 5,
                BuildingAge = 2, 
            }

        };
    }
}
