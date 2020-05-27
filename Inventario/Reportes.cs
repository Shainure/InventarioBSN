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

namespace Inventario
{
    class Reportes
    {
        DataBaseConnection mysql = new DataBaseConnection();



        public void ExpConsolidadoNart()
        {
            string selectQuery = "SELECT ci.codigo_prod, tbn.descripcion, ci.bodega, SUM(ci.cant_conteofinal) as conteoFinal FROM tbconteosinventario ci" +
                " INNER JOIN tbnart tbn ON ci.codigo_prod = tbn.codigo_prod WHERE ci.cant_conteofinal !=-1 GROUP BY ci.codigo_prod ORDER BY ci.codigo_prod;";
            //WHERE ci.cant_conteofinal !=-1

            mysql.OpenConnection();
            MySqlCommand command = new MySqlCommand(selectQuery, mysql.connectionString);
            MySqlDataReader mdr = command.ExecuteReader();

            int dataCell = 6;
            var anio = DateTime.Now.ToString("yyyy");
            var fecha = DateTime.Now.ToString("dddd, dd MMMM yyyy");

            SLDocument sl = new SLDocument();
            sl.SetCellValue("A1", "BSN Medical LTDA");
            sl.SetCellValue("A2", "Inventario " + anio);
            sl.SetCellValue("A3", fecha);
            sl.SetCellValue("A4", "Consolidiado conteo");

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
            sl.SetCellValue("D" + (dataCell+1), "=SUM(D7:D" + dataCell + ")");

            string tmpFile = Path.Combine(Path.GetTempPath(), "Consolidado_Conteo_" + anio + ".xlsx");        //Dirección carpeta temporal + nombre archivo
            sl.SaveAs(tmpFile);         //Guardo el archivo
            System.Diagnostics.Process.Start(tmpFile);

            mysql.CloseConnection();
        }



        // Reporte tarjetas conteo
        public void ExpTarjetasConteos()
        {
            string selectQuery = "SELECT ci.numero_tarjeta, ci.codigo_prod, tbn.descripcion, ci.lote, ci.bodega, ci.ubicacion," +
                        "ci.cant_conteo1, ci.cant_conteo2, ci.cant_conteo3 FROM tbconteosinventario ci INNER JOIN tbnart tbn ON " +
                        "ci.codigo_prod = tbn.codigo_prod ORDER by ci.numero_tarjeta";
            mysql.OpenConnection();
            MySqlCommand command = new MySqlCommand(selectQuery, mysql.connectionString);
            MySqlDataReader mdr = command.ExecuteReader();

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
            string tmpFile = Path.Combine(Path.GetTempPath(), "Tarjetas_conteos_"+anio+".xlsx");        //Junta dirección con nombre de archivo
            sl.SaveAs(tmpFile);         //Guardo el archivo
            System.Diagnostics.Process.Start(tmpFile);

            mysql.CloseConnection();
        }
    }
}
