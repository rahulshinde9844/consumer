using Authorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.Provider
{
    public interface IAgentService
    {
        string GenerateJSONWebToken(Login login);
        Login CheckCredential(Login login);
    }
}
