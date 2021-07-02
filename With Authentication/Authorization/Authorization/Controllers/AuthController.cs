using Authorization.Models;
using Authorization.Provider;
using Microsoft.AspNetCore.Authorization;
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
        private readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthController));
        private readonly IAgentService agentService;
        public AuthController(IAgentService _agentService)
        {
            agentService = _agentService;
        }

        /// <summary>
        /// Post method for Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login([FromBody] Login login)
        {
            try
            {
                _log4net.Info(nameof(Login) + " method invoked, Username : " + login.Username);
                Login loginDetail = agentService.CheckCredential(login);
                if (login != null)
                {
                    var tokenString = agentService.GenerateJSONWebToken(loginDetail);
                    return Ok(tokenString);
                }
                return Unauthorized("Invalid Credentials");
            }
            catch (Exception e)
            {
                _log4net.Error("Error Occured from " + nameof(Login) + "Error Message : " + e.Message);
                return BadRequest(e.Message);
            }
        }


        [Authorize]
        [HttpGet]
        [Route("Validate")]
        public IActionResult Validate()
        {
            return Ok();
        }
    }
}