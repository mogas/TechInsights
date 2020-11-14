namespace TechInsights.Domain.Models
{
    public class BlogPost : BaseEntity
    {
        public string Title { get; set; }
        public string HtmlContent { get; set; }
    }
}
