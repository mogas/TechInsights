﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechInsights.Domain.Interfaces;
using TechInsights.Domain.Models;

namespace TechInsights.Database.Managers
{
    public class BlogPostsManager : IBlogPostsManager
    {
        private readonly IRepositoryBase<BlogPost> _blogPostRepository;
        private readonly IRepositoryBase<BlogPostComment> _blogPostCommentRepository;

        public BlogPostsManager(IRepositoryBase<BlogPost> blogPostRepository, IRepositoryBase<BlogPostComment> blogPostCommentRepository)
        {
            _blogPostRepository = blogPostRepository;
            _blogPostCommentRepository = blogPostCommentRepository;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _blogPostRepository
                .FindAll()
                .Include(i => i.Comments)
                .Include(i => i.Categories)
                .OrderBy(i => i.LastModified)
                .ToListAsync();
        }

        public async Task<IEnumerable<BlogPost>> GetByCategory(string category)
        {
            return await _blogPostRepository
                .FindByCondition(x => x.Categories != null && x.Categories.Any(y => y.Title.Equals(category)))
                .Include(i => i.Comments)
                .Include(i => i.Categories)
                .OrderBy(i => i.LastModified)
                .ToListAsync();
        }

        public async Task<BlogPost> GetByIdAsync(int id)
        {
            return await _blogPostRepository
                .FindByCondition(x => x.Id.Equals(id))
                .Include(i => i.Comments)
                .Include(i => i.Categories)
                .OrderBy(i => i.LastModified)
                .FirstOrDefaultAsync();
        }

        public async Task<BlogPost> GetBySlugAsync(string slug)
        {
            return await _blogPostRepository
                .FindByCondition(x => x != null && !string.IsNullOrWhiteSpace(x.Slug) && x.Slug.Equals(slug))
                .Include(i => i.Comments)
                .Include(i => i.Categories)
                .OrderBy(i => i.LastModified)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> AddBlogPostComment(BlogPostComment comment)
        {
            if (comment != null)
            {
                try
                {
                    await _blogPostCommentRepository.CreateAsync(comment);

                    return true;
                }
                catch (Exception)
                {
                    // TODO
                }
            }

            return false;
        }
    }
}
