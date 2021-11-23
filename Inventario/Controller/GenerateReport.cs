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

namespace Inventario.Controller
{
    public class GenerateReport
    {
        private DbLogic _DbLogic = new DbLogic();

        private readonly string anio = DateTime.Now.ToString("yyyy");
        private readonly string fecha = DateTime.Now.ToString("dddd, dd MMMM yyyy");

        private int dataCell = 6;           //Where the data starts (Column names > Data)
        private char ColumnChar = 'A';      //Char for the first column where data starts (excel)


        public SLDocument ExcelReport(ReportModel report)
        {
            List<ParamsModel> Params = new List<ParamsModel>();
            Params.Add(new ParamsModel { ParamName="num_tarjeta", ParamValue="5" });
            
            //Params.Add(new ParamsModel { ParamName="name3", ParamValue="Value3" });
            //Params.Add(new ParamsModel { ParamName="name4", ParamValue="Value4" });
            var asd = _DbLogic.SqlStoredProcedure("Sp_inf_tarjeta", Params);
            Console.ReadLine();

            /*
            dataCell = 6;
            int numColumna = reader.FieldCount;                         //Número de columnas
            ColumnChar = (char)(64 + reader.FieldCount);            //Número de columnas max en letra (para excel)

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

            newSld.MergeWorksheetCells("A1", ColumnChar + "1");      //Combino primeras celdas
            newSld.MergeWorksheetCells("A2", ColumnChar + "2");
            newSld.MergeWorksheetCells("A3", ColumnChar + "3");
            newSld.MergeWorksheetCells("A4", ColumnChar + "4");

            estiloC.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine);       //Color a cabeceras
            newSld.SetCellStyle("A6", ColumnChar + "6", estiloC);

            newSld.RenameWorksheet(SLDocument.DefaultFirstSheetName, nomPag);      //Nombre de la hoja

            int letraCol = 65; //Letra de columna (convierto a char luego)

            foreach (DataRow row in table.Rows)                                 //Lleno nombre de columnas
            {
                newSld.SetCellValue((char)letraCol + dataCell.ToString(), row.Field<string>("ColumnName"));

                letraCol++;
            }


            var tipos = new List<string>();
            int j = 0;

            while (rdr.Read())       //Lleno la tabla conlos datos del query
            {
                dataCell++;
                letraCol = 65;
                for (int i = 0; i < numColumna; i++)
                {
                    // newSld = new archivo de excel
                    if (rdr.GetFieldType(i).ToString() == "System.String")
                        newSld.SetCellValue((char)letraCol + dataCell.ToString(), "'"+rdr.GetValue(i).ToString());
                    else
                    {
                        int value = Convert.ToInt32(rdr.GetValue(i));
                        if (value < 0)
                            value *= -1;
                        newSld.SetCellValue((char)letraCol + dataCell.ToString(), value);
                    }
                    letraCol++;
                }
                //Guardo los tipos de columnas solo 1 vez
                while (j < numColumna)
                {
                    tipos.Add(rdr.GetFieldType(j).ToString());
                    j++;
                }

            }
            SLStyle estiloB = newSld.CreateStyle(); //Creo estilo para bordes
            estiloB.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            //estiloB.Alignment.Horizontal(Right);

            newSld.SetCellStyle("A6", ColumnChar.ToString() + dataCell.ToString(), estiloB);        //Asigno bordes al rango
            newSld.AutoFitColumn("A", ColumnChar.ToString());                                     //Autoajustar columnas

            return newSld;*/
            return null;
        }
    }
}
