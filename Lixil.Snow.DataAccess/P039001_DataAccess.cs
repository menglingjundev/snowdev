using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.VisualBasic;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{
    /// <summary>
    /// 業者配布履歴の業者変更のデータアクセス
    /// </summary>
    /// <remarks>20190729 王(大連) 新規作成</remarks>
    public class P039001_DataAccess : SqlManager
    {
        /// <summary>
        /// 業者配布履歴・明細を検索して、件数を取得する
        /// </summary>
        /// <param name="txtGyosyaID">業者ID</param>
        /// <returns>取得件数</returns>
        /// <remarks>20190729 王(大連) 新規作成</remarks>
        public int CntHaifudetailByID(string txtGyosyaID)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;

            var result = db.Query<int>($"SELECT COUNT(*) FROM HAIFU_DETAIL HD WHERE HD.GYOSYA_ID  = '{txtGyosyaID}'").ToList();

            return result[0];

        }

        /// <summary>
        /// 変更後の業者IDが存在する場合、変更前の業者IDの業者配布履歴・明細を削除する
        /// </summary>
        /// <param name="txtGyosyaIDMae">変更前の業者ID</param>
        /// <param name="txtGyosyaIDAto">変更後の業者ID</param>
        /// <returns>取得件数</returns>
        /// <remarks>20190729 王(大連) 新規作成</remarks>
        public int DelHaifudetailByID(string txtGyosyaIDMae, string txtGyosyaIDAto)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;

            var result = db.Execute($"DELETE HAIFU_DETAIL HD1 WHERE HD1.GYOSYA_ID = '{txtGyosyaIDMae}'  AND EXISTS (  SELECT 1 FROM HAIFU_DETAIL HD2 WHERE HD1.WC_ECN_NO = HD2.WC_ECN_NO   AND HD1.WC_OBJ_NO = HD2.WC_OBJ_NO  AND HD1.HAIFUMOTO = HD2.HAIFUMOTO  AND HD2.GYOSYA_ID = '{txtGyosyaIDAto}' )");

            return result;
        }

        /// <summary>
        /// 業者配布履歴（最新）を検索して、件数を取得する
        /// </summary>
        /// <param name="txtGyosyaID">業者ID</param>
        /// <returns>取得件数</returns>
        /// <remarks>20190729 王(大連) 新規作成</remarks>
        public int CntHaifudetailLastByID(string txtGyosyaID)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;

            var result = db.Query<int>($"SELECT COUNT(*) FROM HAIFU_DETAIL_LAST HDL WHERE HDL.GYOSYA_ID_1  = '{txtGyosyaID}' OR HDL.GYOSYA_ID_2  = '{txtGyosyaID}' OR HDL.GYOSYA_ID_3  = '{txtGyosyaID}' OR HDL.GYOSYA_ID_4  = '{txtGyosyaID}' OR HDL.GYOSYA_ID_5  = '{txtGyosyaID}' ").ToList();

            return result[0];
        }

        /// <summary>
        /// 業者配布履歴・明細を更新する
        /// </summary>
        /// <param name="TxtGyousyaMaeID">変更前業者ID</param>
        /// <param name="TxtGyousyaAtoID">変更後業者ID</param>
        /// <param name="TxtGyousyaAtoMei">変更後業者名</param>
        /// <param name="userID">ユーザーID</param>
        /// <param name="PGM">機能ID</param>
        /// <returns>処理結果</returns>
        /// <remarks>20181015 陳(大連) 新規作成</remarks>
        public int UpdHaifuDetailDataByID(string TxtGyousyaMaeID, string TxtGyousyaAtoID, string TxtGyousyaAtoMei, string userID, string PGM)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;

            var result = db.Execute($" UPDATE HAIFU_DETAIL SET GYOSYA_ID = '{TxtGyousyaAtoID}', GYOSYA_NAME = '{TxtGyousyaAtoMei}', MODIFY_PGM = '{PGM}' ,MODIFY_PERSON = '{userID}', MODIFY_DATE =NOW() WHERE GYOSYA_ID  = '{TxtGyousyaMaeID}'");

            return result;
        }




        public int UpdHaifuDetailLastDataByID(string TxtGyousyaMaeID, string TxtGyousyaAtoID, string TxtGyousyaAtoMei, string userID, string PGM)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;

            int kousinCnt = 0;   // 更新カウント数

            var sql = "";
            sql += " UPDATE ";
            sql += " HAIFU_DETAIL_LAST HDL ";                      // 業者配布履歴（最新）
            sql += " SET ";                                    // 
            sql += "     HDL.GYOSYA_ID_1 = ";                  // 業者ID１
            sql += "     CASE ";                                   // 
            sql += $"     WHEN HDL.GYOSYA_ID_1 = '{TxtGyousyaMaeID}' ";
            sql += "     THEN NULL ";
            sql += "     ELSE ";
            sql += "         HDL.GYOSYA_ID_1 ";
            sql += "     END ";
            sql += "     ,HDL.GYOSYA_NAME_1 = ";                  // 業者名１
            sql += "     CASE ";                                   // 
            sql += $"     WHEN HDL.GYOSYA_ID_1 = ' {TxtGyousyaMaeID} ' ";
            sql += "     THEN NULL ";
            sql += "     ELSE ";
            sql += "         HDL.GYOSYA_NAME_1 ";
            sql += "     END ";
            sql += "     ,HDL.BUSUU_1 = ";                  // 部数１
            sql += "     CASE ";                                   // 
            sql += $"     WHEN HDL.GYOSYA_ID_1 = ' {TxtGyousyaMaeID} ' ";
            sql += "     THEN NULL ";
            sql += "     ELSE ";
            sql += "         HDL.BUSUU_1 ";
            sql += "     END ";
            sql += "     ,HDL.GYOSYA_ID_2 = ";                  // 業者ID２
            sql += "     CASE ";                                   // 
            sql += $"     WHEN HDL.GYOSYA_ID_2 = '{TxtGyousyaMaeID}' ";
            sql += "     THEN NULL ";
            sql += "     ELSE ";
            sql += "         HDL.GYOSYA_ID_2 ";
            sql += "     END ";
            sql += "     ,HDL.GYOSYA_NAME_2 = ";                  // 業者名２
            sql += "     CASE ";                                   // 
            sql += $"     WHEN HDL.GYOSYA_ID_2 = '{TxtGyousyaMaeID}' ";
            sql += "     THEN NULL ";
            sql += "     ELSE ";
            sql += "         HDL.GYOSYA_NAME_2 ";
            sql += "     END ";
            sql += "     ,HDL.BUSUU_2 = ";                  // 部数２
            sql += "     CASE ";                                   // 
            sql += $"     WHEN HDL.GYOSYA_ID_2 = '{TxtGyousyaMaeID}' ";
            sql += "     THEN NULL ";
            sql += "     ELSE ";
            sql += "         HDL.BUSUU_2 ";
            sql += "     END ";
            sql += "     ,HDL.GYOSYA_ID_3 = ";                  // 業者ID３
            sql += "     CASE ";                                   // 
            sql += $"     WHEN HDL.GYOSYA_ID_3 = '{TxtGyousyaMaeID}' ";
            sql += "     THEN NULL ";
            sql += "     ELSE ";
            sql += "         HDL.GYOSYA_ID_3";
            sql += "     END ";
            sql += "     ,HDL.GYOSYA_NAME_3 = ";                  // 業者名３
            sql += "     CASE ";                                   // 
            sql += $"     WHEN HDL.GYOSYA_ID_3 = '{TxtGyousyaMaeID}'";
            sql += "     THEN NULL ";
            sql += "     ELSE ";
            sql += "         HDL.GYOSYA_NAME_3 ";
            sql += "     END ";
            sql += "     ,HDL.BUSUU_3 = ";                  // 部数３
            sql += "     CASE ";                                   // 
            sql += $"     WHEN HDL.GYOSYA_ID_3 = '{TxtGyousyaMaeID}' ";
            sql += "     THEN NULL ";
            sql += "     ELSE ";
            sql += "         HDL.BUSUU_3 ";
            sql += "     END ";
            sql += "     ,HDL.GYOSYA_ID_4 = ";                  // 業者ID４
            sql += "     CASE ";                                   // 
            sql += $"     WHEN HDL.GYOSYA_ID_4 = '{TxtGyousyaMaeID}' ";
            sql += "     THEN NULL ";
            sql += "     ELSE ";
            sql += "         HDL.GYOSYA_ID_4";
            sql += "     END ";
            sql += "     ,HDL.GYOSYA_NAME_4 = ";                  // 業者名４
            sql += "     CASE ";                                   // 
            sql += $"     WHEN HDL.GYOSYA_ID_4 = '{TxtGyousyaMaeID}' ";
            sql += "     THEN NULL ";
            sql += "     ELSE ";
            sql += "         HDL.GYOSYA_NAME_4 ";
            sql += "     END ";
            sql += "     ,HDL.BUSUU_4 = ";                  // 部数４
            sql += "     CASE ";                                   // 
            sql += $"     WHEN HDL.GYOSYA_ID_4 = '{TxtGyousyaMaeID}' ";
            sql += "     THEN NULL ";
            sql += "     ELSE ";
            sql += "         HDL.BUSUU_4 ";
            sql += "     END ";
            sql += "     ,HDL.GYOSYA_ID_5 = ";                  // 業者ID５
            sql += "     CASE ";                                   // 
            sql += $"     WHEN HDL.GYOSYA_ID_5 = '{TxtGyousyaMaeID}' ";
            sql += "     THEN NULL ";
            sql += "     ELSE ";
            sql += "         HDL.GYOSYA_ID_5";
            sql += "     END ";
            sql += "     ,HDL.GYOSYA_NAME_5 = ";                  // 業者名５
            sql += "     CASE ";                                   // 
            sql += $"     WHEN HDL.GYOSYA_ID_5 = '{TxtGyousyaMaeID}' ";
            sql += "     THEN NULL ";
            sql += "     ELSE ";
            sql += "         HDL.GYOSYA_NAME_5 ";
            sql += "     END ";
            sql += "     ,HDL.BUSUU_5 = ";                  // 部数５
            sql += "     CASE ";                                   // 
            sql += $"     WHEN HDL.GYOSYA_ID_5 = '{TxtGyousyaMaeID}' ";
            sql += "     THEN NULL ";
            sql += "     ELSE ";
            sql += "         HDL.BUSUU_5 ";
            sql += "     END ";
            sql += $" ,HDL.MODIFY_PGM = '{PGM}' ";
            sql += $" ,HDL.MODIFY_PERSON = '{userID}' ";
            sql += " ,HDL.MODIFY_DATE = NOW() ";
            sql += " WHERE ";
            sql += $" ( HDL.GYOSYA_ID_1  = '{TxtGyousyaMaeID}' ";    // 業者１
            sql += $" OR HDL.GYOSYA_ID_2  ='{TxtGyousyaMaeID}' ";   // 業者２
            sql += $" OR HDL.GYOSYA_ID_3  ='{TxtGyousyaMaeID}' ";   // 業者３
            sql += $" OR HDL.GYOSYA_ID_4  ='{TxtGyousyaMaeID}' ";   // 業者４
            sql += $" OR HDL.GYOSYA_ID_5  ='{TxtGyousyaMaeID}' ) "; // 業者５
            sql += " AND EXISTS ";
            sql += " ( ";
            sql += "     SELECT 1 FROM HAIFU_DETAIL_LAST HDL2 ";
            sql += "     WHERE HDL.WC_OBJ_NO = HDL2.WC_OBJ_NO ";
            sql += "     AND HDL.HAIFUMOTO = HDL2.HAIFUMOTO ";
            sql += $"     AND ( HDL2.GYOSYA_ID_1  = '{TxtGyousyaAtoID}' ";
            sql += $"           OR HDL2.GYOSYA_ID_2  = '{TxtGyousyaAtoID}' ";
            sql += $"           OR HDL2.GYOSYA_ID_3  = '{TxtGyousyaAtoID}' ";
            sql += $"           OR HDL2.GYOSYA_ID_4  = '{TxtGyousyaAtoID}' ";
            sql += $"           OR HDL2.GYOSYA_ID_5  = '{TxtGyousyaAtoID}' ";
            sql += "         ) ";
            sql += " ) ";

            kousinCnt = db.Execute(sql);

            var sql2 = "";
            sql2 += " UPDATE ";
            sql2 += " HAIFU_DETAIL_LAST HDL ";                      // 業者配布履歴（最新）
            sql2 += " SET ";                                    // 
            sql2 += "     HDL.GYOSYA_ID_1 = ";                  // 業者ID１
            sql2 += "     CASE ";                                   // 
            sql2 += $"     WHEN HDL.GYOSYA_ID_1 = '{TxtGyousyaMaeID}' ";
            sql2 += $"     THEN '{TxtGyousyaAtoID}' ";
            sql2 += "     ELSE ";
            sql2 += "         HDL.GYOSYA_ID_1 ";
            sql2 += "     END ";
            sql2 += "     ,HDL.GYOSYA_NAME_1 = ";                  // 業者名１
            sql2 += "     CASE ";                                   // 
            sql2 += $"     WHEN HDL.GYOSYA_ID_1 = '{TxtGyousyaMaeID}' ";
            sql2 += $"     THEN '{TxtGyousyaAtoMei}' ";
            sql2 += "     ELSE ";
            sql2 += "         HDL.GYOSYA_NAME_1 ";
            sql2 += "     END ";
            sql2 += "     ,HDL.GYOSYA_ID_2 = ";                  // 業者ID２
            sql2 += "     CASE ";                                   // 
            sql2 += $"     WHEN HDL.GYOSYA_ID_2 = '{TxtGyousyaMaeID}' ";
            sql2 += $"     THEN '{TxtGyousyaAtoID}' ";
            sql2 += "     ELSE ";
            sql2 += "         HDL.GYOSYA_ID_2 ";
            sql2 += "     END ";
            sql2 += "     ,HDL.GYOSYA_NAME_2 = ";                  // 業者名２
            sql2 += "     CASE ";                                   // 
            sql2 += $"     WHEN HDL.GYOSYA_ID_2 = '{TxtGyousyaMaeID}' ";
            sql2 += $"     THEN '{TxtGyousyaAtoMei}' ";
            sql2 += "     ELSE ";
            sql2 += "         HDL.GYOSYA_NAME_2 ";
            sql2 += "     END ";
            sql2 += "     ,HDL.GYOSYA_ID_3 = ";                  // 業者ID３
            sql2 += "     CASE ";                                   // 
            sql2 += $"     WHEN HDL.GYOSYA_ID_3 = '{TxtGyousyaMaeID}' ";
            sql2 += $"     THEN '{TxtGyousyaAtoID}' ";
            sql2 += "     ELSE ";
            sql2 += "         HDL.GYOSYA_ID_3";
            sql2 += "     END ";
            sql2 += "     ,HDL.GYOSYA_NAME_3 = ";                  // 業者名３
            sql2 += "     CASE ";                                   // 
            sql2 += $"     WHEN HDL.GYOSYA_ID_3 = '{TxtGyousyaMaeID}' ";
            sql2 += $"     THEN '{TxtGyousyaAtoMei}' ";
            sql2 += "     ELSE ";
            sql2 += "         HDL.GYOSYA_NAME_3 ";
            sql2 += "     END ";
            sql2 += "     ,HDL.GYOSYA_ID_4 = ";                  // 業者ID４
            sql2 += "     CASE ";                                   // 
            sql2 += $"     WHEN HDL.GYOSYA_ID_4 = '{TxtGyousyaMaeID}' ";
            sql2 += $"     THEN '{TxtGyousyaAtoID}' ";
            sql2 += "     ELSE ";
            sql2 += "         HDL.GYOSYA_ID_4";
            sql2 += "     END ";
            sql2 += "     ,HDL.GYOSYA_NAME_4 = ";                  // 業者名４
            sql2 += "     CASE ";                                   // 
            sql2 += $"     WHEN HDL.GYOSYA_ID_4 = '{TxtGyousyaMaeID}' ";
            sql2 += $"     THEN '{TxtGyousyaAtoMei}' ";
            sql2 += "     ELSE ";
            sql2 += "         HDL.GYOSYA_NAME_4 ";
            sql2 += "     END ";
            sql2 += "     ,HDL.GYOSYA_ID_5 = ";                  // 業者ID５
            sql2 += "     CASE ";                                   // 
            sql2 += $"     WHEN HDL.GYOSYA_ID_5 = '{TxtGyousyaMaeID}' ";
            sql2 += $"     THEN '{TxtGyousyaAtoMei}' ";
            sql2 += "     ELSE ";
            sql2 += "         HDL.GYOSYA_ID_5";
            sql2 += "     END ";
            sql2 += "     ,HDL.GYOSYA_NAME_5 = ";                  // 業者名５
            sql2 += "     CASE ";                                   // 
            sql2 += $"     WHEN HDL.GYOSYA_ID_5 = '{TxtGyousyaMaeID}' ";
            sql2 += $"     THEN '{TxtGyousyaAtoMei}' ";
            sql2 += "     ELSE ";
            sql2 += "         HDL.GYOSYA_NAME_5 ";
            sql2 += "     END ";
            sql2 += $" ,HDL.MODIFY_PGM = '{PGM}' ";
            sql2 += $" ,HDL.MODIFY_PERSON = '{userID}' ";
            sql2 += " ,HDL.MODIFY_DATE = NOW() ";
            sql2 += " WHERE ";
            sql2 += $" HDL.GYOSYA_ID_1  = '{TxtGyousyaMaeID}' ";      // 業者１
            sql2 += $" OR HDL.GYOSYA_ID_2  = '{TxtGyousyaMaeID}' ";   // 業者２
            sql2 += $" OR HDL.GYOSYA_ID_3  = '{TxtGyousyaMaeID}' ";   // 業者３
            sql2 += $" OR HDL.GYOSYA_ID_4  = '{TxtGyousyaMaeID}' ";   // 業者４
            sql2 += $" OR HDL.GYOSYA_ID_5  = '{TxtGyousyaMaeID}' ";   // 業者５

            kousinCnt = kousinCnt + db.Execute(sql);

            return kousinCnt;
        }
    }
}
