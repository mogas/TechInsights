using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechInsights.Domain.Models;

namespace TechInsights.UI.Components
{
    public class ContactFormViewComponent : ViewComponent
    {

        public Task<IViewComponentResult> InvokeAsync()
        {
            // no asynchronous work to do
            // just return fromResult
            return Task.FromResult<IViewComponentResult>(View(new ContactForm()));
        }
    }
}