using Microsoft.AspNetCore.Mvc;
using Repaso_Formularios.Models;
using System.Diagnostics;

namespace Repaso_Formularios.Controllers
{
    public class RepasoHtmlController : Controller
    {
        private readonly ILogger<RepasoHtmlController> _logger;

        public RepasoHtmlController(ILogger<RepasoHtmlController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Tabla()
        {
            return View();
        }

        public ActionResult ComboBox()
        {
            return View();
        }
    }
}