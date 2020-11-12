using System.Collections.Generic;
using System.Threading.Tasks;
using TechInsights.Domain.Models;

namespace TechInsights.Domain.Interfaces
{
    public interface ITestimonialManager
    {
        Task<bool> AddTestimonialAsync(Testimonial testimonial);

        Task<IEnumerable<Testimonial>> GetAllAsync();
    }
}
