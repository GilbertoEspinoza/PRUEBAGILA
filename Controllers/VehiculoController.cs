using Common;
using Entities;
using DAO;
using Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PRUEBAGILA.Controllers
{
    public class VehiculoController : Controller
    {
        readonly int idPag =5;
        private Lineas objLineas = new Lineas();
        private Marcas objMarcas = new Marcas();
        private TipoVehiculos objTipoVehiculos = new TipoVehiculos();
        private TipoUsoVehiculos objTipoUsoVehiculos = new TipoUsoVehiculos();
        private Combustibles objCombustibles = new Combustibles();
        private Vehiculos objVehiculo = new Vehiculos();
        // GET: Vehiculo
        public ActionResult Index()
        {
            if (Session["DataUser"] != null)
            {
                List<Modulo> permisos = Session["modulos"] as List<Modulo>;

                if (!Util.validarActions(idPag, permisos, Util.Vars.Consultar))
                    return RedirectToAction("NotPermission", "ErrorPage");

                Usuario ob = (Usuario)Session["DataUser"];

                ViewBag.tipo = Utilidades.AddFirstItems(new SelectList(objTipoVehiculos.ObtenerListaCombo(0), "Nombre", "Nombre"));
                ViewData["DataUserName"] = ob.Nombre.ToUpper();
                ViewData["DataUsers"] = ob.Correo.ToUpper();
                ViewBag.Add = Util.validarActions(idPag, permisos, Util.Vars.Agregar);
                ViewBag.Mof = Convert.ToInt16(Util.validarActions(idPag, permisos, Util.Vars.Modificar));

                return View();
            }
            else
            {
                SessionHelper.DestroyUserSession();
                return Redirect("~/");
            }
        }

        [Autenticado]
        public ActionResult NuevoVehiculo()
        {
            if (Session["DataUser"] != null)
            {
                List<Modulo> permisos = Session["modulos"] as List<Modulo>;

                if (!Util.validarActions(idPag, permisos, Util.Vars.Agregar))
                    return RedirectToAction("NotAdd", "ErrorPage");

                List<Linea> objLineaList = new List<Linea>();
                List<Vehiculo> objVehiculoList = new List<Vehiculo>();
                Usuario ob = (Usuario)Session["DataUser"];

                ViewBag.IdAccesorio = Utilidades.AddFirstItem(new SelectList(objVehiculoList, "Id", "Nombre"));
                ViewBag.IdLinea = Utilidades.AddFirstItem(new SelectList(objLineaList, "Id", "Nombre"));
                ViewBag.IdMarca = Utilidades.AddFirstItem(new SelectList(objMarcas.ObtenerLista(2), "Id", "Nombre"));
                ViewBag.IdTipo = Utilidades.AddFirstItem(new SelectList(objTipoVehiculos.ObtenerLista(2), "Id", "Nombre"));
                ViewBag.IdTipoUSo = Utilidades.AddFirstItem(new SelectList(objTipoUsoVehiculos.ObtenerListaCombo(0), "Id", "Nombre"));
                ViewBag.IdTipoCombustible = Utilidades.AddFirstItem(new SelectList(objCombustibles.ObtenerLista(2), "Id", "Nombre"));
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

        [Autenticado]
        public ActionResult EditarVehiculo(int? id)
        {
            if (Session["DataUser"] != null)
            {
                List<Modulo> permisos = Session["modulos"] as List<Modulo>;

                if (!Util.validarActions(idPag, permisos, Util.Vars.Modificar))
                    return RedirectToAction("NotPermission", "ErrorPage");

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Usuario ob = (Usuario)Session["DataUser"];

               Vehiculos obj = new Vehiculos();

                var comEdit = obj.ObtenerPorId(id);

                ViewBag.IdMarca = Utilidades.AddFirstItem(new SelectList(objMarcas.ObtenerListaCombo(comEdit.IdMarca), "Id", "Nombre"), comEdit.IdMarca);
                ViewBag.IdLinea = Utilidades.AddFirstItem(new SelectList(objLineas.ObtenerListaCombo(comEdit.IdLinea, comEdit.IdMarca), "Id", "Nombre"), comEdit.IdLinea);
                ViewBag.IdAccesorio = Utilidades.AddFirstItem(new SelectList(objVehiculo.ObtenerListaComboAccesorios(0, comEdit.IdAccesorio), "Id", "Nombre"), comEdit.IdAccesorio);
                ViewBag.IdTipoUso = Utilidades.AddFirstItem(new SelectList(objTipoUsoVehiculos.ObtenerListaCombo(comEdit.IdTipoUso), "Id", "Nombre"), comEdit.IdTipoUso);
                ViewBag.IdTipo = Utilidades.AddFirstItem(new SelectList(objTipoVehiculos.ObtenerListaCombo(comEdit.IdTipo), "Id", "Nombre"), comEdit.IdTipo);
                ViewBag.IdTipoCombustible = Utilidades.AddFirstItem(new SelectList(objCombustibles.ObtenerListaCombo(comEdit.IdTipoCombustible), "Id", "nombre"), comEdit.IdTipoCombustible);

                ViewData["DataUserName"] = ob.Nombre.ToUpper();
                ViewData["DataUsers"] = ob.Correo.ToUpper();

                return View(comEdit);
            }
            else
            {
                SessionHelper.DestroyUserSession();
                return Redirect("~/");
            }
        }

        [Autenticado]
        public ActionResult DetailsVehiculo(int? id)
        {
            if (Session["DataUser"] != null)
            {
                List<Modulo> permisos = Session["modulos"] as List<Modulo>;

                if (!Util.validarActions(idPag, permisos, Util.Vars.Consultar))
                    return RedirectToAction("NotPermission", "ErrorPage");

                Vehiculos obj = new Vehiculos();
                var cates = obj.ObtenerPorId(id);

                Usuario ob = (Usuario)Session["DataUser"];

                ViewData["DataUserName"] = ob.Nombre.ToUpper();
                ViewData["DataUsers"] = ob.Correo.ToUpper();

                return View(cates);
            }
            else
            {
                SessionHelper.DestroyUserSession();
                return Redirect("~/");
            }
        }

        [HttpPost]
        public JsonResult GetJsonLineas(int idMarca)
        {
            var data = Utilidades.AddFirstItems(new SelectList(objLineas.ObtenerListaCombo(0, idMarca), "Id", "Nombre"));
            return Json(data);
        }

        [HttpPost]
        public JsonResult GetJsonVehiculos(int id, int idTipo)
        {
            var data = Utilidades.AddFirstItems(new SelectList(objVehiculo.ObtenerListaComboAccesorios(id, idTipo), "Id", "Nombre"));
            return Json(data);
        }

        [HttpPost]
        public JsonResult PostJsonVehiculo()
        {
            Vehiculos obj = new Vehiculos();
            var data = obj.ObtenerLista(1);

            return Json(data);
        }

        [HttpPost]
        public JsonResult PostJsonVehiculoId(int id)
        {
            Vehiculos obj = new Vehiculos();
            var data = obj.ObtenerPorId(id);

            return Json(data);
        }

        [HttpPost]
        public JsonResult GuardarVehiculo(Vehiculo model)
        {
            var resultado = new JsonResult();
            if (Session["DataUser"] != null)
            {
                Usuario ob = (Usuario)Session["DataUser"];
                Vehiculos obj = new Vehiculos();
                Vehiculo objTotalConteo = new Vehiculo();
                model.IdUsuario = ob.Id;
                model.ActivoCheck = Convert.ToBoolean(model.Activo);
                //model.Activo = 1;
                //model.ActivoCheck = true;

                objTotalConteo = obj.Guardar(model);

                if (string.IsNullOrEmpty(objTotalConteo.MensajeError))
                {
                    resultado.Data = new { mensaje = 1 };
                }
                else
                {
                    resultado.Data = new { mensaje = 0, errorMensaje = objTotalConteo.MensajeError };
                }
            }
            else
            {
                resultado.Data = new { mensaje = -1, errorMensaje = "TU SESIÓN HA EXPIRADO." };
            }
            return resultado;
        }
    }
}