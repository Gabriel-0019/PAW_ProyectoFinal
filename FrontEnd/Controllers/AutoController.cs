using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class AutoController : Controller
    {

        private readonly AutoHelper autoHelper = new();
        private CategoriaHelper categoriaHelper = new();

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var auto = autoHelper.MostrarAutos();

                List<AutoViewModel> autoViewModel = new();

                foreach (var item in auto)
                {
                    item.CategoriaViewModel = categoriaHelper.MostrarCategoria(item.IdCategoria);
                    autoViewModel.Add(item);
                }
                return View(autoViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult MostrarAutos()
        {
            try
            {
                var auto = autoHelper.MostrarAutos();
                return View(auto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult MostrarAutos(string marca = "")
        {
            try
            {
                if (marca == null)
                {
                    var auto = autoHelper.MostrarAutos();
                    return View(auto);
                }
                else
                {
                    var autos = autoHelper.MostrarAutosMarca(marca);
                    return View(autos);
                }
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
                var auto = autoHelper.MostrarAuto(id);
                auto.CategoriaViewModel = categoriaHelper.MostrarCategoria(auto.IdCategoria);
                return View(auto);
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
                AutoViewModel auto = new();
                auto.categorias = categoriaHelper.MostrarCategorias();
                return View(auto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(AutoViewModel auto, IFormFile upload)
        {
            try
            {
                if (upload != null)
                {

                    auto.ImgURL = System.IO.Path.GetExtension(upload.FileName);
                    using var ms = new MemoryStream();
                    upload.CopyTo(ms);
                    auto.File = ms.ToArray();
                }
                var creado = autoHelper.CrearAuto(auto);
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
                var auto = autoHelper.MostrarAuto(id);
                return View(auto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(AutoViewModel auto)
        {
            try
            {
                var editado = autoHelper.EditarAuto(auto);
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
                var auto = autoHelper.MostrarAuto(id);
                return View(auto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Delete(AutoViewModel auto)
        {
            try
            {
                var borrado = autoHelper.BorrarAuto(auto);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult VistaMarcaAuto(string marca)
        {
            try
            {
                var autos = autoHelper.MostrarAutosMarca(marca);
                return RedirectToAction("MostrarAutos", new { autosl = autos });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
