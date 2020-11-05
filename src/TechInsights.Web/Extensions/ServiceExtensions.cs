using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechInsights.Repository;
using TechInsights.Services.Images;
using TechInsights.Services.Portfolio;

namespace TechInsights.Web.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddTransient<IPortfolioService, PortfolioService>();
            services.AddTransient<IImageService, ImageService>();
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<RepositoryContext>(option => option.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        }
    }
}
