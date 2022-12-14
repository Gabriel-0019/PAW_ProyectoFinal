using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAlquilerDAL : IGenericoDAL<Alquiler>
    {
        public bool AddAlquilerEnvio(AlquilerEnvio model);
        public Task<bool> EnviarCorreoFacturaAsync(AlquilerEnvio? model);

    }
}