using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlquilerController : ControllerBase
    {
        private IAlquilerDAL alquilerDAL;

        public AlquilerController()
        {
            alquilerDAL = new AlquilerDALImpl(new rabdContext());
        }

        private static AlquilerModel ConvertirAlquiler(Alquiler alquiler)
        {
            try
            {

                if (alquiler != null)
                {

                    return new AlquilerModel
                    {
                        IdAlquiler = alquiler.IdAlquiler,
                        FechaAlquiler = alquiler.FechaAlquiler,
                        FechaDevolucion = alquiler.FechaDevolucion,
                        IdAuto = alquiler.IdAuto,
                        IdUsuario = alquiler.IdUsuario
                    };

                }

                else
                    return new AlquilerModel();
               
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static Alquiler ConvertirAlquilerModel(AlquilerModel alquiler)
        {
            try
            {
                if (alquiler != null)
                {

                    return new Alquiler
                    {
                        IdAlquiler = alquiler.IdAlquiler,
                        FechaAlquiler = alquiler.FechaAlquiler,
                        FechaDevolucion = alquiler.FechaDevolucion,
                        IdAuto = alquiler.IdAuto,
                        IdUsuario = alquiler.IdUsuario
                    };

                }

                else
                    return new Alquiler();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("MostrarAlquileres")]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<Alquiler> listaAlquileres;
                listaAlquileres = alquilerDAL.GetAll();

                List<AlquilerModel> listaAlquileresModel = new();
                foreach (var item in listaAlquileres)
                {
                    listaAlquileresModel.Add(ConvertirAlquiler(item));
                }

                return new JsonResult(listaAlquileresModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("MostrarAlquiler")]
        public JsonResult Get(int id)
        {
            try
            {
                Alquiler alquiler;
                alquiler = alquilerDAL.Get(id);

                return new JsonResult(ConvertirAlquiler(alquiler));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("InsertarAlquiler")]
        public bool Post([FromBody] string model)
        {
            try
            {
                AlquilerEnvio? alquilerEnvio = JsonSerializer.Deserialize<AlquilerEnvio>(model);
                alquilerDAL.EnviarCorreoFacturaAsync(alquilerEnvio).Wait();
                return alquilerDAL.AddAlquilerEnvio(alquilerEnvio);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [Route("ActualizarAlquiler")]
        public bool Put([FromBody] AlquilerModel alquiler)
        {
            try
            {
                return alquilerDAL.Update(ConvertirAlquilerModel(alquiler));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("EliminarAlquiler")]
        public bool Delete(int id)
        {
            try
            {
                Alquiler alquiler = new Alquiler { IdAlquiler = id };
                return alquilerDAL.Remove(alquiler);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
