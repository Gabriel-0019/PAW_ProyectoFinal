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
    public class RolDALImpl : IRolDAL
    {
        rabdContext rabdContext;

        public RolDALImpl()
        { 
            rabdContext = new rabdContext();
        }

        public RolDALImpl(rabdContext rabdContext)
        {
            this.rabdContext = rabdContext;
        }

        public bool Add(Rol entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Rol>(rabdContext);
                unidad.genericoDAL.Add(entity);

                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddRange(IEnumerable<Rol> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rol> Find(Expression<Func<Rol, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Rol Get(int idRol)
        {
            try
            {
                Rol rol;
                using (var unidad = new UnidadDeTrabajo<Rol>(rabdContext))
                {
                    rol = unidad.genericoDAL.Get(idRol);
                }

                return rol;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Rol> Get()
        {
            try
            {
                IEnumerable<Rol> roles;

                using (var unidad = new UnidadDeTrabajo<Rol>(rabdContext))
                {
                    roles = unidad.genericoDAL.GetAll();
                }
                return roles.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Rol> GetAll()
        {
            try
            {
                IEnumerable<Rol> roles;

                using (var unidad = new UnidadDeTrabajo<Rol>(rabdContext))
                {
                    roles = unidad.genericoDAL.GetAll();
                }

                return roles;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Rol entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Rol>(rabdContext);
                unidad.genericoDAL.Remove(entity);
                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveRange(IEnumerable<Rol> entities)
        {
            throw new NotImplementedException();
        }

        public Rol SingleOrDefault(Expression<Func<Rol, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Rol entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Rol>(rabdContext);
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
