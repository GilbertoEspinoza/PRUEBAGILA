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
    public class UsuariosAdmin
    {

        string strSQL;
        private ResponseModel rm;

        public UsuariosAdmin()
        {
            rm = new ResponseModel();
        }

        public List<Usuario> ObtenerLista(int? id)
        {
            List<Usuario> objResult = new List<Usuario>();
            strSQL = "sp_ObtenerListaUsuarios";
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
                            Usuario objPro = new Usuario();
                            objPro.Id = int.Parse(dtRes.Rows[x]["id"].ToString());
                            objPro.Nombre = dtRes.Rows[x]["nombre"].ToString();
                            objPro.Correo = dtRes.Rows[x]["nombre"].ToString();
                            objPro.ActivoString = dtRes.Rows[x]["activoSting"].ToString();
                            objPro.Activo = Convert.ToInt32(dtRes.Rows[x]["activo"]);
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
