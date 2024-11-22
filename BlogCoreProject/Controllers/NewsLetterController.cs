using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogCoreProject.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        private readonly INewsLetterService _newsLetterService;

        public NewsLetterController(INewsLetterService newsLetterService)
        {
            _newsLetterService = newsLetterService;
        }

        public PartialViewResult SubsMail()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult SubsMail(NewsLetter newsLetter)
        {
            if (string.IsNullOrEmpty(newsLetter.Mail))
            {
                return Json(new { success = false, message = "E-posta adresi boş olamaz." });
            }

            newsLetter.MailStatus = true;
            _newsLetterService.TInsert(newsLetter);

            return Json(new { success = true, message = "Başarıyla abone oldunuz!" });
        }
    }



}

