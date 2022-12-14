using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class FacturacionHelper
    {
        public List<MisFacturasViewModel> MisFacturas(int IdUsuario)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/Facturacion/MisFacturas?IdUsuario=" + IdUsuario);
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<MisFacturasViewModel> misFacturas = JsonConvert.DeserializeObject<List<MisFacturasViewModel>>(content);

                return misFacturas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<MisFacturasViewModel> MostrarFacturas(int IdUsuario)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/Facturacion/MostrarFacturas?IdUsuario=" + IdUsuario);
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<MisFacturasViewModel> misFacturas = JsonConvert.DeserializeObject<List<MisFacturasViewModel>>(content);

                return misFacturas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<MisFacturasViewModel> FacturasPendientesAdmin(int IdUsuario)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/Facturacion/FacturasPendientesAdmin?IdUsuario=" + IdUsuario);
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<MisFacturasViewModel> misFacturas = JsonConvert.DeserializeObject<List<MisFacturasViewModel>>(content);

                return misFacturas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MisFacturasViewModel MiDetalleFactura(int IdFactura, int IdUsuario)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                serviceObj.Client.DefaultRequestHeaders.Add("ApiKey", "corei5Steam");
                HttpResponseMessage response = serviceObj.GetResponse("api/Facturacion/MiDetalleFactura?IdFactura=" + IdFactura + "&IdUsuario=" + IdUsuario);
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                MisFacturasViewModel misFacturas = JsonConvert.DeserializeObject<MisFacturasViewModel>(content);

                return misFacturas;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
