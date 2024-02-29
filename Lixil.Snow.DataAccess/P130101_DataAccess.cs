using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{
    /// <summary>
    /// 採番データアクセス
    /// </summary>
    public class P130101_DataAccess : SqlManager
    {

        #region 採番の分類マスタ
        /// <summary>
        /// 採番用分類１の取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <returns>採番用分類１情報</returns>
        /// <remarks>20231205 孟(大連) 新規作成</remarks>
        public List<string> GetBurui1(string saibanSyurui)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;
            var result = db.Query<string>($"select distinct burui_1 from saiban_bunrui " +
                $"where delete_flg = '0' and saiban_syurui ='{saibanSyurui}' order by burui_1").ToList();

            return result;
        }

        /// <summary>
        /// 採番用分類２の取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <returns>採番用分類２情報</returns>
        /// <remarks>20231205 孟(大連) 新規作成</remarks>
        public List<string> GetBurui2(string saibanSyurui, string burui1)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            var result = db.Query<string>($"select distinct burui_2 from saiban_bunrui " +
                $"where delete_flg = '0' and saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}' order by burui_2").ToList();

            return result;
        }
        /// <summary>
        ///採番用分類３の取得
        ///</summary>
        ///<param name="saibanSyurui">採番の種類</param>
        ///<param name="burui1">採番用分類１</param>
        ///<param name="burui2">採番用分類２</param>
        ///<returns>採番用分類３情報</returns>
        ///<remarks>20231205 孟(大連) 新規作成</remarks>
        public List<string> GetBurui3(string saibanSyurui, string burui1, string burui2)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            var result = db.Query<string>($"select distinct burui_3 from saiban_bunrui " +
                $"where delete_flg = '0' and saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}'  and burui_2 ='{burui2}'" +
                $"order by burui_3").ToList();

            return result;
        }
        /// <summary>
        ///採番用分類４の取得
        ///</summary>
        ///<param name="saibanSyurui">採番の種類</param>
        ///<param name="burui1">採番用分類１</param>
        ///<param name="burui2">採番用分類２</param>
        ///<param name="burui3">採番用分類３</param>
        ///<returns>採番用分類４情報</returns>
        public List<string> GetBurui4(string saibanSyurui, string burui1, string burui2, string burui3)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            var result = db.Query<string>($"select distinct burui_4 from saiban_bunrui " +
                $"where delete_flg = '0' and saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}'  and burui_2 ='{burui2}' and burui_3 ='{burui3}'" +
                $"order by burui_4").ToList();

            return result;
        }

        /// <summary>
        /// 採番用分類５の取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <returns>採番用分類５情報</returns>
        public List<string> GetBurui5(string saibanSyurui, string burui1, string burui2, string burui3, string burui4)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            var result = db.Query<string>($"select distinct burui_5 from saiban_bunrui " +
                $"where delete_flg = '0' and saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}'  and burui_2 ='{burui2}' and burui_3 ='{burui3}' and burui_4 ='{burui4}'" +
                $"order by burui_5").ToList();

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
        /// 採番の種類の取得
        /// </summary>
        /// <returns>採番種類マスタ情報</returns>
        public List<string> GetSaiBanSyurui()
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;
            var result = db.Query<string>($"select distinct saiban_syurui from saiban_syurui " +
                $"where delete_flg = '0' and entry_flg = '1' order by saiban_syurui").ToList();

            return result;
        }

        #endregion
    }
}
