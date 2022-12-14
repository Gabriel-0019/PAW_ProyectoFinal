using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class EnvioController : Controller
    {
        private readonly EnvioHelper envioHelper = new();
        public IActionResult Index()
        {
            try
            {
                var envios = envioHelper.MostrarEnvios();
                return View(envios);
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
                var envio = envioHelper.MostrarEnvio(id);
                return View(envio);
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
        public ActionResult Create(EnvioViewModel envio)
        {
            try
            {
                var creado = envioHelper.CrearEnvio(envio);
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
                var envio = envioHelper.MostrarEnvio(id);
                return View(envio);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(EnvioViewModel envio)
        {
            try
            {
                var editado = envioHelper.EditarEnvio(envio);
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
                var envio = envioHelper.MostrarEnvio(id);
                return View(envio);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Delete(EnvioViewModel envio)
        {
            try
            {
                var borrado = envioHelper.BorrarEnvio(envio);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
