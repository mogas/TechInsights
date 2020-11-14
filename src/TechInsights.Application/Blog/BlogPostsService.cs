using System.Collections.Generic;
using System.Threading.Tasks;
using TechInsights.Domain.Interfaces;
using TechInsights.Domain.Models;

namespace TechInsights.Application.Blog
{
    [Service]
    public class BlogPostsService
    {
        private readonly IBlogPostsManager _blogPostsManager;

        public BlogPostsService(IBlogPostsManager blogPostsManager)
        {
            _blogPostsManager = blogPostsManager;
        }

        public Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return _blogPostsManager.GetAllAsync();
        }

        public Task<BlogPost> GetById(int id)
        {
            return _blogPostsManager.GetByIdAsync(id);
        }
    }
}
