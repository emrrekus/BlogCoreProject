using Microsoft.AspNetCore.Mvc;

namespace BlogCoreProject.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public PartialViewResult HeaderPartial()
		{
			return PartialView();
		}
		public PartialViewResult HeadPartial()
		{
			return PartialView();
		}
	}
}
