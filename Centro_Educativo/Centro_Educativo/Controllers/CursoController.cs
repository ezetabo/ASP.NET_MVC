using Microsoft.AspNetCore.Mvc;

namespace Centro_Educativo.Controllers
{
    public class CursoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Mensaje()
        {
            return "Hola Mundo desde ASP.NET MVC";
        }

        public string Saludo(string nombre, string apellido)
        {
            return $"Hola como estas {nombre} {apellido}";
        }
    }
}
