using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using NuGet.Protocol.Plugins;

namespace FrontEnd.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly UsuarioHelper usuarioHelper = new();
        private readonly RolHelper rolHelper = new();
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var usuarios = usuarioHelper.MostrarUsuarios();
                return View(usuarios);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            try
            {
                var usuario = usuarioHelper.MostrarUsuario(id);
                usuario.rols = rolHelper.MostrarRoles();
                return View(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(UsuarioViewModel usuario)
        {
            try
            {
                var creado = usuarioHelper.CrearUsuario(usuario);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var usuario = usuarioHelper.MostrarUsuario(id);
                usuario.rols = rolHelper.MostrarRoles();
                return View(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(UsuarioViewModel usuario)
        {
            try
            {
                var editado = usuarioHelper.EditarUsuario(usuario);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var usuario = usuarioHelper.MostrarUsuario(id);
                usuario.rols = rolHelper.MostrarRoles();
                return View(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Delete(UsuarioViewModel usuario)
        {
            try
            {
                var borrar = usuarioHelper.BorrarUsuario(usuario);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Login() 
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Login(UsuarioViewModel usuario)
        {
            try
            {
                ViewBag.credenInvalida = null;
                var login = usuarioHelper.Login(usuario);
                if (login.IdUsuario != 0)
                {
                    HttpContext.Session.SetInt32("IdUsuario", login.IdUsuario);
                    HttpContext.Session.SetString("Correo", login.Correo);
                    HttpContext.Session.SetInt32("Rol", login.IdRol);
                    HttpContext.Session.SetString("Nombre", login.Nombre + " " + login.Apellido);

                    ViewBag.sessionIdUsuario = HttpContext.Session.GetInt32("IdUsuario");
                    ViewBag.sessionCorreo = HttpContext.Session.GetString("Correo");
                    ViewBag.sessionRol = HttpContext.Session.GetInt32("Rol");
                    ViewBag.sessionNombre = HttpContext.Session.GetString("Nombre");
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    ViewBag.credenInvalida = "Credenciales inválidas";
                    return View();
                }

                
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult ChangePassword(UsuarioViewModel usuario)
        {
            try
            {
                var changed = usuarioHelper.ChangedPassword(usuario);
                return RedirectToAction("Login");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            try
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult MiPerfil()
        {
            try
            {
                int id = (int)HttpContext.Session.GetInt32("IdUsuario");
                var usuario = usuarioHelper.MostrarUsuario(id);
                usuario.rols = rolHelper.MostrarRoles();
                return View(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult EditarPerfil(int id)
        {
            try
            {
                var usuario = usuarioHelper.MostrarUsuario(id);
                usuario.rols = rolHelper.MostrarRoles();
                return View(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult EditarPerfil(UsuarioViewModel usuario)
        {
            try
            {
                var editado = usuarioHelper.EditarUsuario(usuario);
                return RedirectToAction("MiPerfil");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
