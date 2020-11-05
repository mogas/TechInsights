using System.Collections.Generic;
using System.Threading.Tasks;
using TechInsights.Entities.Models;

namespace TechInsights.Services.Portfolio
{
    public interface IPortfolioService
    {
        Task<IEnumerable<PortfolioClient>> GetAllPortfoliosAsync();
        Task<PortfolioClient> GetPortfolioByIdAsync(int id);
    }
}
