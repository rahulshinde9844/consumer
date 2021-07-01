using NUnit.Framework;
using Authorization;
using Authorization.Models;
using Authorization.Provider;
using System.Collections.Generic;
using Moq;

namespace AuthorizationTesting
{
    public class Tests
    {
        private List<Login> user;

        [SetUp]
        public void Setup()
        {
            user = new List<Login>()
            {
                new Login{Username = "Shivkumar",Password = "shiv@123"}
            };

        }

        [TestCase("Shivkumar","shiv@123")]
        public void GetAgent_Retutns_agent(string username, string password)
        {
            Mock<IAgentService> mock = new Mock<IAgentService>();
            mock.Setup(p => p.GetList()).Returns(user);
            AgentService agentService = new AgentService();
            Login login = new Login { Username = username, Password = password };
            var agentInfo = agentService.GetAgent(login);
            Assert.IsNotNull(agentInfo);
        }

        [TestCase("Shiv", "shiv123")]
        public void GetAgent_Retutns_Null(string username, string password)
        {
            Mock<IAgentService> mock = new Mock<IAgentService>();
            mock.Setup(p => p.GetList()).Returns(user);
            AgentService agentService = new AgentService();
            Login login = new Login { Username = username, Password = password };
            var agentInfo = agentService.GetAgent(login);
            Assert.IsNull(agentInfo);
        }

    }
}