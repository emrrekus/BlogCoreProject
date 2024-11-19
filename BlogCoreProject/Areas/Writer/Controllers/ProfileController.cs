using BlogCoreProject.Areas.Writer.Models;
using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogCoreProject.Areas.Writer.Controllers
{

	[AllowAnonymous]
	[Area("Writer")]
	[Route("Writer/[controller]/[action]")]
	public class ProfileController : Controller
	{
		private readonly IWriterService _writerService;

		public ProfileController(IWriterService writerService)
		{
			_writerService = writerService;
		}

		public IActionResult Index()
		{
			var values = _writerService.TGetById(3);
			UserEditViewModel viewModel = new UserEditViewModel();
			viewModel.Name = values.Name;
			viewModel.Surname = values.Surname;
			viewModel.Mail=values.Mail;
			return View(viewModel);
		}

		[HttpPost]
        public IActionResult Index(UserEditViewModel user)
        {
            var values = _writerService.TGetById(3);

			values.Name = user.Name;
			values.Surname=user.Surname;
			values.Mail=user.Mail;

			_writerService.TUpdate(values);
            return RedirectToAction("Index","Default");
        }
    }
}
