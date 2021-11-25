using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Inventario.Model
{
    public static class DbLogic
    {
        private static string conString = @"Server=TEST\SQLEXPRESS;Database = DBI;User ID = TestLogin; Password=12345;";
        //private static string conString = @"Data Source=EC660980\SQLEXPRESS;Initial Catalog = DBI;Integrated Security=True";


        // ****SELECT* Stored procedure - List of params
        public static DataTable SqlStoredProcedure(ReportModel reportInfo)
        {
            try
            {
                using (SqlConnection myConn = new SqlConnection(conString))
                using (SqlCommand cmd = new SqlCommand(reportInfo.ProcedureQuery, myConn))
                {
                    myConn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (reportInfo.Params != null && reportInfo.Params.Count > 0)
                    {
                        foreach (var prm in reportInfo.Params)
                        {
                            cmd.Parameters.AddWithValue(prm.ParamName, prm.ParamValue);
                        }
                    }

                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
            }
            catch (SqlException ex)
            {
                SqlError(ex);
                return null;
            }
        }


        //NonQuery (insert data)
        public static int SqlSpNonQuery(string SpString, List<ParamsModel> Params)
        {
            try
            {
                using (SqlConnection myConn = new SqlConnection(conString))
                using (SqlCommand cmd = new SqlCommand(SpString, myConn))
                {
                    myConn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (Params != null && Params.Count > 0)
                    {
                        foreach (var prm in Params)
                        {
                            cmd.Parameters.AddWithValue(prm.ParamName, prm.ParamValue);
                        }
                    }

                    int AffectedRows = cmd.ExecuteNonQuery();

                    return AffectedRows;
                }
            }
            catch (SqlException ex)
            {
                SqlError(ex);
                return 0;
            }
        }

        //Builds a detailed string for the error message
        private static void SqlError(SqlException ex)
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

    }
}
