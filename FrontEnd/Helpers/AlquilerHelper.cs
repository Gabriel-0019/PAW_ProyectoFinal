using FrontEnd.Models;
using Newtonsoft.Json;
using System.Reflection;

namespace FrontEnd.Helpers
{
    public class AlquilerHelper
    {
        public List<AlquilerViewModel> MostrarAlquileres()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/Alquiler/MostrarAlquileres");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<AlquilerViewModel> alquileres = JsonConvert.DeserializeObject<List<AlquilerViewModel>>(content);
                
                return alquileres;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AlquilerViewModel MostrarAlquiler(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/Alquiler/MostrarAlquiler?id=" + id);
                response.EnsureSuccessStatusCode();
                AlquilerViewModel alquilerViewModel = response.Content.ReadAsAsync<AlquilerViewModel>().Result;
                return alquilerViewModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CrearAlquiler(AlquilerEnvioViewModel model)
        {
            try
            {
                ServiceRepository serviceObj = new();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                string jsonString = System.Text.Json.JsonSerializer.Serialize(model);
                HttpResponseMessage response = serviceObj.PostResponse("api/Alquiler/InsertarAlquiler", jsonString);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("" + ex.Message);
            }
        }

        public bool EditarAlquiler(AlquilerViewModel alquiler)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.PutResponse("api/Alquiler/ActualizarAlquiler", alquiler);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool BorrarAlquiler(AlquilerViewModel alquiler)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Alquiler/EliminarAlquiler?id=" + alquiler.IdAlquiler);
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
