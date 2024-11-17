using Microsoft.AspNetCore.Mvc;

namespace BlogCoreProject.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
