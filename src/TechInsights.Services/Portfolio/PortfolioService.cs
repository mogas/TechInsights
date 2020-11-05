using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechInsights.Entities.Models;
using TechInsights.Repository;

namespace TechInsights.Services.Portfolio
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IRepositoryBase<PortfolioClient> _portfolioRepository;

        public PortfolioService(IRepositoryBase<PortfolioClient> portfolioRepository)
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
