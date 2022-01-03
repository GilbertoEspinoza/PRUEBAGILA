using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace DAO
{
    public class Usuarios
    {
        string strSQL;
        string strSQLPer;
        private ResponseModel rm;

        public Usuarios()
        {
            rm = new ResponseModel();
        }

        public ResponseModel Logins(string usuario, string clave)
        {
            Usuario objResult = new Usuario();
            strSQL = "sp_Login";
            DALConnection objConexion = new DALConnection();
            try
            {
                objConexion.Conn.ClearParameters();
                objConexion.Conn.AddParameter(new SqlParameter("@usuario", usuario));
                objConexion.Conn.AddParameter(new SqlParameter("@clave", clave));
                DataTable dtRes = objConexion.Conn.GetDataSet(strSQL, CommandType.StoredProcedure).Tables[0];
                DataRow row = null;
                if (dtRes != null)
                {
                    if (dtRes.Rows.Count > 0)
                    {
                        row = dtRes.Rows[0];
                        objResult = new Usuario();
                        BoundRow(ref objResult, row);
                    }
                    SessionHelper.AddUserToSession(objResult.Id.ToString());
                    rm.SetResponse(true);
                }
                else
                    rm.SetResponse(false, "Correo o contraseña incorrecta");
            }
            catch (Exception e)
            {
                objResult.MensajeError = "DAOUsuarios:Login()";
                Elog.save(this, e);
            }
            finally
            {
                objConexion.DisposeConn();
            }
            return rm;
        }

        public Usuario Login(string usuario, string clave)
        {
            Usuario objResult = new Usuario();
            strSQL = "sp_Login";
            DALConnection objConexion = new DALConnection();
            try
            {
                objConexion.Conn.ClearParameters();
                objConexion.Conn.AddParameter(new SqlParameter("@usuario", usuario));
                objConexion.Conn.AddParameter(new SqlParameter("@clave", clave));
                DataTable dtRes = objConexion.Conn.GetDataSet(strSQL, CommandType.StoredProcedure).Tables[0];

                if (dtRes != null)
                {
                    if (dtRes.Rows.Count > 0)
                    {
                        objResult.Id = int.Parse(dtRes.Rows[0]["id"].ToString());
                        objResult.Nombre = dtRes.Rows[0]["nombre"].ToString();
                        objResult.Correo = dtRes.Rows[0]["correo"].ToString();
                        objResult.CambiarCheck = Convert.ToBoolean(dtRes.Rows[0]["cambiar"].ToString());

                        List<Perfil> objResultPerfil = new List<Perfil>();
                        List<Modulo> objResultModulo = new List<Modulo>();

                        for (int x = 0; x < dtRes.Rows.Count; x++)
                        {
                            Perfil objPerfil = new Perfil();
                            Modulo objModulo = new Modulo();

                            if (int.Parse(dtRes.Rows[x]["perfil"].ToString()) > 0)
                            {
                                if (objResultPerfil.Count == 0)
                                {
                                    objPerfil.Id = int.Parse(dtRes.Rows[x]["perfil"].ToString());
                                    objResultPerfil.Add(objPerfil);
                                }
                                else
                                {
                                    if (!objResultPerfil[objResultPerfil.Count - 1].Id.ToString().Contains(dtRes.Rows[x]["perfil"].ToString()))
                                    {
                                        objPerfil.Id = int.Parse(dtRes.Rows[x]["perfil"].ToString());
                                        objResultPerfil.Add(objPerfil);
                                    }
                                }
                            }

                            if (int.Parse(dtRes.Rows[x]["modulo"].ToString()) > 0)
                            {

                                if (objResultModulo.Count == 0)
                                {
                                    objModulo.Id = int.Parse(dtRes.Rows[x]["modulo"].ToString());
                                    objResultModulo.Add(objModulo);
                                }
                                else
                                {
                                    if (!objResultModulo[objResultModulo.Count - 1].Id.ToString().Contains(dtRes.Rows[x]["modulo"].ToString()))
                                    {
                                        objModulo.Id = int.Parse(dtRes.Rows[x]["modulo"].ToString());
                                        objResultModulo.Add(objModulo);
                                    }
                                }

                            }

                        }

                        objResult.ListaPerfil = objResultPerfil;
                        objResult.ListaModulo = objResultModulo;
                    }
                }
            }
            catch (Exception e)
            {
                objResult.MensajeError = "DAOUsuarios:Login()";
                Elog.save(this, e);
            }
            finally
            {
                objConexion.DisposeConn();
            }
            return objResult;
        }

        public Usuario Loginss(string usuario, string clave)
        {
            Usuario objResult = new Usuario();
            strSQL = "sp_Login";
            DALConnection objConexion = new DALConnection();
            try
            {
                objConexion.Conn.ClearParameters();
                objConexion.Conn.AddParameter(new SqlParameter("@usuario", usuario));
                objConexion.Conn.AddParameter(new SqlParameter("@clave", clave));
                DataTable dtRes = objConexion.Conn.GetDataSet(strSQL, CommandType.StoredProcedure).Tables[0];
                DataRow row = null;
                if (dtRes != null)
                {
                    if (dtRes.Rows.Count > 0)
                    {
                        row = dtRes.Rows[0];
                        objResult = new Usuario();
                        BoundRow(ref objResult, row);
                    }
                }
            }
            catch (Exception e)
            {
                objResult.MensajeError = "DAOUsuarios:Login()";
                Elog.save(this, e);
            }
            finally
            {
                objConexion.DisposeConn();
            }
            return objResult;
        }

        public Usuario Obtener(int? id)
        {
            Usuario objResult = new Usuario();
            strSQL = "sp_ObtenerUsuario";
            DALConnection objConexion = new DALConnection();
            try
            {
                objConexion.Conn.ClearParameters();
                objConexion.Conn.AddParameter(new SqlParameter("@id", id));
                DataTable dtRes = objConexion.Conn.GetDataSet(strSQL, CommandType.StoredProcedure).Tables[0];
                DataRow row = null;
                if (dtRes != null)
                {
                    if (dtRes.Rows.Count > 0)
                    {
                        row = dtRes.Rows[0];
                        objResult = new Usuario();
                        BoundRow(ref objResult, row);
                    }
                }
            }
            catch (Exception e)
            {
                objResult.MensajeError = "DAOUsuarios:Obtener()";
                Elog.save(this, e);
            }
            finally
            {
                objConexion.DisposeConn();
            }
            return objResult;
        }

        public List<Usuario> ObtenerLista2(int? id)
        {
            List<Usuario> objResult = new List<Usuario>();
            strSQL = "sp_ObtenerListaUsuariosId";
            DALConnection objConexion = new DALConnection();
            try
            {
                objConexion.Conn.ClearParameters();
                objConexion.Conn.AddParameter(new SqlParameter("@id", id));
                DataTable dtRes = objConexion.Conn.GetDataSet(strSQL, CommandType.StoredProcedure).Tables[0];

                if (dtRes != null)
                {
                    if (dtRes.Rows.Count > 0)
                    {
                        for (int x = 0; x < dtRes.Rows.Count; x++)
                        {
                            Usuario objUser = new Usuario();
                            objUser.Id = int.Parse(dtRes.Rows[x]["id"].ToString());
                            objUser.Nombre = dtRes.Rows[x]["nombre"].ToString();
                            objUser.Correo = dtRes.Rows[x]["correo"].ToString();
                            objUser.ActivoString = dtRes.Rows[x]["activoString"].ToString();
                            objResult.Add(objUser);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Elog.save(this, e);
                throw;
            }
            finally
            {
                objConexion.DisposeConn();
            }
            return objResult;
        }

        public List<Usuario> ObtenerLista(int? id)
        {
            List<Usuario> objResult = new List<Usuario>();
            strSQL = "sp_UsuarioObtener";
            DALConnection objConexion = new DALConnection();
            try
            {
                objConexion.Conn.ClearParameters();
                DataTable dtRes = objConexion.Conn.GetDataSet(strSQL, CommandType.StoredProcedure).Tables[0];

                if (dtRes != null)
                {
                    if (dtRes.Rows.Count > 0)
                    {
                        for (int x = 0; x < dtRes.Rows.Count; x++)
                        {
                            Usuario objUser = new Usuario();
                            objUser.Id = int.Parse(dtRes.Rows[x]["id"].ToString());
                            objUser.Nombre = dtRes.Rows[x]["nombre"].ToString();
                            objUser.Correo = dtRes.Rows[x]["correo"].ToString();
                            objUser.TipoString = dtRes.Rows[x]["tipoString"].ToString();
                            objUser.Imagen = dtRes.Rows[x]["imagen"].ToString();
                            objUser.ActivoCheck = bool.Parse(dtRes.Rows[x]["activo"].ToString());
                            objUser.Activo = Convert.ToInt32(objUser.ActivoCheck);
                            objUser.ActivoString = dtRes.Rows[x]["activoString"].ToString();
                            objResult.Add(objUser);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Elog.save(this, e);
                throw;
            }
            finally
            {
                objConexion.DisposeConn();
            }
            return objResult;
        }

        public List<Usuario> ObtenerListaId(int? id)
        {
            List<Usuario> objResult = new List<Usuario>();
            strSQL = "sp_ObtenerListaUsuariosId";
            DALConnection objConexion = new DALConnection();
            try
            {
                objConexion.Conn.ClearParameters();
                objConexion.Conn.AddParameter(new SqlParameter("@id", id));
                DataTable dtRes = objConexion.Conn.GetDataSet(strSQL, CommandType.StoredProcedure).Tables[0];

                if (dtRes != null)
                {
                    if (dtRes.Rows.Count > 0)
                    {
                        for (int x = 0; x < dtRes.Rows.Count; x++)
                        {
                            Usuario objUs = new Usuario();
                            objUs.Id = int.Parse(dtRes.Rows[x]["id"].ToString());
                            objUs.Nombre = dtRes.Rows[x]["nombre"].ToString();
                            objUs.Correo = dtRes.Rows[x]["correo"].ToString();
                            objUs.Clave = dtRes.Rows[x]["clave"].ToString();
                            objUs.CreadoPor = int.Parse(dtRes.Rows[x]["creadopor"].ToString());
                            objUs.FechaRegistro = Convert.ToDateTime(dtRes.Rows[x]["fecharegistro"].ToString());
                            objUs.Activo = Convert.ToInt32(dtRes.Rows[x]["activo"]);
                            objUs.ActivoCheck = Convert.ToBoolean(dtRes.Rows[x]["activo"]);
                            objUs.ActivoString = dtRes.Rows[x]["activoString"].ToString();
                            objUs.UsuarioCreo = dtRes.Rows[x]["usuariocreo"].ToString();
                            objUs.UsuarioModifico = dtRes.Rows[x]["usuariomodifico"].ToString();
                            objUs.FechaCreacion = dtRes.Rows[x]["fechacreacion"].ToString();
                            objUs.FechaModificado = dtRes.Rows[x]["fechamodificado"].ToString();

                            objResult.Add(objUs);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Elog.save(this, e);
                throw;
            }
            finally
            {
                objConexion.DisposeConn();
            }
            return objResult;
        }

        public Usuario ObtenerPorId(int? id)
        {
            Usuario objResult = new Usuario();
            strSQL = "sp_ObtenerListaUsuariosId";
            DALConnection objConexion = new DALConnection();
            try
            {
                objConexion.Conn.ClearParameters();
                objConexion.Conn.AddParameter(new SqlParameter("@id", id));
                DataTable dtRes = objConexion.Conn.GetDataSet(strSQL, CommandType.StoredProcedure).Tables[0];

                if (dtRes != null)
                {
                    if (dtRes.Rows.Count > 0)
                    {
                        for (int x = 0; x < dtRes.Rows.Count; x++)
                        {
                            Usuario objUs = new Usuario();
                            objUs.Id = int.Parse(dtRes.Rows[x]["id"].ToString());
                            objUs.Nombre = dtRes.Rows[x]["nombre"].ToString();
                            objUs.Correo = dtRes.Rows[x]["correo"].ToString();
                            objUs.Clave = dtRes.Rows[x]["clave"].ToString();
                            objUs.CreadoPor = int.Parse(dtRes.Rows[x]["creadoPor"].ToString());
                            objUs.FechaRegistro = Convert.ToDateTime(dtRes.Rows[x]["fechaRegistro"].ToString());
                            objUs.Activo = Convert.ToInt32(dtRes.Rows[x]["activo"]);
                            objUs.ActivoCheck = Convert.ToBoolean(dtRes.Rows[x]["activo"]);
                            objUs.ActivoString = dtRes.Rows[x]["activoString"].ToString();
                            objUs.UsuarioCreo = dtRes.Rows[x]["usuarioCreo"].ToString();
                            objUs.UsuarioModifico = dtRes.Rows[x]["usuarioModifico"].ToString();
                            objUs.FechaCreacion = dtRes.Rows[x]["fechaCreacion"].ToString();
                            objUs.FechaModificado = dtRes.Rows[x]["fechaModificado"].ToString();
                            objResult = objUs;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Elog.save(this, e);
                throw;
            }
            finally
            {
                objConexion.DisposeConn();
            }
            return objResult;
        }

        public Usuario Guardar(Usuario objeto)
        {
            Usuario objResult = new Usuario();
            DataTable dtRes = null;
            strSQL = "sp_GuardarUsuario";
            DALConnection objConexion = new DALConnection();
            objConexion.Conn.BeginTransaction();
            try
            {
                objConexion.Conn.ClearParameters();
                objConexion.Conn.AddParameter(new SqlParameter("@id", objeto.Id));
                objConexion.Conn.AddParameter(new SqlParameter("@nombre", objeto.Nombre.ToLower()));
                objConexion.Conn.AddParameter(new SqlParameter("@correo", objeto.Correo.ToLower()));
                objConexion.Conn.AddParameter(new SqlParameter("@clave", objeto.Clave));
                objConexion.Conn.AddParameter(new SqlParameter("@cambiar", objeto.Cambiar));
                objConexion.Conn.AddParameter(new SqlParameter("@tipo", objeto.Tipo));
                objConexion.Conn.AddParameter(new SqlParameter("@imagen", Utilidades.ToDBNull2(objeto.Imagen)));
                objConexion.Conn.AddParameter(new SqlParameter("@activo", objeto.ActivoCheck));
                objConexion.Conn.AddParameter(new SqlParameter("@idUsuario", objeto.IdUsuario));

                dtRes = objConexion.Conn.GetDataSet(strSQL, CommandType.StoredProcedure).Tables[0];
                if (dtRes != null)
                {
                    objResult = objeto;
                    objResult.Id = int.Parse(dtRes.Rows[0][0].ToString());

                    if (objResult.Id <= 0)
                    {
                        objResult.MensajeError = dtRes.Rows[0][1].ToString();
                        objConexion.Conn.RollbackTransaction();
                    }
                    else
                    {
                        objResult.MensajeError = null;
                        objConexion.Conn.CommitTransaction();
                    }
                }
                else
                    objConexion.Conn.RollbackTransaction();
            }
            catch (Exception e)
            {
                objResult.MensajeError = "DAOUsuarios:Guardar()";
                objConexion.Conn.RollbackTransaction();
                Elog.save(this, e);
            }
            finally
            {
                objConexion.DisposeConn();
            }
            return objResult;
        }

        public Usuario GuardarUsuarioPerfil(Usuario objeto)
        {
            int id = 0;
            id = Convert.ToInt32(objeto.Id);
            Usuario objResult = new Usuario();
            DataTable dtRes = null;
            strSQL = "sp_GuardarUsuario";
            strSQLPer = "sp_GuardarUsuarioPerfil";
            DALConnection objConexion = new DALConnection();
            objConexion.Conn.BeginTransaction();
            try
            {
                objConexion.Conn.ClearParameters();
                objConexion.Conn.AddParameter(new SqlParameter("@id", objeto.Id));
                objConexion.Conn.AddParameter(new SqlParameter("@nombre", objeto.Nombre.ToLower()));
                objConexion.Conn.AddParameter(new SqlParameter("@correo", objeto.Correo.ToLower()));
                objConexion.Conn.AddParameter(new SqlParameter("@clave", objeto.Clave));
                objConexion.Conn.AddParameter(new SqlParameter("@cambiar", objeto.Cambiar));
                objConexion.Conn.AddParameter(new SqlParameter("@tipo", objeto.Tipo));
                objConexion.Conn.AddParameter(new SqlParameter("@imagen", Utilidades.ToDBNull2(objeto.Imagen)));
                objConexion.Conn.AddParameter(new SqlParameter("@activo", objeto.ActivoCheck));
                objConexion.Conn.AddParameter(new SqlParameter("@idUsuario", objeto.IdUsuario));

                dtRes = objConexion.Conn.GetDataSet(strSQL, CommandType.StoredProcedure).Tables[0];
                if (dtRes != null)
                {
                    objResult = objeto;
                    objResult.Id = int.Parse(dtRes.Rows[0][0].ToString());

                    if (objResult.Id <= 0)
                    {
                        objResult.MensajeError = dtRes.Rows[0][1].ToString();
                    }
                    else
                    {
                        //objResult.MensajeError = null;
                        //objConexion.Conn.CommitTransaction();

                        if (String.IsNullOrEmpty(objResult.MensajeError))
                        {
                            if (objeto.ListaPerfil.Count > 0)
                            {
                                dtRes = null;
                                foreach (var item in objeto.ListaPerfil)
                                {
                                    objConexion.Conn.ClearParameters();
                                    objConexion.Conn.AddParameter(new SqlParameter("@id", objeto.Id));
                                    objConexion.Conn.AddParameter(new SqlParameter("@idPerfil", item.Id));
                                    objConexion.Conn.AddParameter(new SqlParameter("@activo", 1));
                                    objConexion.Conn.AddParameter(new SqlParameter("@idUsuario", objeto.IdUsuario));

                                    dtRes = objConexion.Conn.GetDataSet(strSQLPer, CommandType.StoredProcedure).Tables[0];

                                    if (dtRes != null)
                                    {
                                        if (Convert.ToInt32(int.Parse(dtRes.Rows[0][0].ToString())) <= 0)
                                        {
                                            objResult.MensajeError = "Se genero un error.";
                                            break;
                                        }

                                    }
                                }
                            }

                            if (dtRes != null)
                            {
                                objResult = objeto;
                                objResult.Id = int.Parse(dtRes.Rows[0][0].ToString());
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                objResult.Id = id;
                objResult.MensajeError = "DAOUsuarios:GuardarUsuarioPerfil()";
                Elog.save(this, e);
            }
            finally
            {
                if (String.IsNullOrEmpty(objResult.MensajeError))
                    objConexion.Conn.CommitTransaction();
                else
                    objConexion.Conn.RollbackTransaction();

                objConexion.DisposeConn();
            }

            return objResult;
        }

        public Usuario GuardarPerfilUsuario(Usuario objeto)
        {
            int id = 0;
            id = Convert.ToInt32(objeto.Id);
            Usuario objResult = new Usuario();
            DataTable dtRes = null;
            strSQLPer = "sp_GuardarUsuarioPerfil";
            DALConnection objConexion = new DALConnection();
            objConexion.Conn.BeginTransaction();
            try
            {

                foreach (var item in objeto.ListaPerfil)
                {
                    objConexion.Conn.ClearParameters();
                    objConexion.Conn.AddParameter(new SqlParameter("@id", objeto.Id));
                    objConexion.Conn.AddParameter(new SqlParameter("@idPerfil", item.Id));
                    objConexion.Conn.AddParameter(new SqlParameter("@activo", 1));
                    objConexion.Conn.AddParameter(new SqlParameter("@idUsuario", objeto.IdUsuario));

                    dtRes = objConexion.Conn.GetDataSet(strSQLPer, CommandType.StoredProcedure).Tables[0];

                    if (dtRes != null)
                    {
                        if (Convert.ToInt32(int.Parse(dtRes.Rows[0][0].ToString())) <= 0)
                        {
                            objResult.MensajeError = "Se genero un error.";
                            break;
                        }

                    }
                }

                if (dtRes != null)
                {
                    objResult = objeto;
                    objResult.Id = int.Parse(dtRes.Rows[0][0].ToString());
                }

            }
            catch (Exception e)
            {
                objResult.Id = id;
                objResult.MensajeError = "DAOUsuarios:GuardarPerfilUsuario()";
                Elog.save(this, e);
            }
            finally
            {
                if (String.IsNullOrEmpty(objResult.MensajeError))
                    objConexion.Conn.CommitTransaction();
                else
                    objConexion.Conn.RollbackTransaction();

                objConexion.DisposeConn();
            }

            return objResult;
        }

        public Usuario ModificarImagen(Usuario objeto)
        {
            int id = 0;
            id = Convert.ToInt32(objeto.Id);
            Usuario objResult = new Usuario();
            DataTable dtRes = null;
            strSQL = "sp_ModificarImagenUsuario";
            DALConnection objConexion = new DALConnection();
            objConexion.Conn.BeginTransaction();
            try
            {
                objConexion.Conn.ClearParameters();
                objConexion.Conn.AddParameter(new SqlParameter("@id", objeto.Id));
                objConexion.Conn.AddParameter(new SqlParameter("@imagen", Utilidades.ToDBNull2(objeto.Imagen)));
                objConexion.Conn.AddParameter(new SqlParameter("@idUsuario", objeto.IdUsuario));

                dtRes = objConexion.Conn.GetDataSet(strSQL, CommandType.StoredProcedure).Tables[0];

                if (dtRes != null)
                {
                    objResult = objeto;
                    objResult.Id = int.Parse(dtRes.Rows[0][0].ToString());

                    if (Convert.ToInt32(objResult.Id) <= 0)
                    {
                        objResult.Id = id;
                        objResult.MensajeError = dtRes.Rows[0][1].ToString();
                        objConexion.Conn.RollbackTransaction();
                    }
                    else
                        objConexion.Conn.CommitTransaction();
                }

            }
            catch (Exception e)
            {
                objResult.Id = id;
                objResult.MensajeError = "DAOUsuarios:ModificarImagen()";
                objConexion.Conn.RollbackTransaction();
                Elog.save(this, e);
            }
            finally
            {
                objConexion.DisposeConn();
            }
            return objResult;
        }

        public Usuario UpdatePass(Usuario objeto)
        {
            Usuario objResult = new Usuario();
            DataTable dtRes = null;
            strSQL = "sp_UpdatePass";
            DALConnection objConexion = new DALConnection();
            objConexion.Conn.BeginTransaction();
            try
            {
                objConexion.Conn.ClearParameters();

                objConexion.Conn.AddParameter(new SqlParameter("@id", objeto.Id));
                objConexion.Conn.AddParameter(new SqlParameter("@clave", objeto.Clave));
                objConexion.Conn.AddParameter(new SqlParameter("@newClave", objeto.NewClave));

                dtRes = objConexion.Conn.GetDataSet(strSQL, CommandType.StoredProcedure).Tables[0];
                if (dtRes != null)
                {
                    objResult = objeto;
                    objResult.Id = int.Parse(dtRes.Rows[0][0].ToString());
                    if (int.Parse(dtRes.Rows[0][0].ToString()) <= 0)
                    {
                        objResult.MensajeError = dtRes.Rows[0][1].ToString();
                        objConexion.Conn.RollbackTransaction();
                    }
                    else
                        objConexion.Conn.CommitTransaction();

                }
            }
            catch (Exception e)
            {
                objResult.MensajeError = "DAOUsuarios:UpdatePass()";
                objConexion.Conn.RollbackTransaction();
                Elog.save(this, e);
            }
            finally
            {
                objConexion.DisposeConn();
            }
            return objResult;
        }

        public Usuario ResetPass(Usuario objeto)
        {
            Usuario objResult = new Usuario();
            DataTable dtRes = null;
            strSQL = "sp_ResetPass";
            DALConnection objConexion = new DALConnection();
            objConexion.Conn.BeginTransaction();
            try
            {
                objConexion.Conn.ClearParameters();

                objConexion.Conn.AddParameter(new SqlParameter("@correo", objeto.Correo));
                objConexion.Conn.AddParameter(new SqlParameter("@idUsuario", objeto.IdUsuario));

                dtRes = objConexion.Conn.GetDataSet(strSQL, CommandType.StoredProcedure).Tables[0];
                if (dtRes != null)
                {
                    objResult = objeto;
                    objResult.Id = int.Parse(dtRes.Rows[0][0].ToString());
                    if (int.Parse(dtRes.Rows[0][0].ToString()) <= 0)
                    {
                        objResult.MensajeError = dtRes.Rows[0][1].ToString();
                        objConexion.Conn.RollbackTransaction();
                    }
                    else
                        objConexion.Conn.CommitTransaction();

                }
            }
            catch (Exception e)
            {
                objResult.MensajeError = "DAOUsuarios:ResetPass()";
                objConexion.Conn.RollbackTransaction();
                Elog.save(this, e);
            }
            finally
            {
                objConexion.DisposeConn();
            }
            return objResult;
        }

        public Usuario ModifcarEstatus(Usuario objeto)
        {
            int id = 0;
            id = Convert.ToInt32(objeto.Id);
            Usuario objResult = new Usuario();
            DataTable dtRes = null;
            strSQL = "sp_ModificarEstatusUsuario";
            DALConnection objConexion = new DALConnection();
            objConexion.Conn.BeginTransaction();
            try
            {
                objConexion.Conn.ClearParameters();
                objConexion.Conn.AddParameter(new SqlParameter("@id", objeto.Id));
                objConexion.Conn.AddParameter(new SqlParameter("@activo", objeto.Activo));
                objConexion.Conn.AddParameter(new SqlParameter("@idUsuario", objeto.IdUsuario));

                dtRes = objConexion.Conn.GetDataSet(strSQL, CommandType.StoredProcedure).Tables[0];
                if (dtRes != null)
                {
                    objResult = objeto;
                    objResult.Id = int.Parse(dtRes.Rows[0][0].ToString());

                    if (Convert.ToInt32(objResult.Id) == 0)
                    {
                        objResult.Id = id;
                        objResult.MensajeError = dtRes.Rows[0][1].ToString();
                        objConexion.Conn.RollbackTransaction();
                    }
                    else if (Convert.ToInt32(objResult.Id) < 0)
                    {
                        objResult.Id = id;
                        objResult.MensajeError = dtRes.Rows[0][1].ToString();
                        objConexion.Conn.RollbackTransaction();
                    }
                    else
                        objConexion.Conn.CommitTransaction();
                }
            }
            catch (Exception e)
            {
                objResult.Id = id;
                objResult.MensajeError = "DAOUsuarios:ModifcarEstatus()";
                objConexion.Conn.RollbackTransaction();
                Elog.save(this, e);
            }
            finally
            {
                objConexion.DisposeConn();
            }
            return objResult;
        }

        private void BoundRow(ref Usuario objeto, DataRow row)
        {
            objeto.Id = int.Parse(row["id"].ToString());
            objeto.Nombre = row["nombre"].ToString();
            objeto.Perfil = new Perfil();
            objeto.Perfil.Id = int.Parse(row["perfil"].ToString());
            objeto.Modulos = new Modulo();
            objeto.Modulos.Id = int.Parse(row["modulo"].ToString());
            //objeto.Puesto = new Puesto();
            //objeto.Fecha = row["Fecha"] == null || row["Fecha"].ToString() == "" ? "" : row["Fecha"].ToString();
        }
    }
}
