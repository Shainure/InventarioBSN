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
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Data;

namespace Inventario
{
    internal class Reportes
    {
        private DataBaseConnection sqlDB = new DataBaseConnection();
        private readonly string anio = DateTime.Now.ToString("yyyy");
        private readonly string fecha = DateTime.Now.ToString("dddd, dd MMMM yyyy");
        private int dataCell = 6;
        private char chColumna = 'A';

        private string FilePath(string fileName)
        {
            string tmpFile = Path.Combine(Path.GetTempPath(), fileName);
            string aux = tmpFile;
            int x = 1;
            while (File.Exists(tmpFile + ".xlsx"))
            {
                tmpFile = aux + "_(" + x + ")";
                x++;
            }
            tmpFile += ".xlsx";
            return tmpFile;
        }

        // Reporte "tarjetas conteo"                        --1/9   ◘◘◘◘
        public void ExpTarjetasConteos()
        {
            SqlDataReader mdr = sqlDB.SqlCommand("rpt_tarjetas_conteo", true);

            if (!avisoSinDatos(mdr))
            {
                return;
            }

            SLDocument sl = new SLDocument();
            sl = GenerarReporte(sl, mdr, "Tarjetas conteo", "Tarjetas");

            SLStyle alignment = sl.CreateStyle();
            alignment.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            sl.SetCellStyle("A7", "A" + dataCell.ToString(), alignment);
            alignment.Alignment.Horizontal = HorizontalAlignmentValues.Right;
            sl.SetCellStyle("G7", "I" + dataCell.ToString(), alignment);

            string tmpFile = FilePath("Tarjetas_conteos_" + anio);
            sl.SaveAs(tmpFile);         //Guardo el archivo
            System.Diagnostics.Process.Start(tmpFile);

            sqlDB.CloseConnection();
        }

        private SLDocument GenerarReporte(SLDocument sld, SqlDataReader reader, string subTitulo, string nomPag)
        {
            dataCell = 6;
            int numColumna = reader.FieldCount;                         //Número de columnas
            chColumna = (char)(64 + reader.FieldCount);            //Número de columnas  max en letra (para excel)

            SqlDataReader rdr = reader;
            var table = rdr.GetSchemaTable();       //Obtengo nombre de columnas
            SLDocument newSld = sld;

            newSld.SetCellValue("A1", "BSN Medical LTDA");
            newSld.SetCellValue("A2", "Inventario " + anio);
            newSld.SetCellValue("A3", fecha);
            newSld.SetCellValue("A4", subTitulo);

            SLStyle estiloT = newSld.CreateStyle();     //Estilo título
            estiloT.Font.FontSize = 16;
            estiloT.Font.Bold = true;
            estiloT.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            SLStyle estiloC = newSld.CreateStyle();     //Estilo cabeceras
            estiloC.Font.Bold = true;
            newSld.SetCellStyle("A4", estiloC);         //Imprime sin centrar
            estiloC.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            newSld.SetCellStyle("A1", estiloT);
            newSld.SetCellStyle("A2", estiloC);
            newSld.SetCellStyle("A3", estiloC);

            newSld.MergeWorksheetCells("A1", chColumna + "1");      //Combino primeras celdas
            newSld.MergeWorksheetCells("A2", chColumna + "2");
            newSld.MergeWorksheetCells("A3", chColumna + "3");
            newSld.MergeWorksheetCells("A4", chColumna + "4");

            estiloC.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine);       //Color a cabeceras
            newSld.SetCellStyle("A6", chColumna + "6", estiloC);

            newSld.RenameWorksheet(SLDocument.DefaultFirstSheetName, nomPag);      //Nombre de la hoja

            int letraCol = 65; //Letra de columna (convierto a char luego)

            var result = new List<string>();
            foreach (DataRow row in table.Rows)                                 //Lleno nombre de columnas
            {
                newSld.SetCellValue((char)letraCol + dataCell.ToString(), row.Field<string>("ColumnName"));

                letraCol++;
            }

