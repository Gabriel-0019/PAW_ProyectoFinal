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
    public class DBErroresController : ControllerBase
    {
        private IDBErroresDAL dBErroresDAL;

        public DBErroresController()
        {
            dBErroresDAL = new DBErroresDALImpl(new rabdContext());
        }

        private DBErroresModel ConvertirDBErrores(DBErrores dBErrores)
        {
            try
            {

                if (dBErroresDAL != null)
                {

                    return new DBErroresModel
                    {
                        ErrorDateTime = dBErrores.ErrorDateTime,
                        ErrorLinea = dBErrores.ErrorLinea,
                        ErrorMessage = dBErrores.ErrorMessage,
                        ErrorNumero = dBErrores.ErrorNumero,
                        ErrorProcedimiento = dBErrores.ErrorProcedimiento,
                        ErrorSeveridad = dBErrores.ErrorSeveridad,
                        ErrorStatus = dBErrores.ErrorStatus,
                        IdError = dBErrores.IdError,
                        IdUsuario = dBErrores.IdUsuario
                    };

                }else
                    return new DBErroresModel();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private DBErrores ConvertirDBErroresModel(DBErroresModel dBErrores)
        {
            try
            {
                if (dBErroresDAL != null)
                {

                    return new DBErrores
                    {
                        ErrorDateTime = dBErrores.ErrorDateTime,
                        ErrorLinea = dBErrores.ErrorLinea,
                        ErrorMessage = dBErrores.ErrorMessage,
                        ErrorNumero = dBErrores.ErrorNumero,
                        ErrorProcedimiento = dBErrores.ErrorProcedimiento,
                        ErrorSeveridad = dBErrores.ErrorSeveridad,
                        ErrorStatus = dBErrores.ErrorStatus,
                        IdError = dBErrores.IdError,
                        IdUsuario = dBErrores.IdUsuario
                    };

                }
                else
                    return new DBErrores();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("MostrarDBErrores")]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<DBErrores> listaDBErrores;
                listaDBErrores = dBErroresDAL.GetAll();

                List<DBErroresModel> listaDBErroresModel = new List<DBErroresModel>();
                foreach (var item in listaDBErrores)
                {
                    listaDBErroresModel.Add(ConvertirDBErrores(item));
                }

                return new JsonResult(listaDBErroresModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("MostrarDBError")]
        public JsonResult Get(int id)
        {
            try
            {
                DBErrores dBErrores;
                dBErrores = dBErroresDAL.Get(id);

                return new JsonResult(ConvertirDBErrores(dBErrores));
            }
            catch (Exception)
            {

                throw;
            }
        }

        //[HttpGet]
        //[Route("MostrarDBErrorPorMensaje")]
        //public JsonResult Get(string name)
        //{
        //    try
        //    {
        //        DBErrores dBErrores;
        //        dBErrores = dBErroresDAL.get(name);

        //        return new JsonResult(dBErrores);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
