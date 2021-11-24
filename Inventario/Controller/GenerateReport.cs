using SpreadsheetLight;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventario.Model;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
//using DocumentFormat.OpenXml.Wordprocessing;

namespace Inventario.Controller
{
    public class GenerateReport
    {
        public static bool ExcelReport(ReportModel oReport)
        {
            //Get information for the report 
            oReport.ProcedureQuery = "test";
            System.Data.DataTable DtReport = DbLogic.SqlStoredProcedure(oReport);


            if (DtReport != null || DtReport.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró información para generar el reporte.", "Inventario BSN",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                //sqlDB.CloseConnection();
                return false;
            }


            int CurrentColumn = (int)'A';                           //Used to iterate excel columns
            int ColumnsNumber = DtReport.Columns.Count;             //Report column number based on the query
            int CurrentRow = 6;                                     //Row where the data starts to be written            
            char LastColumnChar = (char)(64 + ColumnsNumber);       //Column number (char)
            string[] headers = ReadXmlData.GetReportsHeader();      //Get headers            

            //Create excel file
            SLDocument ExcelFile = new SLDocument();

            //Set excel Page name
            ExcelFile.RenameWorksheet(SLDocument.DefaultFirstSheetName, oReport.NombrePagina);

            //Insert Initial data
            ExcelFile.SetCellValue("A1", headers[0]);
            ExcelFile.SetCellValue("A2", headers[1]);
            ExcelFile.SetCellValue("A3", DateTime.Now.ToString("dddd, dd MMMM yyyy"));
            ExcelFile.SetCellValue("A4", oReport.RptTitulo);            

            //Tittle style
            SLStyle StyleTittle = ExcelFile.CreateStyle();
            StyleTittle.Font.FontSize = 16;
            StyleTittle.Font.Bold = true;
            StyleTittle.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            //Headers Style
            SLStyle StyleHeaders = ExcelFile.CreateStyle();
            StyleHeaders.Font.Bold = true;
            ExcelFile.SetCellStyle("A4", StyleHeaders);     //Apply style before centering
            StyleHeaders.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            //Apply styles
            ExcelFile.SetCellStyle("A1", StyleTittle);
            ExcelFile.SetCellStyle("A2", StyleHeaders);
            ExcelFile.SetCellStyle("A3", StyleHeaders);

            //Merge header cells to the last cell of the table columns size
            ExcelFile.MergeWorksheetCells("A1", LastColumnChar + "1");
            ExcelFile.MergeWorksheetCells("A2", LastColumnChar + "2");
            ExcelFile.MergeWorksheetCells("A3", LastColumnChar + "3");
            ExcelFile.MergeWorksheetCells("A4", LastColumnChar + "4");

            //Set coloto "Header styles" Style object
            StyleHeaders.Fill.SetPattern(PatternValues.Solid, 
                                        System.Drawing.Color.Aqua,          //Foreground color
                                        System.Drawing.Color.Aquamarine);   //Background Color

            //Set header style (with color) to the Data column names
            ExcelFile.SetCellStyle("A6", LastColumnChar + "6", StyleHeaders);


            // Set table headers text
            for (int i = 0; i < ColumnsNumber; i++)
            {
                ExcelFile.SetCellValue($"{(char)CurrentColumn++}{CurrentRow}", DtReport.Columns[i].ColumnName);
            }

            //Fil the rest of the report
            foreach (DataRow item in DtReport.Rows)
            {
                //Reset column
                CurrentColumn = (int)'A';

                //Step on next row
                CurrentRow++;
                for (int i = 0; i < item.ItemArray.Length; i++)
                {
                    if (item[i] is string)
                    {
                        ExcelFile.SetCellValue($"{(char)CurrentColumn++}{CurrentRow}",
                            Convert.ToString(item[i]));
                    }
                    else
                    {
                        ExcelFile.SetCellValue($"{(char)CurrentColumn++}{CurrentRow}",
                            Convert.ToInt32(item[i]));
                    }
                }
            }

            //Style for the borders 
            SLStyle StyleBorder = ExcelFile.CreateStyle();
            StyleBorder.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            StyleBorder.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            StyleBorder.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            StyleBorder.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            //StyleBorder.Alignment.Horizontal(Right);

            //Apply border style to the data table 
            ExcelFile.SetCellStyle("A6", $"{LastColumnChar}{CurrentRow}", StyleBorder);
            ExcelFile.AutoFitColumn("A", Convert.ToString(LastColumnChar));

            //Get file path & name
            string tmpFile = FilePath($"{oReport.RptTitulo} {DateTime.Now.ToString("yyyy")}");

            //Save file on disk
            ExcelFile.SaveAs(tmpFile);         
            System.Diagnostics.Process.Start(tmpFile);

            //Clear the memory
            ExcelFile.Dispose();

            return true;
        }


        private static string FilePath(string fileName)
        {
            string tmpFile = Path.Combine(Path.GetTempPath(), fileName);
            string aux = tmpFile;
            int index = 1;
            while (File.Exists(tmpFile + ".xlsx"))
            {
                tmpFile = $"{aux} ({index})";
                index++;
            }
            tmpFile += ".xlsx";
            return tmpFile;
        }
    }
}
