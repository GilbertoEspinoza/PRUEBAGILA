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
using System.IO;

namespace PRUEBAGILA.Controllers
{
    public class UsuarioController : Controller
    {
        readonly int idPag = 1;

        // GET: Estudiante
        [Autenticado]
        public ActionResult Index()
        {
            if (Session["DataUser"] != null)
            {
                List<Modulo> permisos = Session["modulos"] as List<Modulo>;

                if (!Util.validarActions(idPag, permisos, Util.Vars.Consultar))
                    return RedirectToAction("NotPermission", "ErrorPage");

                Usuario ob = (Usuario)Session["DataUser"];

                ViewData["DataUserName"] = ob.Nombre.ToUpper();
                ViewData["DataUsers"] = ob.Correo.ToUpper();

                ViewData["Descripcion"] = "Listado de usuarios";

                ViewBag.Add = Util.validarActions(idPag,permisos,Util.Vars.Agregar);
                ViewBag.Edit = Convert.ToInt16(Util.validarActions(idPag, permisos, Util.Vars.Modificar));
                ViewBag.Det = Convert.ToInt16(Util.validarActions(idPag, permisos, Util.Vars.Eliminar));
                return View();
            }
            else
            {
                SessionHelper.DestroyUserSession();
                return Redirect("~/");
            }
        }

        [Autenticado]
        public ActionResult Nuevo()
        {
            if (Session["DataUser"] != null)
            {
                List<Modulo> permisos = Session["modulos"] as List<Modulo>;

                if (!Util.validarActions(idPag, permisos, Util.Vars.Agregar))
                    return RedirectToAction("NotPermission", "ErrorPage");

                Usuario ob = (Usuario)Session["DataUser"];

                Perfiles objPerfiles = new Perfiles();
                ViewBag.tipo = Common.Utilidades.DropDownTipoUsuario(0);
                Usuario objUser = new Usuario();
                Perfil objP = new Perfil();
                var tupleModel = new Tuple<Usuario, List<Perfil>>(objUser, objPerfiles.ObtenerLista(1));

                ViewData["DataUserName"] = ob.Nombre.ToUpper();
                ViewData["DataUsers"] = ob.Correo.ToUpper();
                ViewData["Descripcion"] = "Agregar usuario";

                Session["modulos"] = permisos;
                //return View();
                return View(tupleModel);
            }
            else
            {
                SessionHelper.DestroyUserSession();
                return Redirect("~/");
            }
        }


        [HttpPost]
        public JsonResult Resert(Usuario model)
        {
            var resultado = new JsonResult();
            if (Session["DataUser"] != null)
            {
                Usuario objeto = new Usuario();
                Usuarios obj = new Usuarios();
                Usuario ob = (Usuario)Session["DataUser"];
                objeto = model;
                objeto.Id = ob.Id;
                objeto.Clave = HashHelper.MD5(model.Clave);
                objeto.NewClave = HashHelper.MD5(model.NewClave);

                objeto = obj.UpdatePass(objeto);

                if (string.IsNullOrEmpty(objeto.MensajeError))
                {
                    resultado.Data = new { mensaje = 1 };
                }
                else
                {
                    resultado.Data = new { mensaje = 0, errorMensaje = objeto.MensajeError };
                }
            }
            else
            {
                resultado.Data = new { mensaje = -1, errorMensaje = "TU SESIÓN HA EXPIRADO." };
            }
            return resultado;
        }

        [HttpPost]
        public JsonResult GetJsonUsuario()
        {
            Usuarios obj = new Usuarios();
            var data = obj.ObtenerLista(1);
            return Json(data);
        }

