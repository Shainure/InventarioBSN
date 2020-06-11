using MySql.Data.MySqlClient;
using SpreadsheetLight;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.EMMA;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging;

namespace Inventario
{
    internal class Reportes
    {
        private DataBaseConnection mysql = new DataBaseConnection();

        // Reporte "tarjetas conteo"                        --1/9   ◘◘◘◘
        public void ExpTarjetasConteos()
        {
            string selectQuery = "SELECT ci.numero_tarjeta, ci.codigo_prod, tbn.descripcion, ci.lote, ci.bodega, ci.ubicacion," +
                        "ci.cant_conteo1, ci.cant_conteo2, ci.cant_conteo3 FROM tbconteosinventario ci INNER JOIN tbnart tbn ON " +
                        "ci.codigo_prod = tbn.codigo_prod ORDER by ci.numero_tarjeta;";
            mysql.OpenConnection();
            MySqlCommand command = new MySqlCommand(selectQuery, mysql.connectionString);
            MySqlDataReader mdr = command.ExecuteReader();

            if (!mdr.HasRows)
            {
                MessageBox.Show("No hay datos disponibles.");
                return;
            }

            int dataCell = 6;
            var anio = DateTime.Now.ToString("yyyy");
            var fecha = DateTime.Now.ToString("dddd, dd MMMM yyyy");

            SLDocument sl = new SLDocument();
            sl.SetCellValue("A1", "BSN Medical LTDA");
            sl.SetCellValue("A2", "Inventario " + anio);
            sl.SetCellValue("A3", fecha);
            sl.SetCellValue("A4", "Tarjetas ingresadas");

            SLStyle estiloT = sl.CreateStyle();     //Estilo título
            estiloT.Font.FontSize = 16;
            estiloT.Font.Bold = true;
            estiloT.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            SLStyle estiloC = sl.CreateStyle();     //Estilo cabeceras
            estiloC.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            estiloC.Font.Bold = true;

            sl.SetCellStyle("A1", estiloT);
            sl.SetCellStyle("A2", estiloC);
            sl.SetCellStyle("A3", estiloC);
            sl.SetCellStyle("A4", estiloC);

            sl.MergeWorksheetCells("A1", "I1");      //Combino priimeras celdas
            sl.MergeWorksheetCells("A2", "I2");
            sl.MergeWorksheetCells("A3", "I3");
            sl.MergeWorksheetCells("A4", "B4");

            estiloC.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine);
            sl.SetCellStyle("A6", "I6", estiloC);

            sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Tb Conteos");      //Nombre de la hoja
            sl.SetCellValue("A" + dataCell, "Nro. Tarjeta");
            sl.SetCellValue("B" + dataCell, "Nart");
            sl.SetCellValue("C" + dataCell, "Descripción");
            sl.SetCellValue("D" + dataCell, "Lote");
            sl.SetCellValue("E" + dataCell, "Bodega");
            sl.SetCellValue("F" + dataCell, "Ubicación");
            sl.SetCellValue("G" + dataCell, "Conteo1");
            sl.SetCellValue("H" + dataCell, "Conteo2");
            sl.SetCellValue("I" + dataCell, "Conteo3");

            while (mdr.Read())       //Lleno la tabla conlos datos del query
            {
                dataCell++;
                sl.SetCellValue("A" + dataCell, Convert.ToInt32(mdr["numero_tarjeta"]));
                sl.SetCellValue("B" + dataCell, mdr["codigo_prod"].ToString());
                sl.SetCellValue("C" + dataCell, mdr["descripcion"].ToString());
                sl.SetCellValue("D" + dataCell, Convert.ToInt32(mdr["lote"]));
                sl.SetCellValue("E" + dataCell, Convert.ToInt32(mdr["bodega"]));
                sl.SetCellValue("F" + dataCell, mdr["ubicacion"].ToString());
                sl.SetCellValue("G" + dataCell, Convert.ToInt32(mdr["cant_conteo1"]));
                sl.SetCellValue("H" + dataCell, Convert.ToInt32(mdr["cant_conteo2"]));
                sl.SetCellValue("I" + dataCell, Convert.ToInt32(mdr["cant_conteo3"]));
            }

