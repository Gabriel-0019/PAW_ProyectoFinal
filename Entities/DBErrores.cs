using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class DBErrores
    {
        public int IdError { get; set; }
        public int? ErrorNumero { get; set; }
        public int? ErrorStatus { get; set; }
        public int? ErrorSeveridad { get; set; }
        public int? ErrorLinea { get; set; }
        public string? ErrorProcedimiento { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime? ErrorDateTime { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
