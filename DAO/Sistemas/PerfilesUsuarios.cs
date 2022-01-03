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

    public class PerfilesUsuarios
    {
        string strSQL;
        private ResponseModel rm;


        public PerfilesUsuarios()
        {
            rm = new ResponseModel();
        }

        public List<UsuarioPerfil> ObtenerLista(int? id)
        {
            List<UsuarioPerfil> objResult = new List<UsuarioPerfil>();
            strSQL = "sp_ObtenerListaPerfilesUsuarios";
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
                            UsuarioPerfil objPro = new UsuarioPerfil();
                            objPro.Idusuarioperfile = int.Parse(dtRes.Rows[x]["idPU"].ToString());
                            objPro.IdUsuario = int.Parse(dtRes.Rows[x]["idUsuario"].ToString());
                            objPro.Nombre = dtRes.Rows[x]["nombre"].ToString();
                            objPro.IdPerfil = int.Parse(dtRes.Rows[x]["idPerfil"].ToString());
                            objPro.Perfil = dtRes.Rows[x]["perfil"].ToString();
                            objPro.Descripcion = dtRes.Rows[x]["descripcion"].ToString();
                            objPro.CreadoPor = int.Parse(dtRes.Rows[x]["creadoPor"].ToString());
                            objPro.UsuarioCreo = dtRes.Rows[x]["CreadoPorUsuario"].ToString();
                            objPro.FechaRegistro =Convert.ToDateTime(dtRes.Rows[x]["fechaRegistro"].ToString());
                            //objPro.ModificadoPor = int.Parse(dtRes.Rows[x]["modificadoPor"].ToString());
                            objPro.UsuarioModifico = dtRes.Rows[x]["modifico"].ToString();
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

        public UsuarioPerfil ObtenerNombre(int? id)
        {
            UsuarioPerfil objResult = new UsuarioPerfil();
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
                            UsuarioPerfil objPro = new UsuarioPerfil();
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

        public UsuarioPerfil ObtenerPorId(int? id)
        {
            UsuarioPerfil objResult = new UsuarioPerfil();
            strSQL = "sp_ObtenerListaPerfilesUsuarioPorId";
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
                            UsuarioPerfil objPro = new UsuarioPerfil();
                            objPro.Idusuarioperfile = int.Parse(dtRes.Rows[x]["idPU"].ToString());
                            objPro.IdUsuario = int.Parse(dtRes.Rows[x]["idUsuario"].ToString());
                            objPro.Nombre = dtRes.Rows[x]["nombre"].ToString();
                            objPro.IdPerfil = int.Parse(dtRes.Rows[x]["idPerfil"].ToString());
                            objPro.Perfil = dtRes.Rows[x]["perfil"].ToString();
                            objPro.Descripcion = dtRes.Rows[x]["descripcion"].ToString();
                            objPro.CreadoPor = int.Parse(dtRes.Rows[x]["creadoPor"].ToString());
                            objPro.UsuarioCreo = dtRes.Rows[x]["CreadoPorUsuario"].ToString();
                            objPro.FechaRegistro = Convert.ToDateTime(dtRes.Rows[x]["fechaRegistro"].ToString());
                            //objPro.ModificadoPor = int.Parse(dtRes.Rows[x]["modificadoPor"].ToString());
                            objPro.UsuarioModifico = dtRes.Rows[x]["modifico"].ToString();

                            if(objPro.ModificadoPor>0)
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

        public List<UsuarioPerfil> ObtenerListaPerfilesActivos(int? id)
        {
            List<UsuarioPerfil> objResult = new List<UsuarioPerfil>();
            strSQL = "sp_ObtenerListaPerfilesActivos";
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
                            UsuarioPerfil objPro = new UsuarioPerfil();
                            objPro.IdPerfil = int.Parse(dtRes.Rows[x]["id"].ToString());
                            objPro.Perfil = dtRes.Rows[x]["perfil"].ToString();
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

        public UsuarioPerfil Guardar(UsuarioPerfil objeto)
        {
            UsuarioPerfil objResult = new UsuarioPerfil();
            DataTable dtRes = null;
            strSQL = "sp_GuardarPerfilUsuario";
            DALConnection objConexion = new DALConnection();
            objConexion.Conn.BeginTransaction();
            try
            {
                objConexion.Conn.ClearParameters();

                objConexion.Conn.AddParameter(new SqlParameter("@idU", objeto.IdUsuario));
                objConexion.Conn.AddParameter(new SqlParameter("@idP", objeto.IdPerfil));
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
