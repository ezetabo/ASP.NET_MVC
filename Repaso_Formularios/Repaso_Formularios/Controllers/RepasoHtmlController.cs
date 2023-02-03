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
        
        public ActionResult TablaJs()
        {
            return View();
        }

        public JsonResult ListarPersonas()
        {
            List<Persona> listaPersonas = new List<Persona>() 
            {
                new Persona {IdPersona = 1,Nombre = "Juan",Apellido="Gonzalez"},
                new Persona {IdPersona = 2,Nombre = "Luis",Apellido="Perez"},
                new Persona {IdPersona = 3,Nombre = "Maria",Apellido="Sanchez"}
            };

          return Json(listaPersonas);
        }
    }
}