using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using TechInsights.Application.ContactForm;
using TechInsights.Application.Testimonial;
using TechInsights.Domain.Models;
using TechInsights.UI.Models;

namespace TechInsights.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index([FromServices] TestimonialService testimonialService)
        {
            var testimonials = await testimonialService.GetTestimonies();

            HomeViewModel model = new HomeViewModel()
            {
                Testimonials = testimonials
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(ContactForm form, [FromServices] ContactFormService contactFormService)
        {
            if (form != null && ModelState.IsValid)
            {
                var status = await contactFormService.SendContactMessage(form);

                Thread.Sleep(2000);

                if (status)
                {
                    return View("Index");
                }
            }

            return Error();
        }
    }
}
