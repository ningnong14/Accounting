using Accounting.Interfaces;
using Accounting.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Principal;

namespace Accounting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}