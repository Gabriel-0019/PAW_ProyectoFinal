using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FrontEnd.Models
{
    public class AutoViewModel

    {

        [System.ComponentModel.DataAnnotations.Key]
        public int IdAuto { get; set; }

        public CategoriaViewModel CategoriaViewModel { get; set; }

        public string Marca { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int Capacidad { get; set; }
        public string Placa { get; set; } = null!;
        public bool Disponibilidad { get; set; } = true;
        public int Anno { get; set; }
        

        [Display(Name = "Categoria")]
        public int IdCategoria { get; set; }
        public IEnumerable<CategoriaViewModel> categorias { get; set; }

        
        public string Transmision { get; set; } = null!;
        public decimal PrecioDia { get; set; }
        public string InsertadoPor { get; set; } = null!;
        public string ModificadorPor { get; set; } = null!;
        public string ImgURL { get; set; } = null!;
        public byte[]? File { get; set; }
    }
}
