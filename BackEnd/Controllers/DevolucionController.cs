using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevolucionController : ControllerBase
    {
        private IDevolucionDAL devolucionDAL;

        public DevolucionController()
        {
            devolucionDAL = new DevolucionDALImpl(new rabdContext());
        }

        private DevolucionModel ConvertirDevolucion(Devolucion devolucion)
        {
            try
            {
                if (devolucion != null)
                {

                    return new DevolucionModel
                    {
                        FechaEntrega = devolucion.FechaEntrega,
                        IdFactura = devolucion.IdFactura,
                        IdObservacion = devolucion.IdFactura
                    };
                }else
                    return new DevolucionModel();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("MostrarDevoluciones")]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<Devolucion> listaDevoluciones;
                listaDevoluciones = devolucionDAL.GetAll();

                List<DevolucionModel> listaDevolucionesModel = new();
                foreach (var item in listaDevoluciones)
                {
                    listaDevolucionesModel.Add(ConvertirDevolucion(item));
                }

                return new JsonResult(listaDevolucionesModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("MostrarDevolucion")]
        public JsonResult Get(int id)
        {
            try
            {
                Devolucion devolucion;
                devolucion = devolucionDAL.Get(id);

                return new JsonResult(ConvertirDevolucion(devolucion));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("InsertarDevolucion")]
        public bool Post([FromBody] DevolucionModel devolucion)
        {
            try
            {
                return devolucionDAL.CrearDevolucion(devolucion.IdFactura, devolucion.IdObservacion, devolucion.IdUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [Route("ActualizarDevolucion")]
        public bool Put([FromBody] Devolucion devolucion)
        {
            try
            {
                return devolucionDAL.Update(devolucion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("EliminarDevolucion")]
        public void Delete(int id)
        {
            //try
            //{
            //    Devolucion devolucion = new Devolucion {  = id };
            //    return rolDAL.Remove(rol);
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }
    }
}
