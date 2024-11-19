﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogCoreProject.Areas.Writer.Controllers
{
	[AllowAnonymous]
	[Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}