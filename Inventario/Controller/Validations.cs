using Inventario.Model;
using System;
using System.Data;
using System.Text;

namespace Inventario.Controller
{
    public class Validations
    {
        public static DataTable CheckCard(string index, params string[] _params)
        {
            ReportModel cardModel = ReadXmlData.GetSelectQuery(index, _params);
            var cardInfo = DbLogic.SqlStoredProcedure(cardModel);

            return cardInfo;
        }

        public static bool RequestConteo3(string index, params string[] _params)
        {
            ReportModel conteoModel = ReadXmlData.GetSelectQuery(index, _params);
            var cardInfo = DbLogic.SqlStoredProcedure(conteoModel);

            int conteo1 = Convert.ToInt32(cardInfo.Rows[0][0]);
            int conteo2 = Convert.ToInt32(cardInfo.Rows[0][1]);

            if ((conteo1 != -1 && conteo2 != -1) && (conteo1 != conteo2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string ValidateConteo3(string index, params string[] _params)
        {
            ReportModel conteoModel = ReadXmlData.GetSelectQuery(index, _params);
            var cardInfo = DbLogic.SqlStoredProcedure(conteoModel);

            int conteo1 = Convert.ToInt32(cardInfo.Rows[0][0]);
            int conteo2 = Convert.ToInt32(cardInfo.Rows[0][1]);
            int conteo3 = Convert.ToInt32(cardInfo.Rows[0][2]);

            if ((conteo1 == conteo3) || (conteo2 == conteo3))
            {
                return null;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"¡Conteo 3 de la tarjeta No. {_params[0]} es diferente a los otros conteos!\r\n");
                sb.AppendLine($"Conteo 1 = {conteo1}");
                sb.AppendLine($"Conteo 2 = {conteo2}");
                sb.AppendLine($"Conteo 3 = {conteo3}");

                return sb.ToString();
            }
        }

        public static bool AllowConteo3(string index, params string[] _params)
        {
            ReportModel conteoModel = ReadXmlData.GetSelectQuery(index, _params);
            var cardInfo = DbLogic.SqlStoredProcedure(conteoModel);

            int conteo1 = Convert.ToInt32(cardInfo.Rows[0][0]);
            int conteo2 = Convert.ToInt32(cardInfo.Rows[0][1]);

            if (conteo1 == -1 || conteo2 == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static int CheckConteoValue(string index, params string[] _params)
        {
            ReportModel conteoModel = ReadXmlData.GetSelectQuery(index, _params);
            var cardInfo = DbLogic.SqlStoredProcedure(conteoModel);

            return Convert.ToInt32(cardInfo.Rows[0][0]);
        }
    }
}
