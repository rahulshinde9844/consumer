using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice.Models
{
    public class Property
    {
        public string PropertyId { get; set; }
        public int BuildingSqft { get; set; }
        public string BuildingType { get; set; }
        public int BuildingStoreys { get; set; }
        public int BuildingAge { get; set; }

        //public Property(string pid, int bsqrt, string btype, int bst, int bage )
        //{
        //    this.PropertyId = pid;
        //    this.BuildingSqft = bsqrt;
        //    this.BuildingType = btype;
        //    this.BuildingStoreys = bst;
        //    this.BuildingAge = bage;
        //}
        
    }
}
