using Entities;
using System.Data;
using System.Data.SqlClient;
using Common;
using System.Collections.Generic;
using System;

namespace DAO
{
    public class Vehiculos
    {
        string strSQL;
        private ResponseModel rm;

        public Vehiculos()
        {
            rm = new ResponseModel();
        }

        public List<Vehiculo> ObtenerLista(int? id)
        {
            List<Vehiculo> objResult = new List<Vehiculo>();
            strSQL = "sp_ObtenerListaVehiculos";
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
                            Vehiculo objCat = new Vehiculo();
                            objCat.Id = int.Parse(dtRes.Rows[x]["id"].ToString());
                            objCat.Nombre = dtRes.Rows[x]["nombre"].ToString();
                            objCat.Placas = dtRes.Rows[x]["placas"].ToString();
                            objCat.TipoString = dtRes.Rows[x]["tipoString"].ToString();
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

        public List<Vehiculo> ObtenerListaComboAccesorios(int? id, int? idTipo)
        {
            List<Vehiculo> objResult = new List<Vehiculo>();
            strSQL = "sp_ComboEditarAccesorios";
            DALConnection objConexion = new DALConnection();
            try
            {
                objConexion.Conn.ClearParameters();
                objConexion.Conn.AddParameter(new SqlParameter("@id", id));
                objConexion.Conn.AddParameter(new SqlParameter("@idTipo", idTipo));
                DataTable dtRes = objConexion.Conn.GetDataSet(strSQL, CommandType.StoredProcedure).Tables[0];

                if (dtRes != null)
                {
                    if (dtRes.Rows.Count > 0)
                    {
                        for (int x = 0; x < dtRes.Rows.Count; x++)
                        {
                            Vehiculo objCat = new Vehiculo();
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

        public List<Vehiculo> ObtenerListaAccesorios()
        {
            List<Vehiculo> objResult = new List<Vehiculo>();
            strSQL = "vw_ListadoAccesorios";
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
                            Vehiculo objCat = new Vehiculo();
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

        public List<Vehiculo> ObtenerListaId(int? id)
        {
            List<Vehiculo> objResult = new List<Vehiculo>();
            strSQL = "sp_ObtenerListaVehiculoId";
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
                            Vehiculo objCat = new Vehiculo();
                            objCat.Id = int.Parse(dtRes.Rows[x]["id"].ToString());
                            objCat.Nombre = dtRes.Rows[x]["nombre"].ToString();
                            objCat.ActivoString = dtRes.Rows[x]["ActivoString"].ToString();
                            objCat.Activo = Convert.ToInt32(dtRes.Rows[x]["activo"]);
                            objCat.ActivoCheck = Convert.ToBoolean(dtRes.Rows[x]["activo"]);
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

        public Vehiculo ObtenerPorId(int? id)
        {
            Vehiculo objResult = new Vehiculo();
            strSQL = "sp_ObtenerVehiculoId";
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
                            Vehiculo objCat = new Vehiculo();
                            objCat.Id = int.Parse(dtRes.Rows[x]["id"].ToString());
                            objCat.Nombre = dtRes.Rows[x]["nombre"].ToString();
                            objCat.IdLinea = int.Parse(dtRes.Rows[x]["idLinea"].ToString());
                            objCat.LineaString = dtRes.Rows[x]["lineaString"].ToString();
                            objCat.IdMarca = int.Parse(dtRes.Rows[x]["idMarca"].ToString());
                            objCat.MarcaString = dtRes.Rows[x]["marcaString"].ToString();
                            objCat.Modelo = dtRes.Rows[x]["modelo"].ToString();
                            objCat.IdTipo = int.Parse(dtRes.Rows[x]["idTipo"].ToString());
                            objCat.TipoString = dtRes.Rows[x]["tipoString"].ToString();
                            objCat.IdTipoUso = int.Parse(dtRes.Rows[x]["idtipouso"].ToString());
                            objCat.TipoUsoString = dtRes.Rows[x]["tipousoString"].ToString();
                            objCat.IdTipoCombustible = int.Parse(dtRes.Rows[x]["idTipoCombustible"].ToString());
                            objCat.TipoCombustibleString = dtRes.Rows[x]["tipoCombustibleString"].ToString();
                            objCat.Llantas = int.Parse(dtRes.Rows[x]["llantas"].ToString());
                            objCat.Potencia = int.Parse(dtRes.Rows[x]["potencia"].ToString());
                            objCat.IdAccesorio = int.Parse(dtRes.Rows[x]["idaccesorio"].ToString());
                            objCat.AccesorioString = dtRes.Rows[x]["accesorioString"].ToString();
                            objCat.Placas = dtRes.Rows[x]["placas"].ToString();
                            objCat.Serial = dtRes.Rows[x]["serial"].ToString();
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

        public Vehiculo Guardar(Vehiculo objeto)
        {
            int id = 0;
            id = Convert.ToInt32(objeto.Id);
            Vehiculo objResult = new Vehiculo();
            DataTable dtRes = null;
            strSQL = "sp_GuardarVehiculo";
            DALConnection objConexion = new DALConnection();
            objConexion.Conn.BeginTransaction();
            try
            {
                objConexion.Conn.ClearParameters();
                objConexion.Conn.AddParameter(new SqlParameter("@id", objeto.Id));
                objConexion.Conn.AddParameter(new SqlParameter("@nombre", objeto.Nombre.Trim()));
                objConexion.Conn.AddParameter(new SqlParameter("@idLinea", objeto.IdLinea));
                objConexion.Conn.AddParameter(new SqlParameter("@modelo", objeto.Modelo.Trim()));
                objConexion.Conn.AddParameter(new SqlParameter("@idTipoUso", objeto.IdTipoUso));
                objConexion.Conn.AddParameter(new SqlParameter("@idAccesorio", objeto.IdAccesorio));
                objConexion.Conn.AddParameter(new SqlParameter("@idTipo", objeto.IdTipo));
                objConexion.Conn.AddParameter(new SqlParameter("@idTipoCombustible", objeto.IdTipoCombustible));
                objConexion.Conn.AddParameter(new SqlParameter("@placas", Utilidades.ToDBNull(objeto.Placas.Trim())));
                objConexion.Conn.AddParameter(new SqlParameter("@serial", Utilidades.ToDBNull(objeto.Serial.Trim())));
                objConexion.Conn.AddParameter(new SqlParameter("@llantas", objeto.Llantas));
                objConexion.Conn.AddParameter(new SqlParameter("@potencia", objeto.Potencia));
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
                    else if (Convert.ToInt32(objResult.Id) == -4)
                    {
                        objResult.Id = id;
                        objResult.MensajeError = "El accesorio ya esta asignado.";
                        objConexion.Conn.RollbackTransaction();
                    }
                    else if (Convert.ToInt32(objResult.Id) == -3)
                    {
                        objResult.Id = id;
                        objResult.MensajeError = "El némero de placa ya existe.";
                        objConexion.Conn.RollbackTransaction();
                    }
                    else if (Convert.ToInt32(objResult.Id) == -2)
                    {
                        objResult.Id = id;
                        objResult.MensajeError = "El némero de serie ya existe.";
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
                objResult.MensajeError = "DAOVehiculos:Guardar()";
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
