using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{
    /// <summary>
    /// 採番データアクセス
    /// </summary>
    public class P130302_DataAccess : SqlManager
    {
        #region 採番の分類マスタ
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
        /// <param name="userId">ユーザーID</param>
        /// <returns>影響行数</returns>
        /// <remarks>20231211 孟(大連) 新規作成</remarks>
        public int InsSaibanBunrui(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5, string maeMoji, string kijunbiFlg, int sqlLength, long sqlStart, long sqlEnd, string overFlg, string userId)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            if (string.IsNullOrEmpty(burui1))
            {
                burui1 = Utilities.AppConst.HYPHEN;// 空白の場合は、"-"
            }
            if (string.IsNullOrEmpty(burui2))
            {
                burui2 = Utilities.AppConst.HYPHEN;// 空白の場合は、"-"
            }
            if (string.IsNullOrEmpty(burui3))
            {
                burui3 = Utilities.AppConst.HYPHEN;// 空白の場合は、"-"
            }
            if (string.IsNullOrEmpty(burui4))
            {
                burui4 = Utilities.AppConst.HYPHEN;// 空白の場合は、"-"
            }
            if (string.IsNullOrEmpty(burui5))
            {
                burui5 = Utilities.AppConst.HYPHEN;// 空白の場合は、"-"
            }
            using var db = SqlManager.GetConnection;
            SAIBAN_BUNRUI saiban = new SAIBAN_BUNRUI
            {
                SAIBAN_SYURUI = saibanSyurui,
                BURUI_1 = burui1,
                BURUI_2 = burui2,
                BURUI_3 = burui3,
                BURUI_4 = burui4,
                BURUI_5 = burui5,
                MAE_MOJI = maeMoji,
                KIJUNBI_FLG = kijunbiFlg,
                SEQ_LENGTH = sqlLength,
                SEQ_START = sqlStart,
                SEQ_END = sqlEnd,
                OVER_FLG = overFlg,
				DELETE_FLG="0",
				CREATE_PERSON = userId,
                MODIFY_PERSON = userId
            };

            var result = db.Execute($"insert into saiban_bunrui (saiban_syurui,burui_1,burui_2,burui_3,burui_4,burui_5,mae_moji,KIJUNBI_FLG,SEQ_LENGTH,SEQ_START,SEQ_END,OVER_FLG,DELETE_FLG" +
                $" ,create_pgm ,create_person ,create_date ,modify_pgm , modify_person ,modify_date) VALUES" +
                $" (@SAIBAN_SYURUI, @BURUI_1, @BURUI_2, @BURUI_3, @BURUI_4, @BURUI_5, @MAE_MOJI,  @KIJUNBI_FLG, @SEQ_LENGTH, @SEQ_START, @SEQ_END, @OVER_FLG, @DELETE_FLG" +
                $", @CREATE_PGM, @CREATE_PERSON,NOW(), @MODIFY_PGM,@MODIFY_PERSON,NOW()) ", saiban);

            return result;
        }
        #endregion
    }
}
