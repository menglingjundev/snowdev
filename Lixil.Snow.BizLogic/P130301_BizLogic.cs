using Lixil.Snow.DataAccess;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Reflection;

namespace Lixil.Snow.BizLogic
{
    /// <summary>
    /// 採番の種類マスタのデータアクセス
    /// </summary>
    public class P130301_BizLogic
    {

        //SQL文実行用
        private P130301_DataAccess da;

        public P130301_BizLogic()
        {
            da = new P130301_DataAccess();
        }
        /// <summary>
        /// 採番用分類１の取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <returns>採番用分類１情報</returns>
        /// <remarks>20231205 孟(大連) 新規作成</remarks>
        public List<string> GetDistinctBunrui1(string saibanSyurui)
        {
            // イベントログ追加System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            List<string> result = new List<string>();
            result = da.GetDistinctBunrui1(saibanSyurui);
            da.Close();
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
            // イベントログ追加System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            List<string> result = new List<string>();
            result = da.GetDistinctBunrui2(saibanSyurui, burui1);
            da.Close();
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

            List<string> result = new List<string>();
            result = da.GetDistinctBunrui3(saibanSyurui, burui1, burui2);
            da.Close();
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

            List<string> result = new List<string>();
            result = da.GetDistinctBunrui4(saibanSyurui, burui1, burui2, burui3);
            da.Close();
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

            List<string> result = new List<string>();
            result = da.GetDistinctBunrui5(saibanSyurui, burui1, burui2, burui3, burui4);
            da.Close();
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
            List<string> result = new List<string>();
            result = da.GetDistinctSyurui();
            da.Close();
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
            List<SAIBAN_BUNRUI> result = new List<SAIBAN_BUNRUI>();
            result = da.GetSaibanBunruiAndSaiban(saibanSyurui, burui1, burui2, burui3, burui4, burui5);
            da.Close();
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
            List<SAIBAN_BUNRUI> result = new List<SAIBAN_BUNRUI>();
            result = da.GetBunrui(saibanSyurui, burui1, burui2, burui3, burui4, burui5);
            da.Close();
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

            List<SAIBANSYURUI> result = new List<SAIBANSYURUI>();
            result = da.GetSaiBanSyuruiAll(saibanSyurui);
            da.Close();
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

            List<SAIBAN> result = new List<SAIBAN>();
            result = da.GetSaibanAll(saibanSyurui, burui1, burui2, burui3, burui4, burui5);
            da.Close();
            return result;
        }
    }
}
