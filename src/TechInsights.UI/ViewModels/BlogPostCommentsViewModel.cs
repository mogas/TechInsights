using System.Collections.Generic;
using TechInsights.Domain.Models;

namespace TechInsights.UI.ViewModels
{
    public class BlogPostCommentsViewModel
    {
        public int BlogPostId { get; set; }

        public IEnumerable<BlogPostComment> Comments { get; set; } = new List<BlogPostComment>();

        public BlogPostComment CommentForm { get; set; } = new();
    }
}
