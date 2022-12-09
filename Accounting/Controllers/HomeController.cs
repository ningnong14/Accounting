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
        private readonly IDebitCodeService _addDetailService;

        public HomeController(ILogger<HomeController> logger, IDebitCodeService addDetailService)
        {
            _logger = logger;
            _addDetailService = addDetailService;
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}