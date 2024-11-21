using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogCoreProject.Areas.Admin.ViewComponents
{
    public class İstatistik4 : ViewComponent
    {
        private readonly Context context;

        public İstatistik4(Context _context)
        {
            context = _context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = context.Admins.Where(x=> x.AdminId==2).Select(x => x.Name).FirstOrDefault();
            ViewBag.v2 = context.Admins.Where(x => x.AdminId == 2).Select(x => x.ImageUrl).FirstOrDefault();
            ViewBag.v3 = context.Admins.Where(x => x.AdminId == 2).Select(x => x.ShortDescription).FirstOrDefault();
            return View();
        }

    }
}
