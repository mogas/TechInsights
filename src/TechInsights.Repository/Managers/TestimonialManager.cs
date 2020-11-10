using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechInsights.Domain.Interfaces;
using TechInsights.Domain.Models;

namespace TechInsights.Database.Managers
{
    public class TestimonialManager : ITestimonialManager
    {
        private readonly IRepositoryBase<Testimonial> _testimonialRepository;

        public TestimonialManager(IRepositoryBase<Testimonial> testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public async Task<bool> AddTestimonialAsync(Testimonial testimonial)
        {
            if (testimonial != null)
            {
                try
                {
                    await _testimonialRepository.CreateAsync(testimonial).ConfigureAwait(false);

                    return true;
                }
                catch (Exception)
                {
                    // TODO
                }
            }

            return false;
        }


        public async Task<IEnumerable<Testimonial>> GetAllAsync()
        {
            return await _testimonialRepository.FindAll().ToListAsync();
        }
    }
}
