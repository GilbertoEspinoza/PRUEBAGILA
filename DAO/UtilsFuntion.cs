using Entities;
using System.Data;
using System.Data.SqlClient;
using Common;
using System.Collections.Generic;
using System;

namespace DAO
{
    public class UtilsFuntion
    {
        string strSQL;
        public UtilsFuntion()
        {
        }

        public int ObtenerKmInicio(int? id, int? tipo)
        {
            int kmInicio = 0;
            strSQL = "sp_KmInicio";
            DALConnection objConexion = new DALConnection();
            try
            {
                objConexion.Conn.ClearParameters();
                objConexion.Conn.AddParameter(new SqlParameter("@id", id));
                objConexion.Conn.AddParameter(new SqlParameter("@tipo", tipo));
                DataTable dtRes = objConexion.Conn.GetDataSet(strSQL, CommandType.StoredProcedure).Tables[0];

                if (dtRes != null)
                {
                    if (dtRes.Rows.Count > 0)
                    {
                        for (int x = 0; x < dtRes.Rows.Count; x++)
                        {

                            kmInicio = int.Parse(dtRes.Rows[x]["kmInicio"].ToString());
                        }
                    }
                }
            }
            catch (Exception)
            {
                //objResult.MensajeError = "DAOUtilsFuntion:ObtenerKmInicio(), " + ex.ToString();
                throw;
            }
            finally
            {
                objConexion.DisposeConn();
            }
            return kmInicio;
        }

    }
}
