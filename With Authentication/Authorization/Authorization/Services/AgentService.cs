using Authorization.Models;
using Authorization.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.Provider
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository agentRepository;

        public AgentService(IAgentRepository _agentRepository)
        {
            agentRepository = _agentRepository;
        }
        public string GenerateJSONWebToken(Login login)
        {
            return agentRepository.GenerateJSONWebToken(login);
        }

        private readonly List<Login> AgentList = new List<Login>()
        {
            new Login{ Username = "Shivkumar", Password = "shiv@123"},
            new Login{ Username = "Prakash", Password = "prakash@123"}
        };
        public Login CheckCredential(Login login)
        {           
            Login agent = AgentList.FirstOrDefault(user => user.Username == login.Username && user.Password == login.Password);
            return agent;         
        }
    }
}
