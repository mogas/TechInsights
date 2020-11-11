using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TechInsights.UI.Components
{
    public class NewsViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            // no asynchronous work to do
            // just return fromResult for now
            return Task.FromResult<IViewComponentResult>(View());
        }
    }
}
