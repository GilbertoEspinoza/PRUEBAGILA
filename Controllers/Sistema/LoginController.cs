using System.Web.Mvc;
using Common;
using Entities;
using DAO;
using PRUEBAGILA.Models;
using Filters;

namespace PRUEBAGILA.Controllers
{
    public class LoginController : Controller
    {
        [NoLogin]
        public ActionResult Index(string NombreUsuario, string Password)
        {
            LoginViewModel login = new LoginViewModel();
            if (!string.IsNullOrEmpty(NombreUsuario) && !string.IsNullOrEmpty(Password))
            {
                Usuario objeto = new Usuario();
                Usuarios obj = new Usuarios();
                Password = HashHelper.MD5(Password);

                objeto = obj.Login(NombreUsuario, Password);

                if(string.IsNullOrEmpty(objeto.MensajeError.ToString()))
                { 
                    if (int.Parse(objeto.Id.ToString()) > 0)
                    {
                        SessionHelper.AddUserToSession(objeto.Id.ToString());

                        var usuarioes = objeto;
                        Session["DataUser"] = usuarioes;

                        Modulos p = new Modulos();
                        var permisos = p.ObtenerModulosUsuarios(objeto.Id);
                        Session["modulos"] = permisos;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Nombre de usuario o contraseña invalidos.");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Se genero un error.");
                }

            }

            return View(login);
        }

        public ActionResult Logout()
        {
            Session["DataUser"] = null;

            SessionHelper.DestroyUserSession();
            return Redirect("~/");
        }
    }
}