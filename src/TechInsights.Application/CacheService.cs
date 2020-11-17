using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace TechInsights.Application
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _cache;

        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> input) where T : class
        {
            return _cache.GetOrCreateAsync<T>(key, _ =>
            {
                return input();
            });
        }
    }
}
