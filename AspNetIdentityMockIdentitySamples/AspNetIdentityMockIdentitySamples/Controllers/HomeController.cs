using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using AspNetIdentityMockIdentitySamples.Filters;
using AspNetIdentityMockIdentitySamples.ViewModels;
using Microsoft.AspNet.Identity;

namespace AspNetIdentityMockIdentitySamples.Controllers
{
    [RoutePrefix("home")]
    public class HomeController : Controller
    {
        private UserViewModel Doer
        {
            get
            {
                return new UserViewModel()
                {
                    Id = this.User.Identity.GetUserId(),
                    Name = this.User.Identity.Name,
                    Roles = ((ClaimsIdentity)this.User.Identity).FindAll(ClaimTypes.Role)
                                                                .Select(c => c.Value)
                                                                .ToList()
                };
            }
        }

        [HttpGet, AuthorizeWithRoleAuthenticated(Roles = "Admin, User"), Route("index")]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet, AuthorizeWithRoleAuthenticated(Roles = "Admin"), Route("admin")]
        public ActionResult Admin()
        {
            return this.View();
        }

        [HttpGet, AuthorizeWithRoleAuthenticated(Roles = "Admin, User"), Route("who")]
        public JsonResult Who()
        {
            var user = this.Doer;

            return this.Json(user);
        }
    }
}