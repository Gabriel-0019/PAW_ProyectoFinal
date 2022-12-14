using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public partial class AlquilerEnvio
    {
        public Auto auto { get; set; }

        public Usuario usuario { get; set; }

        public Alquiler alquiler { get; set; }

        public Envio envio { get; set; }
        public decimal PrimerPago { get; set; }
    }
}
