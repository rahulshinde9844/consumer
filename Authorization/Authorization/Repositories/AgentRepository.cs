using Authorization.Models;
using Authorization.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private IAgentProvider provider;

        public AgentRepository(IAgentProvider _provider)
        {
            provider = _provider;
        }
        public LoginCredentials GetAgentDetails(Login cred)
        {
            if (cred == null)
            {
                return null;
            }

            LoginCredentials agent = provider.GetAgent(cred);

            return agent;
        }
    }
}
