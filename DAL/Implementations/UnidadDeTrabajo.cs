using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo<T> : IDisposable where T : class
    {
        private readonly rabdContext rabdContext;
        public IGenericoDAL<T> genericoDAL;

        public UnidadDeTrabajo(rabdContext _rabdContext)
        {
            this.rabdContext = _rabdContext;
            this.genericoDAL = new GenericoDALImpl<T>(rabdContext);
        }

        public bool Complete()
        {
            try
            {
                rabdContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                string msj = ex.Message;
                throw;
            }
        }

        public void Dispose()
        {
            rabdContext.Dispose();
        }
    }
}
