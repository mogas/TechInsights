using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using TechInsights.Application.ContactForm;
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
        public async Task<IActionResult> SendMessage(ContactForm form, [FromServices] ContactFormService contactFormService)
        {
            if (form != null && ModelState.IsValid)
            {
                var status = await contactFormService.SendContactMessage(form);

                if (status)
                {
                    return View("Index");
                }
            }

            return Error();
        }
    }
}
