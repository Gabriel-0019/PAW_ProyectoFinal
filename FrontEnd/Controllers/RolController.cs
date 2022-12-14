using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class RolController : Controller
    {
        private readonly RolHelper rolHelper = new();
        public IActionResult Index()
        {
            try
            {
                var roles = rolHelper.MostrarRoles();
                return View(roles);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            try
            {
                var rol = rolHelper.MostrarRol(id);
                return View(rol);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(RolViewModel rol)
        {
            try
            {
                var creado = rolHelper.CrearRol(rol);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var rol = rolHelper.MostrarRol(id);
                return View(rol);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(RolViewModel rol)
        {
            try
            {
                var editado = rolHelper.ActualizarRol(rol);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var rol = rolHelper.MostrarRol(id);
                return View(rol);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Delete(RolViewModel rol)
        {
            try
            {
                var eliminado = rolHelper.EliminarRol(rol);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
