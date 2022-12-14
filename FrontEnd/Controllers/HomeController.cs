using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AutoHelper autoHelper = new();
        private CategoriaHelper categoriaHelper = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            try
            {
                var autos = autoHelper.MostrarAutos();
                
                List<AutoViewModel> autosCarouselTemp = new();
                for (int i = 0; i < 5; i++)
                {
                    autosCarouselTemp.Add(autos[i]);
                }

                List<AutoViewModel> autosCarousel = new();
                foreach (var item in autosCarouselTemp)
                {
                    item.CategoriaViewModel = categoriaHelper.MostrarCategoria(item.IdCategoria);
                    autosCarousel.Add(item);
                }

                @ViewBag.AutosCarousel = autosCarousel;
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}