﻿using Microsoft.AspNetCore.Mvc;

namespace BlogCoreProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}