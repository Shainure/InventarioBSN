﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Inventario.Model
{
    public class ReadXmlData
    {
        private static readonly XElement reportsXml = XElement.Load("Reports.xml");

        public static ReportModel GetSelectQuery(string queryIndexId, params string[] arguments)
        {
            var data = reportsXml.Descendants("query")
                .Where(c => c.FirstAttribute.Value == queryIndexId)
                .First();

            ReportModel SelectQuery = new ReportModel()
            {
                ProcedureQuery = data.Element("procedureQuery").Value,
                Params = new List<ParamsModel>()
            };

            int index = 0;
            try
            {
                foreach (var pars in data.Descendants("parameter"))
                {
                    SelectQuery.Params.Add(new ParamsModel()
                    {
                        ParamName = pars.Value,
                        ParamValue = arguments[index]
                    });
                    index++;
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(BuildErrorMsg(ex), "Inventario BSN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return SelectQuery;
        }

        public static string[] GetReportsHeader()
        {
            var headers = reportsXml.Descendants("headerInfo")
                .First();

            string[] headersStr = new string[2];

            headersStr[0] = headers.Element("titulo").Value;
            headersStr[1] = $"{headers.Element("subtitulo").Value} {DateTime.Now.ToString("yyyy")}";

            return headersStr;
        }


        public static List<ReportModel> GetReportList()
        {
            var data = reportsXml.Descendants("reporte");

            List<ReportModel> reportsList = new List<ReportModel>();

            foreach (var item in data)
            {
                reportsList.Add(new ReportModel
                {
                    RptTitulo = item.Element("rptTitulo").Value,
                    NombrePagina = item.Element("rptNombrePag").Value,
                    ProcedureQuery = item.Element("procedureQuery").Value,
                    Totales = Convert.ToBoolean(item.Element("totales").Value)
                });
            }

            return reportsList;
        }

        private static string BuildErrorMsg(IndexOutOfRangeException ex)
        {
            StringBuilder errorMessage = new StringBuilder();
            errorMessage.Append("Error en ReadXmlData: Parametros fuera de rango\r\n");
            errorMessage.Append($"HResult: {ex.HResult} {Environment.NewLine}");
            errorMessage.Append($"Message: {ex.Message} {Environment.NewLine}");
            errorMessage.Append($"StackTrace: {ex.StackTrace} {Environment.NewLine}");

            return Convert.ToString(errorMessage);
        }
    }
}
