using System.Threading.Tasks;
using TechInsights.Domain.Models;

namespace TechInsights.Domain.Interfaces
{
    public interface IContactFormManager
    {
        Task<bool> AddContactForm(ContactForm contactForm);
    }
}
