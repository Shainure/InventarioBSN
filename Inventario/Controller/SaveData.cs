using Inventario.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Controller
{
    public class SaveData
    {
        private static DbLogic dbLogic = new DbLogic();

        public static int SaveCard(string index, params string[] _params)
        {
            ReportModel cardModel = ReadXmlData.GetSelectQuery(index, _params);
            int cardInfo = dbLogic.SqlSpNonQuery(cardModel.ProcedureQuery, cardModel.Params);

            return cardInfo;
        }


        public static int Consolidate(string index)
        {
            ReportModel cardModel = ReadXmlData.GetSelectQuery(index);
            var cardInfo = dbLogic.SqlStoredProcedure(cardModel.ProcedureQuery, null);
            int affectedRows = Convert.ToInt32(cardInfo.Rows[0][0]);
            return affectedRows;
        }
    }
}
