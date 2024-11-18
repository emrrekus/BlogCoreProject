using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BlogCoreProject.Controllers
{
	public class RegisterController : Controller
	{
		private readonly IWriterService _writerService;

		public RegisterController(IWriterService writerService)
		{
			_writerService = writerService;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Index(Writer writer)
		{
			WriterValidator validator = new WriterValidator();	
			ValidationResult reuslt = validator.Validate(writer);
			if (reuslt.IsValid)
			{
                _writerService.TInsert(writer);
                return RedirectToAction("Index", "Blog");

            }
			else
			{
				foreach(var item in reuslt.Errors)
				{

					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			
			return View();
			
		}
	}
}
