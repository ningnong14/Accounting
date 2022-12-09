using Microsoft.AspNetCore.Mvc;

namespace Accounting.Controllers
{
    public class RecordAccounting : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
