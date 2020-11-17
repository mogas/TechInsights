using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechInsights.Application.Blog;

namespace TechInsights.UI.Controllers
{
    [Route("[controller]")]
    public class BlogController : Controller
    {
        private readonly BlogPostsService _blogPostsService;

        public BlogController([FromServices] BlogPostsService blogPostsService)
        {
            _blogPostsService = blogPostsService;
        }


        [HttpGet]
        [OutputCache(Profile = "default")]
        public async Task<IActionResult> Index()
        {
            var result = await _blogPostsService.GetAllAsync();
            return View(result);
        }

        [Route("/blog/{slug?}")]
        [OutputCache(Profile = "default")]
        public async Task<IActionResult> BlogPost(string slug)
        {
            var result = await _blogPostsService.GetBySlugAsync(slug);

            return result == null ? this.NotFound() : (IActionResult)this.View(result);
        }
    }
}
