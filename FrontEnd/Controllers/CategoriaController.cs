using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaHelper categoriaHelper = new();
        public IActionResult Index()
        {
            try
            {
                var categorias = categoriaHelper.MostrarCategorias();
                return View(categorias);
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
                var categoria = categoriaHelper.MostrarCategoria(id);
                return View(categoria);
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
        public ActionResult Create(CategoriaViewModel categoria)
        {
            try
            {
                var creado = categoriaHelper.CrearCategoria(categoria);
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
                var categoria = categoriaHelper.MostrarCategoria(id);
                return View(categoria);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CategoriaViewModel categoria)
        {
            try
            {
                var editado = categoriaHelper.EditarCategoria(categoria);
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
                var categoria = categoriaHelper.MostrarCategoria(id);
                return View(categoria);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Delete(CategoriaViewModel categoria)
        {
            try
            {
                var borrado = categoriaHelper.BorrarCategoria(categoria);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