        [HttpPost]
        public JsonResult ModicarEstatus(Usuario model)
        {
            var resultado = new JsonResult();
            if (Session["DataUser"] != null)
            {
                Usuario ob = (Usuario)Session["DataUser"];
                model.IdUsuario = ob.Id;

                Usuarios obj = new Usuarios();
                Usuario objTotalConteo = new Usuario();

                objTotalConteo = obj.ModifcarEstatus(model);

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

        [HttpPost]
        public JsonResult ResertPass(Usuario model)
        {
            var resultado = new JsonResult();
            if (Session["DataUser"] != null)
            {
                Usuario objeto = new Usuario();
                Usuarios obj = new Usuarios();
                Usuario ob = (Usuario)Session["DataUser"];
                objeto = model;
                objeto.IdUsuario = ob.Id;

                objeto = obj.ResetPass(objeto);

                if (string.IsNullOrEmpty(objeto.MensajeError))
                {
                    resultado.Data = new { mensaje = 1 };
                }
                else
                {
                    resultado.Data = new { mensaje = 0, errorMensaje = objeto.MensajeError };
                }
            }
            else
            {
                resultado.Data = new { mensaje = -1, errorMensaje = "TU SESIÓN HA EXPIRADO." };
            }
            return resultado;
        }

        [HttpPost]
        public JsonResult GuardarUsuario(Usuario model)
        {
            var resultado = new JsonResult();
            int id = model.Id;
            if (Session["DataUser"] != null)
            {
                Usuario ob = (Usuario)Session["DataUser"];
                Usuarios obj = new Usuarios();
                Usuario objTotalConteo = new Usuario();
                model.IdUsuario = ob.Id;
               

                if (model.Id == 0)
                {
                    if (Request.Files.Count > 0)
                    {
                        model.Clave = HashHelper.MD5(model.Clave);
                        model.Cambiar = 0;
                        model.Activo = 1;
                        objTotalConteo = obj.Guardar(model);
                        if (string.IsNullOrEmpty(objTotalConteo.MensajeError))
                        {
                            var pathDir = @"\Documentos\Usuarios\";
                            var upload = false;
                            var fileExte = "";
                            var filename = "";
                            var fileFull = "";
                            try
                            {
                                var file = Request.Files[0];
                                fileExte = Path.GetExtension(file.FileName);
                                var fileName = Path.GetFileNameWithoutExtension(file.FileName.Replace(' ', '-'));
                                if (!String.IsNullOrEmpty(fileName))
                                {
                                    //if (String.IsNullOrEmpty(fileExte))
                                    //    fileExte = MimeTypeMap.GetExtension(file.ContentType);

                                    filename = objTotalConteo.Id.ToString() + "_" + objTotalConteo.Nombre.Substring(0, 5);

                                    //pathDir += Util.folder(fileExte.Substring(1, fileExte.Length - 1)) + @"\";

                                    DirectoryInfo di = new DirectoryInfo(Server.MapPath(@"~\" + pathDir));

                                    if (!Directory.Exists(Server.MapPath(@"~\" + pathDir)))
                                    {
                                        Directory.CreateDirectory(Server.MapPath(@"~\" + pathDir));
                                    }

                                    fileFull = filename.Trim() + fileExte;

                                    var path = Path.Combine(Server.MapPath(@"~\" + pathDir), fileFull);

                                    if (Util.FileExistsCaseSensitive(path))
                                    {
                                        string search = filename.Trim() + "*" + fileExte;
                                        FileInfo[] Files = di.GetFiles(search, SearchOption.AllDirectories);
                                        fileFull = filename.Trim() + "(" + (Files.Length + 1).ToString() + ")" + fileExte;
                                        path = Path.Combine(Server.MapPath(@"~\" + pathDir), fileFull);
                                    }

                                    file.SaveAs(path);
                                    upload = true;
                                }
                            }
                            catch (Exception ex) { upload = false; }

                            if (upload)
                            {
                                Usuario objPerIma = new Usuario();
                                Usuario objPerImaR = new Usuario();
                                objPerIma.Id = objTotalConteo.Id;
                                objPerIma.Imagen = pathDir + fileFull;
                                objPerIma.IdUsuario = objTotalConteo.IdUsuario;

                                objPerImaR = obj.ModificarImagen(objPerIma);
                                if (objPerImaR.Id <= 0)
                                {
                                    objTotalConteo.MensajeError = objPerImaR.MensajeError;
                                }
                            }
                        }
                    }
                    else
                    {
                        model.Imagen = null;
                        objTotalConteo = obj.Guardar(model);
                    }
                }
                else
                {
                    objTotalConteo = obj.Guardar(model);
                    objTotalConteo.Id = id;
                }

                if (string.IsNullOrEmpty(objTotalConteo.MensajeError))
                {
                    resultado.Data = new { mensaje = 1, id = objTotalConteo.Id };
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

        [HttpPost]
        public JsonResult GuardarImagen(Usuario model)
        {
            var resultado = new JsonResult();
            int id = model.Id;
            if (Session["DataUser"] != null)
            {
                Usuario ob = (Usuario)Session["DataUser"];
                Usuarios obj = new Usuarios();
                Usuario objTotalConteo = new Usuario();
                model.IdUsuario = ob.Id;

                if (Request.Files.Count > 0)
                {
                    var pathDir = @"\Documentos\Usuarios\";
                    var upload = false;
                    var fileExte = "";
                    var filename = "";
                    var fileFull = "";
                    try
                    {
                        var file = Request.Files[0];
                        fileExte = Path.GetExtension(file.FileName);
                        var fileName = Path.GetFileNameWithoutExtension(file.FileName.Replace(' ', '-'));
                        if (!String.IsNullOrEmpty(fileName))
                        {
                            //if (String.IsNullOrEmpty(fileExte))
                            //    fileExte = MimeTypeMap.GetExtension(file.ContentType);

                            filename = model.Id.ToString() + "_" + model.Nombre.Substring(0, 5);

                            DirectoryInfo di = new DirectoryInfo(Server.MapPath(@"~\" + pathDir));

                            if (!Directory.Exists(Server.MapPath(@"~\" + pathDir)))
                            {
                                Directory.CreateDirectory(Server.MapPath(@"~\" + pathDir));
                            }

                            fileFull = filename.Trim() + fileExte;

                            var path = Path.Combine(Server.MapPath(@"~\" + pathDir), fileFull);

                            if (Util.FileExistsCaseSensitive(path))
                            {
                                string search = filename.Trim() + "*" + fileExte;
                                FileInfo[] Files = di.GetFiles(search, SearchOption.AllDirectories);
                                fileFull = filename.Trim() + "(" + (Files.Length + 1).ToString() + ")" + fileExte;
                                path = Path.Combine(Server.MapPath(@"~\" + pathDir), fileFull);
                            }

                            file.SaveAs(path);
                            upload = true;
                        }
                    }
                    catch (Exception ex) { upload = false; }

                    if (upload)
                    {
                        Usuario objPerIma = new Usuario();
                        Usuario objPerImaR = new Usuario();
                        objPerIma.Id = model.Id;
                        objPerIma.Imagen = pathDir + fileFull;
                        objPerIma.IdUsuario = model.IdUsuario;

                        objPerImaR = obj.ModificarImagen(objPerIma);
                        if (objPerImaR.Id <= 0)
                        {
                            objTotalConteo.MensajeError = objPerImaR.MensajeError;

                            if (Directory.Exists(Server.MapPath(@"~\" + pathDir + fileFull)))
                                Directory.Delete(Server.MapPath(@"~\" + pathDir + fileFull));
                        }

                        if (string.IsNullOrEmpty(objTotalConteo.MensajeError))
                        {
                            resultado.Data = new { mensaje = 1, id = objTotalConteo.Id };
                        }
                        else
                        {
                            resultado.Data = new { mensaje = 0, errorMensaje = objTotalConteo.MensajeError };
                        }
                    }
                }
                else
                {
                    objTotalConteo.MensajeError = "SIN ARCHIVO PARA SUBIR";
                }

                if (string.IsNullOrEmpty(objTotalConteo.MensajeError))
                {
                    resultado.Data = new { mensaje = 1, id = objTotalConteo.Id };
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

        [HttpPost]
        public JsonResult GuardaUsuarioPerfil(Usuario model, int[] perfil)
        {
            var resultado = new JsonResult();
            if (Session["DataUser"] != null)
            {
                Usuario ob = (Usuario)Session["DataUser"];
                Usuarios obj = new Usuarios();
                Usuario objTotalConteo = new Usuario();
                model.IdUsuario = ob.Id;
                model.ListaPerfil = new List<Perfil>();
                foreach (var c in perfil)
                {
                    Perfil objPer = new Perfil();
                    objPer.Id = Convert.ToInt32(c);
                    model.ListaPerfil.Add(objPer);
                }

                objTotalConteo = obj.GuardarPerfilUsuario(model);

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