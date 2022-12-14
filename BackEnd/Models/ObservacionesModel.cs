namespace BackEnd.Models
{
    public class ObservacionesModel
    {
        public int IdObservacion { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }
    }
}
