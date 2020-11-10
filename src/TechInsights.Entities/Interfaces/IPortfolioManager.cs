using System.Collections.Generic;
using System.Threading.Tasks;
using TechInsights.Domain.Models;

namespace TechInsights.Domain.Interfaces
{
    public interface IPortfolioManager
    {
        Task<IEnumerable<PortfolioClient>> GetAllPortfoliosAsync();
        Task<PortfolioClient> GetPortfolioByIdAsync(int id);
    }
}
