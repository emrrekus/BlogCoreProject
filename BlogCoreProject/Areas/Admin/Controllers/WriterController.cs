using BlogCoreProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogCoreProject.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	[Route("Admin/[controller]/[action]")]
	public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public IActionResult GetWriterById(int wid)
        {
            var findWriter =  writers.FirstOrDefault(x => x.Id == wid);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }


        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id = 1,
                Name = "Ahmet",
            },
            new WriterClass
            {
                Id = 2,
                Name = "Mehmet",
            },
            new WriterClass
            {
                Id = 3,
                Name = "Cansu",
            },
            new WriterClass
            {
                Id = 4,
                Name = "Perver",
            },
              new WriterClass
            {
                Id = 5,
                Name = "Lütfü",
            }
        };
    }
}
