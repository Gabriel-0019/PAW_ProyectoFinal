using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDevolucionDAL : IGenericoDAL<Devolucion>
    {
        public bool CrearDevolucion(int IdFactura, int IdObservacion, int IdUsuario);
    }
}
