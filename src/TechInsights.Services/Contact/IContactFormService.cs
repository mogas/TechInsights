using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechInsights.Entities.Models;

namespace TechInsights.Services.Contact
{
    public interface IContactFormService
    {
        Task<bool> AddContactForm(ContactForm contactForm);
    }
}
