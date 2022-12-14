namespace BackEnd.Models
{
    public class AutoModel
    {
        public int IdAuto { get; set; }
        public string Marca { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int Capacidad { get; set; }
        public string Placa { get; set; } = null!;
        public bool Disponibilidad { get; set; }
        public int Anno { get; set; }
        public int IdCategoria { get; set; }
        public string Transmision { get; set; } = null!;
        public decimal PrecioDia { get; set; }
        public string InsertadoPor { get; set; } = null!;
        public string ModificadorPor { get; set; } = null!;
        public string ImgURL { get; set; } = null!;
        public byte[]? File { get; set; }
    }
}
