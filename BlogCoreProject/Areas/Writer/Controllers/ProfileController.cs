using BlogCoreProject.Areas.Writer.Models;
using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogCoreProject.Areas.Writer.Controllers
{


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
			var value = User.Identity.Name;
			var userId= _writerService.TGetAll().FirstOrDefault(x=> x.Mail== value);
			var values = _writerService.TGetById(userId.WriterId);
			UserEditViewModel viewModel = new UserEditViewModel();
			viewModel.Name = values.Name;
			viewModel.Surname = values.Surname;
			viewModel.Mail=values.Mail;
			return View(viewModel);
		}

		[HttpPost]
        public IActionResult Index(UserEditViewModel user)
        {
            var value = User.Identity.Name;
            var userId = _writerService.TGetAll().FirstOrDefault(x => x.Mail == value);
            var values = _writerService.TGetById(userId.WriterId);

			values.Name = user.Name;
			values.Surname=user.Surname;
			values.Mail=user.Mail;

			_writerService.TUpdate(values);
            return RedirectToAction("Index","Default");
        }
    }
}
