using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using TechInsights.Application;
using TechInsights.Database;
using TechInsights.Database.Managers;
using TechInsights.Domain.Interfaces;

namespace TechInsights.UI
{
    public static class ServiceRegister
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var serviceType = typeof(Service);
            var definedTypes = serviceType.Assembly.DefinedTypes;

            var servicesWithAttribute = definedTypes
                .Where(x => x.GetTypeInfo().GetCustomAttribute<Service>() != null);

            foreach (var service in servicesWithAttribute)
            {
                services.AddTransient(service);
            }

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddTransient<IPortfolioManager, PortfolioManager>();
            services.AddTransient<IContactFormManager, ContactFormManager>();
            services.AddTransient<ITestimonialManager, TestimonialManager>();
        }
    }
}
