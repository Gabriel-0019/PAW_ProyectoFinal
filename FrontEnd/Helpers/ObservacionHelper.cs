using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class ObservacionHelper
    {
        public List<ObservacionesViewModel> MostrarObservaciones()
        {
            try
            {
                ServiceRepository serviceObj = new();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/Observacion/MostrarObservaciones");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<ObservacionesViewModel> observaciones = JsonConvert.DeserializeObject<List<ObservacionesViewModel>>(content);

                return observaciones;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ObservacionesViewModel MostrarObservacion(int id)
        {
            try
            {
                ServiceRepository serviceObj = new();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/Observacion/MostrarObservacion?id=" + id);
                response.EnsureSuccessStatusCode();
                ObservacionesViewModel observaciones = response.Content.ReadAsAsync<ObservacionesViewModel>().Result;
                return observaciones;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CrearObservacion(ObservacionesViewModel observacion)
        {
            try
            {
                ServiceRepository serviceObj = new();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.PostResponse("api/Observacion/InsertarObservacion", observacion);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EditarObservacion(ObservacionesViewModel observacion)
        {
            try
            {
                ServiceRepository serviceObj = new();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.PutResponse("api/Observacion/ActualizarObservacion", observacion);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool BorrarObservacion(ObservacionesViewModel observacion)
        {
            try
            {
                ServiceRepository serviceObj = new();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Observacion/EliminarObservacion?id=" + observacion.IdObservacion);
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
