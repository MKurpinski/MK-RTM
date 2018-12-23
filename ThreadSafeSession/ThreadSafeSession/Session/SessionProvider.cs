using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ThreadSafeSession.Session
{
    public class SessionProvider: ISessionProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static Lazy<object> _syncObject = new Lazy<object>(new object());

        public SessionProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Set<T>(string key, T value)
        {
            Debug.WriteLine("Before lock statement");
            lock (_syncObject.Value)
            {
                Debug.WriteLine("Inside lock statement");
                Thread.Sleep(1000);
                _httpContextAccessor.HttpContext.Session.SetString(key, JsonConvert.SerializeObject(value));
            }
            Debug.WriteLine("Exiting lock statement");
        }

        public T Get<T>(string key)
        {
            var value = _httpContextAccessor.HttpContext.Session.GetString(key);

            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
