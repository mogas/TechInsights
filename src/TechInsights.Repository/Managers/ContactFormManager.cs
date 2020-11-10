using System;
using System.Threading.Tasks;
using TechInsights.Domain.Interfaces;
using TechInsights.Domain.Models;

namespace TechInsights.Database.Managers
{
    public class ContactFormManager : IContactFormManager
    {
        private readonly IRepositoryBase<ContactForm> _contactFormRepository;

        public ContactFormManager(IRepositoryBase<ContactForm> contactFormRepository)
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
