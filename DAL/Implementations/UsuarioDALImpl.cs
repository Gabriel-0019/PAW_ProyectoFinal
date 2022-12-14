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
    public class UsuarioDALImpl : IUsuarioDAL
    {
        rabdContext rabdContext;

        public UsuarioDALImpl()
        {
            rabdContext = new rabdContext();
        }

        public UsuarioDALImpl(rabdContext rabdContext)
        {
            this.rabdContext = rabdContext;
        }

        public Usuario IniciarSesion(string correo, string contrasena)
        {

            using (rabdContext = new rabdContext())
            {

                try
                {

                    var result = (from c in rabdContext.Usuarios
                                  where c.Correo.Equals(correo) && c.Contrasena.Equals(contrasena)
                                  select c).FirstOrDefault();

                    if (result != null)
                    {
                        Usuario usuario = new()
                        {
                            IdUsuario = result.IdUsuario,
                            Correo = result.Correo,
                            NumeroTarjeta = result.NumeroTarjeta,
                            IdRol = result.IdRol,
                            Nombre = result.Nombre,
                            Apellido = result.Apellido,
                            Cedula = result.Cedula,
                            Cvv = result.Cvv,
                            FechaExpiracion = result.FechaExpiracion,
                            NombreTitular = result.NombreTitular
                        };
                        return usuario;
                    }

                    return new Usuario();

                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        public string CambiarContrasena(string correo, string contrasena)
        {
            try
            {
                using (rabdContext = new rabdContext())
                {
                    string sql = "[dbo].[CambiarContrasena] @Correo, @Contrasena";
                    var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@Correo",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 50,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = correo
                        },
                        new SqlParameter() {
                            ParameterName = "@Contrasena",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 50,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = contrasena
                        }
                    };

                    var resultado = rabdContext.Database.ExecuteSqlRaw(sql, param);

                    if (resultado != 0)
                    {
                        return "OK";
                    }

                    return "Update falló";
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        public bool VerificarUsuario(string correo)
        {

            using (rabdContext = new rabdContext())
            {

                try
                {

                    var result = (from c in rabdContext.Usuarios
                                  where c.Correo.Equals(correo)
                                  select c).FirstOrDefault();

                    if (result != null)
                        return true;
                    else
                        return false;

                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        public bool Add(Usuario entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Usuario>(rabdContext);
                unidad.genericoDAL.Add(entity);

                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddRange(IEnumerable<Usuario> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> Find(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Usuario Get(int id)
        {
            try
            {
                Usuario usuario;
                using (var unidad = new UnidadDeTrabajo<Usuario>(rabdContext))
                {
                    usuario = unidad.genericoDAL.Get(id);
                }

                return usuario;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Usuario> Get()
        {
            try
            {
                IEnumerable<Usuario> usuarios;

                using (var unidad = new UnidadDeTrabajo<Usuario>(rabdContext))
                {
                    usuarios = unidad.genericoDAL.GetAll();
                }
                return usuarios.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            try
            {
                IEnumerable<Usuario> usuarios;

                using (var unidad = new UnidadDeTrabajo<Usuario>(rabdContext))
                {
                    usuarios = unidad.genericoDAL.GetAll();
                }

                return usuarios;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Usuario> GetByName(string nombre)
        {
            try
            {
                List<Usuario> listaUsuario;

                using (rabdContext = new rabdContext())
                {
                    listaUsuario = (from c in rabdContext.Usuarios
                                  where c.Nombre.Contains(nombre)
                                  select c).ToList();
                }

                return listaUsuario;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool Remove(Usuario entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Usuario>(rabdContext);
                unidad.genericoDAL.Remove(entity);
                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveRange(IEnumerable<Usuario> entities)
        {
            throw new NotImplementedException();
        }

        public Usuario SingleOrDefault(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Usuario>(rabdContext);
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
