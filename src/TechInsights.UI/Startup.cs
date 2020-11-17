using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using TechInsights.Database;
using TechInsights.UI.Infrastructure;
using WebMarkupMin.AspNetCore3;

namespace TechInsights.UI
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));


            services.AddApplicationServices();


            services.AddControllersWithViews();


            services.AddRouting(x =>
            {
                x.LowercaseUrls = true;
                x.AppendTrailingSlash = false;
            });

            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var localHostSslPort = 0;


            if (env.IsDevelopment())
            {
                //WebEssentials.AspNetCore.StaticFilesWithCache
                app.UseStaticFiles();
                app.UseDeveloperExceptionPage();

                localHostSslPort = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Properties/launchSettings.json")
                    .Build()
                    .GetSection("iisSettings")
                    .GetSection("iisExpress")
                    .GetValue<int>("sslPort");
            }
            else
            {
                app.UseExceptionHandler("/Shared/Error");
                app.UseHsts();
                app.UseStaticFilesWithCache();
                app.UseWebMarkupMin();
            }

            app.Use(
                (context, next) =>
                {
                    context.Response.Headers["X-Content-Type-Options"] = "nosniff";
                    return next();
                });

            app.UseStatusCodePagesWithReExecute("/Shared/Error");


            app.UseHttpsRedirection();


            app.UseMiddleware<CanonicalUrlMiddleware>(localHostSslPort);

            //WebEssentials.AspNetCore.OutputCaching
            app.UseOutputCaching();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
