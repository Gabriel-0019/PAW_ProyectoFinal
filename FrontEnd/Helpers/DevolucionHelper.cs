using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class DevolucionHelper
    {
        public List<DevolucionesViewModel> MostrarDevoluciones()
        {
            try
            {
                ServiceRepository serviceObj = new();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/Devolucion/MostrarDevoluciones");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<DevolucionesViewModel> devoluciones = JsonConvert.DeserializeObject<List<DevolucionesViewModel>>(content);

                return devoluciones;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DevolucionesViewModel MostrarDevolucion(int id)
        {
            try
            {
                ServiceRepository serviceObj = new();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/Devolucion/MostrarDevolucion?id=" + id);
                response.EnsureSuccessStatusCode();
                DevolucionesViewModel devolucionViewModel = response.Content.ReadAsAsync<DevolucionesViewModel>().Result;
                return devolucionViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CrearDevolucion(DevolucionesViewModel devolucion)
        {
            try
            {
                ServiceRepository serviceObj = new();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.PostResponse("api/Devolucion/InsertarDevolucion", devolucion);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EditarDevolucion(DevolucionesViewModel devolucion)
        {
            try
            {
                ServiceRepository serviceObj = new();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.PutResponse("api/Devolucion/ActualizarDevolucion", devolucion);
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
