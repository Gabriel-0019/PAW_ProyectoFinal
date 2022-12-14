namespace FrontEnd.Models
{
    public class AlquilerViewModel
    {
        public int IdAlquiler { get; set; }
        public int IdUsuario { get; set; }
        public int IdAuto { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public DateTime FechaDevolucion { get; set; }
    }
}
