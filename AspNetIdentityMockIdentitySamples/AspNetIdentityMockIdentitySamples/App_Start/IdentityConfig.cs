using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(AspNetIdentityMockIdentitySamples.IdentityConfig))]

namespace AspNetIdentityMockIdentitySamples
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/account/login"),
                ExpireTimeSpan = TimeSpan.FromHours(8),
                Provider = new CookieAuthenticationProvider()
            });
        }
    }
}