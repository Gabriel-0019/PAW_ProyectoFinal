using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class EnvioHelper
    {
        public List<EnvioViewModel> MostrarEnvios()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/Envio/MostrarEnvios");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<EnvioViewModel> envios = JsonConvert.DeserializeObject<List<EnvioViewModel>>(content);

                return envios;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EnvioViewModel MostrarEnvio(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/Envio/MostrarEnvio?id=" + id);
                response.EnsureSuccessStatusCode();
                EnvioViewModel envioViewModel = response.Content.ReadAsAsync<EnvioViewModel>().Result;
                return envioViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CrearEnvio(EnvioViewModel envio)
        {
            try
            {
                ServiceRepository serviceObj = new();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.PostResponse("api/Envio/InsertarEnvio", envio);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EditarEnvio(EnvioViewModel envio)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.PutResponse("api/Envio/ActualizarEnvio", envio);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool BorrarEnvio(EnvioViewModel envio)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Usuario/EliminarUsuario?id=" + envio.IdEnvio);
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
