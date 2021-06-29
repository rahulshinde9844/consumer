using Authorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.Provider
{
    public interface IAgentProvider
    {
        public List<LoginCredentials> GetList();

        public LoginCredentials GetAgent(Login cred);
    }
}
