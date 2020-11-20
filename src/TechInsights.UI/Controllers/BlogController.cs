using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using TechInsights.Application.Services.Blog;
using TechInsights.Domain.Models;
using TechInsights.UI.ViewModels;

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

            var viewModel = new BlogViewModel()
            {
                BlogPosts = result
            };

            return View(viewModel);
        }

        [Route(Constants.Routes.BlogPost)]
        [OutputCache(Profile = "default")]
        public async Task<IActionResult> BlogPost(string slug)
        {
            var result = await _blogPostsService.GetBySlugAsync(slug);

            var viewModel = new BlogPostViewModel()
            {
                BlogPost = result,
                BlogPostComments = new BlogPostCommentsViewModel()
                {
                    Comments = result.Comments,
                    BlogPostId = result.Id,
                    CommentForm = new BlogPostComment()
                    {
                        BlogPostId = result.Id
                    }
                }
            };

            return viewModel?.BlogPost == null ? this.NotFound() : (IActionResult)this.View(viewModel);
        }

        [Route(Constants.Routes.BlogPostByCategory)]
        [OutputCache(Profile = "default")]
        public async Task<IActionResult> Category(string category, int page = 0)
        {
            var result = await _blogPostsService.GetByCategoryAsync(category);

            return this.View("~/Views/Blog/Index.cshtml", result);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddComment(BlogPostComment comment)
        {
            if (comment != null && ModelState.IsValid)
            {
                var result = await _blogPostsService.AddComment(comment);

                Thread.Sleep(Constants.Timers.Spinner);

                if (result)
                {
                    return PartialView("_CommentsForm");
                }
            }

            return null;
        }
    }
}
