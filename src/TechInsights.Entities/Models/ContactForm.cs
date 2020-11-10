    using System.ComponentModel.DataAnnotations;

namespace TechInsights.Domain.Models
{
    public class ContactForm : BaseEntity
    {
        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
