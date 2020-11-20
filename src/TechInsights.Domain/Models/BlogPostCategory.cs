using System.ComponentModel.DataAnnotations;

namespace TechInsights.Domain.Models
{
    public class BlogPostCategory : BaseEntity
    {
        [Required]
        public string Title { get; set; }
    }
}
