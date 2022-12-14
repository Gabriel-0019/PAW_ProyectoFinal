using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private IRolDAL rolDAL;

        public RolController()
        {
            rolDAL = new RolDALImpl(new rabdContext());
        }

        private RolModel ConvertirRol(Rol rol)
        {
            try
            {

                if (rol != null)
                {

                    return new RolModel
                    {
                        IdRol = rol.IdRol,
                        NombreRol = rol.NombreRol,
                    };
                }
                else
                    return new RolModel();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Rol ConvertirRolModel(RolModel rol)
        {
            try
            {

                if (rol != null)
                {

                    return new Rol
                    {
                        IdRol = rol.IdRol,
                        NombreRol = rol.NombreRol,
                    };
                }
                else
                    return new Rol();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("MostrarRoles")]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<Rol> listaRoles;
                listaRoles = rolDAL.GetAll();

                List<RolModel> listaRolModel = new();
                foreach (var item in listaRoles)
                {
                    listaRolModel.Add(ConvertirRol(item));
                }

                return new JsonResult(listaRolModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("MostrarRol")]
        public JsonResult Get(int id)
        {
            try
            {
                Rol rol;
                rol = rolDAL.Get(id);

                return new JsonResult(ConvertirRol(rol));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("InsertarRol")]
        public bool Post([FromBody] RolModel rol)
        {
            try
            {
                return rolDAL.Add(ConvertirRolModel(rol)); ;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [Route("ActualizarRol")]
        public bool Put([FromBody] RolModel rol)
        {
            try
            {
                return rolDAL.Update(ConvertirRolModel(rol));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("EliminarRol")]
        public bool Delete(int id)
        {
            try
            {
                Rol rol = new Rol { IdRol = id };
                return rolDAL.Remove(rol);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
