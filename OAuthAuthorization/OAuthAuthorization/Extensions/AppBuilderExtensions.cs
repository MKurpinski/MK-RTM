using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using OAuthAuthorization.Providers;
using Owin;

namespace OAuthAuthorization.Extensions
{
    public static class AppBuilderExtensions
    {
        public static void UseOAuth(this IAppBuilder app)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                Provider = new OAuthAuthorizationProvider()
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}