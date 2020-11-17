using System;
using System.Threading.Tasks;

namespace TechInsights.Application
{
    public interface ICacheService
    {
        Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> input) where T : class;
    }
}
