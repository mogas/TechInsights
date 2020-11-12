using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechInsights.Domain.Interfaces;
using TechInsights.Domain.Models;

namespace TechInsights.Database.Managers
{
    public class PortfolioManager : IPortfolioManager
    {
        private readonly IRepositoryBase<PortfolioClient> _portfolioRepository;

        public PortfolioManager(IRepositoryBase<PortfolioClient> portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public async Task<IEnumerable<PortfolioClient>> GetAllPortfoliosAsync()
        {
            return await _portfolioRepository.FindAll().ToListAsync();
        }

        public async Task<PortfolioClient> GetPortfolioByIdAsync(int id)
        {
            return await _portfolioRepository.FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
