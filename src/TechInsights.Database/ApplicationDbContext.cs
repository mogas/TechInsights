using Microsoft.EntityFrameworkCore;
using TechInsights.Domain.Models;

namespace TechInsights.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<PortfolioClient> PortfolioClient { get; set; }

        public DbSet<ContactForm> ContactForm { get; set; }

        public DbSet<Testimonial> Testimonial { get; set; }

        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<BlogPostComment> BlogPostComment { get; set; }
    }
}
