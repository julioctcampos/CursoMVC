using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using GTAC.GTACAir.Web.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartup(typeof(GTAC.GTACAir.Web.Startup))]

namespace GTAC.GTACAir.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            app.CreatePerOwinContext(() => new GTACIdentityDbContext());

            app.CreatePerOwinContext(() =>
                new UserManager<IdentityUser>(
                    new UserStore<IdentityUser>(new GTACIdentityDbContext())
                )
            );
        }
    }
}