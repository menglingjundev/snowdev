using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{
    /// <summary>
    /// フォーム１６データアクセス
    /// </summary>
    public class P130102_DataAccess : SqlManager
    {
        /// <summary>
        /// 採番マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <param name="burui5">採番用分類５</param>
        /// <param name="maeMoji">前部文字列</param>
        /// <param name="isLock">ロック用</param>
        /// <returns>採番マスタ情報</returns>
        /// <remarks>20231208 孟(大連) 新規作成</remarks>
        public List<SAIBAN> GetSaiban(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5, string maeMoji, bool isLock)
        {

            // イベントログ追加System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            string strWhere = string.Empty;
            if (isLock)
            {
                strWhere = " FOR UPDATE";
            }
            using var db = SqlManager.GetConnection;
            var result = db.Query<SAIBAN>($"select saiban_syurui ,burui_1 ,burui_2 ,burui_3 ,burui_4 ,burui_5" +
                $" ,mae_moji ,kijunbi ,seq_last  " +
                $" from saiban " +
                $"where 0 = 0 and saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}'  and burui_2 ='{burui2}' " +
                $"and burui_3 ='{burui3}' and burui_4 ='{burui4}' and burui_5 ='{burui5}'" + strWhere).ToList();

            return result;
        }

        /// <summary>
        /// 採番マスタのデータを登録
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <param name="burui5">採番用分類５</param>
        /// <param name="maeMoji">前部文字列</param>
        /// <param name="kijunbi">基準日</param>
        /// <param name="seqLast">最終番号</param>
        /// <returns>影響行数</returns>
        /// <param name="userID">ユーザーID</param>
        /// <param name="PGM">機能ID</param>
        /// <remarks>20231208 孟(大連) 新規作成</remarks>
        public int InsertSaiban(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5, string maeMoji, DateTime kijunbi, long seqLast, string userID, string PGM)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            SAIBAN saiban = new SAIBAN
            {
                SAIBAN_SYURUI = saibanSyurui,
                BURUI_1 = burui1,
                BURUI_2 = burui2,
                BURUI_3 = burui3,
                BURUI_4 = burui4,
                BURUI_5 = burui5,
                MAE_MOJI = maeMoji,
                KIJUNBI = kijunbi,
                SEQ_LAST = seqLast,
                CREATE_PGM = PGM,
                CREATE_PERSON = userID,
                MODIFY_PGM = PGM,
                MODIFY_PERSON = userID
            };

            var result = db.Execute($"insert into saiban (saiban_syurui,burui_1,burui_2,burui_3,burui_4,burui_5,mae_moji,kijunbi,seq_last" +
                $" ,create_pgm ,create_person ,create_date ,modify_pgm , modify_person ,modify_date) VALUES" +
                $" (@SAIBAN_SYURUI, @BURUI_1, @BURUI_2, @BURUI_3, @BURUI_4, @BURUI_5, @MAE_MOJI,  @KIJUNBI, @SEQ_LAST, @CREATE_PGM" +
                $", @CREATE_PERSON,NOW(), @MODIFY_PGM,@MODIFY_PERSON,NOW()) ", saiban);


            return result;
        }

        /// <summary>
        /// 採番マスタのデータを更新
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <param name="burui5">採番用分類５</param>
        /// <param name="maeMoji">前部文字列</param>
        /// <param name="kijunbi">基準日</param>
        /// <param name="seqLast">最終番号</param>
        /// <returns>影響行数</returns>
        /// <param name="userID">ユーザーID</param>
        /// <param name="PGM">機能ID</param>
        /// <remarks>20231208 孟(大連) 新規作成</remarks>
        public int UpdateSaiban(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5, string maeMoji, DateTime kijunbi, long seqLast, string userID, string PGM)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            SAIBAN saiban = new SAIBAN
            {
                SAIBAN_SYURUI = saibanSyurui,
                BURUI_1 = burui1,
                BURUI_2 = burui2,
                BURUI_3 = burui3,
                BURUI_4 = burui4,
                BURUI_5 = burui5,
                MAE_MOJI = maeMoji,
                KIJUNBI = kijunbi,
                SEQ_LAST = seqLast,
                CREATE_PGM = PGM,
                CREATE_PERSON = userID,
                MODIFY_PGM = PGM,
                MODIFY_PERSON = userID
            };

            var result = db.Execute($"UPDATE SAIBAN SET KIJUNBI = @KIJUNBI,SEQ_LAST = @SEQ_LAST,MODIFY_PGM = @MODIFY_PGM,MODIFY_PERSON = @MODIFY_PERSON,MODIFY_DATE = NOW()" +
               $" WHERE SAIBAN_SYURUI = @SAIBAN_SYURUI AND BURUI_1 = @BURUI_1 AND BURUI_2 = @BURUI_2 AND BURUI_3 = @BURUI_3 AND BURUI_4 = @BURUI_4 " +
               $" AND BURUI_5 = @BURUI_5 AND MAE_MOJI = @MAE_MOJI", saiban);

            return result;
        }

        /// <summary>
        /// 採番種類の取得
        /// </summary>
        /// <param name="saibanSyurui">採番種類</param>
        /// <returns>採番種類マスタ情報</returns>
        /// <remarks>20231208 孟(大連) 新規作成</remarks>
        public List<SAIBANSYURUI> GetSaiBanSyurui(string saibanSyurui)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            var result = db.Query<SAIBANSYURUI>($"select saiban_syurui ,rireki_flg" +
                $" from saiban_syurui " +
                $"where delete_flg = '0' and saiban_syurui ='{saibanSyurui}' ").ToList();

            return result;
        }

        /// <summary>
        /// 採番の分類マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <param name="burui5">採番用分類５</param>
        /// <returns>採番の分類マスタ情報</returns>
        /// <remarks>20231208 孟(大連) 新規作成</remarks>
        public List<SAIBAN_BUNRUI> GetSaibanBunrui(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            var result = db.Query<SAIBAN_BUNRUI>($"select saiban_syurui ,burui_1 ,burui_2 ,burui_3 ,burui_4 ,burui_5" +
                $" ,mae_moji ,kijunbi_flg ,seq_length ,seq_start ,seq_end ,over_flg ,delete_flg ,create_pgm ,create_person ,create_date ,modify_pgm ,modify_person ,modify_date " +
                $" from saiban_bunrui " +
                $"where delete_flg = '0' and saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}'  and burui_2 ='{burui2}' " +
                $"and burui_3 ='{burui3}' and burui_4 ='{burui4}' and burui_5 ='{burui5}'").ToList();

            return result;
        }

        /// <summary>
        /// 採番履歴マスタのデータを登録
        /// </summary>
        /// <param name="partNumber">品番</param>
        /// <param name="partName">品名</param>
        /// <param name="reason">新設理由</param>
        /// <param name="tenkai">今後の展開</param>
        /// <param name="syozoku">所属</param>
        /// <param name="sakuseiPerson">作成者</param>
        /// <returns>影響行数</returns>
        /// <param name="userID">ユーザーID</param>
        /// <param name="PGM">機能ID</param>
        /// <remarks>20231208 孟(大連) 新規作成</remarks>
        public int InsertSaibanRireki(string partNumber, string partName, string reason, string tenkai, string syozoku, string sakuseiPerson, string userID, string PGM)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            SAIBAN_RIREKI saiban_rireki = new SAIBAN_RIREKI
            {
                PART_NUMBER = partNumber,
                PART_NAME = partName,
                REASON = reason,
                TENKAI = tenkai,
                SYOZOKU = syozoku,
                SAKUSEI_PERSON = sakuseiPerson,
                CREATE_PGM = PGM,
                CREATE_PERSON = userID,
                MODIFY_PGM = PGM,
                MODIFY_PERSON = userID
            };

            var result = db.Execute($"insert into saiban_rireki (part_number,part_name,reason,tenkai,syozoku,sakusei_person" +
                $" ,create_pgm ,create_person ,create_date ,modify_pgm , modify_person ,modify_date) VALUES" +
                $" (@PART_NUMBER, @PART_NAME, @REASON, @TENKAI, @SYOZOKU, @SAKUSEI_PERSON, @CREATE_PGM" +
                $", @CREATE_PERSON,NOW(), @MODIFY_PGM,@MODIFY_PERSON,NOW()) ", saiban_rireki);

            return result;
        }

    }
}
