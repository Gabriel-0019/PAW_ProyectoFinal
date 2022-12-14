using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Devolucion
    {
        public int IdFactura { get; set; }
        public int IdObservacion { get; set; }
        public DateTime FechaEntrega { get; set; }

        public virtual Facturacion IdFacturaNavigation { get; set; } = null!;
        public virtual Observaciones IdObservacionNavigation { get; set; } = null!;
    }
}
