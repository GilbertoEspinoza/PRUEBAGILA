using Entities;
using System.Data;
using System.Data.SqlClient;
using Common;
using System.Collections.Generic;
using System;

namespace DAO
{
    public class TipoUsoVehiculos
    {
        string strSQL;
        private ResponseModel rm;

        public TipoUsoVehiculos()
        {
            rm = new ResponseModel();
        }

        public List<TipoUsoVehiculo> ObtenerLista(int? id)
        {
            List<TipoUsoVehiculo> objResult = new List<TipoUsoVehiculo>();
            strSQL = "sp_ObtenerListaTipoUsos";
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
                            TipoUsoVehiculo objCat = new TipoUsoVehiculo();
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

        public List<TipoUsoVehiculo> ObtenerListaCombo(int? id)
        {
            List<TipoUsoVehiculo> objResult = new List<TipoUsoVehiculo>();
            strSQL = "sp_ComboEditarTipoUsos";
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
                            TipoUsoVehiculo objCat = new TipoUsoVehiculo();
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
