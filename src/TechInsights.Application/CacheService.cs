using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace TechInsights.Application
{
    public class CacheService : ICacheService
    {
        private readonly bool CacheEnabled;
        private readonly IMemoryCache _cache;

        public CacheService(IMemoryCache cache, IConfiguration configuration)
        {
            _cache = cache;
            _ = bool.TryParse(configuration["SiteSettings:cacheEnabled"], out CacheEnabled);
        }

        public Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> input) where T : class
        {

            if (CacheEnabled)
            {
                return _cache.GetOrCreateAsync<T>(key, _ =>
                {
                    return input();
                });
            }

            return input();
        }
    }
}
