using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;

using SQL = System.Data;

using System.Data.SqlClient;
using System.Windows.Forms;

namespace Inventario
{
    internal class DataBaseConnection
    {
        //private static SqlConnection connection = new SqlConnection(@"Data Source=EC660980\SQLEXPRESS;Initial Catalog = DBI;Integrated Security=True");
        private static SqlConnection connection = new SqlConnection(@"Server=TEST\SQLEXPRESS;Database = DBI;User ID = TestLogin; Password=12345;");
        //Guardar en app.config

        public SqlDataReader SqlCommand(string queryString, bool procedure)
        {
            SqlCommand cmd = new SqlCommand(queryString, connection);
            if (procedure)
                cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (SqlException ex)
            {
                SqlError(ex);
                return null;
            }
        }


        public int SqlUpdate(string queryString)
        {
            SqlCommand cmd = new SqlCommand(queryString, connection);

            try
            {
                cmd.Connection.Open();
                //SqlDataReader reader = cmd.ExecuteReader();
                int resultado = cmd.ExecuteNonQuery();
                //cmd.Connection.Close();
                return resultado;
            }
            catch (SqlException ex)
            {
                SqlError(ex);
                return -1;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }


        private void SqlError(SqlException ex)
        {
            StringBuilder errorMessages = new StringBuilder();
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                errorMessages.Append("Index #" + i + "\n" +
                    "Código error: " + ex.Errors[i].Number + "\n" +
                    "Mensaje: " + ex.Errors[i].Message + "\n" +
                    "Server: " + ex.Errors[i].Server + "\n" +
                    "Procedure: " + ex.Errors[i].Procedure + "\n" +
                    "Source: " + ex.Errors[i].Source + "\n");
            }
            MessageBox.Show(Convert.ToString(errorMessages), "Inventario BSN", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public int ConsolidarConteo()
        {
            int filas = 0;
            string selectQuery = "SELECT * FROM tbconteosinventario WHERE estado=1";
            string updateQuery = "";

            SqlDataReader sdr = SqlCommand(selectQuery, false);

            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                try
                {
                    while (sdr.Read())
                    {
                        if (Convert.ToInt32(sdr["cant_conteo1"]) == Convert.ToInt32(sdr["cant_conteo2"]))
                        {
                            //filas++;
                            updateQuery += "UPDATE tbconteosinventario SET cant_conteofinal =cant_conteo2 WHERE numero_tarjeta=" + sdr.GetValue(0).ToString() + ";\n";
                        }
                        else
                        {
                            updateQuery += "UPDATE tbconteosinventario SET cant_conteofinal =cant_conteo3 WHERE numero_tarjeta=" + sdr.GetValue(0).ToString() + ";\n";
                        }
                    }
                    CloseConnection();

                    using (SqlCommand comd = connection.CreateCommand())
                    {
                        comd.CommandText = updateQuery;
                        comd.Connection.Open();
                        filas = comd.ExecuteNonQuery();
                        comd.Connection.Close();
                    }
                }
                catch (SqlException ex)
                {
                    SqlError(ex);
                }
            }
            return filas;
        }

        public bool TercerConteo(string tarjeta)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand();
            try
            {
                //Compara conteos
                string selectQuery = "select cant_conteo1, cant_conteo2, cant_conteo3 from tbconteosinventario where numero_tarjeta=" + tarjeta;

                cmd = new SqlCommand(selectQuery, connection);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (Convert.ToInt32(reader["cant_conteo1"]) == -1 || Convert.ToInt32(reader["cant_conteo2"]) == -1)
                    {
                        result =  false;
                    }
                    else if (Convert.ToInt32(reader["cant_conteo1"]) != Convert.ToInt32(reader["cant_conteo2"]))
                    {
                        if (Convert.ToInt32(reader["cant_conteo3"]) == -1)
                            result = true;
                    }
                }

            }
            catch (SqlException ex)
            {
                SqlError(ex);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return result;
        }

        public bool CheckConnection()
        {
            bool result = false;
            try
            {
                connection.Open();
                result = true;
                connection.Close();
            }
            catch (SqlException ex)
            {
                SqlError(ex);
                result = false;
            }
            return result;
        }

        public void OpenConnection()
        {
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
        }
    }
}