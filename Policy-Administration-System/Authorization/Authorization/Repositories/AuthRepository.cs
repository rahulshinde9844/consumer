using Authorization.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authorization.Repositories
{
    public class AuthRepository
    {
        private readonly IConfiguration _configuration;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthRepository));
        private readonly IAgentRepository _agentRepository;
        public AuthRepository(IConfiguration configuration, IAgentRepository agentRepository)
        {
            _configuration = configuration;
            _agentRepository = agentRepository;
        }

        public string GenerateJSONWebToken(LoginCredentials agentInfo)
        {
            _log4net.Info("Token Is Generated!");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims = {
                new Claim(ClaimTypes.Role, agentInfo.Role),
                new Claim("username", agentInfo.Username)
            };

            var token = new JwtSecurityToken(
              issuer: _configuration["Jwt:Issuer"],
              audience: _configuration["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);



            return new JwtSecurityTokenHandler().WriteToken(token);


        }

        /// <summary>
        /// Finding Agent with matching credentials
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>

        public LoginCredentials AuthenticateAgent(Login login)
        {
            _log4net.Info("Validating the Agent!");

            //Validate the Agent Credentials 
            LoginCredentials agent = _agentRepository.GetAgentDetails(login);


            return agent;
        }
    }
}
