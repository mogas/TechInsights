using Microsoft.AspNetCore.Http;

namespace TechInsights.UI.Extensions
{
    public static class HttpContextExtensions
    {
        public static (bool, string) CanonicalUrl(this HttpContext context, int localhostSslPort)
        {
            var host = context.Request.Host.Host;
            var port = host == "localhost" ? localhostSslPort : context.Request.Host.Port ?? 0;

            var portString = port == 80 || port == 443 ? string.Empty : $":{port}";

            var pathBase = context.Request.PathBase.HasValue ? context.Request.PathBase.Value : string.Empty;

            var isCanonical = context.Request.IsHttps;

            var path = pathBase + context.Request.Path.Value;
            var pathLower = path.ToLower();

            isCanonical = isCanonical && path == pathLower;

            if (pathLower != "/" && pathLower.EndsWith("/"))
            {
                isCanonical = false;
                pathLower = pathLower.TrimEnd('/');
            }

            var query = context.Request.QueryString.HasValue ? $"?{context.Request.QueryString.Value}" : string.Empty;

            const string httpsFormat = "https://{0}{1}{2}{3}";

            return (isCanonical, string.Format(httpsFormat, host, portString, pathLower, query));
        }
    }
}
