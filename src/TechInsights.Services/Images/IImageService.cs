using System.Threading.Tasks;
using TechInsights.Entities.Models;

namespace TechInsights.Services.Images
{
    public interface IImageService
    {
        Task<bool> SaveImage(Image imageModel, string wwwRootPath);

        Task<bool> DeleteImage(int id, string wwwRootPath);
    }
}
