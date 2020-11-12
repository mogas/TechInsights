using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TechInsights.UI.Extensions;

namespace TechInsights.UI.Infrastructure
{
    public class CanonicalUrlMiddleware
    {
        private readonly int _localHostSslPort;
        private readonly RequestDelegate _next;

        public CanonicalUrlMiddleware(RequestDelegate next, int localHostSslPort)
        {
            _next = next;
            _localHostSslPort = localHostSslPort;
        }

        public async Task Invoke(HttpContext context)
        {
            (bool isCanonical, string url) = context.CanonicalUrl(_localHostSslPort);

            if (!isCanonical)
            {
                context.Response.Redirect(url, true);
            }

            await _next(context).ConfigureAwait(false);
        }
    }
}
