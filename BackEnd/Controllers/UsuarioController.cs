using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;


namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioDAL usuarioDAL;

        public UsuarioController()
        {
            usuarioDAL = new UsuarioDALImpl(new rabdContext());
        }

        private static UsuarioModel ConvertirUsuario(Usuario usuario)
        {
            try
            {

                if (usuario != null)
                {

                    return new UsuarioModel
                    {
                        Apellido = usuario.Apellido,
                        Cedula = usuario.Cedula,
                        Contrasena = usuario.Contrasena,
                        Correo = usuario.Correo,
                        Cvv = usuario.Cvv,
                        FechaExpiracion = usuario.FechaExpiracion,
                        IdRol = usuario.IdRol,
                        IdUsuario = usuario.IdUsuario,
                        Nombre = usuario.Nombre,
                        NombreTitular = usuario.NombreTitular,
                        NumeroTarjeta = usuario.NumeroTarjeta,
                    };
                }else 
                    return new UsuarioModel();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static Usuario ConvertirUsuarioModel(UsuarioModel usuario)
        {
            try
            {
                if (usuario != null)
                {

                    return new Usuario
                    {
                        Apellido = usuario.Apellido,
                        Cedula = usuario.Cedula,
                        Contrasena = usuario.Contrasena,
                        Correo = usuario.Correo,
                        Cvv = usuario.Cvv,
                        FechaExpiracion = usuario.FechaExpiracion,
                        IdRol = usuario.IdRol,
                        IdUsuario = usuario.IdUsuario,
                        Nombre = usuario.Nombre,
                        NombreTitular = usuario.NombreTitular,
                        NumeroTarjeta = usuario.NumeroTarjeta,
                    };
                }
                else
                    return new Usuario();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("MostrarUsuarios")]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<Usuario> listaUsuarios;
                listaUsuarios = usuarioDAL.GetAll();

                List<UsuarioModel> listaUsuariosModel = new();
                foreach (var item in listaUsuarios)
                {
                    listaUsuariosModel.Add(ConvertirUsuario(item));
                }

                return new JsonResult(listaUsuariosModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("MostrarUsuario")]
        public JsonResult Get(int id)
        {
            try
            {
                Usuario usuario;
                usuario = usuarioDAL.Get(id);

                return new JsonResult(usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("InsertarUsuario")]
        public bool Post([FromBody] UsuarioModel usuario)
        {
            try
            {
                return usuarioDAL.Add(ConvertirUsuarioModel(usuario));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [Route("ActualizarUsuario")]
        public bool Put([FromBody] UsuarioModel usuario)
        {
            try
            {
                return usuarioDAL.Update(ConvertirUsuarioModel(usuario));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("EliminarUsuario")]
        public bool Delete(int id)
        {
            try
            {
                Usuario usuario = new() { IdUsuario = id };
                return usuarioDAL.Remove(usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("IniciarSesion")]
        public JsonResult IniciarSesion(string correo, string contrasena)
        {
            try
            {
                return new JsonResult(usuarioDAL.IniciarSesion(correo, contrasena));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("CambiarContrasena")]
        public string CambiarContrasena(string correo, string contrasena)
        {

            try
            {
                if (usuarioDAL.VerificarUsuario(correo))
                    return usuarioDAL.CambiarContrasena(correo, contrasena);
                else
                    return "Correo inválido";
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
