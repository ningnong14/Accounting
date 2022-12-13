using Accounting.Interfaces;
using Accounting.Models;
using Accounting.Models.Model;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
