using System.Collections.Generic;
using TechInsights.Domain.Models;

namespace TechInsights.UI.ViewModels
{
    public class BlogViewModel
    {
        public IEnumerable<BlogPost> BlogPosts { get; set; }
    }
}
