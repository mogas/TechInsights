using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using TechInsights.Entities.Models;
using TechInsights.Services.Contact;
using TechInsights.Web.Models;

namespace TechInsights.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactFormService _contactFormService;

        public HomeController(ILogger<HomeController> logger, IContactFormService contactFormService)
        {
            _logger = logger;
            _contactFormService = contactFormService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(ContactForm form)
        {
            if (form != null && ModelState.IsValid)
            {
                var result = await _contactFormService.AddContactForm(form);

                if (result)
                {
                    return View("Index");
                }
            }

            return Error();
        }
    }
}
