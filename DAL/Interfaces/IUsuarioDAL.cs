using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUsuarioDAL : IGenericoDAL<Usuario>
    {
        Usuario IniciarSesion(string correo, string contrasena);
        string CambiarContrasena(string correo, string contrasena);
        bool VerificarUsuario(string correo);
    }
}
