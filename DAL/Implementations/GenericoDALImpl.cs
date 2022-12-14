using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class GenericoDALImpl<TEntity> : IGenericoDAL<TEntity> where TEntity : class
    {
        protected readonly rabdContext rabdContext;

        public GenericoDALImpl(rabdContext rabdContext)
        {
            this.rabdContext = rabdContext;
        }

        public bool Add(TEntity entity)
        {
            try
            {
                rabdContext.Set<TEntity>().Add(entity);

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                rabdContext.Set<TEntity>().AddRange(entities);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return rabdContext.Set<TEntity>().Where(predicate);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public TEntity Get(int id)
        {
            try
            {
                return rabdContext.Set<TEntity>().Find(id);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return rabdContext.Set<TEntity>().ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                rabdContext.Set<TEntity>().Attach(entity);
                rabdContext.Set<TEntity>().Remove(entity);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            try
            {
                rabdContext.Set<TEntity>().RemoveRange(entities);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return rabdContext.Set<TEntity>().SingleOrDefault(predicate);
            }
            catch (Exception)
            {

                throw null;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                rabdContext.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
