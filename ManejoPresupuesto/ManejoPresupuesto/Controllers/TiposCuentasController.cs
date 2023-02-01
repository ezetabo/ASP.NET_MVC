using Dapper;
using ManejoPresupuesto.Models;
using ManejoPresupuesto.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Controllers
{
    public class TiposCuentasController : Controller
    {
        private readonly IRepositorioTipoCuentas repositorioTipoCuentas;
        private readonly IServicioUsuarios servicioUsuarios;

        public TiposCuentasController(IRepositorioTipoCuentas repositorioTipoCuentas,
            IServicioUsuarios servicioUsuarios)
        {
            this.repositorioTipoCuentas = repositorioTipoCuentas;
            this.servicioUsuarios = servicioUsuarios;
        }

        public async Task<IActionResult> Index()
        {
            var usuarioId = servicioUsuarios.ObtnerUsurioId();
            var tiposCuentas = await repositorioTipoCuentas.Obtener(usuarioId);
            return View(tiposCuentas);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(TipoCuenta tipo)
        {
            if (!ModelState.IsValid)
            {
                return View(tipo);
            }
            tipo.UsuarioId = servicioUsuarios.ObtnerUsurioId();

            if (await repositorioTipoCuentas.Existe(tipo.Nombre, tipo.UsuarioId))
            {
                ModelState.AddModelError(nameof(tipo.Nombre), $"El nombre {tipo.Nombre} ya existe.");
                return View(tipo);
            }

            await repositorioTipoCuentas.Crear(tipo);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var usuarioId = servicioUsuarios.ObtnerUsurioId();
            var tipoCuenta = await repositorioTipoCuentas.ObternerPorId(id, usuarioId);
            if (tipoCuenta is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }
            return View(tipoCuenta);
        }

        [HttpGet]
        public async Task<IActionResult> Borrar(int id)
        {
            var usuarioId = servicioUsuarios.ObtnerUsurioId();
            var tipoCuenta = await repositorioTipoCuentas.ObternerPorId(id, usuarioId);
            if (tipoCuenta is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }
            return View(tipoCuenta);
        }

        [HttpPost]
        public async Task<IActionResult> BorrarTipoCuenta(int id)
        {
            var usuarioId = servicioUsuarios.ObtnerUsurioId();
            var tipoCuenta = await repositorioTipoCuentas.ObternerPorId(id, usuarioId);
            if (tipoCuenta is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }
            await repositorioTipoCuentas.Borrar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Editar(TipoCuenta tipoCuenta)
        {
            var usuarioId = servicioUsuarios.ObtnerUsurioId();
            var tipoCuentaExiste = await repositorioTipoCuentas.ObternerPorId(tipoCuenta.Id, usuarioId);
            if (tipoCuentaExiste is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }
            await repositorioTipoCuentas.Actualizar(tipoCuenta);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> VerificarExisteTipoCuenta(string nombre)
        {
            var usuarioId = servicioUsuarios.ObtnerUsurioId();

            if (await repositorioTipoCuentas.Existe(nombre, usuarioId))
            {
                return Json($"El nombre {nombre} ya existe.");
            }

            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> Ordenar([FromBody] int[] ids)
        {
            var usuarioId = servicioUsuarios.ObtnerUsurioId();
            var tiposCuentas = await repositorioTipoCuentas.Obtener(usuarioId);
            var idsTiposCuentas = tiposCuentas.Select(x => x.Id);
            var idsTiposCuentasNoPertenecenAlUsuario = ids.Except(idsTiposCuentas).ToList();

            if (idsTiposCuentasNoPertenecenAlUsuario.Count > 0)
            {
                return Forbid();
            }

            var tiposCuentasOrdenados = ids.Select((valor, indice) =>
                                                    new TipoCuenta() { Id = valor, Orden = indice + 1 }).AsEnumerable();

            await repositorioTipoCuentas.Ordenar(tiposCuentasOrdenados);

            return Ok();
        }

        public IActionResult Fecha()
        {
            return View();
        }
    }
}
