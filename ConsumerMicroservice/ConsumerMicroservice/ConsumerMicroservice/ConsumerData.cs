using ConsumerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice
{
    public class ConsumerData
    {
        public static List<Consumer> ConsumerList = new List<Consumer>()

        {
           new Consumer()
            {
                ConsumerId = "C01",
                ConsumerName = "Praneeth",
                DOB = "07/12/1989",
                Email = "praneeth@gmail.com",
                Pan = "ABC1234567",
                BusinessOverview = "Sole Proprietorships",
                ValidityofConsumer = 2 ,
                AgentId = 1,
                AgentName = "Lasya"
            },
            new Consumer()
            {
                ConsumerId = "C02",
                ConsumerName = "Tarak",
                DOB = "04/03/1987",
                Email = "tarak0403@gmail.com",
                Pan = "ABC1144567",
                BusinessOverview = "Corporations" ,
                ValidityofConsumer = 2 ,
                AgentId = 2,
                AgentName = "Dileep"
            },
            new Consumer()
            {
                ConsumerId = "C03",
                ConsumerName = "Poojitha",
                DOB = "08/02/1989",
                Email = "pooji0802@gmail.com",
                Pan = "XYZ1234567",
                BusinessOverview = "entrepreneurs",
                ValidityofConsumer = 3 ,
                AgentId = 3,
                AgentName = "Vardhan"
            },
            new Consumer()
            {
                ConsumerId = "C04",
                ConsumerName = "Minnie",
                DOB = "11/11/1988",
                Email = "minnie49@gmail.com",
                Pan = "ABC1156472",
                BusinessOverview = "Sole Proprietorships" ,
                ValidityofConsumer = 1 ,
                AgentId = 4,
                AgentName = "Srinivas"
            },
            new Consumer()
            {
                ConsumerId = "C05",
                ConsumerName = "Sai",
                DOB = "14/07/1989",
                Email = "sai140789@gmail.com",
                Pan = "XYZ1111289",
                BusinessOverview = "Corporations",
                ValidityofConsumer = 3 ,
                AgentId = 5,
                AgentName = "Sowmya"
            },
            new Consumer()
            {
                ConsumerId = "C06",
                ConsumerName = "Madhura",
                DOB = "09/05/1989",
                Email = "madhurap@gmail.com",
                Pan = "XYZ1111889",
                BusinessOverview = "Sole Proprietorships",
                ValidityofConsumer = 1,
                AgentId = 6,
                AgentName = "varun"
            },
        };
    }
}
