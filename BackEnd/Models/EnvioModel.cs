namespace BackEnd.Models
{
    public class EnvioModel
    {
        public int IdEnvio { get; set; }
        public string DetalleDireccion { get; set; } = null!;
        public decimal PrecioBase { get; set; }
        public int IdConductor { get; set; }
        public DateTime FechaEnvio { get; set; }
    }
}
