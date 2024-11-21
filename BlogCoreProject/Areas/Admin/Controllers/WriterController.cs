using BlogCoreProject.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography;

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

        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
            var jsonWriters = JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
        }

        public IActionResult Delete(int writerid)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == writerid);
            if (findWriter == null)
            {
                return Json(new { success = false, message = "Yazar bulunamadı." });
            }

            writers.Remove(findWriter);
            return Json(new { success = true, message = "Yazar başarıyla silindi." });
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
