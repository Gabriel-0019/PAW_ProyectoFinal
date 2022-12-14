using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class CategoriaAuto
    {
        public CategoriaAuto()
        {
            Autos = new HashSet<Auto>();
        }

        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; } = null!;

        public virtual ICollection<Auto> Autos { get; set; }
    }
}
