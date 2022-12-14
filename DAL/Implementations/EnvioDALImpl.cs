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
    public class EnvioDALImpl : IEnvioDAL
    {
        rabdContext rabdContext;

        public EnvioDALImpl()
        {
            rabdContext = new rabdContext();
        }

        public EnvioDALImpl(rabdContext rabdContext)
        {
            this.rabdContext = rabdContext;
        }

        public bool Add(Envio entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Envio>(rabdContext);
                unidad.genericoDAL.Add(entity);

                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddRange(IEnumerable<Envio> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Envio> Find(Expression<Func<Envio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Envio Get(int id)
        {
            try
            {
                Envio envio;
                using (var unidad = new UnidadDeTrabajo<Envio>(rabdContext))
                {
                    envio = unidad.genericoDAL.Get(id);
                }

                return envio;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Envio> Get()
        {
            try
            {
                IEnumerable<Envio> envios;

                using (var unidad = new UnidadDeTrabajo<Envio>(rabdContext))
                {
                    envios = unidad.genericoDAL.GetAll();
                }
                return envios.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Envio> GetAll()
        {
            try
            {
                IEnumerable<Envio> envios;

                using (var unidad = new UnidadDeTrabajo<Envio>(rabdContext))
                {
                    envios = unidad.genericoDAL.GetAll();
                }

                return envios;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Envio entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Envio>(rabdContext);
                unidad.genericoDAL.Remove(entity);
                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveRange(IEnumerable<Envio> entities)
        {
            throw new NotImplementedException();
        }

        public Envio SingleOrDefault(Expression<Func<Envio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Envio entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Envio>(rabdContext);
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
