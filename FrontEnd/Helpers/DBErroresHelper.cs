using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class DBErroresHelper
    {
        public List<DBErroresViewModel> MostrarErrores()
        {
            try
            {
                ServiceRepository serviceObj = new();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/DBErrores/MostrarDBErrores");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<DBErroresViewModel> dberrores = JsonConvert.DeserializeObject<List<DBErroresViewModel>>(content);

                return dberrores;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DBErroresViewModel MostrarError(int id)
        {
            try
            {
                ServiceRepository serviceObj = new();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/DBErrores/MostrarDBError?id=" + id);
                response.EnsureSuccessStatusCode();
                DBErroresViewModel erroresViewModel = response.Content.ReadAsAsync<DBErroresViewModel>().Result;
                return erroresViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
