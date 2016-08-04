using System.Web.Mvc;
using AspNetIdentityMockIdentitySamples.Filters;

namespace AspNetIdentityMockIdentitySamples.Controllers
{
    [RoutePrefix("admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet, AuthorizeWithRoleAuthenticated(Roles = "Admin"), Route("index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}