using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Facturacion
    {
        public Facturacion()
        {
            Devolucions = new HashSet<Devolucion>();
        }

        public int IdFactura { get; set; }
        public int IdEnvio { get; set; }
        public int IdAlquiler { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal MontoAlquiler { get; set; }
        public decimal PrimerPago { get; set; }
        public decimal MontoMulta { get; set; }
        public decimal SegundoPago { get; set; }
        public DateTime FechaUltActu { get; set; }

        public virtual Alquiler IdAlquilerNavigation { get; set; } = null!;
        public virtual Envio IdEnvioNavigation { get; set; } = null!;
        public virtual ICollection<Devolucion> Devolucions { get; set; }
    }
}
