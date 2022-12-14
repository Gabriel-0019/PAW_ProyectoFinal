using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Envio
    {
        public Envio()
        {
            Facturacions = new HashSet<Facturacion>();
        }

        public int IdEnvio { get; set; }
        public string DetalleDireccion { get; set; } = null!;
        public decimal PrecioBase { get; set; }
        public int IdConductor { get; set; }
        public DateTime FechaEnvio { get; set; }

        public virtual Usuario IdConductorNavigation { get; set; } = null!;
        public virtual ICollection<Facturacion> Facturacions { get; set; }
    }
}
