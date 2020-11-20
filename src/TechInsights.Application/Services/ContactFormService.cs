using System.Threading.Tasks;
using TechInsights.Domain.Interfaces;

namespace TechInsights.Application.Services.ContactForm
{
    [Service]
    public class ContactFormService
    {
        private readonly IContactFormManager _contactFormManager;

        public ContactFormService(IContactFormManager contactFormManager)
        {
            _contactFormManager = contactFormManager;
        }

        public async Task<bool> SendContactMessage(TechInsights.Domain.Models.ContactForm contactForm)
        {
            return await _contactFormManager.AddContactForm(contactForm);
        }
    }
}
