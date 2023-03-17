using Centro_Educativo.Models;
using Centro_Educativo.servicios;
using Microsoft.AspNetCore.Mvc;

namespace Centro_Educativo.Controllers
{
    public class CursoController : Controller
    {
        private readonly IRepositorioCurso repositorioCurso;

        public CursoController(IRepositorioCurso repositorioCurso) 
        {
            this.repositorioCurso = repositorioCurso;
        }

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

        public JsonResult ListarCursos()
        {
           var cursos =  repositorioCurso.ObtenerPorEstado(1);
            return Json(cursos);
        }

    }
}
