using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechInsights.Entities.Models;
using TechInsights.Services.Portfolio;

namespace TechInsights.Web.Controllers
{
    public class CurriculumController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IMapper _mapper;

        public CurriculumController(IPortfolioService portfolioService, IMapper mapper)
        {
            _portfolioService = portfolioService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var portfolios = await _portfolioService.GetAllPortfoliosAsync();

            var portfoliosModel = _mapper.Map<IEnumerable<PortfolioClientDto>>(portfolios);

            return View();
        }
    }
}
