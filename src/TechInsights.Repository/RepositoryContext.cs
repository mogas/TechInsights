using Microsoft.EntityFrameworkCore;
using TechInsights.Entities.Models;

namespace TechInsights.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<PortfolioClient> PortfolioClient { get; set; }
    }
}
