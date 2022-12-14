namespace BackEnd.Models
{
    public class FacturacionModel
    {
        public int IdFactura { get; set; }
        public int IdEnvio { get; set; }
        public int IdAlquiler { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal MontoAlquiler { get; set; }
        public decimal PrimerPago { get; set; }
        public decimal MontoMulta { get; set; }
        public decimal SegundoPago { get; set; }
        public DateTime FechaUltActu { get; set; }
    }
}
