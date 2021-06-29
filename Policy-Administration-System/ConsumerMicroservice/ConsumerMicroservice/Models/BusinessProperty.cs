using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice.Models
{
    public class BusinessProperty
    {
        public string ConsumerId { get; set; }
        public string PropertyId { get; set; }
        public int BuildingSqft { get; set; }
        public string BuildingType { get; set; }
        public int BuildingStoreys { get; set; }
        public int BuildingAge { get; set; }
         public int CostOfTheAsset { get; set; }
        public int SalvageValue { get; set; }
        public int UsefulLifeOfTheAsset { get; set; }
        
    }
}
