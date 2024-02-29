using Dapper;
using Lixil.Snow.Utilities;
using Microsoft.VisualBasic;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{
    /// <summary>
    /// 配布実施
    /// </summary>
    /// <remarks>20181015 修(大連) 新規作成</remarks>
    public class P030305_DataAccess : SqlManager
    {

        /// <summary>
        /// 配布履歴更新
        /// </summary>
        /// <param name="kaiSyuBi">回収日</param>
        /// <param name="wcEcnNo">変更通知番号</param>
        /// <param name="wcObjNo">図面・ドキュメントの番号</param>
        /// <param name="gyosyaID">業者ID</param>
        /// <param name="userID">ユーザーID</param>
        /// <param name="haifumoto">配布元</param>
        /// <param name="PGM">機能ID</param>
        /// <returns>処理結果</returns>
        /// <remarks>20181015 修(大連) 新規作成</remarks>
        public int UpdHaifuDetailDate(string kaiSyuBi, string wcEcnNo, string wcObjNo, string gyosyaID, string haifumoto, string userID, string PGM)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;
            var sql = "";
            sql += " UPDATE ";
            sql += " HAIFU_DETAIL ";               // 業者配布履歴・明細
            sql += " SET ";
            // 回収日が空白場合
            if (string.IsNullOrEmpty(kaiSyuBi))
            {
                sql += " STATUS = '" + Utilities.AppConst.Status.HAIFUZUMI + "' ";      // 配布区分
                sql += " ,HAIFUBI = TO_DATE( NOW() ,'YYYY/MM/DD') ";
            }
            else
            {
                // 回収日が空白以外場合
                sql += " STATUS = '" + Utilities.AppConst.Status.KAISYUZUMI + "' ";
                sql += $" ,KAISYUBI = TO_DATE( '{kaiSyuBi}' ,'YYYY/MM/DD') ";
            }
            sql += $" ,MODIFY_PGM = '{PGM}' ";
            sql += $" ,MODIFY_PERSON = '{userID}' ";
            sql += " ,MODIFY_DATE = NOW() ";
            sql += " WHERE ";
            sql += $" WC_ECN_NO  = '{wcEcnNo}' ";     // 変更通知番号
            sql += $" AND WC_OBJ_NO  = '{wcObjNo}' "; // 図面・ドキュメントの番号
            sql += $" AND GYOSYA_ID  = '{gyosyaID}' "; // 業者ID
            sql += $" AND HAIFUMOTO  = '{haifumoto}' "; // 配布元

            var result = db.Execute(sql);
            return result;
        }

    }
}
