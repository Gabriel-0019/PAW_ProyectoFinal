using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Text.Json;


namespace FrontEnd.Controllers
{
    public class AlquilerController : Controller
    {

        private readonly AlquilerHelper alquilerHelper = new();
        public IActionResult Index()
        {
            try
            {
                var alquileres = alquilerHelper.MostrarAlquileres();
                return View(alquileres);
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
                var alquiler = alquilerHelper.MostrarAlquiler(id);
                return View(alquiler);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string autoID)
        {
            try
            {
                AlquilerEnvioViewModel model = new AlquilerEnvioViewModel();
                Helpers.AutoHelper helper = new AutoHelper();
                model.auto = helper.MostrarAuto(int.Parse(autoID));
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        public ActionResult Create(AlquilerEnvioViewModel model)
        {
            try
            {
                //El IDUsuario ded model.alquiler.IDUsuario toma un valor <> 0 cuando se seleciona pagar otro monto
                AutoHelper helper = new AutoHelper();
                model.alquiler.IdUsuario = (int)HttpContext.Session.GetInt32("IdUsuario");
                model.auto = helper.MostrarAuto(model.auto.IdAuto);
                var creado = alquilerHelper.CrearAlquiler(model);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {

                throw new Exception("" + ex.Message);
            }
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var alquiler = alquilerHelper.MostrarAlquiler(id);
                return View(alquiler);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(AlquilerViewModel alquiler)
        {
            try
            {
                var editado = alquilerHelper.EditarAlquiler(alquiler);
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
                var borrado = alquilerHelper.MostrarAlquiler(id);
                return View(borrado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Delete(AlquilerViewModel alquiler)
        {
            try
            {
                var borrado = alquilerHelper.BorrarAlquiler(alquiler);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}