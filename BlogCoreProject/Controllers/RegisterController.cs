using BlogCoreProject.Models;
using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogCoreProject.Controllers
{
	[AllowAnonymous]
	public class RegisterController : Controller
	{
		

		private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(UserRegisterViewModel writer)
		{
			
			if(ModelState.IsValid)
			{
				AppUser user = new AppUser()
				{
					Email = writer.Mail,
					UserName = writer.Username,
					Name = writer.Name,
					Surname = writer.Surname,
					ImageUrl="abc"

				};
				var result= await _userManager.CreateAsync(user,writer.Password);

				if(result.Succeeded)
				{
					return RedirectToAction("Index","Login");
				}
				else
				{
					foreach(var item in result.Errors)
					{
						ModelState.AddModelError("",item.Description);
					}
				}
			}
			return View(writer);
		}

	}
}
