using System.Web.Mvc;
using AspNetIdentityMockIdentitySamples.Filters;

namespace AspNetIdentityMockIdentitySamples.Controllers
{
    [RoutePrefix("home")]
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet, AuthorizeWithRoleAuthenticated(Roles = "Admin, User"), Route("index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}