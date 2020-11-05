using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;
using TechInsights.Entities.Models;
using TechInsights.Repository;

namespace TechInsights.Services.Images
{
    public class ImageService : IImageService
    {
        private readonly IRepositoryBase<Image> _imageRepository;

        public ImageService(IRepositoryBase<Image> imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<bool> SaveImage(Image imageModel, string wwwRootPath)
        {
            if (imageModel != null && !string.IsNullOrWhiteSpace(wwwRootPath))
            {
                string fileName = Path.GetFileNameWithoutExtension(imageModel.File.FileName);
                string path = Path.Combine($"{wwwRootPath}/img/portfolio/", fileName);
                string extension = Path.GetExtension(imageModel.File.FileName);

                imageModel.Name = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                using (var fileStream = new FileStream(path + extension, FileMode.Create))
                {
                    await imageModel.File.CopyToAsync(fileStream).ConfigureAwait(false);
                }

                await _imageRepository.CreateAsync(imageModel).ConfigureAwait(false);

                await _imageRepository.SaveAsync().ConfigureAwait(false);

                return true;
            }

            return false;
        }

        public async Task<bool> DeleteImage(int id, string wwwRootPath)
        {
            var imageModel = _imageRepository.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();

            if (imageModel?.Result != null)
            {
                string path = Path.Combine($"{wwwRootPath}/img/portfolio/", imageModel.Result.Name);

                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                _imageRepository.Delete(imageModel.Result);

                await _imageRepository.SaveAsync().ConfigureAwait(false);
            }

            return false;
        }
    }
}
