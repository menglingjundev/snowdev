using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{
    /// <summary>
    /// 採番データアクセス
    /// </summary>
    public class P130301_DataAccess : SqlManager
    {

        #region 採番の分類マスタ
        /// <summary>
        /// 採番用分類１の取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <returns>採番用分類１情報</returns>
        /// <remarks>20231205 孟(大連) 新規作成</remarks>
        public List<string> GetDistinctBunrui1(string saibanSyurui)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            var result = db.Query<string>($"select distinct burui_1 from saiban_bunrui " +
                $"where saiban_syurui ='{saibanSyurui}' order by burui_1").ToList();

            return result;
        }
        /// <summary>
        /// 採番用分類２の取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <returns>採番用分類２情報</returns>
        /// <remarks>20231205 孟(大連) 新規作成</remarks>
        public List<string> GetDistinctBunrui2(string saibanSyurui, string burui1)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            var result = db.Query<string>($"select distinct burui_2 from saiban_bunrui " +
                $"where saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}' order by burui_2").ToList();

            return result;
        }
        /// <summary>
        /// 採番用分類３の取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <returns>採番用分類３情報</returns>
        /// <remarks>20231205 孟(大連) 新規作成</remarks>
        public List<string> GetDistinctBunrui3(string saibanSyurui, string burui1, string burui2)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            var result = db.Query<string>($"select distinct burui_3 from saiban_bunrui " +
                $"where saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}'  and burui_2 ='{burui2}'" +
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
        ///<remarks>20231205 孟(大連) 新規作成</remarks>
        public List<string> GetDistinctBunrui4(string saibanSyurui, string burui1, string burui2, string burui3)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            var result = db.Query<string>($"select distinct burui_4 from saiban_bunrui " +
                $"where saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}'  and burui_2 ='{burui2}' and burui_3 ='{burui3}'" +
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
        /// <remarks>20231205 孟(大連) 新規作成</remarks>
        public List<string> GetDistinctBunrui5(string saibanSyurui, string burui1, string burui2, string burui3, string burui4)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            var result = db.Query<string>($"select distinct burui_5 from saiban_bunrui " +
                $"where saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}'  and burui_2 ='{burui2}' and burui_3 ='{burui3}' and burui_4 ='{burui4}'" +
                $"order by burui_5").ToList();

            return result;
        }

        /// <summary>
        /// 採番の種類の取得
        /// </summary>
        /// <returns>採番種類マスタ情報</returns>
        /// <remarks>20231205 孟(大連) 新規作成</remarks>
        public List<string> GetDistinctSyurui()
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;
            var result = db.Query<string>($"select distinct saiban_syurui from saiban_syurui " +
                $"order by saiban_syurui").ToList();

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
        /// <remarks>20231205 孟(大連) 新規作成</remarks>
        public List<SAIBAN_BUNRUI> GetSaibanBunruiAndSaiban(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            string strAnd = string.Empty;
            if (!string.IsNullOrEmpty(burui1))
            {
                strAnd += $" and sb.burui_1 = '{burui1}' ";
            }
            if (!string.IsNullOrEmpty(burui2))
            {
                strAnd += $" and sb.burui_2 = '{burui2}' ";
            }
            if (!string.IsNullOrEmpty(burui3))
            {
                strAnd += $" and sb.burui_3 = '{burui3}' ";
            }
            if (!string.IsNullOrEmpty(burui4))
            {
                strAnd += $" and sb.burui_4 = '{burui4}' ";
            }
            if (!string.IsNullOrEmpty(burui5))
            {
                strAnd += $" and sb.burui_5 = '{burui5}' ";
            }
            using var db = SqlManager.GetConnection;
            var result = db.Query<SAIBAN_BUNRUI>($"select sb.saiban_syurui ,sb.burui_1 ,sb.burui_2 ,sb.burui_3 ,sb.burui_4 ,sb.burui_5" +
                $" ,sb.mae_moji ,sb.kijunbi_flg ,sb.seq_length ,sb.seq_start ,sb.seq_end ,sb.over_flg ,sb.delete_flg ,case when sb.kijunbi_flg = '0' then sai.seq_last else 0 end  as seq_last" +
                $" ,sb.create_pgm ,sb.create_person ,sb.create_date ,sb.modify_pgm ,sb.modify_person ,sb.modify_date " +
                $" from saiban_bunrui sb left join saiban sai" +
                $" on sb.saiban_syurui = sai.saiban_syurui and sb.burui_1 = sai.burui_1 and sb.burui_2 = sai.burui_2 and sb.burui_3 = sai.burui_3 " +
                $" and sb.burui_4 = sai.burui_4 and sb.burui_5 = sai.burui_5 and sb.mae_moji= sai.mae_moji " +
                $"where sb.saiban_syurui ='{saibanSyurui}' " + strAnd).ToList();

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
        /// <remarks>20231205 孟(大連) 新規作成</remarks>
        public List<SAIBAN_BUNRUI> GetBunrui(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            string strAnd = string.Empty;
            if (!string.IsNullOrEmpty(burui1))
            {
                strAnd += $" and burui_1 = '{burui1}' ";
            }
            if (!string.IsNullOrEmpty(burui2))
            {
                strAnd += $" and burui_2 = '{burui2}' ";
            }
            if (!string.IsNullOrEmpty(burui3))
            {
                strAnd += $" and burui_3 = '{burui3}' ";
            }
            if (!string.IsNullOrEmpty(burui4))
            {
                strAnd += $" and burui_4 = '{burui4}' ";
            }
            if (!string.IsNullOrEmpty(burui5))
            {
                strAnd += $" and burui_5 = '{burui5}' ";
            }
            using var db = SqlManager.GetConnection;
            var result = db.Query<SAIBAN_BUNRUI>($"select saiban_syurui ,burui_1 ,burui_2 ,burui_3 ,burui_4 ,burui_5" +
                $" ,mae_moji ,kijunbi_flg ,seq_length ,seq_start ,seq_end ,over_flg ,delete_flg " +
                $" ,create_pgm ,create_person ,create_date ,modify_pgm ,modify_person ,modify_date " +
                $" from saiban_bunrui" +
                $" where saiban_syurui ='{saibanSyurui}' " + strAnd).ToList();

            return result;
        }

        /// <summary>
        /// 採番の種類マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <returns>採番の種類マスタ情報</returns>
        /// <remarks>20231205 孟(大連) 新規作成</remarks>
        public List<SAIBANSYURUI> GetSaiBanSyuruiAll(string saibanSyurui)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            //var result = db.Query<SAIBAN_BUNRUI>($"select saiban_syurui ,burui_1 ,burui_2 ,burui_3 ,burui_4 ,burui_5" +
            //    $" ,mae_moji ,kijunbi_flg ,seq_length ,seq_start ,seq_end ,over_flg ,delete_flg " +
            //    $" ,create_pgm ,create_person ,create_date ,modify_pgm ,modify_person ,modify_date " +
            //    $" from saiban_bunrui" +
            //    $" where saiban_syurui ='{saibanSyurui}' order by saiban_syurui").ToList();

            var result = db.Query<SAIBANSYURUI>($"select saiban_syurui ,burui_1_flg ,burui_2_flg ,burui_3_flg ,burui_4_flg ,burui_5_flg" +
                $" ,rireki_flg ,entry_flg,delete_flg " +
                $" from saiban_syurui" +
                $" where saiban_syurui ='{saibanSyurui}' order by saiban_syurui").ToList();

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
        /// <returns>採番マスタ情報</returns>
        /// <remarks>20231205 孟(大連) 新規作成</remarks>
        public List<SAIBAN> GetSaibanAll(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            var result = db.Query<SAIBAN>($"select saiban_syurui ,burui_1 ,burui_2 ,burui_3 ,burui_4 ,burui_5" +
                $" ,mae_moji ,kijunbi ,seq_last  " +
                $" from saiban_bunrui " +
                $"where saiban_syurui ='{saibanSyurui}' and burui_1 ='{burui1}'  and burui_2 ='{burui2}' " +
                $"and burui_3 ='{burui3}' and burui_4 ='{burui4}' and burui_5 ='{burui5}'").ToList();

            return result;
        }

        #endregion
    }
}
