using Authorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.Provider
{
    public interface IAgentService
    {
        public List<Login> GetList();

        public Login GetAgent(Login cred);
    }
}
