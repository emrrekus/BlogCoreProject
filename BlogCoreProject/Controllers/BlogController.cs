using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogCoreProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;

		public BlogController(IArticleService articleService)
		{
			_articleService = articleService;
		}

		public IActionResult Index()
        {
            
            return View(_articleService.GetBlogListWithCategory());
        }

        public IActionResult BlogDetails(int id)
        {
            var values = _articleService.TGetById(id);
            
            return View(values);
        }
    }
}