            SLStyle estiloB = sl.CreateStyle(); //Creo estilo para bordes
            estiloB.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            //estiloB.Alignment.Horizontal(Right);

            sl.SetCellStyle("A6", "I" + dataCell.ToString(), estiloB);        //Asigno bordes al rango
            sl.AutoFitColumn("A", "I");                                     //Autoajustar columnas

            SLStyle alignment = sl.CreateStyle();
            alignment.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            sl.SetCellStyle("A7", "A" + dataCell.ToString(), alignment);
            alignment.Alignment.Horizontal = HorizontalAlignmentValues.Right;
            sl.SetCellStyle("G7", "I" + dataCell.ToString(), alignment);

            string path = Path.GetTempPath();                                                   //Para sacar la dirección de la carpeta temporal
            string tmpFile = Path.Combine(Path.GetTempPath(), "Tarjetas_conteos_" + anio + ".xlsx");        //Junta dirección con nombre de archivo
            sl.SaveAs(tmpFile);         //Guardo el archivo
            System.Diagnostics.Process.Start(tmpFile);

            mysql.CloseConnection();
        }

        //Reporte "Consolidado Conteo"                      --2/4   ◘◘◘◘
        public void ExpConsolidadoNart()
        {
            string selectQuery = "SELECT ci.codigo_prod, tbn.descripcion, ci.bodega, SUM(ci.cant_conteofinal) as conteoFinal FROM tbconteosinventario ci" +
                " INNER JOIN tbnart tbn ON ci.codigo_prod = tbn.codigo_prod WHERE ci.cant_conteofinal !=-1 GROUP BY ci.codigo_prod ORDER BY ci.codigo_prod;";
            //WHERE ci.cant_conteofinal !=-1

            mysql.OpenConnection();
            MySqlCommand command = new MySqlCommand(selectQuery, mysql.connectionString);
            MySqlDataReader mdr = command.ExecuteReader();

            if (!mdr.HasRows)
            {
                MessageBox.Show("No hay datos disponibles.");
                return;
            }

            int dataCell = 6;
            var anio = DateTime.Now.ToString("yyyy");
            var fecha = DateTime.Now.ToString("dddd, dd MMMM yyyy");

            SLDocument sl = new SLDocument();
            sl.SetCellValue("A1", "BSN Medical LTDA");
            sl.SetCellValue("A2", "Inventario " + anio);
            sl.SetCellValue("A3", fecha);
            sl.SetCellValue("A4", "Consolidado conteo");

            SLStyle estiloT = sl.CreateStyle();     //Estilo título
            estiloT.Font.FontSize = 16;
            estiloT.Font.Bold = true;
            estiloT.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            SLStyle estiloC = sl.CreateStyle();     //Estilo cabeceras
            estiloC.Font.Bold = true;
            sl.SetCellStyle("A4", estiloC);         //Imprime sin centrar
            estiloC.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            sl.SetCellStyle("A1", estiloT);
            sl.SetCellStyle("A2", estiloC);
            sl.SetCellStyle("A3", estiloC);

            sl.MergeWorksheetCells("A1", "D1");      //Combino primeras celdas
            sl.MergeWorksheetCells("A2", "D2");
            sl.MergeWorksheetCells("A3", "D3");
            sl.MergeWorksheetCells("A4", "B4");

            estiloC.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine);       //Color a cabeceras
            sl.SetCellStyle("A6", "D6", estiloC);

            sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Consolidado");      //Nombre de la hoja
            sl.SetCellValue("A" + dataCell, "Nart");
            sl.SetCellValue("B" + dataCell, "Descripción");
            sl.SetCellValue("C" + dataCell, "Bodega");
            sl.SetCellValue("D" + dataCell, "Cant Total Conteo");

            while (mdr.Read())       //Lleno la tabla conlos datos del query
            {
                dataCell++;
                sl.SetCellValue("A" + dataCell, mdr["codigo_prod"].ToString());
                sl.SetCellValue("B" + dataCell, mdr["descripcion"].ToString());
                sl.SetCellValue("C" + dataCell, Convert.ToInt32(mdr["bodega"]));
                sl.SetCellValue("D" + dataCell, Convert.ToInt32(mdr["conteoFinal"]));
            }

