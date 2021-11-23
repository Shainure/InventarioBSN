using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Model
{
    public class ReportModel
    {
        public string RptTitulo { get; set; }
        public string NombrePagina { get; set; }
        public string ProcedureQuery { get; set; }
        public bool Totales { get; set; }
        public List<ParamsModel> Params { get; set; }
    }
}
