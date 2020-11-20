using System;
using System.ComponentModel.DataAnnotations;

namespace TechInsights.Domain.Models
{
    public class BlogPostComment : BaseEntity
    {
        [Required]
        public string Author { get; set; }

        [Required]
        public string Content { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public int BlogPostId { get; set; }

        [Required]
        public DateTime PubDate { get; set; } = DateTime.UtcNow;

    }
}
