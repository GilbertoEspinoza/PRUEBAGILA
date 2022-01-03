using Common;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaludDigna.Controllers
{
    public class ErrorPageController : Controller
    {
        // GET: ErrorPage
        public ActionResult NotFound()
        {
            if (Session["DataUser"] != null)
            {
                Usuario ob = (Usuario)Session["DataUser"];

                ViewData["DataUserName"] = ob.Nombre.ToUpper();
                ViewData["DataUsers"] = ob.Correo.ToUpper();
                ViewData["DataIdUSer"] = ob.Id;
                return View();
                //return View("~/ErrorPage/_ErrorPage.cshtml");
            }
            else
            {
                SessionHelper.DestroyUserSession();
                return Redirect("~/");
            }
        }

        // GET: ErrorPage
        public ActionResult NotPermission()
        {
            if (Session["DataUser"] != null)
            {
                Usuario ob = (Usuario)Session["DataUser"];

                ViewData["DataUserName"] = ob.Nombre.ToUpper();
                ViewData["DataUsers"] = ob.Correo.ToUpper();
                ViewData["DataIdUSer"] = ob.Id;
                return View();
                //return View("~/ErrorPage/_ErrorPage.cshtml");
            }
            else
            {
                SessionHelper.DestroyUserSession();
                return Redirect("~/");
            }
        }

        // GET: ErrorPage
        public ActionResult RecordNotFound()
        {
            if (Session["DataUser"] != null)
            {
                Usuario ob = (Usuario)Session["DataUser"];

                ViewData["DataUserName"] = ob.Nombre.ToUpper();
                ViewData["DataUsers"] = ob.Correo.ToUpper();
                ViewData["DataIdUSer"] = ob.Id;
                return View();
                //return View("~/ErrorPage/_ErrorPage.cshtml");
            }
            else
            {
                SessionHelper.DestroyUserSession();
                return Redirect("~/");
            }
        }

        // GET: ErrorPage
        public ActionResult NotAdd()
        {
            if (Session["DataUser"] != null)
            {
                Usuario ob = (Usuario)Session["DataUser"];

                ViewData["DataUserName"] = ob.Nombre.ToUpper();
                ViewData["DataUsers"] = ob.Correo.ToUpper();
                ViewData["DataIdUSer"] = ob.Id;
                return View();
                //return View("~/ErrorPage/_ErrorPage.cshtml");
            }
            else
            {
                SessionHelper.DestroyUserSession();
                return Redirect("~/");
            }
        }

        // GET: Error
        public ActionResult Index(int error = 0)
        {
            if (Session["DataUser"] != null)
            {
                Usuario ob = (Usuario)Session["DataUser"];
                
                ViewData["DataUserName"] = ob.Nombre.ToUpper();
                ViewData["DataUsers"] = ob.Correo.ToUpper();
                ViewData["DataIdUSer"] = ob.Id;
                ViewBag.Error = error;
                switch (error)
                {
                    case 404:
                        ViewBag.Titulo = "Ocurrio un error inesperado";
                        ViewBag.Description = "Esto es muy vergonzoso, esperemos que no vuelva a pasar ..";
                        break;

                    case 500:
                        ViewBag.Titulo = "Página no encontrada";
                        ViewBag.Description = "La URL que está intentando ingresar no existe";
                        break;

                    case 501:
                        ViewBag.Titulo = "Registro no encontrado";
                        ViewBag.Description = "La orden ya fue atendida.";
                        break;

                    case 502:
                        ViewBag.Titulo = "Registro no encontrado";
                        ViewBag.Description = "La orden ya fue cancelada.";
                        break;

                    case 503:
                        ViewBag.Titulo = "Registro no encontrado";
                        ViewBag.Description = "La orden requiere un levantamiento.";
                        break;

                    default:
                        ViewBag.Titulo = "Página no encontrada";
                        ViewBag.Description = "Algo salio muy mal :( ..";
                        break;
                }

                return View("~/Views/ErrorPage/_ErrorPage.cshtml");
            }
            else
            {
                SessionHelper.DestroyUserSession();
                return Redirect("~/");
            }
        }

        // GET: ErrorPage
        public ActionResult ErrorNavegador()
        {
            return View();
        }
    }
}