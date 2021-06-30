using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice.Models
{
    public class Consumer
    {
        public string ConsumerId { get; set; }
        public string ConsumerName { get; set; }
        public string Email { get; set; }
        public string Pan { get; set; }
        public string BusinessOverview { get; set; }
        public int ValidityofConsumer { get; set; }
        public int AgentId { get; set; }
        public string AgentName { get; set; }


        //public Consumer(string cId, string cName, string dob, string email, string pan, string boverview, int vcon, int aid, string aname)
        //{
        //    this.ConsumerId = cId;
        //    this.ConsumerName = cName;
        //    this.DOB = dob;
        //    this.Email = email;
        //    this.Pan = pan;
        //    this.BusinessOverview = boverview;
        //    this.ValidityofConsumer = vcon;
        //    this.AgentId = aid;
        //    this.AgentName = aname;
        //}
    }
}
