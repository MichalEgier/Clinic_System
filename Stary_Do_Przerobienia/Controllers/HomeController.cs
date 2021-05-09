using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ViewResult Index() => View();

        //[Authorize(Roles = "Admin")]
        [Route("Start")]
        [HttpGet]
        public IActionResult Start()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize(Roles = "Admin")]
        [Route("admin")]
        [HttpGet]
        public IActionResult GoAdminMode()
        {
            return RedirectToAction("Start", "AdminController");
        }

        [AllowAnonymous]
        [Route("user")]
        [HttpGet]
        public IActionResult GoShopping()
        {
            return RedirectToAction("Start", "CasualUserController");
        }
    }
}
