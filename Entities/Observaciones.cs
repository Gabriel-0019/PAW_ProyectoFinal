using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Observaciones
    {
        public Observaciones()
        {
            Devolucions = new HashSet<Devolucion>();
        }

        public int IdObservacion { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }

        public virtual ICollection<Devolucion> Devolucions { get; set; }
    }
}
