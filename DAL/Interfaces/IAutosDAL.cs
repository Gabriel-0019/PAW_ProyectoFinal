using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAutoDAL : IGenericoDAL<Auto>
    {
        List<Auto> GetByName(string Marca);
    }
}
