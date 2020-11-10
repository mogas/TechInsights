using System.Collections.Generic;
using System.Threading.Tasks;
using TechInsights.Domain.Interfaces;

namespace TechInsights.Application.Testimonial
{
    [Service]
    public class TestimonialService
    {
        private readonly ITestimonialManager _testimonialManager;

        public TestimonialService(ITestimonialManager testimonialManager)
        {
            _testimonialManager = testimonialManager;
        }

        public Task<IEnumerable<TechInsights.Domain.Models.Testimonial>> GetTestimonies()
        {
            return _testimonialManager.GetAllAsync();
        }
    }
}
