using Accounting.Interfaces;
using Accounting.Models.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Packaging.Signing;
using OfficeOpenXml;
using System.Data;
using System.IO;

namespace Accounting.Controllers
{
    public class SerachController : Controller
    {
        public SerachController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
