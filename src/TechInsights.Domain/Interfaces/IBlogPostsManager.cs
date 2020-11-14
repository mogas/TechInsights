﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TechInsights.Domain.Models;

namespace TechInsights.Domain.Interfaces
{
    public interface IBlogPostsManager
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();

        Task<BlogPost> GetByIdAsync(int id);
    }
}
