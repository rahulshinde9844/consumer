using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice.Models
{
    public class Business
    {

        public string BusinessId { get; set; }
        public string BusinessType { get; set; }
        public int AnnualTurnOver { get; set; }
        public int TotalEmployees { get; set; }
        

        //public Business( string bid, string btype, int ato, int te)
        //{
        //    this.BusinessId = bid;
        //    this.BusinessType = btype;
        //    this.AnnualTurnOver = ato;
        //    this.TotalEmployees = te;
        //}
	}
}
