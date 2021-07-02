using Insureity_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insureity_Portal.Services
{
    public interface ILoginTokenService
    {
        string GetToken(string url, LoginDetails user);
    }
}
