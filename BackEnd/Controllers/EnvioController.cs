using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;


namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {

        private IEnvioDAL envioDAL;

        public EnvioController()
        {
            envioDAL = new EnvioDALImpl(new rabdContext());
        }

        private EnvioModel ConvertirEnvio(Envio envio)
        {
            try
            {

                if (envio != null)
                {

                    return new EnvioModel
                    {
                        DetalleDireccion = envio.DetalleDireccion,
                        FechaEnvio = envio.FechaEnvio,
                        IdConductor = envio.IdConductor,
                        IdEnvio = envio.IdEnvio,
                        PrecioBase = envio.PrecioBase
                    };
                }else
                    return new EnvioModel();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Envio ConvertirEnvioModel(EnvioModel envio)
        {
            try
            {
                if (envio != null)
                {

                    return new Envio
                    {
                        DetalleDireccion = envio.DetalleDireccion,
                        FechaEnvio = envio.FechaEnvio,
                        IdConductor = envio.IdConductor,
                        IdEnvio = envio.IdEnvio,
                        PrecioBase = envio.PrecioBase
                    };
                }
                else
                    return new Envio();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("MostrarEnvios")]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<Envio> listaEnvios;
                listaEnvios = envioDAL.GetAll();

                List<EnvioModel> listaEnviosModel = new();
                foreach (var item in listaEnvios)
                {
                    listaEnviosModel.Add(ConvertirEnvio(item));
                }

                return new JsonResult(listaEnviosModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("MostrarEnvio")]
        public JsonResult Get(int id)
        {
            try
            {
                Envio envio;
                envio = envioDAL.Get(id);

                return new JsonResult(ConvertirEnvio(envio));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("InsertarEnvio")]
        public bool Post([FromBody] EnvioModel envio)
        {
            try
            {
                return envioDAL.Add(ConvertirEnvioModel(envio));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [Route("ActualizarEnvio")]
        public bool Put([FromBody] EnvioModel envio)
        {
            try
            {
                return envioDAL.Update(ConvertirEnvioModel(envio));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("EliminarEnvio")]
        public bool Delete(int id)
        {
            try
            {
                Envio envio = new Envio { IdEnvio = id };
                return envioDAL.Remove(envio);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
