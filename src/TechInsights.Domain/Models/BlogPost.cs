using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechInsights.Domain.Models
{
    public class BlogPost : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Excerpt { get; set; } = string.Empty;

        [Required]
        public string HtmlContent { get; set; }

        public virtual ICollection<BlogPostCategory> Categories { get; } = new List<BlogPostCategory>();

        public virtual ICollection<BlogPostComment> Comments { get; set; } = new List<BlogPostComment>();

        public DateTime LastModified { get; set; } = DateTime.UtcNow;

        public string Slug { get; set; } = string.Empty;

        public string GetLink() => $"/blog/{this.Slug}/";

        public string GetEncodedLink() => $"/blog/{System.Net.WebUtility.UrlEncode(this.Slug)}/";

    }
}
