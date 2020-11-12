using Microsoft.AspNetCore.Mvc;
using TechInsights.Application.Portfolio;

namespace TechInsights.UI.Controllers
{
    public class CurriculumController : Controller
    {
        public CurriculumController()
        {
        }

        public IActionResult Index([FromServices] PortfolioService portfolioService)
        {
            var portfolios = portfolioService.GetPortfolios();

            return View();
        }
    }
}
