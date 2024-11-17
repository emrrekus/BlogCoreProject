using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogCoreProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IArticleService _categoryService;

        public CategoryController(IArticleService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _categoryService.TGetAll();
            return View(values);
        }
    }
}
