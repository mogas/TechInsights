using System.Collections.Generic;
using System.Threading.Tasks;
using TechInsights.Domain.Interfaces;
using TechInsights.Domain.Models;

namespace TechInsights.Application.Portfolio
{
    [Service]
    public class PortfolioService
    {
        private readonly IPortfolioManager _portfolioManager;
        private readonly ICacheService _cacheService;

        public PortfolioService(IPortfolioManager portfolioManager, ICacheService cacheService)
        {
            _portfolioManager = portfolioManager;
            _cacheService = cacheService;
        }

        public Task<IEnumerable<PortfolioClient>> GetPortfolios()
        {
            return _cacheService.GetOrCreateAsync<IEnumerable<PortfolioClient>>("PortfolioAll", () => _portfolioManager.GetAllPortfoliosAsync());
        }
    }
}
