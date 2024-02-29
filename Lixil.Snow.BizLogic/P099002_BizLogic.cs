using Dapper;
using Lixil.Snow.DataAccess;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.BizLogic
{
    /// <summary>
    /// 図面・ドキュメント履歴削除機能（浴室）の表示／更新用のデータアクセス
    /// </summary>
    public class P099002_BizLogic
    {

        //SQL文実行用
        private P099002_DataAccess da;

        public P099002_BizLogic()
        {
            da = new P099002_DataAccess();
        }

        /// <summary>
        /// 業者配布履歴・ヘッダを検索して、表示用データを取得する
        /// </summary>
        /// <param name="txtTxtWcEcnNo">変更通知番号</param>
        /// <returns>表示用データ</returns>
        public List<HAIFU_HEADER> SelHaifuHeaderByWcEcnNo(string txtTxtWcEcnNo)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            var result = da.SelHaifuHeaderByWcEcnNo(txtTxtWcEcnNo);
            da.Close();
            return result;
        }

        /// <summary>
        /// 業者配布履歴・ヘッダから業者配布履歴・ヘッダ(削除済)を登録する
        /// </summary>
        /// <param name="txtTxtWcEcnNo">変更通知番号</param>
        /// <param name="userID">ユーザーID</param>
        /// <param name="PGM">機能ID</param>    
        /// <returns>表示用データ</returns>
        public int InsertDeleteHHByWcEcnNo(string txtTxtWcEcnNo, string userID, string PGM)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            var result = da.InsertDeleteHHByWcEcnNo(txtTxtWcEcnNo, userID, PGM);
            da.Close();
            return result;
        }

        /// <summary>
        /// 図番一覧画面（洗面）表示用データを取得する
        /// </summary>
        /// <param name="txtTxtWcEcnNo">変更通知番号</param>
        /// <returns>取得更新件数</returns>
        public List<DOCUMENT_VERSION> SelDocumentVersionByWcEcnNo(string txtTxtWcEcnNo)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            var result = da.SelDocumentVersionByWcEcnNo(txtTxtWcEcnNo);
            da.Close();
            return result;
        }

    }
}
