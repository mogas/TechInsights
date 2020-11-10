using System.Collections.Generic;
using TechInsights.Domain.Models;

namespace TechInsights.UI.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Testimonial> Testimonials { get; set; } = new List<Testimonial>();

        public ContactForm ContactForm { get; set; } = new ContactForm();
    }
}
