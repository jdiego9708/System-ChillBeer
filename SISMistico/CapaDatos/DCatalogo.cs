using CapaEntidades.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DCatalogo
    {
        #region CONSTRUCTOR VACIO
        public DCatalogo()
        {

        }
        #endregion

        #region MENSAJE SQL
        private void SqlCon_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            this.Mensaje_error = e.Message;
        }
        #endregion

        #region PROPIEDADES
        private string mensaje_error;
        public string Mensaje_error
        {
            get
            {
                return mensaje_error;
            }

            set
            {
                mensaje_error = value;
            }
        }
        #endregion

        #region METODO INSERTAR CATALOGO
        public Task<string> InsertarCatalogo(Catalogo catalogo)
        {
            string rpta = string.Empty;
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
                SqlCon.FireInfoMessageEventOnUserErrors = true;

                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Catalogo_i",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_tipo = new SqlParameter()
                {
                    ParameterName = "@Id_tipo",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_tipo);

                SqlParameter Id_padre = new SqlParameter()
                {
                    ParameterName = "@Id_padre",
                    SqlDbType = SqlDbType.Int,
                    Value = catalogo.Id_padre,
                };
                SqlCmd.Parameters.Add(Id_padre);

                SqlParameter Nombre_tipo = new SqlParameter()
                {
                    ParameterName = "@Nombre_tipo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = catalogo.Nombre_tipo.Trim(),
                };
                SqlCmd.Parameters.Add(Nombre_tipo);

                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO";

                if (rpta != "OK")
                {
                    if (this.Mensaje_error != null)
                    {
                        rpta = this.Mensaje_error;
                    }
                }
                else
                {
                    catalogo.Id_tipo = Convert.ToInt32(SqlCmd.Parameters["@Id_tipo"].Value);
                }
            }
            catch (SqlException ex)
            {
                rpta = ex.Message;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return Task.FromResult(rpta);
        }
        #endregion

        #region METODO BUSCAR CATALOGO
        public Task<(string rpta, DataTable dt)> BuscarCatalogo(string tipo_busqueda, string texto_busqueda)
        {
            string rpta = "OK";
            DataTable dt = new DataTable();

            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
                SqlCon.FireInfoMessageEventOnUserErrors = true;
                SqlCon.Open();

                SqlCommand Sqlcmd = new SqlCommand()
                {
                    Connection = SqlCon,
                    CommandText = "sp_Catalogo_g",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Tipo_busqueda = new SqlParameter()
                {
                    ParameterName = "@Tipo_busqueda",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = tipo_busqueda.Trim().ToUpper()
                };
                Sqlcmd.Parameters.Add(Tipo_busqueda);

                SqlParameter Texto_busqueda = new SqlParameter()
                {
                    ParameterName = "@Texto_busqueda",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = texto_busqueda.Trim().ToUpper()
                };
                Sqlcmd.Parameters.Add(Texto_busqueda);

                SqlDataAdapter SqlData = new SqlDataAdapter(Sqlcmd);
                SqlData.Fill(dt);

                if (dt != null)
                {
                    if (dt.Rows.Count < 1)
                    {
                        if (this.Mensaje_error != null)
                            throw new Exception(this.Mensaje_error);
                    }
                }
            }
            catch (SqlException ex)
            {
                rpta = ex.Message;
                dt = null;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                dt = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return Task.FromResult((rpta, dt));
        }

        #endregion
    }
}
