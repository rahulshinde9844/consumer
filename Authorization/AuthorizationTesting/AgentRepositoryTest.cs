using NUnit.Framework;
using Authorization;
using Authorization.Models;
using Authorization.Provider;
using System.Collections.Generic;
using Moq;
using Authorization.Repositories;

namespace AuthorizationTesting
{
    class AgentRepositoryTest
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

        [TestCase("Shivkumar", "shiv@123")]
        public void GetAgentDetails_Retutns_agent(string username, string password)
        {
            Login login = new Login { Username = username, Password = password };
            Mock<IAgentRepository> mockrepository = new Mock<IAgentRepository>();
            mockrepository.Setup(p => p.GetAgentDetails(login)).Returns(user[0]);
            var agentInfo = mockrepository.Object.GetAgentDetails(login);
            Assert.IsNotNull(agentInfo);

            AgentService agentService = new AgentService();
            var agent = agentService.GetAgent(login);
            Assert.IsNotNull(agent);
            Assert.AreEqual(agent, user);

        }

        [TestCase("shiv", "shiva")]
        public void GetAgentDetails_Retutns_Null(string username, string password)
        {
            user[0] = null;
            Login login = new Login { Username = username, Password = password };
            Mock<IAgentRepository> mock = new Mock<IAgentRepository>();
            mock.Setup(p => p.GetAgentDetails(login)).Returns(user[0]);
            var agentInfo = mock.Object.GetAgentDetails(login);
            Assert.IsNull(agentInfo);
        }


    }
}
