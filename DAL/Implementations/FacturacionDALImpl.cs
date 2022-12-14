using DAL.Interfaces;
using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class FacturacionDALImpl : IFacturacionDAL
    {
        rabdContext rabdContext;

        public FacturacionDALImpl()
        {
            rabdContext = new rabdContext();
        }

        public FacturacionDALImpl(rabdContext rabdContext)
        {
            this.rabdContext = rabdContext;
        }

        public bool Add(Facturacion entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Facturacion>(rabdContext);
                unidad.genericoDAL.Add(entity);

                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddRange(IEnumerable<Facturacion> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Facturacion> Find(Expression<Func<Facturacion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Facturacion Get(int id)
        {
            try
            {
                Facturacion facturacion;
                using (var unidad = new UnidadDeTrabajo<Facturacion>(rabdContext))
                {
                    facturacion = unidad.genericoDAL.Get(id);
                }

                return facturacion;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Facturacion> Get()
        {
            try
            {
                IEnumerable<Facturacion> facturaciones;

                using (var unidad = new UnidadDeTrabajo<Facturacion>(rabdContext))
                {
                    facturaciones = unidad.genericoDAL.GetAll();
                }
                return facturaciones.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Facturacion> GetAll()
        {
            try
            {
                IEnumerable<Facturacion> facturaciones;

                using (var unidad = new UnidadDeTrabajo<Facturacion>(rabdContext))
                {
                    facturaciones = unidad.genericoDAL.GetAll();
                }

                return facturaciones;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MisFacturas_Result GetMiDetalleFacturas(int IdFactura, int IdUsuario)
        {
            try
            {
                string sql = "[dbo].[MiDetalleFactura] @IdFactura, @IdUsuario";

                var param = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = "@IdFactura",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Size = 20,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = IdFactura
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@IdUsuario",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Size = 20,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = IdUsuario
                    }
                };

                var results = rabdContext.MisFacturas_Results.FromSqlRaw(sql, param).ToList();

                if (results != null)
                {
                    MisFacturas_Result misFacturas_Result = new();
                    foreach (var item in results)
                    {
                        misFacturas_Result.IdFactura = item.IdFactura;
                        misFacturas_Result.FechaFactura = item.FechaFactura;
                        misFacturas_Result.Placa = item.Placa;
                        misFacturas_Result.DetalleDireccion = item.DetalleDireccion;
                        misFacturas_Result.FechaEnvio = item.FechaEnvio;
                        misFacturas_Result.PrimerPago = item.PrimerPago;
                        misFacturas_Result.SegundoPago = item.SegundoPago;
                        misFacturas_Result.MontoMulta = item.MontoMulta;
                        misFacturas_Result.Marca = item.Marca;
                        misFacturas_Result.FechaUltActu = item.FechaUltActu;
                        misFacturas_Result.PrecioBase = item.PrecioBase;
                        misFacturas_Result.Modelo = item.Modelo;
                        misFacturas_Result.Nombre = item.Nombre;
                        misFacturas_Result.MontoAlquiler = item.MontoAlquiler;
                        misFacturas_Result.NombreCategoria = item.NombreCategoria;

                    }

                    return misFacturas_Result;
                }

                return new MisFacturas_Result();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<MisFacturas_Result> GetMisFacturas(int IdUsuario)
        {
            try
            {
                List<MisFacturas_Result> results;
                string sql = "[dbo].[MisFacturas] @IdUsuario";

                var param = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = "@IdUsuario",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Size = 20,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = IdUsuario
                    }
                };

                results = rabdContext.MisFacturas_Results.FromSqlRaw(sql, param).ToList();

                if (results != null)
                {
                    return results;
                }

                return new List<MisFacturas_Result>();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<MisFacturas_Result> FacturasPendientesAdmin(int IdUsuario)
        {
            try
            {
                List<MisFacturas_Result> results;
                string sql = "[dbo].[FacturasPendientesAdmin] @IdUsuario";

                var param = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = "@IdUsuario",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Size = 20,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = IdUsuario
                    }
                };

                results = rabdContext.MisFacturas_Results.FromSqlRaw(sql, param).ToList();

                if (results != null)
                {
                    return results;
                }

                return new List<MisFacturas_Result>();

            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool Remove(Facturacion entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Facturacion>(rabdContext);
                unidad.genericoDAL.Remove(entity);
                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveRange(IEnumerable<Facturacion> entities)
        {
            throw new NotImplementedException();
        }

        public Facturacion SingleOrDefault(Expression<Func<Facturacion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Facturacion entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Facturacion>(rabdContext);
                unidad.genericoDAL.Update(entity);
                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<MisFacturas_Result> MostrarFacturas(int IdUsuario)
        {
            try
            {
                List<MisFacturas_Result> results;
                string sql = "[dbo].[MostrarFacturas] @IdUsuario";

                var param = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = "@IdUsuario",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Size = 20,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = IdUsuario
                    }
                };

                results = rabdContext.MisFacturas_Results.FromSqlRaw(sql, param).ToList();

                if (results != null)
                {
                    return results;
                }

                return new List<MisFacturas_Result>();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
