namespace BackEnd.Models
{
    public class UsuarioModel
    {
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
    }
}
