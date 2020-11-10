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

        public PortfolioService(IPortfolioManager portfolioManager)
        {
            _portfolioManager = portfolioManager;
        }

        public Task<IEnumerable<PortfolioClient>> GetPortfolios()
        {
            return _portfolioManager.GetAllPortfoliosAsync();
        }
    }
}
