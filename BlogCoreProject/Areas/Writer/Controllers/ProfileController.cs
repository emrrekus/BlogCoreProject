using BlogCoreProject.Areas.Writer.Models;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogCoreProject.Areas.Writer.Controllers
{


	[Area("Writer")]
	[Route("Writer/[controller]/[action]")]

    public class ProfileController : Controller
	{
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
		{
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel viewModel = new UserEditViewModel();
			viewModel.Name = values.Name;
			viewModel.Surname = values.Surname;
			viewModel.Mail=values.Email;
			return View(viewModel);
		}

		[HttpPost]
        public  async Task<IActionResult> Index(UserEditViewModel user)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            values.Name = user.Name;
			values.Surname=user.Surname;
			values.Email=user.Mail;

            var result = await _userManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
