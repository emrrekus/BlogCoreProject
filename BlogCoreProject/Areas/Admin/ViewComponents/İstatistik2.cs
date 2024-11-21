using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogCoreProject.Areas.Admin.ViewComponents
{
    public class İstatistik2 : ViewComponent
    {

        private readonly Context context;

        public İstatistik2(Context _context)
        {
            context = _context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = context.Articles.OrderBy(x => x.ArticleId).Select(x => x.Title).Take(1).FirstOrDefault();
            ViewBag.v2 = context.Comments.Count();
            ViewBag.v3 = context.Categories.Count();
            return View();
        }
    }
}
