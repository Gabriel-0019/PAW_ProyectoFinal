using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FrontEnd.Models
{
    public class DevolucionesViewModel
    {
        public int IdFactura { get; set; }

        [Display(Name = "Observacion")]
        public int IdObservacion { get; set; }
        public IEnumerable<ObservacionesViewModel> observaciones { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int IdUsuario { get; set; }
    }
}
