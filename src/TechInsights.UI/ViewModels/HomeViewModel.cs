using System.Collections.Generic;
using TechInsights.Domain.Models;

namespace TechInsights.UI.ViewModels
{
    public class HomeViewModel
    {
        public ContactForm ContactForm { get; set; } = new ContactForm();

        public IEnumerable<Testimonial> Testimonials { get; set; }
    }
}
