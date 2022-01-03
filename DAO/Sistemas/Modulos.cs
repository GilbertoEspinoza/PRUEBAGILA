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
    public class Modulos
    {
        string strSQL;
        private ResponseModel rm;

        public Modulos()
        {
            rm = new ResponseModel();
        }

        public List<Modulo> ObtenerModulosUsuarios(int? id)
        {
            List<Modulo> objResult = new List<Modulo>();
            strSQL = "sp_ObtenerModulosUsuarios";
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
                            Modulo objModulo = new Modulo();
                            objModulo.Id = Convert.ToInt32(dtRes.Rows[x]["id"].ToString());
                            objModulo.MenuP = dtRes.Rows[x]["menuP"].ToString();

                            if(!String.IsNullOrEmpty(dtRes.Rows[x]["tipoP"].ToString()))
                                objModulo.TipoP = int.Parse(dtRes.Rows[x]["tipoP"].ToString());

                            objModulo.ModuloName = dtRes.Rows[x]["nombre"].ToString();
                            objModulo.Tag = dtRes.Rows[x]["tag"].ToString();
                            objModulo.ControllerTag = dtRes.Rows[x]["controllerTag"].ToString();
                            objModulo.CssClass = dtRes.Rows[x]["cssclass"].ToString();
                            objModulo.Tipo = int.Parse(dtRes.Rows[x]["tipo"].ToString());
                            objModulo.Menu = int.Parse(dtRes.Rows[x]["menu"].ToString());
                            objModulo.Controller = dtRes.Rows[x]["controller"].ToString();
                            objModulo.Action = dtRes.Rows[x]["actionMenu"].ToString();
                            objModulo.CssClassP = dtRes.Rows[x]["cssclassP"].ToString();
                            objModulo.Icon = dtRes.Rows[x]["icon"].ToString();
                            objModulo.IconP = dtRes.Rows[x]["iconP"].ToString();
                            objModulo.Agregar = Convert.ToInt32(dtRes.Rows[x]["agregar"]);
                            objModulo.Modificar = Convert.ToInt32(dtRes.Rows[x]["modificar"]);
                            objModulo.Eliminar = Convert.ToInt32(dtRes.Rows[x]["eliminar"]);
                            objModulo.Consultar = Convert.ToInt32(dtRes.Rows[x]["consultar"]);
                            objModulo.Autorizar = Convert.ToInt32(dtRes.Rows[x]["autorizar"]);
                            objModulo.Cancel = Convert.ToInt32(dtRes.Rows[x]["cancel"]);
                            objModulo.Validar = Convert.ToInt32(dtRes.Rows[x]["validar"]);
                            objModulo.Viewdoc = Convert.ToInt32(dtRes.Rows[x]["viewdoc"]);
                            objModulo.Updaload = Convert.ToInt32(dtRes.Rows[x]["updaload"]);
                            objModulo.Download = Convert.ToInt32(dtRes.Rows[x]["download"]);
                            objModulo.Zona = Convert.ToInt32(dtRes.Rows[x]["zona"]);
                            objModulo.Asignar = Convert.ToInt32(dtRes.Rows[x]["asignar"]);
                            objModulo.Imprimir = Convert.ToInt32(dtRes.Rows[x]["imprimir"]);
                            objResult.Add(objModulo);
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
