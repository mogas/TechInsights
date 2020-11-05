using Microsoft.AspNetCore.Mvc;

namespace TechInsights.Web.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
