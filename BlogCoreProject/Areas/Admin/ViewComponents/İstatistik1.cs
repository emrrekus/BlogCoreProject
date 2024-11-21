using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogCoreProject.Areas.Admin.ViewComponents
{
    public class İstatistik1 : ViewComponent
    {
        private readonly Context context;

        public İstatistik1(Context _context)
        {
            context = _context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = context.Articles.Count();
            ViewBag.v2= context.Comments.Count();   
            ViewBag.v3= context.Categories.Count();
            return View();
        }

    }
}
