namespace BackEnd.Models
{
    public class DevolucionModel
    {
        public int IdFactura { get; set; }
        public int IdObservacion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int IdUsuario { get; set; }
    }
}
