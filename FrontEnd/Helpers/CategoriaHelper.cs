using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class CategoriaHelper
    {
        public List<CategoriaViewModel> MostrarCategorias()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/CategoriaAuto/MostrarCategorias");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<CategoriaViewModel> categoria = JsonConvert.DeserializeObject<List<CategoriaViewModel>>(content);

                return categoria;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CategoriaViewModel MostrarCategoria(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/CategoriaAuto/MostrarCategoria?id=" + id);
                response.EnsureSuccessStatusCode();
                CategoriaViewModel categoria = response.Content.ReadAsAsync<CategoriaViewModel>().Result;
                return categoria;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CrearCategoria(CategoriaViewModel categoria)
        {
            try
            {
                ServiceRepository serviceObj = new();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.PostResponse("api/CategoriaAuto/InsertarCategoria", categoria);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EditarCategoria(CategoriaViewModel categoria)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.PutResponse("api/CategoriaAuto/ActualizarCategoria", categoria);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool BorrarCategoria(CategoriaViewModel categoria)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Usuario/EliminarCategoria?id=" + categoria.IdCategoria);
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
