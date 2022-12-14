namespace FrontEnd.Models
{
    public class MisFacturasViewModel
    {
        public int IdFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal MontoAlquiler { get; set; }
        public decimal PrimerPago { get; set; }
        public decimal MontoMulta { get; set; }
        public decimal SegundoPago { get; set; }
        public DateTime FechaUltActu { get; set; }
        public string? Nombre { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Placa { get; set; }
        public string? DetalleDireccion { get; set; }
        public decimal? PrecioBase { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string? NombreCategoria { get; set; }
    }
}
