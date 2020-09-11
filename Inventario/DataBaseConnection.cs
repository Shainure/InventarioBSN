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
        private static SqlConnection connection = new SqlConnection(@"Data Source=TEST\SQLEXPRESS;Initial Catalog = DBI; Persist Security Info=True;User ID = TestLogin; Password=12345");

        public SqlDataReader SqlCommand(string queryString, bool procedure)
        {
            SqlCommand cmd = new SqlCommand(queryString, connection);
            if (procedure) { cmd.CommandType = CommandType.StoredProcedure; }

            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                return reader;
            }
            catch (SqlException ex)
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
                MessageBox.Show(Convert.ToString(errorMessages), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
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
                            filas++;
                            updateQuery += "UPDATE tbconteosinventario SET cant_conteofinal =cant_conteo2 WHERE numero_tarjeta=" + sdr.GetValue(0).ToString() + ";\n";
                        }
                        else
                        {
                            filas++;
                            updateQuery += "UPDATE tbconteosinventario SET cant_conteofinal =cant_conteo3 WHERE numero_tarjeta=" + sdr.GetValue(0).ToString() + ";\n";
                        }
                    }
                    CloseConnection();

                    using (SqlCommand comd = connection.CreateCommand())
                    {
                        comd.CommandText = updateQuery;
                        connection.Open();
                        comd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                catch (SqlException ex)
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
                    MessageBox.Show(Convert.ToString(errorMessages), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return filas;
        }

        public bool TercerConteo(string tarjeta)
        {
            bool result = false;
            try
            {
                //Compara conteos
                string selectQuery = "select cant_conteo1, cant_conteo2, cant_conteo3 from tbconteosinventario where numero_tarjeta=" + tarjeta;

                SqlDataReader mdr = SqlCommand(selectQuery, false);
                if (mdr.Read())
                {
                    if (Convert.ToInt32(mdr["cant_conteo1"]) == -1 || Convert.ToInt32(mdr["cant_conteo2"]) == -1)
                    {
                        result = false;
                    }
                    else if (Convert.ToInt32(mdr["cant_conteo1"]) != Convert.ToInt32(mdr["cant_conteo2"]))
                    {
                        if (Convert.ToInt32(mdr["cant_conteo3"]) == -1)
                        {
                            result = true;
                        }
                    }
                }
                connection.Close();
            }
            catch
            {
                result = false;
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
                MessageBox.Show(Convert.ToString(errorMessages), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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