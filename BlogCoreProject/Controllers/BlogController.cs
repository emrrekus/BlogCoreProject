using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogCoreProject.Controllers
{
    [AllowAnonymous]
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

        public IActionResult BlogListByWriter()
        {
            var values = _articleService.GetListWithCategoryWithoutWriter(3).Where(x => x.Status == true).ToList();

            return View(values);
        }

        public IActionResult BlogAdd()
        {
            ViewBag.Categories = _articleService.GetBlogListWithCategory();
            ViewBag.Writers = _articleService.GetBlogListWithWriter();
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Article article)
        {

            _articleService.TInsert(article);
            return RedirectToAction("Index", "Default", new { area = "Writer" });
        }

        public IActionResult DeleteBlog(int id)
        {
            var value= _articleService.TGetById(id);
            value.Status=false;
            _articleService.TUpdate(value);
            return RedirectToAction("BlogListByWriter","Blog");
        }

        public IActionResult EditBlog(int id)
        {

            var article = _articleService.TGetById(id);
            ViewBag.Categories = _articleService.GetBlogListWithCategory().Select(category => new SelectListItem
            {
                Text=category.Category.CategoryName,
                Value=category.CategoryId.ToString(),
                Selected=category.CategoryId== article.CategoryId
            }).ToList();
            ViewBag.Writers = _articleService.GetBlogListWithWriter().Select(writer => new SelectListItem
            {
                Text = writer.Writer.Name,
                Value = writer.WriterId.ToString(),
                Selected = writer.WriterId == article.WriterId
            }).ToList();
            return View(article);
        }

        [HttpPost]
        public IActionResult EditBlog(Article article)
        {
            _articleService.TUpdate(article);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
