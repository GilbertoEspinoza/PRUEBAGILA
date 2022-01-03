using Entities;
using System.Data;
using System.Data.SqlClient;
using Common;
using System.Collections.Generic;
using System;

namespace DAO
{
    public class Combustibles
    {
        string strSQL;
        private ResponseModel rm;

        public Combustibles()
        {
            rm = new ResponseModel();
        }

        public List<Combustible> ObtenerLista(int? id)
        {
            List<Combustible> objResult = new List<Combustible>();
            strSQL = "sp_ObtenerListaCombustible";
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
                            Combustible objCat = new Combustible();
                            objCat.Id = int.Parse(dtRes.Rows[x]["id"].ToString());
                            objCat.Nombre = dtRes.Rows[x]["nombre"].ToString();
                            objCat.ActivoString = dtRes.Rows[x]["ActivoString"].ToString();
                            objCat.Activo = Convert.ToInt32(dtRes.Rows[x]["activo"]);
                            objResult.Add(objCat);
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

        public List<Combustible> ObtenerListaCombo(int? id)
        {
            List<Combustible> objResult = new List<Combustible>();
            strSQL = "sp_ComboEditarCombustible";
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
                            Combustible objCat = new Combustible();
                            objCat.Id = int.Parse(dtRes.Rows[x]["id"].ToString());
                            objCat.Nombre = dtRes.Rows[x]["nombre"].ToString();
                            objResult.Add(objCat);
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

        public Combustible ObtenerPorId(int? id)
        {
            Combustible objResult = new Combustible();
            strSQL = "sp_ObtenerListaCombustibleId";
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
                            Combustible objCat = new Combustible();
                            objCat.Id = int.Parse(dtRes.Rows[x]["id"].ToString());
                            objCat.Nombre = dtRes.Rows[x]["nombre"].ToString();
                            objCat.CreadoPor = int.Parse(dtRes.Rows[x]["creadoPor"].ToString());
                            objCat.FechaRegistro = Convert.ToDateTime(dtRes.Rows[x]["fechaRegistro"].ToString());
                            objCat.Activo = Convert.ToInt32(dtRes.Rows[x]["activo"]);
                            objCat.ActivoCheck = Convert.ToBoolean(dtRes.Rows[x]["activo"]);
                            objCat.ActivoString = dtRes.Rows[x]["ActivoString"].ToString();
                            objCat.UsuarioCreo = dtRes.Rows[x]["usuarioCreo"].ToString();
                            objCat.UsuarioModifico = dtRes.Rows[x]["usuarioModifico"].ToString();
                            objCat.FechaCreacion = dtRes.Rows[x]["fechaCreacion"].ToString();
                            objCat.FechaModificado = dtRes.Rows[x]["fechaModificado"].ToString();
                            objResult = objCat;
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

        public Combustible Guardar(Combustible objeto)
        {
            int id = 0;
            id = Convert.ToInt32(objeto.Id);
            Combustible objResult = new Combustible();
            DataTable dtRes = null;
            strSQL = "sp_GuardarCombustible";
            DALConnection objConexion = new DALConnection();
            objConexion.Conn.BeginTransaction();
            try
            {
                objConexion.Conn.ClearParameters();
                objConexion.Conn.AddParameter(new SqlParameter("@id", objeto.Id));
                objConexion.Conn.AddParameter(new SqlParameter("@nombre", objeto.Nombre));
                objConexion.Conn.AddParameter(new SqlParameter("@activo", objeto.ActivoCheck));
                objConexion.Conn.AddParameter(new SqlParameter("@idUsuario", objeto.IdUsuario));
                
                dtRes = objConexion.Conn.GetDataSet(strSQL, CommandType.StoredProcedure).Tables[0];
                if (dtRes != null)
                {
                    objResult = objeto;
                    objResult.Id = int.Parse(dtRes.Rows[0][0].ToString());

                    if (Convert.ToInt32(objResult.Id) == 0)
                    {
                        objResult.Id = id;
                        objResult.MensajeError = "Información ya existente.";
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
                objResult.MensajeError = "DAOCombustibles:Guardar()";
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
