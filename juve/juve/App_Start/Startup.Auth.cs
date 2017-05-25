using juve.App_Start;
using juve.DAL;
using juve.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace juve
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(DataContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>
                (ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>
                (ApplicationSignInManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType =
                DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.
                    OnValidateIdentity<ApplicationUserManager,
                    IdentityModels.ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) =>
                        user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie
                (DefaultAuthenticationTypes.ExternalCookie);
            app.UseTwoFactorSignInCookie
                (DefaultAuthenticationTypes.TwoFactorCookie,
                TimeSpan.FromMinutes(5));
            app.UseTwoFactorRememberBrowserCookie
                (DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
        }
    }
}