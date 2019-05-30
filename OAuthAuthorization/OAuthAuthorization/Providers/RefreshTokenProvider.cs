using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;

namespace OAuthAuthorization.Providers
{
    public class RefreshTokenProvider : AuthenticationTokenProvider
    {
        private static readonly ConcurrentDictionary<string, AuthenticationTicket> _refreshTokens = new ConcurrentDictionary<string, AuthenticationTicket>();

        public override async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var guid = Guid.NewGuid().ToString();
            _refreshTokens.TryAdd(guid, context.Ticket);
            context.SetToken(guid);
        }

        public override async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            if (_refreshTokens.TryRemove(context.Token, out var ticket))
            {
                context.SetTicket(ticket);
            }
        }
    }
}