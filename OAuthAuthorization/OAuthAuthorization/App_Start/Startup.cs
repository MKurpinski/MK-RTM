using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using OAuthAuthorization.Extensions;
using Owin;

[assembly: OwinStartup(typeof(OAuthAuthorization.App_Start.Startup))]

namespace OAuthAuthorization.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);

            app.UseOAuth();
            app.UseWebApi(config);
        }
    }
}
