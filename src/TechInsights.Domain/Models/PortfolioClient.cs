using System.ComponentModel.DataAnnotations;

namespace TechInsights.Domain.Models
{
    public class PortfolioClient : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Client { get; set; }

        [Required]
        public string ProjectYear { get; set; }

        public string Category { get; set; }

        public string ProjectUrl { get; set; }
    }
}
