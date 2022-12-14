using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;


namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservacionController : ControllerBase
    {
        private IObservacionesDAL observacionesDAL;

        public ObservacionController()
        {
            observacionesDAL = new ObservacionesDALImpl(new rabdContext());
        }

        private static ObservacionesModel ConvertirObservacion(Observaciones observaciones)
        {
            try
            {

                if (observaciones != null)
                {

                    return new ObservacionesModel
                    {
                        Descripcion = observaciones.Descripcion,
                        Estado = observaciones.Estado,
                        IdObservacion = observaciones.IdObservacion,
                    };
                }else
                    return new ObservacionesModel();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static Observaciones ConvertirObservacionModel(ObservacionesModel observaciones)
        {
            try
            {
                if (observaciones != null)
                {

                    return new Observaciones
                    {
                        Descripcion = observaciones.Descripcion,
                        Estado = observaciones.Estado,
                        IdObservacion = observaciones.IdObservacion,
                    };
                }
                else
                    return new Observaciones();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("MostrarObservaciones")]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<Observaciones> listaObservaciones;
                listaObservaciones = observacionesDAL.GetAll();

                List<ObservacionesModel> listaObservacionesModel = new();
                foreach (var item in listaObservaciones)
                {
                    listaObservacionesModel.Add(ConvertirObservacion(item));
                }

                return new JsonResult(listaObservacionesModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("MostrarObservacion")]
        public JsonResult Get(int id)
        {
            try
            {
                Observaciones observaciones;
                observaciones = observacionesDAL.Get(id);

                return new JsonResult(ConvertirObservacion(observaciones));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("InsertarObservacion")]
        public bool Post([FromBody] ObservacionesModel observaciones)
        {
            try
            {
                return observacionesDAL.Add(ConvertirObservacionModel(observaciones));
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<ObservacionController>/5
        [HttpPut]
        [Route("ActualizarObservacion")]
        public bool Put([FromBody] ObservacionesModel observaciones)
        {
            try
            {
                return observacionesDAL.Update(ConvertirObservacionModel(observaciones));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("EliminarObservacion")]
        public bool Delete(int id)
        {
            try
            {
                Observaciones observaciones = new Observaciones { IdObservacion = id };
                return observacionesDAL.Remove(observaciones);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
