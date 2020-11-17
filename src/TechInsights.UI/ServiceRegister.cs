using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using TechInsights.Application;
using TechInsights.Database;
using TechInsights.Database.Managers;
using TechInsights.Domain.Interfaces;
using WebEssentials.AspNetCore.OutputCaching;
using WebMarkupMin.AspNetCore3;
using WebMarkupMin.Core;

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

            // Output caching (https://github.com/madskristensen/WebEssentials.AspNetCore.OutputCaching)
            services.AddOutputCaching(
                options =>
                {
                    options.Profiles["default"] = new OutputCacheProfile
                    {
                        Duration = 3600
                    };
                });

            // HTML minification (https://github.com/Taritsyn/WebMarkupMin)
            services
                .AddWebMarkupMin(
                    options =>
                    {
                        options.AllowMinificationInDevelopmentEnvironment = true;
                        options.DisablePoweredByHttpHeaders = true;
                    })
                .AddHtmlMinification(
                    options =>
                    {
                        options.MinificationSettings.RemoveOptionalEndTags = false;
                        options.MinificationSettings.WhitespaceMinificationMode = WhitespaceMinificationMode.Safe;
                    });


            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddTransient<IPortfolioManager, PortfolioManager>();
            services.AddTransient<IContactFormManager, ContactFormManager>();
            services.AddTransient<ITestimonialManager, TestimonialManager>();
            services.AddTransient<IBlogPostsManager, BlogPostsManager>();
        }
    }
}
