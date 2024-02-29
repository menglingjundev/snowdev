using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{
    /// <summary>
    /// 採番データアクセス
    /// </summary>
    public class P130310_DataAccess : SqlManager
    {
        /// <summary>
        /// 採番の種類マスタを更新
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="saibanBunruiFlg1">採番用分類１要否</param>
        /// <param name="saibanBunruiFlg2">採番用分類２要否</param>
        /// <param name="saibanBunruiFlg3">採番用分類３要否</param>
        /// <param name="saibanBunruiFlg4">採番用分類４要否</param>
        /// <param name="saibanBunruiFlg5">採番用分類５要否</param>
        /// <param name="saibanRirekiFlg">採番履歴要否</param>
        /// <param name="saibanGamenFlg">採番画面可否</param> 
        /// <param name="deleteFlg">削除</param> 
        /// <param name="userId">ユーザーID</param>  
        /// <returns>影響行数</returns>
        public int UpdSaibanSyurui(string saibanSyurui, string saibanBunruiFlg1, string saibanBunruiFlg2, string saibanBunruiFlg3, string saibanBunruiFlg4, string saibanBunruiFlg5, string saibanRirekiFlg, string saibanGamenFlg, string deleteFlg, string userId)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;
            SAIBANSYURUI saiban = new SAIBANSYURUI
            {
                SAIBAN_SYURUI = saibanSyurui,
                BURUI_1_FLG = saibanBunruiFlg1,
                BURUI_2_FLG = saibanBunruiFlg2,
                BURUI_3_FLG = saibanBunruiFlg3,
                BURUI_4_FLG = saibanBunruiFlg4,
                BURUI_5_FLG = saibanBunruiFlg5,
                RIREKI_FLG = saibanRirekiFlg,
                ENTRY_FLG = saibanGamenFlg,
                DELETE_FLG = deleteFlg,
                CREATE_PERSON = userId,
                MODIFY_PERSON = userId
            };

            var result = db.Execute($"UPDATE SAIBAN_SYURUI SET BURUI_1_FLG = @BURUI_1_FLG, BURUI_2_FLG = @BURUI_2_FLG, BURUI_3_FLG = @BURUI_3_FLG, BURUI_4_FLG = @BURUI_4_FLG, BURUI_5_FLG = @BURUI_5_FLG," +
                $"RIREKI_FLG=@RIREKI_FLG,ENTRY_FLG=@ENTRY_FLG, DELETE_FLG=@DELETE_FLG,MODIFY_PGM = 'B130301',MODIFY_PERSON = @MODIFY_PERSON,MODIFY_DATE = NOW()" +
               $" WHERE SAIBAN_SYURUI = @SAIBAN_SYURUI ", saiban);

            return result;
        }

    }
}
