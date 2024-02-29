using Dapper;
using Lixil.Snow.DataAccess;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Reflection;

namespace Lixil.Snow.BizLogic
{
    /// <summary>
    /// 採番の種類マスタのデータアクセス
    /// </summary>
    public class P130310_BizLogic
    {

        //SQL文実行用
        private P130310_DataAccess da;

        public P130310_BizLogic()
        {
            da = new P130310_DataAccess();
        }

        /// <summary>
        /// 採番の種類マスタを登録
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="saibanBunruiFlg1">採番用分類１要否</param>
        /// <param name="saibanBunruiFlg2">採番用分類２要否</param>
        /// <param name="saibanBunruiFlg3">採番用分類３要否</param>
        /// <param name="saibanBunruiFlg4">採番用分類４要否</param>
        /// <param name="saibanBunruiFlg5">採番用分類５要否</param>
        /// <param name="saibanRirekiFlg">採番履歴要否</param>
        /// <param name="saibanGamenFlg">採番画面可否</param>   
        /// <param name="userId">ユーザーID</param>
        /// <returns>影響行数</returns>
        public int UpdSaibanSyurui(string saibanSyurui, string saibanBunruiFlg1, string saibanBunruiFlg2, string saibanBunruiFlg3, string saibanBunruiFlg4, string saibanBunruiFlg5, string saibanRirekiFlg, string saibanGamenFlg, string deleteFlg, string userId)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            int result = da.UpdSaibanSyurui(saibanSyurui, saibanBunruiFlg1, saibanBunruiFlg2, saibanBunruiFlg3, saibanBunruiFlg4, saibanBunruiFlg5, saibanRirekiFlg, saibanGamenFlg, deleteFlg, userId);
            da.Close();
            return result;
        }
    }
}
