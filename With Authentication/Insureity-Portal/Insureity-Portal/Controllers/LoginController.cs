using Insureity_Portal.Models;
using Insureity_Portal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Insureity_Portal.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginTokenService loginTokenService;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(HomeController));


        public LoginController(ILoginTokenService _loginTokenService)
        {
            loginTokenService = _loginTokenService;
        }

        public IActionResult Index()
        {
            _log4net.Info(nameof(Index) + " method invoked.");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([FromForm] LoginDetails loginDetail)
        {
            try
            {
                _log4net.Info(nameof(Login) + " method invoked by the Username :" + loginDetail.Username);
                string token = loginTokenService.GetToken("https://localhost:44369/api/Auth", loginDetail);

                if (token != null)
                {
                    using (var client = new HttpClient())
                    {
                        var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                        client.DefaultRequestHeaders.Accept.Add(contentType);
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                        HttpContext.Session.SetString("Username", loginDetail.Username);
                        HttpContext.Session.SetString("token", token);

                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Username or Password is Incorrect");
                return View("Index");
            }
            catch (Exception e)
            {

                ErrorViewModel error = new ErrorViewModel
                {
                    ErrorMessage = e.Message
                };
                _log4net.Error("Error occured in " + nameof(Login) + " Error message:  " + error.ErrorMessage);
                return View("Error", error);
            }

        }


    }
}
