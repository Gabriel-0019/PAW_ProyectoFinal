using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class DBErroresDALImpl : IDBErroresDAL
    {
        rabdContext rabdContext;

        public DBErroresDALImpl()
        {
            rabdContext = new rabdContext();
        }

        public DBErroresDALImpl(rabdContext rabdContext)
        {
            this.rabdContext = rabdContext;
        }

        public bool Add(DBErrores entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<DBErrores> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DBErrores> Find(Expression<Func<DBErrores, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public DBErrores Get(int id)
        {
            try
            {
                DBErrores dbErrores;
                using (var unidad = new UnidadDeTrabajo<DBErrores>(rabdContext))
                {
                    dbErrores = unidad.genericoDAL.Get(id);
                }

                return dbErrores;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DBErrores> Get()
        {
            try
            {
                IEnumerable<DBErrores> dbErrores;

                using (var unidad = new UnidadDeTrabajo<DBErrores>(rabdContext))
                {
                    dbErrores = unidad.genericoDAL.GetAll();
                }
                return dbErrores.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<DBErrores> GetAll()
        {
            try
            {
                IEnumerable<DBErrores> dbErrores;

                using (var unidad = new UnidadDeTrabajo<DBErrores>(rabdContext))
                {
                    dbErrores = unidad.genericoDAL.GetAll();
                }

                return dbErrores;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DBErrores> GetByErrorMessage(string mensaje)
        {
            try
            {
                List<DBErrores> listaDBErrores;

                using (rabdContext = new rabdContext())
                {
                    listaDBErrores = (from c in rabdContext.Dberrores
                                    where c.ErrorMessage.Contains(mensaje)
                                    select c).ToList();
                }

                return listaDBErrores;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(DBErrores entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<DBErrores> entities)
        {
            throw new NotImplementedException();
        }

        public DBErrores SingleOrDefault(Expression<Func<DBErrores, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(DBErrores entity)
        {
            throw new NotImplementedException();
        }
    }
}
