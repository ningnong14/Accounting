using Accounting.Interfaces;
using Accounting.Models.Model;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Controllers
{
    public class LoginController : Controller
    {
        public LoginController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
