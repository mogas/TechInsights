using System;
using System.Threading.Tasks;
using TechInsights.Entities.Models;
using TechInsights.Repository;

namespace TechInsights.Services.Contact
{
    public class ContactFormService : IContactFormService
    {
        private readonly IRepositoryBase<ContactForm> _contactFormRepository;

        public ContactFormService(IRepositoryBase<ContactForm> contactFormRepository)
        {
            _contactFormRepository = contactFormRepository;
        }

        public async Task<bool> AddContactForm(ContactForm contactForm)
        {
            if (contactForm != null)
            {
                try
                {
                    await _contactFormRepository.CreateAsync(contactForm).ConfigureAwait(false);

                    await _contactFormRepository.SaveAsync().ConfigureAwait(false);

                    return true;
                }
                catch (Exception)
                {
                    // TODO
                }
            }

            return false;
        }
    }
}
