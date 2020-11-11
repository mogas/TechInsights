using Microsoft.AspNetCore.Http;

namespace TechInsights.UI.Extensions
{
    public static class HttpContextExtensions
    {
        private const string HttpsFormat = "https://{0}{1}{2}{3}";

        public static (bool, string) CanonicalUrl(this HttpContext context, int localhostSslPort)
        {
            string host = context.Request.Host.Host;

            int port = host == "localhost" ?
                localhostSslPort :
                context.Request.Host.Port ??
                0;

            string portString = port == 80 || port == 443 ?
                string.Empty :
                $":{port}";

            string pathBase = context.Request.PathBase.HasValue ?
                context.Request.PathBase.Value :
                string.Empty;

            bool isCanonical = context.Request.IsHttps;

            string path = pathBase + context.Request.Path.Value;
            string pathLower = path.ToLower();

            isCanonical = isCanonical && path == pathLower;

            if (pathLower != "/" && pathLower.EndsWith("/"))
            {
                isCanonical = false;
                pathLower = pathLower.TrimEnd('/');
            }

            string query = context.Request.QueryString.HasValue ?
                $"?{context.Request.QueryString.Value}" :
                string.Empty;

            return (isCanonical, string.Format(HttpsFormat, host, portString, pathLower, query));
        }
    }
}
