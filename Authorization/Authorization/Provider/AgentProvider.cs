using Authorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.Provider
{
    public class AgentProvider : IAgentProvider
    {
        private static List<LoginCredentials> AgentList = new List<LoginCredentials>()
        {
            new LoginCredentials{ Username = "steve", Password = "steve@123", Role="Agent"},
            new LoginCredentials{ Username = "marsh", Password = "marsh@123", Role="Agent"}
        };
        public List<LoginCredentials> GetList()
        {
            return AgentList;
        }

        public LoginCredentials GetAgent(Login cred)
        {
            List<LoginCredentials> AgentList = GetList();
            LoginCredentials agentDetails = AgentList.FirstOrDefault(user => user.Username == cred.Username && user.Password == cred.Password);

            return agentDetails;
        }
    }
}
