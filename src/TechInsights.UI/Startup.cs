using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.IO.Compression;
using System.Linq;
using TechInsights.Database;
using TechInsights.UI.Infrastructure;
using WebMarkupMin.AspNetCore3;

namespace TechInsights.UI
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _config = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] {
                    "image/jpeg", "image/png", "image/svg+xml"});
                options.EnableForHttps = true;
            });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });

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


            if (_env.IsProduction())
            {
                services.AddMemoryCache();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

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
                app.UseOutputCaching();

                // TODO: Remove this line before moving to production
                localHostSslPort = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Properties/launchSettings.json")
                   .Build()
                   .GetSection("iisSettings")
                   .GetSection("iisExpress")
                   .GetValue<int>("sslPort");
            }

            app.Use(
                (context, next) =>
                {
                    context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
                    context.Response.Headers.Add("X-Xss-Protection", "1; mode=block");
                    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                    context.Response.Headers.Add("Referrer-Policy", "strict-origin-when-cross-origin");
                    context.Response.Headers.Add("X-Permitted-Cross-Domain-Policies", "none");
                    context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'");

                    return next();
                });

            app.UseStatusCodePagesWithReExecute("/Shared/Error");


            app.UseHttpsRedirection();

            app.UseMiddleware<CanonicalUrlMiddleware>(localHostSslPort);


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
