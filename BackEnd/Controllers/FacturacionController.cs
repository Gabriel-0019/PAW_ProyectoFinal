using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturacionController : ControllerBase
    {
        private IFacturacionDAL facturacionDAL;

        public FacturacionController()
        {
            facturacionDAL = new FacturacionDALImpl(new rabdContext());
        }

        private FacturacionModel ConvertirFacturacion(Facturacion facturacion)
        {
            try
            {

                if (facturacion != null)
                {

                    return new FacturacionModel
                    {
                        FechaFactura = facturacion.FechaFactura,
                        FechaUltActu = facturacion.FechaUltActu,
                        IdAlquiler = facturacion.IdAlquiler,
                        IdEnvio = facturacion.IdEnvio,
                        IdFactura = facturacion.IdFactura,
                        MontoAlquiler = facturacion.MontoAlquiler,
                        MontoMulta = facturacion.MontoMulta,
                        PrimerPago = facturacion.PrimerPago,
                        SegundoPago = facturacion.SegundoPago,
                    };
                }
                else
                    return new FacturacionModel();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("MostrarFacturas")]
        public JsonResult Get(int IdUsuario)
        {
            try
            {
                var misFacturas = facturacionDAL.MostrarFacturas(IdUsuario);
                return new JsonResult(misFacturas);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public bool Post([FromBody] Facturacion facturacion)
        {
            try
            {
                return facturacionDAL.Add(facturacion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<FacturacionController>/5
        [HttpPut]
        public bool Put([FromBody] Facturacion facturacion)
        {
            try
            {
                return facturacionDAL.Update(facturacion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                Facturacion facturacion = new Facturacion { IdFactura = id };
                return facturacionDAL.Remove(facturacion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet, Route("MisFacturas")]
        public JsonResult MisFacturas(int IdUsuario)
        {
            try
            {
                var misFacturas = facturacionDAL.GetMisFacturas(IdUsuario);
                return new JsonResult(misFacturas);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet, Route("FacturasPendientesAdmin")]
        public JsonResult FacturasPendientesAdmin(int IdUsuario)
        {
            try
            {
                var misFacturas = facturacionDAL.FacturasPendientesAdmin(IdUsuario);
                return new JsonResult(misFacturas);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet, Route("MiDetalleFactura")]
        public JsonResult MiDetalleFactura(int IdFactura,int IdUsuario)
        {
            try
            {
                var miDetalleFactura = facturacionDAL.GetMiDetalleFacturas(IdFactura, IdUsuario);
                return new JsonResult(miDetalleFactura);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
