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
    public class AutosDALImpl : IAutoDAL
    {
        rabdContext rabdContext;

        public AutosDALImpl()
        {
            rabdContext = new rabdContext();
        }

        public AutosDALImpl(rabdContext rabdContext)
        {
            this.rabdContext = rabdContext;
        }

        public bool Add(Auto entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Auto>(rabdContext);
                unidad.genericoDAL.Add(entity);

                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddRange(IEnumerable<Auto> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Auto> Find(Expression<Func<Auto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Auto Get(int id)
        {
            try
            {
                Auto auto;
                using (var unidad = new UnidadDeTrabajo<Auto>(rabdContext))
                {
                    auto = unidad.genericoDAL.Get(id);
                }

                return auto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Auto> Get()
        {
            try
            {
                IEnumerable<Auto> autos;

                using (var unidad = new UnidadDeTrabajo<Auto>(rabdContext))
                {
                    autos = unidad.genericoDAL.GetAll();
                }
                return autos.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Auto> GetAll()
        {
            try
            {
                IEnumerable<Auto> autos;

                using (var unidad = new UnidadDeTrabajo<Auto>(rabdContext))
                {
                    autos = unidad.genericoDAL.GetAll();
                }

                return autos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Auto> GetByBrand(string nombre)
        {
            try
            {
                List<Auto> listaAutos;

                using (rabdContext = new rabdContext())
                {
                    listaAutos = (from c in rabdContext.Autos
                                    where c.Marca.Contains(nombre)
                                    select c).ToList();
                }

                return listaAutos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Auto entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Auto>(rabdContext);
                unidad.genericoDAL.Remove(entity);
                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveRange(IEnumerable<Auto> entities)
        {
            throw new NotImplementedException();
        }

        public Auto SingleOrDefault(Expression<Func<Auto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Auto entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Auto>(rabdContext);
                unidad.genericoDAL.Update(entity);
                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Auto> GetByName(string Marca)
        {
            try
            {
                List<Auto> listaAutos;

                using (rabdContext = new rabdContext())
                {
                    listaAutos = (from c in rabdContext.Autos
                                  where c.Marca.Contains(Marca)
                                  select c).ToList();
                }

                return listaAutos;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
