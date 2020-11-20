using System.Collections.Generic;
using System.Threading.Tasks;
using TechInsights.Domain.Interfaces;

namespace TechInsights.Application.Services.Testimonial
{
    [Service]
    public class TestimonialService
    {
        private readonly ITestimonialManager _testimonialManager;
        private readonly ICacheService _cacheService;

        public TestimonialService(ITestimonialManager testimonialManager, ICacheService cacheService)
        {
            _testimonialManager = testimonialManager;
            _cacheService = cacheService;
        }

        public Task<IEnumerable<TechInsights.Domain.Models.Testimonial>> GetTestimonies()
        {
            return _cacheService.GetOrCreateAsync<IEnumerable<TechInsights.Domain.Models.Testimonial>>("TestimonialAll", () => _testimonialManager.GetAllAsync());
        }
    }
}
