using DAL.Interfaces;
using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class DevolucionDALImpl : IDevolucionDAL
    {
        rabdContext rabdContext;

        public DevolucionDALImpl()
        {
            rabdContext = new rabdContext();
        }

        public DevolucionDALImpl(rabdContext rabdContext)
        {
            this.rabdContext = rabdContext;
        }

        public bool Add(Devolucion entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Devolucion>(rabdContext);
                unidad.genericoDAL.Add(entity);

                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddRange(IEnumerable<Devolucion> entities)
        {
            throw new NotImplementedException();
        }

        public bool CrearDevolucion(int IdFactura, int IdObservacion, int IdUsuario)
        {
            try
            {
                string SQL = "[dbo].[CrearDevolucion] @IdFactura, @IdObservacion, @IdUsuario";
                var param = new SqlParameter[]
                {
                        new SqlParameter()
                        {
                            ParameterName="@IdFactura",
                            SqlDbType = System.Data.SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                            Value= IdFactura
                        },
                        new SqlParameter()
                        {
                             ParameterName="@IdObservacion",
                            SqlDbType = System.Data.SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                            Value= IdObservacion
                        },
                        new SqlParameter()
                        {
                             ParameterName="@IdUsuario",
                            SqlDbType = System.Data.SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                            Value= IdUsuario
                        }
                };

                rabdContext.Database.ExecuteSqlRaw(SQL, param);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Devolucion> Find(Expression<Func<Devolucion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Devolucion Get(int id)
        {
            try
            {
                Devolucion devolucion;
                using (var unidad = new UnidadDeTrabajo<Devolucion>(rabdContext))
                {
                    devolucion = unidad.genericoDAL.Get(id);
                }

                return devolucion;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Devolucion> Get()
        {
            try
            {
                IEnumerable<Devolucion> devoluciones;

                using (var unidad = new UnidadDeTrabajo<Devolucion>(rabdContext))
                {
                    devoluciones = unidad.genericoDAL.GetAll();
                }
                return devoluciones.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Devolucion> GetAll()
        {
            try
            {
                IEnumerable<Devolucion> devoluciones;

                using (var unidad = new UnidadDeTrabajo<Devolucion>(rabdContext))
                {
                    devoluciones = unidad.genericoDAL.GetAll();
                }

                return devoluciones;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Devolucion entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Devolucion>(rabdContext);
                unidad.genericoDAL.Remove(entity);
                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveRange(IEnumerable<Devolucion> entities)
        {
            throw new NotImplementedException();
        }

        public Devolucion SingleOrDefault(Expression<Func<Devolucion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Devolucion entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Devolucion>(rabdContext);
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
