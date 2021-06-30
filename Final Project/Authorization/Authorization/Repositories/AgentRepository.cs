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
        private IAgentService agentService;

        public AgentRepository(IAgentService _provider)
        {
            agentService = _provider;
        }
        public Login GetAgentDetails(Login cred)
        {
            if (cred == null)
            {
                return null;
            }

            Login agent = agentService.GetAgent(cred);

            return agent;
        }
    }
}
