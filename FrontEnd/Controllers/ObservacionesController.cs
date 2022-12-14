using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class ObservacionesController : Controller
    {
        private readonly ObservacionHelper observacionHelper = new();
        public IActionResult Index()
        {
            try
            {
                var observaciones = observacionHelper.MostrarObservaciones();
                return View(observaciones);
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
                var observacion = observacionHelper.MostrarObservacion(id);
                return View(observacion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(int IdFactura)
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
        public ActionResult Create(ObservacionesViewModel observaciones)
        {
            try
            {
                var creado = observacionHelper.CrearObservacion(observaciones);
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
                var observacion = observacionHelper.MostrarObservacion(id);
                return View(observacion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(ObservacionesViewModel observaciones)
        {
            try
            {
                var editado = observacionHelper.EditarObservacion(observaciones);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var observacion = observacionHelper.MostrarObservacion(id);
                return View(observacion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Delete(ObservacionesViewModel observacion)
        {
            try
            {
                var editado = observacionHelper.BorrarObservacion(observacion);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
