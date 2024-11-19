using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogCoreProject.Controllers
{

    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IWriterService _writerService;

		public LoginController(IWriterService writerService)
		{
			_writerService = writerService;
		}

		public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Writer writer)
        {
            var value= _writerService.TGetAll().FirstOrDefault(x=> x.Mail==writer.Mail && x.WriterPassword==writer.WriterPassword);

            if(value!=null)
            {
                var claims = new List<Claim>
               {
                   new Claim(ClaimTypes.Name,writer.Mail),
               };
                var userIdentity= new ClaimsIdentity(claims,"a");
                ClaimsPrincipal principal= new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Dashboard", new { area = "Writer" });
            }
            else
            {
				return View();
			}

            
        }
    }
}
