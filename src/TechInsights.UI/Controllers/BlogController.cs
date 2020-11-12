using Microsoft.AspNetCore.Mvc;

namespace TechInsights.UI.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
