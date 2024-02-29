using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{
    /// <summary>
    /// Snow業者マスタのデータアクセス
    /// </summary>
    /// <remarks>20181015 修(大連) 新規作成</remarks>
    public class P030303_DataAccess : SqlManager
    {
        /// <summary>
        /// Snow業者マスタの取得
        /// </summary>
        /// <param name="drpBumon">部門</param>
        /// <param name="txtGyosyaName">業者名</param>
        /// <param name="txtCanaName">業者名</param>
        /// <returns>業者マスタ</returns>
        /// <remarks>20181015 修(大連) 新規作成</remarks>
        public List<GYOSYA> SelGyosyaData(string drpBumon, string txtGyosyaName, string txtCanaName)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;

            var wherestr = "";
            // 業者名(テキストBOX)で入力された業者名が空白以外の場合
            if (!string.IsNullOrEmpty(txtGyosyaName))
            {
                wherestr += $"AND GS.GYOSYA_NAME like '{txtGyosyaName}'";
            }
            // 業者名(カナ)(テキストBOX)で入力された業者名(カナ)が空白以外の場合
            if (!string.IsNullOrEmpty(txtCanaName))
            {
                wherestr += $" AND GS.KANA_NAME like '{txtCanaName}'";
            }

            var result = db.Query<GYOSYA>($"SELECT GS.BUMON ,GS.GYOSYA_ID ,GS.GYOSYA_NAME FROM GYOSYA GS WHERE GS.BUMON  = '{drpBumon}' " + wherestr + "ORDER BY GS.KANA_NAME ").ToList();

            return result;
        }

    }
}
