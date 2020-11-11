using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechInsights.Application;
using TechInsights.Application.Testimonial;

namespace TechInsights.UI.Components
{
    public class TestimonialViewComponent : ViewComponent
    {
        private readonly TestimonialService _testimonialService;

        public TestimonialViewComponent([Service] TestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var testimonials = await _testimonialService.GetTestimonies().ConfigureAwait(false);

            return View(testimonials);
        }
    }
}
