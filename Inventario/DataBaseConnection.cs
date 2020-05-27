using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data.MySqlClient;
using System.Data;
using System.Reflection;
using SQL = System.Data;

namespace Inventario
{
    class DataBaseConnection
    {
        public MySqlConnection connectionString = new MySqlConnection("server=localhost;user id=root;Pwd=root;database=dbi");
        MySqlCommand command;
        //127.0.0.1
        //public MySqlConnection connectionString = new MySqlConnection("server=localhost;user id=root;Pwd=root;database=dbi");


        public void OpenConnection()
        {
            connectionString.Open();
        }
        public void CloseConnection()
        {
            connectionString.Close();
        }

        
        public SQL.DataTable leerTbConteos(int numTarjeta)
        {
            SQL.DataTable dt = new SQL.DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("Select * from tbsaldobodega;", connectionString);
            da.Fill(dt);
            return dt;
        }


        //Trae los valores de tbConteosInventarios y tbNart para poner en el cuadro de la interfaz
        public MySqlDataReader QueryInfo(int numTarjeta)
        {
            MySqlDataReader mdr = null;
            string selectQuery = "SELECT ci.codigo_prod, tbn.descripcion, ci.lote, ci.bodega, ci.ubicacion FROM tbconteosinventario ci " +
                "INNER JOIN tbnart tbn ON ci.codigo_prod = tbn.codigo_prod WHERE numero_tarjeta=" + numTarjeta;
            connectionString.Open();
            command = new MySqlCommand(selectQuery, connectionString);
            mdr = command.ExecuteReader();
            //connectionString.Close();
            return mdr;
        }


        //Comprueba si ya hubo un conteo
        public MySqlDataReader QueryConteo(int numTarjeta, int numConteo)
        {
            MySqlDataReader mdr;
            string selectQuery = "select cant_conteo"+ numConteo + " from tbconteosinventario where numero_tarjeta=" + numTarjeta;
            connectionString.Open();
            command = new MySqlCommand(selectQuery, connectionString);
            mdr = command.ExecuteReader();
            //connectionString.Close();
            return mdr;            
        }

        public int ConsolidarConteo()
        {
            int filas = 0;
            MySqlDataReader mdr;
            string selectQuery = "select * from tbconteosinventario where estado=1";
            connectionString.Open();
            command = new MySqlCommand(selectQuery, connectionString);
            mdr = command.ExecuteReader();
            string updateQuery = "";

            while (mdr.Read())
            {
                if (mdr.GetInt32("cant_conteo1") == mdr.GetInt32("cant_conteo2"))
                {
                    filas++;
                    updateQuery += "UPDATE tbconteosinventario SET cant_conteofinal =cant_conteo2 WHERE numero_tarjeta=" + mdr.GetString(0)+";\n";
                }
                else
                {
                    filas++;
                    updateQuery += "UPDATE tbconteosinventario SET cant_conteofinal =cant_conteo3 WHERE numero_tarjeta=" + mdr.GetString(0) + ";\n";
                }
            }
            connectionString.Close();

            connectionString.Open();
            command = new MySqlCommand(updateQuery, connectionString);
            mdr = command.ExecuteReader();
            connectionString.Close();

            return filas;
        }

        //Guarda el registro
        public bool GrabarConteo(string tarjeta, string conteo, string total)
        {
            bool result = false;
            try
            {
                MySqlDataReader mdr;               
                string updateQuery = "UPDATE tbconteosinventario SET cant_conteo"+conteo+" = "+total+", estado=1 WHERE numero_tarjeta=" + tarjeta;
                connectionString.Open();
                command = new MySqlCommand(updateQuery, connectionString);
                mdr = command.ExecuteReader();
                connectionString.Close();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }


        public bool TercerConteo(string tarjeta)
        {
            bool result = false;
            try
            {
                MySqlDataReader mdr;
                //Compara conteos
                string selectQuery = "select cant_conteo1, cant_conteo2, cant_conteo3 from tbconteosinventario where numero_tarjeta=" + tarjeta;
                connectionString.Open();
                command = new MySqlCommand(selectQuery, connectionString);
                mdr = command.ExecuteReader();
                if (mdr.Read())
                {
                    if(mdr.GetInt32("cant_conteo1") == -1 || mdr.GetInt32("cant_conteo2") == -1)
                    {
                        result = false;
                    }
                    else if (mdr.GetInt32("cant_conteo1")!= mdr.GetInt32("cant_conteo2"))
                    {
                        if(mdr.GetInt32("cant_conteo3")==-1)
                        {
                            result = true;
                        }
                    }
                }
                connectionString.Close();
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
                connectionString.Open();
                result = true;
                connectionString.Close();
            }
            catch
            {
                result = false;
            }
            return result;
        }

    }
}
