using Common;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{

    public class UsuariosModulos
    {
        string strSQL;
        private ResponseModel rm;


        public UsuariosModulos()
        {
            rm = new ResponseModel();
        }

        public List<UsuarioModulo> ObtenerLista(int? id)
        {
            List<UsuarioModulo> objResult = new List<UsuarioModulo>();
            strSQL = "sp_ObtenerListaModulosUsuarios";
            DALConnection objConexion = new DALConnection();
            try
            {
                objConexion.Conn.ClearParameters();
                objConexion.Conn.AddParameter(new SqlParameter("@id", id));
                objConexion.Conn.AddParameter(new SqlParameter("@idSelector", 1));
                DataTable dtRes = objConexion.Conn.GetDataSet(strSQL, CommandType.StoredProcedure).Tables[0];

                if (dtRes != null)
                {
                    if (dtRes.Rows.Count > 0)
                    {
                        for (int x = 0; x < dtRes.Rows.Count; x++)
                        {
                            UsuarioModulo objPro = new UsuarioModulo();
                            objPro.Idusuariomodulo = int.Parse(dtRes.Rows[x]["idUM"].ToString());
                            objPro.IdUsuario = int.Parse(dtRes.Rows[x]["idUsuario"].ToString());
                            objPro.Nombre = dtRes.Rows[x]["nombre"].ToString();
                            objPro.IdModulo = int.Parse(dtRes.Rows[x]["idModulo"].ToString());
                            objPro.Modulo = dtRes.Rows[x]["modulo"].ToString();
                            objPro.CreadoPor = int.Parse(dtRes.Rows[x]["creadoPor"].ToString());
                            objPro.CreadoPorUsuario = dtRes.Rows[x]["CreadoPorUsuario"].ToString();
                            objPro.FechaRegistro =Convert.ToDateTime(dtRes.Rows[x]["fechaRegistro"].ToString());
                            //objPro.ModificadoPor = int.Parse(dtRes.Rows[x]["modificadoPor"].ToString());
                            objPro.Modifico = dtRes.Rows[x]["Modifico"].ToString();
                            //objPro.FechaModificacion = DateTime.Parse(dtRes.Rows[x]["fechaModificacion"].ToString());
                            objPro.Activo = Convert.ToInt32(dtRes.Rows[x]["activo"]);
                            objPro.ActivoString = dtRes.Rows[x]["activoString"].ToString();

                            objResult.Add(objPro);
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

        public UsuarioModulo ObtenerNombre(int? id)
        {
            UsuarioModulo objResult = new UsuarioModulo();
            strSQL = "sp_ObtenerListaPerfilesUsuarioPorNombre";
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

                            UsuarioModulo objPro = new UsuarioModulo();
                            objPro.NombreUsuario = dtRes.Rows[x]["nombre"].ToString();
                            objPro.IdUsuario = int.Parse(dtRes.Rows[x]["id"].ToString());

                            objResult = objPro;
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

        public UsuarioModulo ObtenerPorId(int? id)
        {
            UsuarioModulo objResult = new UsuarioModulo();
            strSQL = "sp_ObtenerListaModulosUsuarios";
            DALConnection objConexion = new DALConnection();
            try
            {
                objConexion.Conn.ClearParameters();
                objConexion.Conn.AddParameter(new SqlParameter("@id", id));
                objConexion.Conn.AddParameter(new SqlParameter("@idSelector", 2));
                DataTable dtRes = objConexion.Conn.GetDataSet(strSQL, CommandType.StoredProcedure).Tables[0];

                if (dtRes != null)
                {
                    if (dtRes.Rows.Count > 0)
                    {
                        for (int x = 0; x < dtRes.Rows.Count; x++)
                        {

                            UsuarioModulo objPro = new UsuarioModulo();
                            objPro.Idusuariomodulo = int.Parse(dtRes.Rows[x]["idUM"].ToString());
                            objPro.IdUsuario = int.Parse(dtRes.Rows[x]["idUsuario"].ToString());
                            objPro.Nombre = dtRes.Rows[x]["nombre"].ToString();
                            objPro.IdModulo = int.Parse(dtRes.Rows[x]["idModulo"].ToString());
                            objPro.Modulo = dtRes.Rows[x]["modulo"].ToString();
                            objPro.CreadoPor = int.Parse(dtRes.Rows[x]["creadoPor"].ToString());
                            objPro.CreadoPorUsuario = dtRes.Rows[x]["CreadoPorUsuario"].ToString();
                            objPro.FechaRegistro = Convert.ToDateTime(dtRes.Rows[x]["fechaRegistro"].ToString());
                            //objPro.ModificadoPor = int.Parse(dtRes.Rows[x]["modificadoPor"].ToString());
                            objPro.Modifico = dtRes.Rows[x]["Modifico"].ToString();
                            objPro.FechaModificacion = Convert.ToDateTime(dtRes.Rows[x]["fechaModificacion"].ToString());
                            objPro.Activo = Convert.ToInt32(dtRes.Rows[x]["activo"]);
                            objPro.ActivoString = dtRes.Rows[x]["activoString"].ToString();

                            objResult = objPro;
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

        public List<UsuarioPerfil> ObtenerListaPerfiles()
        {

            List<UsuarioPerfil> objResult = new List<UsuarioPerfil>();
            strSQL = "sp_ObtenerListaPerfilesParaUsuarios";
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
                            UsuarioPerfil objPro = new UsuarioPerfil();
                            objPro.IdPerfil = int.Parse(dtRes.Rows[x]["id"].ToString());
                            objPro.Perfil = dtRes.Rows[x]["perfil"].ToString();

                            objResult.Add(objPro);
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

        public List<UsuarioModulo> ObtenerListaUsuariosModulosActivos(int? id)
        {

            List<UsuarioModulo> objResult = new List<UsuarioModulo>();
            strSQL = "sp_ObtenerListaUsuariosModulosActivos";
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
                            UsuarioModulo objPro = new UsuarioModulo();
                            objPro.IdModulo = int.Parse(dtRes.Rows[x]["id"].ToString());
                            objPro.Modulo = dtRes.Rows[x]["modulo"].ToString();
                            objPro.Check = dtRes.Rows[x]["estado"].ToString();

                            objResult.Add(objPro);
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

        public UsuarioModulo Guardar(UsuarioModulo objeto)
        {
            UsuarioModulo objResult = new UsuarioModulo();
            DataTable dtRes = null;
            strSQL = "sp_GuardarUsuarioModulo";
            DALConnection objConexion = new DALConnection();
            objConexion.Conn.BeginTransaction();
            try
            {
                objConexion.Conn.ClearParameters();

                objConexion.Conn.AddParameter(new SqlParameter("@idU", objeto.IdUsuario));
                objConexion.Conn.AddParameter(new SqlParameter("@idM", objeto.IdModulo));
                objConexion.Conn.AddParameter(new SqlParameter("@activo", objeto.Activo));
                objConexion.Conn.AddParameter(new SqlParameter("@idUsuario", objeto.ModificadoPor));
                
                dtRes = objConexion.Conn.GetDataSet(strSQL, CommandType.StoredProcedure).Tables[0];
                objConexion.Conn.CommitTransaction();
                //if (dtRes != null)
                //{
                //    objResult = objeto;
                //    objResult.Id = int.Parse(dtRes.Rows[0][0].ToString());
                //}
            }
            catch (Exception e)
            {
                objResult.MensajeError = "DAOCatalagos:Guardar()";
                objConexion.Conn.RollbackTransaction();
                Elog.save(this, e);
            }
            finally
            {
                objConexion.DisposeConn();
            }
            return objResult;
        }

    }
}
