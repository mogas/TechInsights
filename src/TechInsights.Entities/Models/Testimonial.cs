namespace TechInsights.Domain.Models
{
    public class Testimonial : BaseEntity
    {
        public string Name { get; set; }

        public string Position { get; set; }

        public string Testimony { get; set; }
    }
}
