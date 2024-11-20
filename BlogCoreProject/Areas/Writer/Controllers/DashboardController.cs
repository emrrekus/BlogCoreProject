using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogCoreProject.Areas.Writer.Controllers
{

    [Area("Writer")]
	[Route("Writer/[controller]/[action]")]
   
	public class DashboardController : Controller
    {
        
        public IActionResult Index()
        {
            Context context = new Context();

            ViewBag.v1=context.Categories.Count();
            ViewBag.v2=context.Writers.Count(); 
            ViewBag.v3=context.Articles.Where(x=> x.WriterId == 3).Count();
            ViewBag.v4=context.Comments.Count();

            return View();
        }
    }
}
