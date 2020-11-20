using TechInsights.Domain.Models;

namespace TechInsights.UI.ViewModels
{
    public class BlogPostViewModel
    {
        public BlogPost BlogPost { get; set; }

        public BlogPostCommentsViewModel BlogPostComments { get; set; } = new();
    }
}
