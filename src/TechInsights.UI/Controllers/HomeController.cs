using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TechInsights.Application;
using TechInsights.Application.Services.ContactForm;
using TechInsights.Application.Services.Testimonial;
using TechInsights.Domain.Models;
using TechInsights.UI.ViewModels;

namespace TechInsights.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestimonialService _testimonialService;

        public HomeController(ILogger<HomeController> logger, [Service] TestimonialService testimonialService)
        {
            _logger = logger;
            _testimonialService = testimonialService;
        }

        [OutputCache(Profile = "default")]
        public async Task<IActionResult> Index()
        {
            HomeViewModel model = new();

            model.Testimonials = await _testimonialService.GetTestimonies();

            return View(model);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> SendMessage(ContactForm form, [FromServices] ContactFormService contactFormService)
        {
            if (form != null && ModelState.IsValid)
            {
                var status = await contactFormService.SendContactMessage(form);

                Thread.Sleep(Constants.Timers.Spinner);

                if (status)
                {
                    return PartialView("_ContactForm");
                }
            }

            return null;
        }
    }
}
