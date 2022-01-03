using Entities;
using System.Data;
using System.Data.SqlClient;
using Common;
using System.Collections.Generic;
using System;

namespace DAO
{
    public class Marcas
    {
        string strSQL;
        private ResponseModel rm;

        public Marcas()
        {
            rm = new ResponseModel();
        }

        public List<Marca> ObtenerLista(int? id)
        {
            List<Marca> objResult = new List<Marca>();
            strSQL = "sp_ObtenerListaMarca";
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
                            Marca objCat = new Marca();
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

        public List<Marca> ObtenerListaCombo(int? id)
        {
            List<Marca> objResult = new List<Marca>();
            strSQL = "sp_ComboEditarMarcas";
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
                            Marca objCat = new Marca();
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

    }
}
