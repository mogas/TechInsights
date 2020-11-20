using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechInsights.Application.Services.Blog;
using TechInsights.Domain.Models;

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

        [Route(Constants.Routes.BlogPost)]
        [OutputCache(Profile = "default")]
        public async Task<IActionResult> BlogPost(string slug)
        {
            var result = await _blogPostsService.GetBySlugAsync(slug);

            return result == null ? this.NotFound() : (IActionResult)this.View(result);
        }

        [Route(Constants.Routes.BlogPostByCategory)]
        [OutputCache(Profile = "default")]
        public async Task<IActionResult> Category(string category, int page = 0)
        {
            var result = await _blogPostsService.GetByCategoryAsync(category);

            return this.View("~/Views/Blog/Index.cshtml", result);
        }

        [Route(Constants.Routes.BlogAddComment)]
        [OutputCache(Profile = "default")]
        [HttpPost]
        public async Task<IActionResult> AddComment(string postId, BlogPostComment comment)
        {


            return this.View("~/Views/Blog/Index.cshtml");
        }
    }
}
