using Insureity_Portal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Insureity_Portal.Services
{
    public class LoginTokenService : ILoginTokenService
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(LoginTokenService));
        public string GetToken(string url, LoginDetails user)
        {
            try
            {
                _log4net.Info(nameof(GetToken) + " method invoked.");
                var jsonData = JsonConvert.SerializeObject(user);
                var encodedData = new StringContent(jsonData, Encoding.UTF8, "application/json");

                using var client = new HttpClient();
                var response = client.PostAsync(url, encodedData).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string tokenString = response.Content.ReadAsStringAsync().Result;
                    return tokenString;
                }
                return null;
            }
            catch (Exception e)
            {
                _log4net.Info("Error occured in " + nameof(LoginTokenService) + " Error message:  " + e.Message);
                throw e;
            }

        }
    }
}
