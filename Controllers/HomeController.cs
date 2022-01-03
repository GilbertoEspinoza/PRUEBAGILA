using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Entities;
using DAO;
using PRUEBAGILA.Models;
using Filters;
using System.Net;

namespace PRUEBAGILA.Controllers
{
    public class HomeController : Controller
    {

        [Autenticado]
        public ActionResult Index()
        {
            if (Session["DataUser"] != null)
            {
                ViewData["Message"] = "Le damos la bienvenida al Sistema Integral Registros (SIR), para gila software.";
                ViewData["Descripcion"] = "Dashboard SIR";

                Usuario ob = (Usuario)Session["DataUser"];

                ViewData["DataUserName"] = ob.Nombre.ToUpper();
                ViewData["DataUsers"] = ob.Correo.ToUpper();

                return View();
            }
            else
            {
                SessionHelper.DestroyUserSession();
                return Redirect("~/");
            }
        }

        [HttpPost]
        public JsonResult Do()
        {
            var fecha = DateTime.Now;
            return Json(fecha.ToString());
        }

        [HttpPost]
        public JsonResult CheckChange()
        {
            var resultado = new JsonResult();
            if (Session["DataUser"] != null)
            {
                Usuario ob = (Usuario)Session["DataUser"];
                resultado.Data = new { mensaje = ob.CambiarCheck };
            }
            else
            {
                resultado.Data = new { mensaje = 0 };
            }
            return resultado;
        }

        
    }
}