using Lixil.Snow.DataAccess;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.BizLogic
{
    /// <summary>
    /// 配布実施
    /// </summary>
    /// <remarks>20181015 修(大連) 新規作成</remarks>
    public class P030304_BizLogic
    {
        //SQL文実行用
        private P030304_DataAccess da;

        public P030304_BizLogic()
        {
            da = new P030304_DataAccess();
        }

        /// <summary>
        /// 配布履歴更新
        /// </summary>
        /// <param name="kaiSyuBi">回収日</param>
        /// <param name="wcEcnNo">変更通知番号</param>
        /// <param name="wcObjNo">図面・ドキュメントの番号</param>
        /// <param name="gyosyaID">業者ID</param>
        /// <param name="userID">ユーザーID</param>
        /// <param name="PGM">機能ID</param>
        /// <returns>処理結果</returns>
        /// <remarks>20181015 修(大連) 新規作成</remarks>
        public int UpdHaifuDetailDate(string kaiSyuBi, string wcEcnNo, string wcObjNo, string gyosyaID, string userID, string PGM)
        {
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            var result = da.UpdHaifuDetailDate(kaiSyuBi, wcEcnNo, wcObjNo, gyosyaID, userID, PGM);
            da.Close();
            return result;
        }

    }
}
