using Inventario.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        // Aviso, no se encontraron datos para generar el reporte
        private static bool avisoSinDatos(SqlDataReader mdr)
        {
            if (mdr.HasRows)
                return true;
            else
            {
                MessageBox.Show("No se encontró información para generar el reporte.", "Inventario BSN",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                //sqlDB.CloseConnection();
                return false;
            }
        }


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