            SLStyle estiloB = sl.CreateStyle(); //Creo estilo para bordes
            estiloB.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            //estiloB.Alignment.Horizontal(Right);

            sl.SetCellStyle("A6", "D" + dataCell.ToString(), estiloB);        //Asigno bordes al rango
            sl.AutoFitColumn("A", "D");                                     //Autoajustar columnas

            SLStyle alignment = sl.CreateStyle();
            alignment.Alignment.Horizontal = HorizontalAlignmentValues.Right;
            sl.SetCellStyle("G7", "D" + dataCell.ToString(), alignment);

            SLStyle number = sl.CreateStyle();
            number.FormatCode = "#,##0";
            sl.SetCellStyle("D7", "D" + (dataCell + 1).ToString(), number);

            //Suma de conteo Dx
            sl.SetCellValue("C" + (dataCell + 1), "TOTAL:");
            sl.SetCellValue("D" + (dataCell + 1), "=SUM(D7:D" + dataCell + ")");

            string tmpFile = Path.Combine(Path.GetTempPath(), "Consolidado_Conteo_" + anio + ".xlsx");        //Dirección carpeta temporal + nombre archivo
            sl.SaveAs(tmpFile);         //Guardo el archivo
            System.Diagnostics.Process.Start(tmpFile);

            mysql.CloseConnection();
        }

        //Reporte "diferencia conteo vs foto cierre"        --3/5   ◘◘◘◘
        public void ExpConteoVsCierre()
        {
            string selectQuery = "SELECT sb.codigo_prod, tbn.descripcion, SUM(CASE WHEN ci.cant_conteofinal >0 THEN ci.cant_conteofinal ELSE 0 END) as CantConteo, " +
                "sb.cantidad as CantSaldo, (SUM(CASE WHEN ci.cant_conteofinal >0 THEN ci.cant_conteofinal ELSE 0 END))-sb.cantidad as Diferencia " +
                "FROM tbsaldobodega sb INNER JOIN tbnart tbn ON sb.codigo_prod = tbn.codigo_prod " +
                "INNER JOIN tbconteosinventario ci ON ci.codigo_prod = sb.codigo_prod GROUP BY sb.codigo_prod ORDER BY sb.codigo_prod;";

            mysql.OpenConnection();
            MySqlCommand command = new MySqlCommand(selectQuery, mysql.connectionString);
            MySqlDataReader mdr = command.ExecuteReader();

            if (!mdr.HasRows)
            {
                MessageBox.Show("No hay datos disponibles.");
                return;
            }

            int dataCell = 6;
            var anio = DateTime.Now.ToString("yyyy");
            var fecha = DateTime.Now.ToString("dddd, dd MMMM yyyy");

            SLDocument sl = new SLDocument();
            sl.SetCellValue("A1", "BSN Medical LTDA");
            sl.SetCellValue("A2", "Inventario " + anio);
            sl.SetCellValue("A3", fecha);
            sl.SetCellValue("A4", "Diferencia conteo vs foto cierre");

            SLStyle estiloT = sl.CreateStyle();     //Estilo título
            estiloT.Font.FontSize = 16;
            estiloT.Font.Bold = true;
            estiloT.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            SLStyle estiloC = sl.CreateStyle();     //Estilo cabeceras
            estiloC.Font.Bold = true;
            sl.SetCellStyle("A4", estiloC);         //Imprime sin centrar
            estiloC.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            sl.SetCellStyle("A1", estiloT);
            sl.SetCellStyle("A2", estiloC);
            sl.SetCellStyle("A3", estiloC);

            sl.MergeWorksheetCells("A1", "E1");      //Combino primeras celdas
            sl.MergeWorksheetCells("A2", "E2");
            sl.MergeWorksheetCells("A3", "E3");
            sl.MergeWorksheetCells("A4", "B4");

            estiloC.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine);       //Color a cabeceras
            sl.SetCellStyle("A6", "E6", estiloC);

            sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Diferencia");      //Nombre de la hoja
            sl.SetCellValue("A" + dataCell, "Nart");
            sl.SetCellValue("B" + dataCell, "Descripción");
            sl.SetCellValue("C" + dataCell, "Conteo final");
            sl.SetCellValue("D" + dataCell, "Saldo bodega");
            sl.SetCellValue("E" + dataCell, "Diferencia");

            while (mdr.Read())       //Iteración - Lleno la tabla conlos datos del query
            {
                int dif = Convert.ToInt32(mdr["Diferencia"]);

                if (dif != 0)
                {
                    dataCell++;
                    sl.SetCellValue("A" + dataCell, mdr["codigo_prod"].ToString());
                    sl.SetCellValue("B" + dataCell, mdr["descripcion"].ToString());

                    int cConteo = Convert.ToInt32(mdr["CantConteo"]);
                    int tnrConteo = cConteo == 0 ? -1 : cConteo;
                    sl.SetCellValue("C" + dataCell, tnrConteo);

                    sl.SetCellValue("D" + dataCell, Convert.ToInt32(mdr["CantSaldo"]));

                    int trnDiferencia = dif < 0 ? dif * -1 : dif;
                    sl.SetCellValue("E" + dataCell, trnDiferencia);
                    //= SI(C7 < 0; D7; (SI((D7 - C7) < 0; (D7 - C7) * -1; (D7 - C7))))
                }
            }

            SLStyle estiloB = sl.CreateStyle(); //Creo estilo para bordes
            estiloB.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            //estiloB.Alignment.Horizontal(Right);

            sl.SetCellStyle("A6", "E" + dataCell.ToString(), estiloB);        //Asigno bordes al rango
            sl.AutoFitColumn("A", "E");                                     //Autoajustar columnas

            SLStyle alignment = sl.CreateStyle();
            alignment.Alignment.Horizontal = HorizontalAlignmentValues.Right;
            sl.SetCellStyle("C7", "E" + dataCell.ToString(), alignment);

            SLStyle number = sl.CreateStyle();
            number.FormatCode = "#,##0";
            sl.SetCellStyle("C7", "E" + (dataCell + 1).ToString(), number);

            string tmpFile = Path.Combine(Path.GetTempPath(), "Diferencia_conteo_vs_foto_cierre_" + anio + ".xlsx");        //Dirección carpeta temporal + nombre archivo
            sl.SaveAs(tmpFile);         //Guardo el archivo
            System.Diagnostics.Process.Start(tmpFile);

            mysql.CloseConnection();
        }

        //Reporte No digitados (Foto cierre/tarjetas)       --4-5/2 ◘◘◘◘
        public void ExpNoDigitados(int x)
        {
            string Query = "";
            string campo2 = "";
            string fileName = "Reporte No digitados";
            string sub = "Reporte No digitados";
            if (x == 1)
            {
                Query = "SELECT distinct codigo_prod, lote as campo2 FROM tbconteosinventario where codigo_prod not in (SELECT codigo_prod FROM tbnart);";
                campo2 = "Lote";
                fileName = "Narts_digitados_no_estan_en_cierre_";
                sub = "Narts digitados que no están en cierre";
            }
            else if (x == 2)
            {
                Query = "SELECT distinct codigo_prod, descripcion as campo2 FROM tbnart where codigo_prod not in (SELECT codigo_prod FROM tbconteosinventario);";
                campo2 = "Descripción";
                fileName = "Narts_foto_cierre_no_digitados_";
                sub = "Narts foto cierre no digitados";
            }

            mysql.OpenConnection();
            MySqlCommand command = new MySqlCommand(Query, mysql.connectionString);
            MySqlDataReader mdr = command.ExecuteReader();

            if (!mdr.HasRows)
            {
                MessageBox.Show("No hay datos disponibles.");
                return;
            }

            int dataCell = 6;
            var anio = DateTime.Now.ToString("yyyy");
            var fecha = DateTime.Now.ToString("dddd, dd MMMM yyyy");

            SLDocument sl = new SLDocument();
            sl.SetCellValue("A1", "BSN Medical LTDA");
            sl.SetCellValue("A2", "Inventario " + anio);
            sl.SetCellValue("A3", fecha);
            sl.SetCellValue("A4", sub);

            SLStyle estiloT = sl.CreateStyle();     //Estilo título
            estiloT.Font.FontSize = 16;
            estiloT.Font.Bold = true;
            estiloT.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            SLStyle estiloC = sl.CreateStyle();     //Estilo cabeceras
            estiloC.Font.Bold = true;
            sl.SetCellStyle("A4", estiloC);         //Imprime sin centrar
            estiloC.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            sl.SetCellStyle("A1", estiloT);
            sl.SetCellStyle("A2", estiloC);
            sl.SetCellStyle("A3", estiloC);

            sl.MergeWorksheetCells("A1", "D1");      //Combino primeras celdas
            sl.MergeWorksheetCells("A2", "D2");
            sl.MergeWorksheetCells("A3", "D3");
            sl.MergeWorksheetCells("A4", "D" +
                "4");

            estiloC.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine);       //Color a cabeceras
            sl.SetCellStyle("A6", "B6", estiloC);

            sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "No digitados");      //Nombre de la hoja
            sl.SetCellValue("A" + dataCell, "Nart");
            sl.SetCellValue("B" + dataCell, campo2);

            while (mdr.Read())       //Lleno la tabla conlos datos del query
            {
                dataCell++;
                sl.SetCellValue("A" + dataCell, mdr["codigo_prod"].ToString());
                sl.SetCellValue("B" + dataCell, mdr["campo2"].ToString());
            }

            SLStyle estiloB = sl.CreateStyle(); //Creo estilo para bordes
            estiloB.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            //estiloB.Alignment.Horizontal(Right);

            sl.SetCellStyle("A6", "B" + dataCell.ToString(), estiloB);        //Asigno bordes al rango
            sl.AutoFitColumn("A", "B");                                     //Autoajustar columnas

            //SLStyle alignment = sl.CreateStyle();
            //alignment.Alignment.Horizontal = HorizontalAlignmentValues.Right;
            //sl.SetCellStyle("G7", "B" + dataCell.ToString(), alignment);

            string tmpFile = Path.Combine(Path.GetTempPath(), fileName + anio + ".xlsx");        //Dirección carpeta temporal + nombre archivo
            sl.SaveAs(tmpFile);         //Guardo el archivo
            System.Diagnostics.Process.Start(tmpFile);

            mysql.CloseConnection();
        }

        //Reporte Total conteo y foto cierre                --6
        public void ReporteTotales()
        {
            string selectQuery = "SELECT sb.codigo_prod, tbn.descripcion, SUM(CASE WHEN ci.cant_conteofinal >0 THEN ci.cant_conteofinal ELSE 0 END) as CantConteo, " +
                "sb.cantidad as CantSaldo FROM tbsaldobodega sb INNER JOIN tbnart tbn ON sb.codigo_prod = tbn.codigo_prod " +
                "INNER JOIN tbconteosinventario ci ON ci.codigo_prod = sb.codigo_prod GROUP BY sb.codigo_prod ORDER BY sb.codigo_prod;";

            mysql.OpenConnection();
            MySqlCommand command = new MySqlCommand(selectQuery, mysql.connectionString);
            MySqlDataReader mdr = command.ExecuteReader();

            if (!mdr.HasRows)
            {
                MessageBox.Show("No hay datos disponibles.");
                return;
            }

            int dataCell = 6;
            var anio = DateTime.Now.ToString("yyyy");
            var fecha = DateTime.Now.ToString("dddd, dd MMMM yyyy");

            SLDocument sl = new SLDocument();
            sl.SetCellValue("A1", "BSN Medical LTDA");
            sl.SetCellValue("A2", "Inventario " + anio);
            sl.SetCellValue("A3", fecha);
            sl.SetCellValue("A4", "Total conteo y foto cierre");

            SLStyle estiloT = sl.CreateStyle();     //Estilo título
            estiloT.Font.FontSize = 16;
            estiloT.Font.Bold = true;
            estiloT.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            SLStyle estiloC = sl.CreateStyle();     //Estilo cabeceras
            estiloC.Font.Bold = true;
            sl.SetCellStyle("A4", estiloC);         //Imprime sin centrar
            estiloC.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            sl.SetCellStyle("A1", estiloT);
            sl.SetCellStyle("A2", estiloC);
            sl.SetCellStyle("A3", estiloC);

            sl.MergeWorksheetCells("A1", "D1");      //Combino primeras celdas
            sl.MergeWorksheetCells("A2", "D2");
            sl.MergeWorksheetCells("A3", "D3");
            sl.MergeWorksheetCells("A4", "B4");

            estiloC.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine);       //Color a cabeceras
            sl.SetCellStyle("A6", "D6", estiloC);

            sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Totales");      //Nombre de la hoja
            sl.SetCellValue("A" + dataCell, "Nart");
            sl.SetCellValue("B" + dataCell, "Descripción");
            sl.SetCellValue("C" + dataCell, "Conteo final");
            sl.SetCellValue("D" + dataCell, "Saldo bodega");

            int totalConteo = 0;
            int totalSaldo = 0;

            while (mdr.Read())       //Iteración - Lleno la tabla conlos datos del query
            {
                dataCell++;
                sl.SetCellValue("A" + dataCell, mdr["codigo_prod"].ToString());
                sl.SetCellValue("B" + dataCell, mdr["descripcion"].ToString());

                int cConteo = Convert.ToInt32(mdr["CantConteo"]);
                totalConteo += cConteo;
                int tnrConteo = cConteo == 0 ? -1 : cConteo;
                sl.SetCellValue("C" + dataCell, tnrConteo);

                sl.SetCellValue("D" + dataCell, Convert.ToInt32(mdr["CantSaldo"]));
                totalSaldo += Convert.ToInt32(mdr["CantSaldo"]);
            }

            SLStyle estiloB = sl.CreateStyle(); //Creo estilo para bordes
            estiloB.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            //estiloB.Alignment.Horizontal(Right);

            sl.SetCellStyle("A6", "D" + dataCell.ToString(), estiloB);        //Asigno bordes al rango
            sl.AutoFitColumn("A", "D");                                     //Autoajustar columnas

            dataCell++;
            sl.SetCellValue("B" + dataCell, "Total:");
            sl.SetCellValue("C" + dataCell, totalConteo);
            sl.SetCellValue("D" + dataCell, totalSaldo);

            SLStyle alignment = sl.CreateStyle();
            alignment.Alignment.Horizontal = HorizontalAlignmentValues.Right;
            sl.SetCellStyle("C7", "D" + dataCell.ToString(), alignment);

            estiloB.Font.Bold = true;
            sl.SetCellStyle("B" + dataCell, "D" + dataCell.ToString(), alignment);
            sl.SetCellStyle("B" + dataCell, "D" + dataCell.ToString(), estiloB);

            SLStyle number = sl.CreateStyle();
            number.FormatCode = "#,##0";
            sl.SetCellStyle("C7", "D" + (dataCell + 1).ToString(), number);

            string tmpFile = Path.Combine(Path.GetTempPath(), "Total_conteo_y_foto_cierre_" + anio + ".xlsx");        //Dirección carpeta temporal + nombre archivo
            sl.SaveAs(tmpFile);         //Guardo el archivo
            System.Diagnostics.Process.Start(tmpFile);

            mysql.CloseConnection();
        }

        //Reporte "Tarjetas que faltan por contar"          --7/7   ◘◘◘◘
        public void ExpTarjetasConteoFaltante()
        {
            string selectQuery = "SELECT ci.numero_tarjeta, ci.codigo_prod, tbn.descripcion, ci.lote, ci.cant_conteo1, ci.cant_conteo2, ci.cant_conteo3 " +
                    "FROM tbconteosinventario ci INNER JOIN tbnart tbn ON ci.codigo_prod = tbn.codigo_prod " +
                    "WHERE ci.cant_conteo1 = -1 AND ci.cant_conteo2 = -1 AND ci.cant_conteo3 = -1 ORDER BY ci.numero_tarjeta;";
            mysql.OpenConnection();
            MySqlCommand command = new MySqlCommand(selectQuery, mysql.connectionString);
            MySqlDataReader mdr = command.ExecuteReader();

            if (!mdr.HasRows)
            {
                MessageBox.Show("No hay datos disponibles.");
                return;
            }

            int dataCell = 6;
            var anio = DateTime.Now.ToString("yyyy");
            var fecha = DateTime.Now.ToString("dddd, dd MMMM yyyy");

            SLDocument sl = new SLDocument();
            sl.SetCellValue("A1", "BSN Medical LTDA");
            sl.SetCellValue("A2", "Inventario " + anio);
            sl.SetCellValue("A3", fecha);
            sl.SetCellValue("A4", "Tarjetas con conteo faltante");

            SLStyle estiloT = sl.CreateStyle();     //Estilo título
            estiloT.Font.FontSize = 16;
            estiloT.Font.Bold = true;
            estiloT.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            SLStyle estiloC = sl.CreateStyle();     //Estilo cabeceras
            estiloC.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            estiloC.Font.Bold = true;

            sl.SetCellStyle("A1", estiloT);
            sl.SetCellStyle("A2", estiloC);
            sl.SetCellStyle("A3", estiloC);
            sl.SetCellStyle("A4", estiloC);

            sl.MergeWorksheetCells("A1", "G1");      //Combino priimeras celdas
            sl.MergeWorksheetCells("A2", "G2");
            sl.MergeWorksheetCells("A3", "G3");
            sl.MergeWorksheetCells("A4", "B4");

            estiloC.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine);
            sl.SetCellStyle("A6", "G6", estiloC);

            sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Faltantes");      //Nombre de la hoja
            sl.SetCellValue("A" + dataCell, "Nro. Tarjeta");
            sl.SetCellValue("B" + dataCell, "Nart");
            sl.SetCellValue("C" + dataCell, "Descripción");
            sl.SetCellValue("D" + dataCell, "Lote");
            sl.SetCellValue("E" + dataCell, "Conteo 1");
            sl.SetCellValue("F" + dataCell, "Conteo 2");
            sl.SetCellValue("G" + dataCell, "Conteo 3");

            while (mdr.Read())       //Lleno la tabla conlos datos del query
            {
                dataCell++;
                sl.SetCellValue("A" + dataCell, Convert.ToInt32(mdr["numero_tarjeta"]));
                sl.SetCellValue("B" + dataCell, mdr["codigo_prod"].ToString());
                sl.SetCellValue("C" + dataCell, mdr["descripcion"].ToString());
                sl.SetCellValue("D" + dataCell, Convert.ToInt32(mdr["lote"]));
                sl.SetCellValue("E" + dataCell, Convert.ToInt32(mdr["cant_conteo1"]));
                sl.SetCellValue("F" + dataCell, Convert.ToInt32(mdr["cant_conteo2"]));
                sl.SetCellValue("G" + dataCell, Convert.ToInt32(mdr["cant_conteo3"]));
            }

            SLStyle estiloB = sl.CreateStyle(); //Creo estilo para bordes
            estiloB.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            //estiloB.Alignment.Horizontal(Right);

            sl.SetCellStyle("A6", "G" + dataCell.ToString(), estiloB);        //Asigno bordes al rango
            sl.AutoFitColumn("A", "G");                                     //Autoajustar columnas

            SLStyle alignment = sl.CreateStyle();
            alignment.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            sl.SetCellStyle("A7", "A" + dataCell.ToString(), alignment);
            alignment.Alignment.Horizontal = HorizontalAlignmentValues.Right;
            sl.SetCellStyle("G7", "G" + dataCell.ToString(), alignment);

            string path = Path.GetTempPath();                                                   //Para sacar la dirección de la carpeta temporal
            string tmpFile = Path.Combine(Path.GetTempPath(), "Tarjetas_conteo_faltante" + anio + ".xlsx");        //Junta dirección con nombre de archivo
            sl.SaveAs(tmpFile);         //Guardo el archivo
            System.Diagnostics.Process.Start(tmpFile);

            mysql.CloseConnection();
        }
    }
}