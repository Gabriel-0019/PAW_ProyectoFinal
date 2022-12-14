using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class FacturacionController : Controller
    {
        private FacturacionHelper facturacionHelper = new();
        private ObservacionHelper observacionHelper = new();

        public IActionResult MisFacturas()
        {
			try
			{
                int IdUsuario = (int)HttpContext.Session.GetInt32("IdUsuario");
                var misFacturas = facturacionHelper.MisFacturas(IdUsuario);

                return View(misFacturas);
			}
			catch (Exception)
			{
				throw;
			}
        }

        public ActionResult MostrarFacturas()
        {
            try
            {
                int IdUsuario = (int)HttpContext.Session.GetInt32("IdUsuario");
                var facturas = facturacionHelper.MostrarFacturas(IdUsuario);

                return View(facturas);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult FacturasPendientesAdmin()
        {
            try
            {
                int IdUsuario = (int)HttpContext.Session.GetInt32("IdUsuario"); 
                var misFacturas = facturacionHelper.FacturasPendientesAdmin(IdUsuario);

                return View(misFacturas);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Details(int id)
        {
			try
			{
                int IdUsuario = (int)HttpContext.Session.GetInt32("IdUsuario");
                var miFactura = facturacionHelper.MiDetalleFactura(id, IdUsuario);
                return View(miFactura);
			}
			catch (Exception)
			{
				throw;
			}
        }

        public ActionResult DetailsPendienteAdmin(int id)
        {
            try
            {
                int IdUsuario = (int)HttpContext.Session.GetInt32("IdUsuario");
                var miFactura = facturacionHelper.MiDetalleFactura(id, IdUsuario);
                DevolucionesViewModel devolucion = new();
                devolucion.IdFactura = miFactura.IdFactura;
                devolucion.observaciones = observacionHelper.MostrarObservaciones();
                ViewBag.devolucion = devolucion;
                return View(miFactura);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
