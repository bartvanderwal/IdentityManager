using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace IdentityManager.Host.Controllers {
    public class HomeController : Controller {
        
        // GET: Login
        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password, string returnUrl) {
            var idmUsername = ConfigurationManager.AppSettings["IdmUsername"];
            var idmPassword = ConfigurationManager.AppSettings["IdmPassword"];
            if (username == idmUsername && password==idmPassword) {
                var claims = new Claim[] {
                    new Claim("name", "Brock"),
                    // new Claim("name", "Alice Smith"),
                    new Claim("role", "Admin")
                };
                var id = new ClaimsIdentity(claims, "Cookies");
                Request.GetOwinContext().Authentication.SignIn(id);
                return Redirect(!string.IsNullOrEmpty(returnUrl) ? returnUrl : "/idm");
            }
            return View();
        }
    }
}