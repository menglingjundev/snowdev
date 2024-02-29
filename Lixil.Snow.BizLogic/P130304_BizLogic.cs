using Lixil.Snow.DataAccess;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Npgsql;
using System.Data;
using System.Reflection;
using System.Transactions;

namespace Lixil.Snow.BizLogic
{
    /// <summary>
    /// 採番の種類マスタのデータアクセス
    /// </summary>
    public class P130304_BizLogic
    {

        //SQL文実行用
        private P130304_DataAccess da;

        public P130304_BizLogic()
        {
            da = new P130304_DataAccess();
        }

        /// <summary>
        /// 採番分類マスタ
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <param name="burui5">採番用分類５</param>
        /// <param name="maeMoji">前部文字列</param>
        /// <param name="kijunbiFlg">基準日要否</param>
        /// <param name="sqlLength">連番桁数</param>
        /// <param name="sqlStart">連番範囲(開始)</param>
        /// <param name="sqlEnd">連番範囲(終了)</param>
        /// <param name="overFlg">終了値超えの処理</param>
        /// <param name="deleteFlg">削除フラグ</param> 
        /// <param name="userId">ユーザーID</param>
        /// <returns>処理結果</returns>
        /// <remarks>20231211 孟(大連) 新規作成</remarks>
        public int UpdSaibanBunrui(string saibanSyurui, List<SAIBAN_BUNRUI> paramDt, string userId)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            int result = 0;
            string overFlg = "0";
            string kijunbiFlg = "0";
            string deleteFlg = "0";
            using (NpgsqlTransaction scope = SqlManager.BeginTransaction)
            {
                for (int columnCount = 0; columnCount <= paramDt.Count - 1; columnCount++)
                {
                    if (paramDt[columnCount].MAE_MOJI == Utilities.AppConst.HITUYOU)
                        kijunbiFlg = Utilities.AppConst.HITUYOU_FLG;
                    else
                        kijunbiFlg = Utilities.AppConst.HUYOU_FLG;
                    if (paramDt[columnCount].OVER_FLG == Utilities.AppConst.ERR)
                        overFlg = Utilities.AppConst.HITUYOU_FLG;
                    else
                        overFlg = Utilities.AppConst.HUYOU_FLG;
                    // 削除　
                    if (paramDt[columnCount].DELETE_FLG == "true")
                        deleteFlg = Utilities.AppConst.HITUYOU_FLG;
                    else
                        deleteFlg = Utilities.AppConst.HUYOU_FLG;
                    int ketasu = int.Parse(paramDt[columnCount].SEQ_LENGTH.ToString());
                    long startRenban = long.Parse(paramDt[columnCount].SEQ_START.ToString());
                    long endRenban = long.Parse(paramDt[columnCount].SEQ_END.ToString());
                    result = da.UpdSaibanBunrui(saibanSyurui, paramDt[columnCount].BURUI_1, paramDt[columnCount].BURUI_2, paramDt[columnCount].BURUI_3, paramDt[columnCount].BURUI_4, paramDt[columnCount].BURUI_5, paramDt[columnCount].MAE_MOJI, kijunbiFlg, ketasu, startRenban, endRenban, overFlg, deleteFlg, userId);
                    if (result == 0)
                    {
                        da.Close();
                        scope.Dispose();
                        return result;
                    }
                }
                da.Close();
                scope.Commit();
            }
            return result;
        }
    }
}
