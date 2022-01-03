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
    public class Perfiles
    {
  
        string strSQL;
        private ResponseModel rm;

        public Perfiles()
        {
            rm = new ResponseModel();
        }


        public List<Perfil> ObtenerLista(int? id)
        {
            List<Perfil> objResult = new List<Perfil>();
            strSQL = "sp_ObtenerListadoPerfil";
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
                            Perfil objPro = new Perfil();
                            objPro.Id = int.Parse(dtRes.Rows[x]["id"].ToString());
                            objPro.PerfilName = dtRes.Rows[x]["nombre"].ToString();
                            objPro.Descripcion = dtRes.Rows[x]["descripcion"].ToString();
                            objPro.ActivoCheck = bool.Parse(dtRes.Rows[x]["activo"].ToString());
                            objPro.Activo= Convert.ToInt32(objPro.ActivoCheck);
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

        
    }
}
