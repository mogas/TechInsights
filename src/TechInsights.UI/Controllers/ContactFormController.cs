using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using TechInsights.Application.ContactForm;
using TechInsights.Domain.Models;

namespace TechInsights.UI.Controllers
{
    public class ContactFormController : Controller
    {
        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> SendMessage(ContactForm form, [FromServices] ContactFormService contactFormService)
        {
            if (form != null && ModelState.IsValid)
            {
                var status = await contactFormService.SendContactMessage(form);

                Thread.Sleep(2000);

                if (status)
                {
                    return ViewComponent("ContactForm");
                }
            }

            return null;
        }
    }
}