            while (rdr.Read())       //Lleno la tabla conlos datos del query
            {
                dataCell++;
                letraCol = 65;
                for (int i = 0; i < numColumna; i++)
                {
                    newSld.SetCellValue((char)letraCol + dataCell.ToString(), rdr.GetValue(i).ToString());
                    letraCol++;
                }
            }

            SLStyle estiloB = newSld.CreateStyle(); //Creo estilo para bordes
            estiloB.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            //estiloB.Alignment.Horizontal(Right);

            newSld.SetCellStyle("A6", chColumna.ToString() + dataCell.ToString(), estiloB);        //Asigno bordes al rango
            newSld.AutoFitColumn("A", chColumna.ToString());                                     //Autoajustar columnas

            return newSld;
        }

        //Reporte "Consolidado Conteo"                      --2/4   ◘◘◘◘
        public void ExpConsolidadoNart()
        {
            SqlDataReader mdr = sqlDB.SqlCommand("rpt_consolidado_conteo", true);

            if (!avisoSinDatos(mdr))
            {
                return;
            }

            SLDocument sl = new SLDocument();
            sl = GenerarReporte(sl, mdr, "Consolidado conteo", "Consolidado");

            SLStyle alignment = sl.CreateStyle();
            alignment.Alignment.Horizontal = HorizontalAlignmentValues.Right;
            sl.SetCellStyle("G7", "D" + dataCell.ToString(), alignment);

            SLStyle number = sl.CreateStyle();
            number.FormatCode = "#,##0";
            sl.SetCellStyle("D7", "D" + (dataCell + 1).ToString(), number);

            //Suma de conteo Dx
            sl.SetCellValue("C" + (dataCell + 1), "TOTAL:");
            sl.SetCellValue("D" + (dataCell + 1), "=SUM(D7:D" + dataCell + ")");

            string tmpFile = FilePath("Consolidado_Conteo_" + anio);
            sl.SaveAs(tmpFile);         //Guardo el archivo
            System.Diagnostics.Process.Start(tmpFile);

            sqlDB.CloseConnection();
        }

        //Reporte "diferencia conteo vs foto cierre"        --3/5   ◘◘◘◘
        public void ExpConteoVsCierre()
        {
            SqlDataReader mdr = sqlDB.SqlCommand("rpt_diferencia_conteo_cierre", true);

            if (!avisoSinDatos(mdr))
            {
                return;
            }

            SLDocument sl = new SLDocument();
            sl = GenerarReporte(sl, mdr, "Diferencia conteo vs foto cierre", "Diferencia");

            SLStyle alignment = sl.CreateStyle();
            alignment.Alignment.Horizontal = HorizontalAlignmentValues.Right;
            sl.SetCellStyle("C7", "E" + dataCell.ToString(), alignment);

            SLStyle number = sl.CreateStyle();
            number.FormatCode = "#,##0";
            sl.SetCellStyle("C7", "E" + (dataCell + 1).ToString(), number);

            string tmpFile = FilePath("Diferencia_conteo_vs_foto_cierre_" + anio);
            sl.SaveAs(tmpFile);         //Guardo el archivo
            System.Diagnostics.Process.Start(tmpFile);

            sqlDB.CloseConnection();
        }

