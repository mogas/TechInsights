using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechInsights.Domain.Interfaces;
using TechInsights.Domain.Models;

namespace TechInsights.Database.Managers
{
    public class BlogPostsManager : IBlogPostsManager
    {
        private readonly IRepositoryBase<BlogPost> _blogPostRepository;

        public BlogPostsManager(IRepositoryBase<BlogPost> blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _blogPostRepository.FindAll().ToListAsync();
        }

        public async Task<BlogPost> GetByIdAsync(int id)
        {
            return await _blogPostRepository.FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<BlogPost> GetBySlugAsync(string slug)
        {
            return await _blogPostRepository.FindByCondition(x => x != null && !string.IsNullOrWhiteSpace(x.Slug) && x.Slug.Equals(slug)).FirstOrDefaultAsync();
        }
    }
}
