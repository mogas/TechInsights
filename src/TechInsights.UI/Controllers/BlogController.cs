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
        public async Task<IActionResult> Index()
        {
            var result = await _blogPostsService.GetAllAsync();
            return View(result);
        }

        [HttpGet("{postId}/{name?}")]
        public async Task<IActionResult> BlogPost(int postId)
        {
            var result = await _blogPostsService.GetById(postId);

            return View(result);
        }
    }
}
