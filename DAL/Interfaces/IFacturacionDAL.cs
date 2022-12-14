using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IFacturacionDAL : IGenericoDAL<Facturacion>
    {
        List<MisFacturas_Result> GetMisFacturas(int IdUsuario);
        List<MisFacturas_Result> FacturasPendientesAdmin(int IdUsuario);
        MisFacturas_Result GetMiDetalleFacturas(int IdFactura,int IdUsuario);
        List<MisFacturas_Result> MostrarFacturas(int IdUsuario);
    }

}
