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
    public class P130306_DataAccess : SqlManager
    {
        /// <summary>
        /// 採番マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="isLock">ロック用</param>
        /// <returns>採番マスタ情報</returns>
        public List<SAIBAN> GetSaiban1(string saibanSyurui, string burui1, bool isLock)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            string strWhere = string.Empty;
            if (isLock)
            {
                strWhere = " FOR UPDATE NOWAIT";
            }
            using var db = SqlManager.GetConnection;
            var result = db.Query<SAIBAN>($"select saiban_syurui ,burui_1 ,burui_2 ,burui_3 ,burui_4 ,burui_5" +
                $" ,mae_moji ,kijunbi ,seq_last  " +
                $" from saiban " +
                $" where saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}' " + strWhere).ToList();

            return result;

        }

        /// <summary>
        /// 採番の分類マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="isLock">ロック用</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<SAIBAN_BUNRUI> GetSaibanBunrui1(string saibanSyurui, string burui1, bool isLock)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            string strWhere = string.Empty;
            if (isLock)
            {
                strWhere = " FOR UPDATE NOWAIT";
            }
            using var db = SqlManager.GetConnection;
            var result = db.Query<SAIBAN_BUNRUI>($"select saiban_syurui ,burui_1 ,burui_2 ,burui_3 ,burui_4 ,burui_5" +
                $" ,mae_moji ,kijunbi_flg ,seq_length ,seq_start ,seq_end ,over_flg ,delete_flg ,create_pgm ,create_person ,create_date ,modify_pgm ,modify_person ,modify_date " +
                $" from saiban_bunrui " +
                $"where delete_flg = '0' and saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}' " + strWhere).ToList();

            return result;

        }

        /// <summary>
        /// 採番マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="isLock">ロック用</param>
        /// <returns>採番マスタ情報</returns>
        public List<SAIBAN> GetSaiban2(string saibanSyurui, string burui1, string burui2, bool isLock)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            string strWhere = string.Empty;
            if (isLock)
            {
                strWhere = " FOR UPDATE NOWAIT";
            }
            using var db = SqlManager.GetConnection;
            var result = db.Query<SAIBAN>($"select saiban_syurui ,burui_1 ,burui_2 ,burui_3 ,burui_4 ,burui_5" +
                $" ,mae_moji ,kijunbi ,seq_last ,create_pgm ,create_person ,create_date ,modify_pgm ,modify_person ,modify_date " +
                $" from saiban " +
                $"where 0 = 0 and saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}' and burui_2 ='{burui2}' " + strWhere).ToList();

            return result;
        }

        /// <summary>
        /// 採番の分類マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="isLock">ロック用</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<SAIBAN_BUNRUI> GetSaibanBunrui2(string saibanSyurui, string burui1, string burui2, bool isLock)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            string strWhere = string.Empty;
            if (isLock)
            {
                strWhere = " FOR UPDATE NOWAIT";
            }
            using var db = SqlManager.GetConnection;
            var result = db.Query<SAIBAN_BUNRUI>($"select saiban_syurui ,burui_1 ,burui_2 ,burui_3 ,burui_4 ,burui_5" +
                $" ,mae_moji ,kijunbi_flg ,seq_length ,seq_start ,seq_end ,over_flg ,delete_flg ,create_pgm ,create_person ,create_date ,modify_pgm ,modify_person ,modify_date " +
                $" from saiban_bunrui " +
                $"where saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}' and burui_2 ='{burui2}' " + strWhere).ToList();

            return result;
        }

        /// <summary>
        /// 採番マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="isLock">ロック用</param>
        /// <returns>採番マスタ情報</returns>
        public List<SAIBAN> GetSaiban3(string saibanSyurui, string burui1, string burui2, string burui3, bool isLock)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            string strWhere = string.Empty;
            if (isLock)
            {
                strWhere = " FOR UPDATE NOWAIT";
            }
            using var db = SqlManager.GetConnection;
            var result = db.Query<SAIBAN>($"select saiban_syurui ,burui_1 ,burui_2 ,burui_3 ,burui_4 ,burui_5" +
                $" ,mae_moji ,kijunbi ,seq_last ,create_pgm ,create_person ,create_date ,modify_pgm ,modify_person ,modify_date " +
                $" from saiban " +
                $"where 0 = 0 and saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}' and burui_2 ='{burui2}' and burui_3 ='{burui3}' " + strWhere).ToList();

            return result;
        }

        /// <summary>
        /// 採番の分類マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="isLock">ロック用</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<SAIBAN_BUNRUI> GetSaibanBunrui3(string saibanSyurui, string burui1, string burui2, string burui3, bool isLock)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            string strWhere = string.Empty;
            if (isLock)
            {
                strWhere = " FOR UPDATE NOWAIT";
            }
            using var db = SqlManager.GetConnection;
            var result = db.Query<SAIBAN_BUNRUI>($"select saiban_syurui ,burui_1 ,burui_2 ,burui_3 ,burui_4 ,burui_5" +
                $" ,mae_moji ,kijunbi_flg ,seq_length ,seq_start ,seq_end ,over_flg ,delete_flg ,create_pgm ,create_person ,create_date ,modify_pgm ,modify_person ,modify_date " +
                $" from saiban_bunrui " +
                $"where saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}' and burui_2 ='{burui2}' and burui_3 ='{burui3}' " + strWhere).ToList();

            return result;
        }

        /// <summary>
        /// 採番マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <param name="isLock">ロック用</param>
        /// <returns>採番マスタ情報</returns>
        public List<SAIBAN> GetSaiban4(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, bool isLock)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            string strWhere = string.Empty;
            if (isLock)
            {
                strWhere = " FOR UPDATE NOWAIT";
            }
            using var db = SqlManager.GetConnection;
            var result = db.Query<SAIBAN>($"select saiban_syurui ,burui_1 ,burui_2 ,burui_3 ,burui_4 ,burui_5" +
                $" ,mae_moji ,kijunbi ,seq_last ,create_pgm ,create_person ,create_date ,modify_pgm ,modify_person ,modify_date " +
                $" from saiban " +
                $"where 0 = 0 and saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}' and burui_2 ='{burui2}' and burui_3 ='{burui3}' and burui_4 ='{burui4}' " + strWhere).ToList();

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
        /// <param name="isLock">ロック用</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<SAIBAN_BUNRUI> GetSaibanBunrui4(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, bool isLock)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            string strWhere = string.Empty;
            if (isLock)
            {
                strWhere = " FOR UPDATE NOWAIT";
            }
            using var db = SqlManager.GetConnection;
            var result = db.Query<SAIBAN_BUNRUI>($"select saiban_syurui ,burui_1 ,burui_2 ,burui_3 ,burui_4 ,burui_5" +
                $" ,mae_moji ,kijunbi_flg ,seq_length ,seq_start ,seq_end ,over_flg ,delete_flg ,create_pgm ,create_person ,create_date ,modify_pgm ,modify_person ,modify_date " +
                $" from saiban_bunrui " +
                $"where saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}' and burui_2 ='{burui2}' and burui_3 ='{burui3}' and burui_4 ='{burui4}' " + strWhere).ToList();

            return result;
        }

        /// <summary>
        /// 採番マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <param name="burui5">採番用分類５</param>
        /// <param name="isLock">ロック用</param>
        /// <returns>採番マスタ情報</returns>
        public List<SAIBAN> GetSaiban5(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5, bool isLock)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            string strWhere = string.Empty;
            if (isLock)
            {
                strWhere = " FOR UPDATE NOWAIT";
            }
            using var db = SqlManager.GetConnection;
            var result = db.Query<SAIBAN>($"select saiban_syurui ,burui_1 ,burui_2 ,burui_3 ,burui_4 ,burui_5" +
                $" ,mae_moji ,kijunbi ,seq_last ,create_pgm ,create_person ,create_date ,modify_pgm ,modify_person ,modify_date " +
                $" from saiban " +
                $"where 0 = 0 and saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}' and burui_2 ='{burui2}' and burui_3 ='{burui3}' and burui_4 ='{burui4}' and burui_5 ='{burui5}' " + strWhere).ToList();

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
        /// <param name="isLock">ロック用</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<SAIBAN_BUNRUI> GetSaibanBunrui5(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5, bool isLock)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            string strWhere = string.Empty;
            if (isLock)
            {
                strWhere = " FOR UPDATE NOWAIT";
            }
            using var db = SqlManager.GetConnection;
            var result = db.Query<SAIBAN_BUNRUI>($"select saiban_syurui ,burui_1 ,burui_2 ,burui_3 ,burui_4 ,burui_5" +
                $" ,mae_moji ,kijunbi_flg ,seq_length ,seq_start ,seq_end ,over_flg ,delete_flg ,create_pgm ,create_person ,create_date ,modify_pgm ,modify_person ,modify_date " +
                $" from saiban_bunrui " +
                $"where  saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}' and burui_2 ='{burui2}' and burui_3 ='{burui3}' and burui_4 ='{burui4}' and burui_5 ='{burui5}' " + strWhere).ToList();

            return result;
        }

        /// <summary>
        /// 採番分類マスタのデータを更新
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="atoBurui1">変更後の分類名</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="userId">ユーザーID</param>
        /// <returns>影響行数</returns>
        public int UpdSaibanBunrui1(string saibanSyurui, string atoBurui1, string burui1, string userId)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;
            SAIBAN_BUNRUI saiban = new SAIBAN_BUNRUI
            {
                SAIBAN_SYURUI = saibanSyurui,
                BURUI_1 = atoBurui1,
                CREATE_PERSON = userId,
                MODIFY_PERSON = userId
            };

            var result = db.Execute($"UPDATE SAIBAN_BUNRUI SET BURUI_1 = @BURUI_1, MODIFY_PGM = 'B130301',MODIFY_PERSON = @MODIFY_PERSON,MODIFY_DATE = NOW()" +
               $" WHERE SAIBAN_SYURUI = @SAIBAN_SYURUI AND BURUI_1 = '{burui1}'", saiban);

            return result;
        }

        /// <summary>
        /// 採番マスタのデータを更新
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="atoBurui1">変更後の分類名</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="userId">ユーザーID</param>
        /// <returns>影響行数</returns>
        public int UpdateSaiban1(string saibanSyurui, string atoBurui1, string burui1, string userId)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;
            SAIBAN saiban = new SAIBAN
            {
                SAIBAN_SYURUI = saibanSyurui,
                BURUI_1 = atoBurui1,
                BURUI_2 = burui1,
                CREATE_PERSON = userId,
                MODIFY_PERSON = userId
            };

            var result = db.Execute($"UPDATE SAIBAN SET BURUI_1 = @BURUI_1,MODIFY_PGM = 'B130301',MODIFY_PERSON = @MODIFY_PERSON,MODIFY_DATE = NOW()" +
               $" WHERE SAIBAN_SYURUI = @SAIBAN_SYURUI AND BURUI_1 = @BURUI_2 ", saiban);

            return result;
        }

        /// <summary>
        /// 採番分類マスタのデータを更新
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="atoBurui2">変更後の分類名</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="userId">ユーザーID</param>
        /// <returns>影響行数</returns>
        public int UpdSaibanBunrui2(string saibanSyurui, string atoBurui2, string burui1, string burui2, string userId)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;
            SAIBAN_BUNRUI saiban = new SAIBAN_BUNRUI
            {
                SAIBAN_SYURUI = saibanSyurui,
                BURUI_1 = burui1,
                BURUI_2 = burui2,
                BURUI_3 = atoBurui2,
                CREATE_PERSON = userId,
                MODIFY_PERSON = userId
            };

            var result = db.Execute($"UPDATE SAIBAN_BUNRUI SET BURUI_2 = @BURUI_3, MODIFY_PGM = 'B130301',MODIFY_PERSON = @MODIFY_PERSON,MODIFY_DATE = NOW()" +
               $" WHERE SAIBAN_SYURUI = @SAIBAN_SYURUI AND BURUI_1 = @BURUI_1 AND BURUI_2 = @BURUI_2", saiban);

            return result;
        }

        /// <summary>
        /// 採番マスタのデータを更新
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="atoBurui2">変更後の分類名</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="userId">ユーザーID</param>
        /// <returns>影響行数</returns>
        public int UpdateSaiban2(string saibanSyurui, string atoBurui2, string burui1, string burui2, string userId)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;
            SAIBAN saiban = new SAIBAN
            {
                SAIBAN_SYURUI = saibanSyurui,
                BURUI_1 = burui1,
                BURUI_2 = burui1,
                BURUI_3 = atoBurui2,
                CREATE_PERSON = userId,
                MODIFY_PERSON = userId
            };

            var result = db.Execute($"UPDATE SAIBAN SET BURUI_2 = @BURUI_3,MODIFY_PGM = 'B130301',MODIFY_PERSON = @MODIFY_PERSON,MODIFY_DATE = NOW()" +
                    $" WHERE SAIBAN_SYURUI = @SAIBAN_SYURUI AND BURUI_1 = @BURUI_1  AND BURUI_2 = @BURUI_2", saiban);

            return result;
        }

        /// <summary>
        /// 採番分類マスタのデータを更新
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="atoBurui3">変更後の分類名</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="userId">ユーザーID</param>
        /// <returns>影響行数</returns>
        public int UpdSaibanBunrui3(string saibanSyurui, string atoBurui3, string burui1, string burui2, string burui3, string userId)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;
            SAIBAN_BUNRUI saiban = new SAIBAN_BUNRUI
            {
                SAIBAN_SYURUI = saibanSyurui,
                BURUI_1 = burui1,
                BURUI_2 = burui2,
                BURUI_3 = burui3,
                BURUI_4 = atoBurui3,
                CREATE_PERSON = userId,
                MODIFY_PERSON = userId
            };

            var result = db.Execute($"UPDATE SAIBAN_BUNRUI SET BURUI_3 = @BURUI_4, MODIFY_PGM = 'B130301',MODIFY_PERSON = @MODIFY_PERSON,MODIFY_DATE = NOW()" +
               $" WHERE SAIBAN_SYURUI = @SAIBAN_SYURUI AND BURUI_1 = @BURUI_1 AND BURUI_2 = @BURUI_2 AND BURUI_3 = @BURUI_3", saiban);

            return result;
        }

        /// <summary>
        /// 採番マスタのデータを更新
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="atoBurui3">変更後の分類名</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="userId">ユーザーID</param>
        /// <returns>影響行数</returns>
        public int UpdateSaiban3(string saibanSyurui, string atoBurui3, string burui1, string burui2, string burui3, string userId)
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
                BURUI_4 = atoBurui3,
                CREATE_PERSON = userId,
                MODIFY_PERSON = userId
            };

            var result = db.Execute($"UPDATE SAIBAN SET BURUI_3 = @BURUI_4,MODIFY_PGM = 'B130301',MODIFY_PERSON = @MODIFY_PERSON,MODIFY_DATE = NOW()" +
                    $" WHERE SAIBAN_SYURUI = @SAIBAN_SYURUI AND BURUI_1 = @BURUI_1 AND BURUI_2 = @BURUI_2 AND BURUI_3 = @BURUI_3", saiban);

            return result;
        }

        /// <summary>
        /// 採番分類マスタのデータを更新
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="atoBurui4">変更後の分類名</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <param name="userId">ユーザーID</param>
        /// <returns>影響行数</returns>
        public int UpdSaibanBunrui4(string saibanSyurui, string atoBurui4, string burui1, string burui2, string burui3, string burui4, string userId)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;
            SAIBAN_BUNRUI saiban = new SAIBAN_BUNRUI
            {
                SAIBAN_SYURUI = saibanSyurui,
                BURUI_1 = burui1,
                BURUI_2 = burui2,
                BURUI_3 = burui3,
                BURUI_4 = burui4,
                BURUI_5 = atoBurui4,
                CREATE_PERSON = userId,
                MODIFY_PERSON = userId
            };

            var result = db.Execute($"UPDATE SAIBAN_BUNRUI SET BURUI_4 = @BURUI_5, MODIFY_PGM = 'B130301',MODIFY_PERSON = @MODIFY_PERSON,MODIFY_DATE = NOW()" +
               $" WHERE SAIBAN_SYURUI = @SAIBAN_SYURUI AND BURUI_1 = @BURUI_1 AND BURUI_2 = @BURUI_2 AND BURUI_3 = @BURUI_3 AND BURUI_4 = @BURUI_4", saiban);

            return result;
        }

        /// <summary>
        /// 採番マスタのデータを更新
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="atoBurui4">変更後の分類名</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <param name="userId">ユーザーID</param>
        /// <returns>影響行数</returns>
        public int UpdateSaiban4(string saibanSyurui, string atoBurui4, string burui1, string burui2, string burui3, string burui4, string userId)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;
            SAIBAN saiban = new SAIBAN
            {
                SAIBAN_SYURUI = saibanSyurui,
                BURUI_1 = burui1,
                BURUI_2 = burui1,
                BURUI_3 = burui3,
                BURUI_4 = burui4,
                BURUI_5 = atoBurui4,
                CREATE_PERSON = userId,
                MODIFY_PERSON = userId
            };

            var result = db.Execute($"UPDATE SAIBAN SET BURUI_4 = @BURUI_5,MODIFY_PGM = 'B130301',MODIFY_PERSON = @MODIFY_PERSON,MODIFY_DATE = NOW()" +
                    $" WHERE SAIBAN_SYURUI = @SAIBAN_SYURUI AND BURUI_1 = @BURUI_1 AND BURUI_2 = @BURUI_2 AND BURUI_3 = @BURUI_3 AND BURUI_4 = @BURUI_4", saiban);

            return result;
        }

        /// <summary>
        /// 採番分類マスタのデータを更新
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="atoBurui5">変更後の分類名</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <param name="burui5">採番用分類５</param>
        /// <param name="userId">ユーザーID</param>
        /// <returns>影響行数</returns>
        public int UpdSaibanBunrui5(string saibanSyurui, string atoBurui5, string burui1, string burui2, string burui3, string burui4, string burui5, string userId)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;
            SAIBAN_BUNRUI saiban = new SAIBAN_BUNRUI
            {
                SAIBAN_SYURUI = saibanSyurui,
                BURUI_1 = burui1,
                BURUI_2 = burui2,
                BURUI_3 = burui3,
                BURUI_4 = burui4,
                BURUI_5 = burui5,
                MAE_MOJI = atoBurui5,
                CREATE_PERSON = userId,
                MODIFY_PERSON = userId
            };

            var result = db.Execute($"UPDATE SAIBAN_BUNRUI SET BURUI_5 = @MAE_MOJI, MODIFY_PGM = 'B130301',MODIFY_PERSON = @MODIFY_PERSON,MODIFY_DATE = NOW()" +
               $" WHERE SAIBAN_SYURUI = @SAIBAN_SYURUI AND BURUI_1 = @BURUI_1 AND BURUI_2 = @BURUI_2 AND BURUI_3 = @BURUI_3 AND BURUI_4 = @BURUI_4 AND BURUI_5 = @BURUI_5", saiban);

            return result;
        }

        /// <summary>
        /// 採番マスタのデータを更新
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="atoBurui5">変更後の分類名</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <param name="burui5">採番用分類５</param>
        /// <param name="userId">ユーザーID</param>
        /// <returns>影響行数</returns>
        public int UpdateSaiban5(string saibanSyurui, string atoBurui5, string burui1, string burui2, string burui3, string burui4, string burui5, string userId)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            SAIBAN saiban = new SAIBAN
            {
                SAIBAN_SYURUI = saibanSyurui,
                BURUI_1 = burui1,
                BURUI_2 = burui1,
                BURUI_3 = burui3,
                BURUI_4 = burui4,
                BURUI_5 = burui5,
                MAE_MOJI = atoBurui5,
                CREATE_PERSON = userId,
                MODIFY_PERSON = userId
            };

            var result = db.Execute($"UPDATE SAIBAN SET BURUI_5 = @MAE_MOJI,MODIFY_PGM = 'B130301',MODIFY_PERSON = @MODIFY_PERSON,MODIFY_DATE = NOW()" +
                    $" WHERE SAIBAN_SYURUI = @SAIBAN_SYURUI AND BURUI_1 = @BURUI_1 AND BURUI_2 = @BURUI_2 AND BURUI_3 = @BURUI_3 AND BURUI_4 = @BURUI_4 AND BURUI_5 = @BURUI_5", saiban);

            return result;
        }

        /// <summary>
        /// 採番の分類マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="atoBurui1">変更後の分類名</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<SAIBAN_BUNRUI> GetUpdSaibanBunrui1(string saibanSyurui, string atoBurui1)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;
            var result = db.Query<SAIBAN_BUNRUI>($"select saiban_syurui ,burui_1 ,burui_2 ,burui_3 ,burui_4 ,burui_5" +
                $" ,mae_moji ,kijunbi_flg ,seq_length ,seq_start ,seq_end ,over_flg ,delete_flg ,create_pgm ,create_person ,create_date ,modify_pgm ,modify_person ,modify_date " +
                $" from saiban_bunrui " +
                $"where saiban_syurui ='{saibanSyurui}' and burui_1 ='{atoBurui1}' ").ToList();

            return result;
        }

        /// <summary>
        /// 採番の分類マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="atoBurui2">変更後の分類名</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<SAIBAN_BUNRUI> GetUpdSaibanBunrui2(string saibanSyurui, string burui1, string atoBurui2)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;
            var result = db.Query<SAIBAN_BUNRUI>($"select saiban_syurui ,burui_1 ,burui_2 ,burui_3 ,burui_4 ,burui_5" +
                $" ,mae_moji ,kijunbi_flg ,seq_length ,seq_start ,seq_end ,over_flg ,delete_flg ,create_pgm ,create_person ,create_date ,modify_pgm ,modify_person ,modify_date " +
                $" from saiban_bunrui " +
                $"where saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}' and burui_2 ='{atoBurui2}' ").ToList();

            return result;
        }

        /// <summary>
        /// 採番の分類マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="atoBurui3">変更後の分類名</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<SAIBAN_BUNRUI> GetUpdSaibanBunrui3(string saibanSyurui, string burui1, string burui2, string atoBurui3)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;
            var result = db.Query<SAIBAN_BUNRUI>($"select saiban_syurui ,burui_1 ,burui_2 ,burui_3 ,burui_4 ,burui_5" +
                $" ,mae_moji ,kijunbi_flg ,seq_length ,seq_start ,seq_end ,over_flg ,delete_flg ,create_pgm ,create_person ,create_date ,modify_pgm ,modify_person ,modify_date " +
                $" from saiban_bunrui " +
                $"where saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}' and burui_2 ='{burui2}' and burui_3 ='{atoBurui3}' ").ToList();

            return result;
        }

        /// <summary>
        /// 採番の分類マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="atoBurui4">変更後の分類名</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<SAIBAN_BUNRUI> GetUpdSaibanBunrui4(string saibanSyurui, string burui1, string burui2, string burui3, string atoBurui4)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;
            var result = db.Query<SAIBAN_BUNRUI>($"select saiban_syurui ,burui_1 ,burui_2 ,burui_3 ,burui_4 ,burui_5" +
                $" ,mae_moji ,kijunbi_flg ,seq_length ,seq_start ,seq_end ,over_flg ,delete_flg ,create_pgm ,create_person ,create_date ,modify_pgm ,modify_person ,modify_date " +
                $" from saiban_bunrui " +
                $"where saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}' and burui_2 ='{burui2}' and burui_3 ='{burui3}' and burui_4 ='{atoBurui4}' ").ToList();

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
        /// <param name="atoBurui5">変更後の分類名</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<SAIBAN_BUNRUI> GetUpdSaibanBunrui5(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string atoBurui5)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;
            var result = db.Query<SAIBAN_BUNRUI>($"select saiban_syurui ,burui_1 ,burui_2 ,burui_3 ,burui_4 ,burui_5" +
                $" ,mae_moji ,kijunbi_flg ,seq_length ,seq_start ,seq_end ,over_flg ,delete_flg ,create_pgm ,create_person ,create_date ,modify_pgm ,modify_person ,modify_date " +
                $" from saiban_bunrui " +
                $"where saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}' and burui_2 ='{burui2}' and burui_3 ='{burui3}' and burui_4 ='{burui4}' and burui_5 ='{atoBurui5}'").ToList();

            return result;
        }


    }
}
