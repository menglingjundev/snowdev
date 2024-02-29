using Lixil.Snow.DataAccess;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Reflection;
using System.Transactions;
using static System.Formats.Asn1.AsnWriter;

namespace Lixil.Snow.BizLogic
{
    /// <summary>
    /// 配布実施
    /// </summary>
    /// <remarks>20181015 修(大連) 新規作成</remarks>
    public class P039001_BizLogic
    {
        //SQL文実行用
        private P039001_DataAccess da;

        public P039001_BizLogic()
        {
            da = new P039001_DataAccess();
        }

        /// <summary>
        /// 業者配布履歴・明細を検索して、件数を取得する
        /// </summary>
        /// <param name="txtGyosyaID">業者ID</param>
        /// <returns>取得件数</returns>
        /// <remarks>20190729 王(大連) 新規作成</remarks>
        public int CntHaifudetailByID(string txtGyosyaID)
        {
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            var result = da.CntHaifudetailByID(txtGyosyaID);
            da.Close();
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
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            var result = da.CntHaifudetailLastByID(txtGyosyaID);
            da.Close();
            return result;

        }

        /// <summary>
        /// 業者配布履歴・明細と業者配布履歴（最新）を更新する
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
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            int result = new int();

            //TODO
            // 4.3 対象データを更新する
            // 4.3.1 変更後の業者IDが存在する場合、変更前の業者IDの業者配布履歴・明細を削除する
            da.DelHaifudetailByID(TxtGyousyaMaeID, TxtGyousyaAtoID);

            // 4.3.2 業者配布履歴・明細を更新する
            result = da.UpdHaifuDetailDataByID(TxtGyousyaMaeID, TxtGyousyaAtoID, TxtGyousyaAtoMei, userID, PGM);

            // 4.3.3 業者配布履歴（最新）を更新する
            result = result + da.UpdHaifuDetailLastDataByID(TxtGyousyaMaeID, TxtGyousyaAtoID, TxtGyousyaAtoMei, userID, PGM);

            if (result == 0)
            {
                da.Close();
                return result;
            }

            da.Close();
            return result;
        }
    }
}
