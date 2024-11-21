using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

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


            string api = "15e163da093aea0dea0cb45dac03c476";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.v5 = document.Descendants("city").ElementAt(0).Attribute("name").Value;

            return View();
        }

    }
}
