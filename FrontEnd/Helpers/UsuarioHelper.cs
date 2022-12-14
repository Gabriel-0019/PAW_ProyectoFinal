using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class UsuarioHelper
    {
        public List<UsuarioViewModel> MostrarUsuarios()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/Usuario/MostrarUsuarios");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<UsuarioViewModel> usuarios = JsonConvert.DeserializeObject<List<UsuarioViewModel>>(content);

                return usuarios;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UsuarioViewModel MostrarUsuario(int id)
        {
            try
            {
                ServiceRepository serviceObj = new();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/Usuario/MostrarUsuario?id=" + id);
                response.EnsureSuccessStatusCode();
                UsuarioViewModel usuarioViewModel = response.Content.ReadAsAsync<UsuarioViewModel>().Result;
                return usuarioViewModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CrearUsuario(UsuarioViewModel usuario)
        {
            try
            {
                usuario.IdRol = 3;
                ServiceRepository serviceObj = new();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.PostResponse("api/Usuario/InsertarUsuario", usuario);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EditarUsuario(UsuarioViewModel usuario)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.PutResponse("api/Usuario/ActualizarUsuario", usuario);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool BorrarUsuario(UsuarioViewModel usuario)
        {
            try
            {
                ServiceRepository serviceObj = new();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Usuario/EliminarUsuario?id=" + usuario.IdUsuario);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UsuarioViewModel Login(UsuarioViewModel usuario)
        {
            try
            {
                ServiceRepository serviceObj = new();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/Usuario/IniciarSesion?correo=" + usuario.Correo + "&contrasena=" + usuario.Contrasena);
                response.EnsureSuccessStatusCode();
                UsuarioViewModel usuarioViewModel = response.Content.ReadAsAsync<UsuarioViewModel>().Result;
                
                return usuarioViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ChangedPassword(UsuarioViewModel usuario)
        {
            try
            {
                ServiceRepository serviceObj = new();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/Usuario/CambiarContrasena?correo=" + usuario.Correo + "&contrasena=" + usuario.Contrasena);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
