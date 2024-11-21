using BlogCoreProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> categories = new List<CategoryClass>();

            categories.Add(new CategoryClass {
                CategoryName="Teknoloji",
                CategoryCount=10
                
            });
            categories.Add(new CategoryClass
            {
                CategoryName = "Spor",
                CategoryCount = 20

            });
            categories.Add(new CategoryClass
            {
                CategoryName = "Yazılım",
                CategoryCount = 15

            });
            categories.Add(new CategoryClass
            {
                CategoryName = "Tekstil",
                CategoryCount = 5

            });
            categories.Add(new CategoryClass
            {
                CategoryName = "Arge",
                CategoryCount = 30


            });
            categories.Add(new CategoryClass
            {
                CategoryName = "Donanım",
                CategoryCount = 20

            });

            return Json(new {jsonlist = categories});
        }
    }
}
