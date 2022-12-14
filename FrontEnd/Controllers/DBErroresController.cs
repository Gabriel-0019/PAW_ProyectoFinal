using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace FrontEnd.Controllers
{
    public class DBErroresController : Controller
    {
        private readonly DBErroresHelper dberroreshelper = new();
        public IActionResult Index()
        {
            try
            {
                var dberrores = dberroreshelper.MostrarErrores();
                return View(dberrores);
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
                var error = dberroreshelper.MostrarError(id);
                return View(error);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
