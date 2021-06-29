using Authorization.Models;
using Authorization.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _configuration;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthController));
        private readonly IAgentRepository _agentRepository;


        public AuthController(IConfiguration configuration, IAgentRepository agentRepository)
        {
            _configuration = configuration;
            _agentRepository = agentRepository;
        }

        /// <summary>
        /// Post method for Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Login([FromBody] Login login)
        {
            AuthRepository _authRepository = new AuthRepository(_configuration, _agentRepository);
            _log4net.Info("Login initiated!");
            IActionResult response = Unauthorized();
            var user = _authRepository.AuthenticateAgent(login);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                var tokenString = _authRepository.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

    }
}
