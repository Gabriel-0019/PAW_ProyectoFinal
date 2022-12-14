using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FrontEnd.Models
{
    public class UsuarioViewModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int IdUsuario { get; set; }

        public RolViewModel RolViewModel { get; set; }

        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public long NumeroTarjeta { get; set; }
        public int Cvv { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string NombreTitular { get; set; } = null!;

        [Display(Name = "Rol")]
        public int IdRol { get; set; }
        public IEnumerable<RolViewModel> rols { get; set; }
    }
}