        //Reporte No digitados (Foto cierre/tarjetas)       --4-5/2 ◘◘◘◘
        public void ExpNoDigitados(int x)
        {
            string fileName = "Reporte No digitados";
            string sub = "Reporte No digitados";
            string procedure = "rpt_digitados_no_cierre";
            if (x == 1)
            {
                fileName = "Narts_digitados_no_estan_en_cierre_";
                sub = "Narts digitados que no están en foto cierre";
            }
            else if (x == 2)
            {
                procedure = "rpt_cierre_no_digitados";
                fileName = "Narts_foto_cierre_no_digitados_";
                sub = "Narts foto cierre no digitados";
            }

            SqlDataReader mdr = sqlDB.SqlCommand(procedure, true);

            if (!avisoSinDatos(mdr))
            {
                return;
            }

            SLDocument sl = new SLDocument();
            sl = GenerarReporte(sl, mdr, sub, "No digitados");

            //SLStyle alignment = sl.CreateStyle();
            //alignment.Alignment.Horizontal = HorizontalAlignmentValues.Right;
            //sl.SetCellStyle("G7", "B" + dataCell.ToString(), alignment);

            string tmpFile = FilePath(fileName + anio);
            sl.SaveAs(tmpFile);         //Guardo el archivo
            System.Diagnostics.Process.Start(tmpFile);

            sqlDB.CloseConnection();
        }

        //Reporte Total conteo y foto cierre                --6
        public void ReporteTotales()
        {
            SqlDataReader mdr = sqlDB.SqlCommand("rpt_total_conteo_cierre", true);

            if (!avisoSinDatos(mdr))
            {
                return;
            }

            SLDocument sl = new SLDocument();
            sl = GenerarReporte(sl, mdr, "Total conteo y foto cierre", "Totales");

            /*
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
            }*/

            SLStyle estiloB = sl.CreateStyle(); //Creo estilo para bordes
            dataCell++;

            sl.SetCellValue("B" + dataCell, "Total:");
            /*sl.SetCellValue("C" + dataCell, totalConteo);
            sl.SetCellValue("D" + dataCell, totalSaldo);*/
            sl.SetCellValue("C" + dataCell, "=+(C7:C" + (dataCell - 1) + ")");
            sl.SetCellValue("D" + dataCell, "=+(D7:D" + (dataCell - 1) + ")");

            SLStyle alignment = sl.CreateStyle();
            alignment.Alignment.Horizontal = HorizontalAlignmentValues.Right;
            sl.SetCellStyle("C7", "D" + dataCell.ToString(), alignment);

            estiloB.Font.Bold = true;
            sl.SetCellStyle("B" + dataCell, "D" + dataCell.ToString(), alignment);
            sl.SetCellStyle("B" + dataCell, "D" + dataCell.ToString(), estiloB);

            SLStyle number = sl.CreateStyle();
            number.FormatCode = "#,##0";
            sl.SetCellStyle("C7", "D" + (dataCell + 1).ToString(), number);

            string tmpFile = FilePath("Total_conteo_y_foto_cierre_" + anio);
            sl.SaveAs(tmpFile);         //Guardo el archivo
            System.Diagnostics.Process.Start(tmpFile);

            sqlDB.CloseConnection();
        }

        //Reporte "Tarjetas que faltan por contar"          --7/7   ◘◘◘◘
        public void ExpTarjetasConteoFaltante()
        {
            SqlDataReader mdr = sqlDB.SqlCommand("rpt_tarjetas_sin_contar", true);

            if (!avisoSinDatos(mdr))
            {
                return;
            }

            SLDocument sl = new SLDocument();
            sl = GenerarReporte(sl, mdr, "Tarjetas con conteo faltante", "Faltantes");

            SLStyle alignment = sl.CreateStyle();
            alignment.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            sl.SetCellStyle("A7", "A" + dataCell.ToString(), alignment);
            alignment.Alignment.Horizontal = HorizontalAlignmentValues.Right;
            sl.SetCellStyle("G7", "G" + dataCell.ToString(), alignment);

            string tmpFile = FilePath("Tarjetas_conteo_faltante_" + anio);
            sl.SaveAs(tmpFile);         //Guardo el archivo
            System.Diagnostics.Process.Start(tmpFile);

            sqlDB.CloseConnection();
        }

        private bool avisoSinDatos(SqlDataReader mdr)
        {
            if (mdr.HasRows)
            {
                return true;
            }
            else
            {
                MessageBox.Show("No se encontró información.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
        }
    }
}