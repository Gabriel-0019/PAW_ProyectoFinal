using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Alquilers = new HashSet<Alquiler>();
            Dberrores = new HashSet<DBErrores>();
            Envios = new HashSet<Envio>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public long NumeroTarjeta { get; set; }
        public int Cvv { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string NombreTitular { get; set; } = null!;
        public int IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; } = null!;
        public virtual ICollection<Alquiler> Alquilers { get; set; }
        public virtual ICollection<DBErrores> Dberrores { get; set; }
        public virtual ICollection<Envio> Envios { get; set; }
    }
}
