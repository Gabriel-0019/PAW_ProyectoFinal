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
    public class ObservacionesDALImpl : IObservacionesDAL
    {
        rabdContext rabdContext;

        public ObservacionesDALImpl()
        {
            rabdContext = new rabdContext();
        }

        public ObservacionesDALImpl(rabdContext rabdContext)
        {
            this.rabdContext = rabdContext;
        }

        public bool Add(Observaciones entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Observaciones>(rabdContext);
                unidad.genericoDAL.Add(entity);

                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddRange(IEnumerable<Observaciones> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Observaciones> Find(Expression<Func<Observaciones, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Observaciones Get(int id)
        {
            try
            {
                Observaciones observacion;
                using (var unidad = new UnidadDeTrabajo<Observaciones>(rabdContext))
                {
                    observacion = unidad.genericoDAL.Get(id);
                }

                return observacion;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Observaciones> Get()
        {
            try
            {
                IEnumerable<Observaciones> observaciones;

                using (var unidad = new UnidadDeTrabajo<Observaciones>(rabdContext))
                {
                    observaciones = unidad.genericoDAL.GetAll();
                }
                return observaciones.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Observaciones> GetAll()
        {
            try
            {
                IEnumerable<Observaciones> observaciones;

                using (var unidad = new UnidadDeTrabajo<Observaciones>(rabdContext))
                {
                    observaciones = unidad.genericoDAL.GetAll();
                }

                return observaciones;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Observaciones entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Observaciones>(rabdContext);
                unidad.genericoDAL.Remove(entity);
                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveRange(IEnumerable<Observaciones> entities)
        {
            throw new NotImplementedException();
        }

        public Observaciones SingleOrDefault(Expression<Func<Observaciones, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Observaciones entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Observaciones>(rabdContext);
                unidad.genericoDAL.Update(entity);
                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
