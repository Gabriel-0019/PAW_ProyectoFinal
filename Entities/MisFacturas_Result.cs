using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Keyless]
    public class MisFacturas_Result
    {
        public int IdFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal MontoAlquiler { get; set; }
        public decimal PrimerPago { get; set; }
        public decimal MontoMulta { get; set; }
        public decimal SegundoPago { get; set; }
        public DateTime FechaUltActu { get; set; }
        public string? Nombre { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Placa { get; set; }
        public string? DetalleDireccion { get; set; }
        public decimal? PrecioBase { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string? NombreCategoria { get; set; }
    }
}
