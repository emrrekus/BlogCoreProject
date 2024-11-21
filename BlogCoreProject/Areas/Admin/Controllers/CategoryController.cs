using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using X.PagedList.Extensions;

namespace BlogCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]

    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult CategoryList(int page = 1)
        {

            return View(_categoryService.TGetAll().ToPagedList(page, 5));
        }


        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            category.Status = true;
            _categoryService.TInsert(category);
            return RedirectToAction("CategoryList");
        }


        [Route("CategoryStatusChange/{id}")]
        public IActionResult CategoryStatusChange(int id)
        {
            var value = _categoryService.TGetById(id);
            value.Status = !value.Status;
            _categoryService.TUpdate(value);
            return RedirectToAction("CategoryList");
        }

      
        public IActionResult Test()
        {
            return RedirectToAction("CategoryList");
        }

    }
}
