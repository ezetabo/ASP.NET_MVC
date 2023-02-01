using Microsoft.AspNetCore.Mvc;

namespace Centro_Educativo.Controllers
{
    public class SeccionController : Controller
    {
        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult NoEncontrado()
        {
            return View();
        }
    }
}
