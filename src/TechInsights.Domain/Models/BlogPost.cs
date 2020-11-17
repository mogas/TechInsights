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
        public string HtmlContent { get; set; }

        public IList<string> Categories { get; } = new List<string>();

        public virtual ICollection<BlogPostComment> Comments { get; } = new List<BlogPostComment>();

        public DateTime LastModified { get; set; } = DateTime.UtcNow;

        public string Slug { get; set; } = string.Empty;

        public string GetLink(string blogPageName) => $"/{blogPageName }/{this.Slug}/";

        public string GetEncodedLink(string blogPageName) => $"/{blogPageName}/{System.Net.WebUtility.UrlEncode(this.Slug)}/";

    }
}
