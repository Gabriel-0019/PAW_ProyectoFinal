using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class RolHelper
    {
        public List<RolViewModel> MostrarRoles()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/Rol/MostrarRoles");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<RolViewModel> roles = JsonConvert.DeserializeObject<List<RolViewModel>>(content);

                return roles;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RolViewModel MostrarRol(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/Rol/MostrarRol?id=" + id);
                response.EnsureSuccessStatusCode();
                RolViewModel rolViewModel = response.Content.ReadAsAsync<RolViewModel>().Result;
                return rolViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CrearRol(RolViewModel rol)
        {
            try
            {
                ServiceRepository serviceObj = new();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.PostResponse("api/Rol/InsertarRol", rol);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ActualizarRol(RolViewModel rol)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.PutResponse("api/Rol/ActualizarRol", rol);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarRol(RolViewModel rol)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Rol/EliminarRol?id=" + rol.IdRol);
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
