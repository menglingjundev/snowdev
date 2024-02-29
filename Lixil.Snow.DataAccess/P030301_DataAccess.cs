using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{
    /// <summary>
    /// 配布履歴検索
    /// </summary>
    /// <remarks>20181015 修(大連) 新規作成</remarks>
    public class P030301_DataAccess : SqlManager
    {
        /// <summary>
        /// 変更通知番号の取得
        /// </summary>
        /// <param name="contestInfo">コンテキスト</param>
        /// <returns>業者配布履歴・ヘッダテーブル</returns>
        /// <remarks>20181015 修(大連) 新規作成</remarks>
        public List<HAIFU_HEADER> SelContestData(List<string> contestInfo)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;

            var wherestr = "";
            if (contestInfo.Count > 0)
            {
                for (int i = 0; i < contestInfo.Count; i++)
                {
                    if (i == 0)
                        wherestr += " AND ( HH.CONTEXT = '" + contestInfo[i] + "'  ";
                    else
                        wherestr += "OR HH.CONTEXT = '" + contestInfo[i] + "'  ";
                }
                wherestr += " ) ";
            }

            var result = db.Query<HAIFU_HEADER>($" SELECT DISTINCT(HH.WC_ECN_NO) FROM HAIFU_HEADER HH INNER JOIN HAIFU_DETAIL HD ON HH.WC_ECN_NO = HD.WC_ECN_NO AND HH.WC_OBJ_NO = HD.WC_OBJ_NO  WHERE HD.STATUS = '{Utilities.AppConst.Status.HAIFUYOTEI}' " + wherestr + " ORDER BY HH.WC_ECN_NO ").ToList();
            return result;
        }

        /// <summary>
        /// 業者配布履歴の取得
        /// </summary>
        /// <param name="contestInfo">コンテキスト</param>
        /// <param name="wcEcnNo">変更通知番号</param>
        /// <param name="txtZuban">図番</param>
        /// <param name="txtFile">ファイル名</param>
        /// <param name="gyosyaID">業者ID</param>
        /// <param name="rdoStatus">配布区分</param>
        /// <param name="kensakuKensu">検索件数</param>
        /// <param name="haifumoto">配布元</param>
        /// <returns>業者配布履歴・ヘッダテーブル</returns>
        /// <remarks>20181015 修(大連) 新規作成</remarks>
        public List<HAIFU_HEADER> SelHaifuData(List<string> contestInfo, string wcEcnNo, string txtZuban, string txtFile, string gyosyaID, bool RdoStatus, int kensakuKensu, string haifumoto)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;

            var sql = "";

            sql += " SELECT ";
            sql += " HH.WC_OBJ_NO ";                // 図面・ドキュメントの番号
            sql += " ,HH.ZUBAN ";                   // 図番
            sql += " ,HH.FILE_PATH ";               // ドキュメントファイルパス
            sql += " ,HH.FILE_NAME ";               // ドキュメントファイル名
            sql += " ,HH.ZUBAN_VERSION ";           // 改訂
            sql += " ,HH.CONTEXT ";                 // コンテキスト
            sql += " ,HH.WC_ECN_NO ";               // 変更通知番号
            sql += " ,HH.ECN_NAME ";                // 変更通知の名前
            sql += " ,HD.GYOSYA_ID ";               // 業者ID
            sql += " ,HD.GYOSYA_NAME ";             // 業者名
            sql += " ,HD.BUSUU ";                   // 部数
            sql += " ,HD.STATUS ";                  // 配布区分
            sql += " ,HD.HAIFUBI ";                 // 配布日
            sql += " ,HD.KAISYUBI ";                // 回収日
            sql += " ,HD.HAIFUMOTO ";               // 配布元
            sql += " FROM  ";
            sql += " HAIFU_HEADER HH ";
            sql += " INNER JOIN ";
            sql += " HAIFU_DETAIL HD ";
            sql += " ON ";
            sql += " HH.WC_ECN_NO = HD.WC_ECN_NO ";
            sql += " AND HH.WC_OBJ_NO = HD.WC_OBJ_NO ";
            sql += " WHERE 1=1 ";

            //コンテキスト(リストBOX)で選択したコンテキスがある場合
            if (contestInfo.Count > 0)
            {
                for (int columnCount = 0; columnCount <= contestInfo.Count - 1; columnCount++)
                {
                    if (columnCount == 0)
                        sql += " AND ( HH.CONTEXT = '" + contestInfo[columnCount] + "'  ";
                    else
                        sql += "OR HH.CONTEXT = '" + contestInfo[columnCount] + "'  ";
                }
                sql += " ) ";
            }

            // 変更通知番号(コンボBOX)で選択、または、変更通知番号(テキストBOX)で入力した変更通知番号がある場合
            if (!string.IsNullOrEmpty(wcEcnNo))
            {
                sql += $" AND HH.WC_ECN_NO = '{wcEcnNo}' ";
            }

            // 図番(テキストBOX)で入力した図番がある場合
            if (!string.IsNullOrEmpty(txtZuban))
            {
                if (txtZuban.Substring(txtZuban.Length - 1, 1) == AppConst.HOSHI)
                {
                    var hoshiName = txtZuban.Substring(0, txtZuban.LastIndexOf(AppConst.HOSHI));
                    // 入力した図番に「*」がある場合
                    sql += $" AND HH.ZUBAN Like '{hoshiName}%' ";
                }
                else
                {
                    // 入力した図番に「*」がない場合
                    sql += $" AND HH.ZUBAN = '{txtZuban}' ";
                }
            }

            // ファイル名(テキストBOX)で入力したファイル名がある場合
            if (!string.IsNullOrEmpty(txtFile))
            {
                if (txtFile.Substring(txtFile.Length - 1, 1) == AppConst.HOSHI)
                {
                    var hoshiName = txtFile.Substring(0, txtFile.LastIndexOf(AppConst.HOSHI));
                    // 入力したファイル名に「*」がある場合
                    sql += $" AND HH.FILE_NAME Like ''{hoshiName}'%' ";
                }
                else
                {
                    // 入力したファイル名に「*」がない場合
                    sql += $" AND HH.FILE_NAME ='{txtFile}' ";
                }
            }


            // 画面に表示される業者IDが空白以外の場合
            if (!string.IsNullOrEmpty(gyosyaID))
            {
                sql += $" AND HD.GYOSYA_ID = '{gyosyaID}' ";
            }
            // 画面に表示される配布元が空白以外の場合
            if (!string.IsNullOrEmpty(haifumoto))
            {
                sql += $" AND HD.HAIFUMOTO = {haifumoto} ";
            }

            if (RdoStatus == true)
            {
                // 未配布(オプションボタン)が選択されている場合、配布区分="配布予定"
                sql += " AND HD.STATUS = '" + Utilities.AppConst.Status.HAIFUYOTEI + "' ";
            }
            else
            {
                // 配布済(オプションボタン)が選択されている場合、配布区分="配布済"または"回収済"
                sql += " AND HD.STATUS IN ('" + Utilities.AppConst.Status.HAIFUZUMI + "','" + Utilities.AppConst.Status.KAISYUZUMI + "') ";
                sql += $" AND ROWNUM <= '{kensakuKensu}' ";
            }
            sql += " ORDER BY HH.WC_OBJ_NO ASC, HH.ZUBAN_VERSION ASC ";

            var result = db.Query<HAIFU_HEADER>(sql).ToList();
            return result;
        }

        public int SelHaifuDataCnt(List<string> contestInfo, string wcEcnNo, string txtZuban, string txtFile, string gyosyaID, string haifumoto)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;

            var sql = "";

            sql += " SELECT ";
            sql += " COUNT(*)";
            sql += " FROM  ";
            sql += " HAIFU_HEADER HH ";
            sql += " INNER JOIN ";
            sql += " HAIFU_DETAIL HD ";
            sql += " ON ";
            sql += " HH.WC_ECN_NO = HD.WC_ECN_NO ";
            sql += " AND HH.WC_OBJ_NO = HD.WC_OBJ_NO ";
            sql += " WHERE 1=1 ";

            //コンテキスト(リストBOX)で選択したコンテキスがある場合
            if (contestInfo.Count > 0)
            {
                for (int columnCount = 0; columnCount <= contestInfo.Count - 1; columnCount++)
                {
                    if (columnCount == 0)
                        sql += " AND ( HH.CONTEXT = '" + contestInfo[columnCount] + "'  ";
                    else
                        sql += "OR HH.CONTEXT = '" + contestInfo[columnCount] + "'  ";
                }
                sql += " ) ";
            }

            // 変更通知番号(コンボBOX)で選択、または、変更通知番号(テキストBOX)で入力した変更通知番号がある場合
            if (!string.IsNullOrEmpty(wcEcnNo))
            {
                sql += $" AND HH.WC_ECN_NO = '{wcEcnNo}' ";
            }

            // 図番(テキストBOX)で入力した図番がある場合
            if (!string.IsNullOrEmpty(txtZuban))
            {
                if (txtZuban.Substring(txtZuban.Length - 1, 1) == AppConst.HOSHI)
                {
                    var hoshiName = txtZuban.Substring(0, txtZuban.LastIndexOf(AppConst.HOSHI));
                    // 入力した図番に「*」がある場合
                    sql += $" AND HH.ZUBAN Like '{hoshiName}%' ";
                }
                else
                {
                    // 入力した図番に「*」がない場合
                    sql += $" AND HH.ZUBAN = '{txtZuban}' ";
                }
            }

            // ファイル名(テキストBOX)で入力したファイル名がある場合
            if (!string.IsNullOrEmpty(txtFile))
            {
                if (txtFile.Substring(txtFile.Length - 1, 1) == AppConst.HOSHI)
                {
                    var hoshiName = txtFile.Substring(0, txtFile.LastIndexOf(AppConst.HOSHI));
                    // 入力したファイル名に「*」がある場合
                    sql += $" AND HH.FILE_NAME Like ''{hoshiName}'%' ";
                }
                else
                {
                    // 入力したファイル名に「*」がない場合
                    sql += $" AND HH.FILE_NAME ='{txtFile}' ";
                }
            }


            // 画面に表示される業者IDが空白以外の場合
            if (!string.IsNullOrEmpty(gyosyaID))
            {
                sql += $" AND HD.GYOSYA_ID = '{gyosyaID}' ";
            }
            // 画面に表示される配布元が空白以外の場合
            if (!string.IsNullOrEmpty(haifumoto))
            {
                sql += $" AND HD.HAIFUMOTO = {haifumoto} ";
            }

            var result = db.Query<int>(sql).ToList();
            return result[0];
        }

    }
}
