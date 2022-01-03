using Entities;
using System.Data;
using System.Data.SqlClient;
using Common;
using System.Collections.Generic;
using System;

namespace DAO
{
    public class TipoVehiculos
    {
        string strSQL;
        private ResponseModel rm;

        public TipoVehiculos()
        {
            rm = new ResponseModel();
        }

        public List<TipoVehiculo> ObtenerLista(int? id)
        {
            List<TipoVehiculo> objResult = new List<TipoVehiculo>();
            strSQL = "sp_ObtenerListaTipoVehiculos";
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
                            TipoVehiculo objCat = new TipoVehiculo();
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

        public List<TipoVehiculo> ObtenerListaCombo(int? id)
        {
            List<TipoVehiculo> objResult = new List<TipoVehiculo>();
            strSQL = "sp_ComboEditarTipoVehiculos";
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
                            TipoVehiculo objCat = new TipoVehiculo();
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
