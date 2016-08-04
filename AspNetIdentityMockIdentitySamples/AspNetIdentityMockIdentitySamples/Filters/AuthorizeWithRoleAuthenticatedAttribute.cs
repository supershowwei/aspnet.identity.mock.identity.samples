using System.Net;
using System.Web.Mvc;

namespace AspNetIdentityMockIdentitySamples.Filters
{
    public class AuthorizeWithRoleAuthenticatedAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}