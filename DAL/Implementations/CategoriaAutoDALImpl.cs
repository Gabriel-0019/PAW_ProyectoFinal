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
    public class CategoriaAutoDALImpl : ICategoriaAutoDAL
    {
        rabdContext rabdContext;

        public CategoriaAutoDALImpl()
        {
            rabdContext = new rabdContext();
        }

        public CategoriaAutoDALImpl(rabdContext rabdContext)
        {
            this.rabdContext = rabdContext;
        }

        public bool Add(CategoriaAuto entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<CategoriaAuto>(rabdContext);
                unidad.genericoDAL.Add(entity);

                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddRange(IEnumerable<CategoriaAuto> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriaAuto> Find(Expression<Func<CategoriaAuto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public CategoriaAuto Get(int id)
        {
            try
            {
                CategoriaAuto categoriaAuto;
                using (var unidad = new UnidadDeTrabajo<CategoriaAuto>(rabdContext))
                {
                    categoriaAuto = unidad.genericoDAL.Get(id);
                }

                return categoriaAuto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CategoriaAuto> Get()
        {
            try
            {
                IEnumerable<CategoriaAuto> categoriasAutos;

                using (var unidad = new UnidadDeTrabajo<CategoriaAuto>(rabdContext))
                {
                    categoriasAutos = unidad.genericoDAL.GetAll();
                }
                return categoriasAutos.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<CategoriaAuto> GetAll()
        {
            try
            {
                IEnumerable<CategoriaAuto> categoriasAutos;

                using (var unidad = new UnidadDeTrabajo<CategoriaAuto>(rabdContext))
                {
                    categoriasAutos = unidad.genericoDAL.GetAll();
                }

                return categoriasAutos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CategoriaAuto> GetByName(string nombre)
        {
            try
            {
                List<CategoriaAuto> listaCategoriasAutos;

                using (rabdContext = new rabdContext())
                {
                    listaCategoriasAutos = (from c in rabdContext.CategoriaAutos
                                    where c.NombreCategoria.Contains(nombre)
                                    select c).ToList();
                }

                return listaCategoriasAutos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(CategoriaAuto entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<CategoriaAuto>(rabdContext);
                unidad.genericoDAL.Remove(entity);
                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveRange(IEnumerable<CategoriaAuto> entities)
        {
            throw new NotImplementedException();
        }

        public CategoriaAuto SingleOrDefault(Expression<Func<CategoriaAuto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(CategoriaAuto entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<CategoriaAuto>(rabdContext);
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
