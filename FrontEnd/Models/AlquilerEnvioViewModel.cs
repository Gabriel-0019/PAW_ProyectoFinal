namespace FrontEnd.Models
{
    public class AlquilerEnvioViewModel
    {
        public AutoViewModel auto { get; set; }

        public UsuarioViewModel usuario { get; set; }

        public AlquilerViewModel alquiler { get; set; }

        public EnvioViewModel envio { get; set; }
        public decimal PrimerPago { get; set; }
    }
}