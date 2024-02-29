using Lixil.Snow.DataAccess;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Reflection;

namespace Lixil.Snow.BizLogic
{
    /// <summary>
    /// 採番の種類マスタのデータアクセス
    /// </summary>
    public class P130101_BizLogic
    {

        //SQL文実行用
        private P130101_DataAccess da;

        public P130101_BizLogic()
        {
            da = new P130101_DataAccess();
        }
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
            List<string> result = new List<string>();
            result = da.GetBurui1(saibanSyurui);
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
        public List<string> GetBurui2(string saibanSyurui, string burui1)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<string> result = new List<string>();
            result = da.GetBurui2(saibanSyurui, burui1);
            da.Close();
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
            List<string> result = new List<string>();
            result = da.GetBurui3(saibanSyurui, burui1, burui2);
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
        public List<string> GetBurui4(string saibanSyurui, string burui1, string burui2, string burui3)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<string> result = new List<string>();
            result = da.GetBurui4(saibanSyurui, burui1, burui2, burui3);
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
        public List<string> GetBurui5(string saibanSyurui, string burui1, string burui2, string burui3, string burui4)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<string> result = new List<string>();
            result = da.GetBurui5(saibanSyurui, burui1, burui2, burui3, burui4);
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
        public List<SAIBAN_BUNRUI> GetSaibanBunrui(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<SAIBAN_BUNRUI> result = new List<SAIBAN_BUNRUI>();
            result = da.GetSaibanBunrui(saibanSyurui, burui1, burui2, burui3, burui4, burui5);
            da.Close();
            return result;
        }

        /// <summary>
        /// 採番の種類の取得
        /// </summary>
        /// <returns>採番種類マスタ情報</returns>
        public List<string> GetSaibanSyurui()
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<string> result = new List<string>();
            result = da.GetSaiBanSyurui();
            da.Close();
            return result;
        }

    }
}
