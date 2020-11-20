using Microsoft.AspNetCore.Mvc;

namespace TechInsights.UI.Controllers
{
    public class SharedController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => this.View(this.Response.StatusCode);
    }
}