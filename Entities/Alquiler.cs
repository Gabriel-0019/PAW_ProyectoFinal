using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Alquiler
    {
        public Alquiler()
        {
            Facturacions = new HashSet<Facturacion>();
        }

        public int IdAlquiler { get; set; }
        public int IdUsuario { get; set; }
        public int IdAuto { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public DateTime FechaDevolucion { get; set; }

        public virtual Auto IdAutoNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Facturacion> Facturacions { get; set; }
    }
}
