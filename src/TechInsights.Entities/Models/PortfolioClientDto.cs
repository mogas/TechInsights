namespace TechInsights.Entities.Models
{
    public class PortfolioClientDto : BaseDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Client { get; set; }

        public string ProjectYear { get; set; }

        public string Category { get; set; }

        public string ProjectUrl { get; set; }

        public byte[] ClientImage { get; set; }
    }
}
