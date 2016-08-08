using System;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace AspNetIdentityMockIdentitySamples.Controllers
{
    [RoutePrefix("account")]
    public class AccountController : Controller
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        // GET: Account
        [HttpGet, Route("~/"), Route("login")]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost, Route("login")]
        public ActionResult Login(string id, string password)
        {
            if (id.Equals("johnny", StringComparison.OrdinalIgnoreCase) && password.Equals("p@ssw0rd"))
            {
                // 是主廚
                var identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, id));
                identity.AddClaim(new Claim(ClaimTypes.Name, "主廚"));
                identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));

                this.AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, identity);

                return this.RedirectToAction("admin", "home");
            }
            else if (id.Equals("mary", StringComparison.OrdinalIgnoreCase) && password.Equals("password"))
            {
                // 一般使用者
                var identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, id));
                identity.AddClaim(new Claim(ClaimTypes.Name, "一般使用者"));
                identity.AddClaim(new Claim(ClaimTypes.Role, "User"));

                this.AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, identity);

                return this.RedirectToAction("index", "home");
            }

            return this.View("Login");
        }
    }
}