﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Inventario.Model
{
    public class ReportInfo
    {
        private static readonly XElement reportsXml = XElement.Load("Reports.xml");

        public static List<ReportModel> GetReportList()
        {
            var  data = reportsXml.Descendants("reporte");//.Where(
                                                       //rpt => (string) rpt.Element("rptTitulo"));

            var headers = reportsXml.Descendants("headerInfo");

            Console.WriteLine("total {0} \r\n", data.Count());

            foreach (var item in headers)
            {
                Console.WriteLine($"{item.Element("titulo").Value}");
                Console.WriteLine($"{item.Element("subtitulo").Value} {DateTime.Now.Year}");

                Console.WriteLine("\r\n-------\r\n");
            }

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
    }
}