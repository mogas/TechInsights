using System.Collections.Generic;
using System.Threading.Tasks;
using TechInsights.Domain.Interfaces;
using TechInsights.Domain.Models;

namespace TechInsights.Application.Services.Blog
{
    [Service]
    public class BlogPostsService
    {
        private readonly IBlogPostsManager _blogPostsManager;
        private readonly ICacheService _cacheService;

        public BlogPostsService(IBlogPostsManager blogPostsManager, ICacheService cacheService)
        {
            _blogPostsManager = blogPostsManager;
            _cacheService = cacheService;
        }

        public Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return _cacheService.GetOrCreateAsync<IEnumerable<BlogPost>>("PostsAll", () => _blogPostsManager.GetAllAsync());
        }

        public Task<BlogPost> GetByIdAsync(int id)
        {
            return _cacheService.GetOrCreateAsync<BlogPost>($"Post-{id}", () => _blogPostsManager.GetByIdAsync(id));
        }

        public Task<BlogPost> GetBySlugAsync(string slug)
        {
            return _cacheService.GetOrCreateAsync<BlogPost>($"Post-{slug}", () => _blogPostsManager.GetBySlugAsync(slug));
        }

        public Task<IEnumerable<BlogPost>> GetByCategoryAsync(string category)
        {
            return _cacheService.GetOrCreateAsync<IEnumerable<BlogPost>>($"Post-{category}", () => _blogPostsManager.GetByCategory(category));
        }
    }
}
