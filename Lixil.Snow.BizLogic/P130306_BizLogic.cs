using Dapper;
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
    public class P130306_BizLogic
    {

        //SQL文実行用
        private P130306_DataAccess da;

        public P130306_BizLogic()
        {
            da = new P130306_DataAccess();
        }

        ///// <summary>
        ///// 採番マスタのデータの取得
        ///// </summary>
        ///// <param name="saibanSyurui">採番の種類</param>
        ///// <param name="burui1">採番用分類１</param>
        ///// <param name="isLock">ロック用</param>
        ///// <returns>採番マスタ情報</returns>
        //public List<SAIBAN> GetSaiban1(string saibanSyurui, string burui1, bool isLock)
        //{
        //    // イベントログ追加
        //    Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
        //    var result = da.GetSaiban1(saibanSyurui, burui1, isLock);
        //    da.Close();
        //    return result;
        //}

        ///// <summary>
        ///// 採番の分類マスタのデータの取得
        ///// </summary>
        ///// <param name="saibanSyurui">採番の種類</param>
        ///// <param name="burui1">採番用分類１</param>
        ///// <param name="isLock">ロック用</param>
        ///// <returns>採番の分類マスタ情報</returns>
        //public List<SAIBAN_BUNRUI> GetSaibanBunrui1(string saibanSyurui, string burui1, bool isLock)
        //{
        //    // イベントログ追加
        //    Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
        //    var result = da.GetSaibanBunrui1(saibanSyurui, burui1, isLock);
        //    da.Close();
        //    return result;
        //}

        ///// <summary>
        ///// 採番マスタのデータの取得
        ///// </summary>
        ///// <param name="saibanSyurui">採番の種類</param>
        ///// <param name="burui1">採番用分類１</param>
        ///// <param name="burui2">採番用分類２</param>
        ///// <param name="isLock">ロック用</param>
        ///// <returns>採番マスタ情報</returns>
        //public List<SAIBAN> GetSaiban2(string saibanSyurui, string burui1, string burui2, bool isLock)
        //{

        //    // イベントログ追加
        //    Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
        //    var result = da.GetSaiban2(saibanSyurui, burui1, burui2, isLock);
        //    da.Close();
        //    return result;
        //}

        ///// <summary>
        ///// 採番の分類マスタのデータの取得
        ///// </summary>
        ///// <param name="saibanSyurui">採番の種類</param>
        ///// <param name="burui1">採番用分類１</param>
        ///// <param name="burui2">採番用分類２</param>
        ///// <param name="isLock">ロック用</param>
        ///// <returns>採番の分類マスタ情報</returns>
        //public List<SAIBAN_BUNRUI> GetSaibanBunrui2(string saibanSyurui, string burui1, string burui2, bool isLock)
        //{

        //    // イベントログ追加
        //    Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
        //    var result = da.GetSaibanBunrui2(saibanSyurui, burui1, burui2, isLock);
        //    da.Close();
        //    return result;
        //}

        ///// <summary>
        ///// 採番マスタのデータの取得
        ///// </summary>
        ///// <param name="saibanSyurui">採番の種類</param>
        ///// <param name="burui1">採番用分類１</param>
        ///// <param name="burui2">採番用分類２</param>
        ///// <param name="burui3">採番用分類３</param>
        ///// <param name="isLock">ロック用</param>
        ///// <returns>採番マスタ情報</returns>
        //public List<SAIBAN> GetSaiban3(string saibanSyurui, string burui1, string burui2, string burui3, bool isLock)
        //{

        //    // イベントログ追加
        //    Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
        //    var result = da.GetSaiban3(saibanSyurui, burui1, burui2, burui3, isLock);
        //    da.Close();
        //    return result;
        //}

        ///// <summary>
        ///// 採番の分類マスタのデータの取得
        ///// </summary>
        ///// <param name="saibanSyurui">採番の種類</param>
        ///// <param name="burui1">採番用分類１</param>
        ///// <param name="burui2">採番用分類２</param>
        ///// <param name="burui3">採番用分類３</param>
        ///// <param name="isLock">ロック用</param>
        ///// <returns>採番の分類マスタ情報</returns>
        //public List<SAIBAN_BUNRUI> GetSaibanBunrui3(string saibanSyurui, string burui1, string burui2, string burui3, bool isLock)
        //{

        //    // イベントログ追加
        //    Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
        //    var result = da.GetSaibanBunrui3(saibanSyurui, burui1, burui2, burui3, isLock);
        //    da.Close();
        //    return result;
        //}

        ///// <summary>
        ///// 採番マスタのデータの取得
        ///// </summary>
        ///// <param name="saibanSyurui">採番の種類</param>
        ///// <param name="burui1">採番用分類１</param>
        ///// <param name="burui2">採番用分類２</param>
        ///// <param name="burui3">採番用分類３</param>
        ///// <param name="burui4">採番用分類４</param>
        ///// <param name="isLock">ロック用</param>
        ///// <returns>採番マスタ情報</returns>
        //public List<SAIBAN> GetSaiban4(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, bool isLock)
        //{

        //    // イベントログ追加
        //    Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
        //    var result = da.GetSaiban4(saibanSyurui, burui1, burui2, burui3, burui4, isLock);
        //    da.Close();
        //    return result;
        //}

        ///// <summary>
        ///// 採番の分類マスタのデータの取得
        ///// </summary>
        ///// <param name="saibanSyurui">採番の種類</param>
        ///// <param name="burui1">採番用分類１</param>
        ///// <param name="burui2">採番用分類２</param>
        ///// <param name="burui3">採番用分類３</param>
        ///// <param name="burui4">採番用分類４</param>
        ///// <param name="isLock">ロック用</param>
        ///// <returns>採番の分類マスタ情報</returns>
        //public List<SAIBAN_BUNRUI> GetSaibanBunrui4(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, bool isLock)
        //{

        //    // イベントログ追加
        //    Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
        //    var result = da.GetSaibanBunrui4(saibanSyurui, burui1, burui2, burui3, burui4, isLock);
        //    da.Close();
        //    return result;
        //}

        ///// <summary>
        ///// 採番マスタのデータの取得
        ///// </summary>
        ///// <param name="saibanSyurui">採番の種類</param>
        ///// <param name="burui1">採番用分類１</param>
        ///// <param name="burui2">採番用分類２</param>
        ///// <param name="burui3">採番用分類３</param>
        ///// <param name="burui4">採番用分類４</param>
        ///// <param name="burui5">採番用分類５</param>
        ///// <param name="isLock">ロック用</param>
        ///// <returns>採番マスタ情報</returns>
        //public List<SAIBAN> GetSaiban5(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5, bool isLock)
        //{

        //    // イベントログ追加
        //    Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
        //    var result = da.GetSaiban5(saibanSyurui, burui1, burui2, burui3, burui4, burui5, isLock);
        //    da.Close();
        //    return result;
        //}

        ///// <summary>
        ///// 採番の分類マスタのデータの取得
        ///// </summary>
        ///// <param name="saibanSyurui">採番の種類</param>
        ///// <param name="burui1">採番用分類１</param>
        ///// <param name="burui2">採番用分類２</param>
        ///// <param name="burui3">採番用分類３</param>
        ///// <param name="burui4">採番用分類４</param>
        ///// <param name="burui5">採番用分類５</param>
        ///// <param name="isLock">ロック用</param>
        ///// <returns>採番の分類マスタ情報</returns>
        //public List<SAIBAN_BUNRUI> GetSaibanBunrui5(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5, bool isLock)
        //{

        //    // イベントログ追加
        //    Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
        //    var result = da.GetSaibanBunrui5(saibanSyurui, burui1, burui2, burui3, burui4, burui5, isLock);
        //    da.Close();
        //    return result;
        //}

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
            var result = da.UpdSaibanBunrui1(saibanSyurui, atoBurui1, burui1, userId);
            da.Close();
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
            var result = da.UpdateSaiban1(saibanSyurui, atoBurui1, burui1, userId);
            da.Close();
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
            var result = da.UpdSaibanBunrui2(saibanSyurui, atoBurui2, burui1, burui2, userId);
            da.Close();
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
            var result = da.UpdateSaiban2(saibanSyurui, atoBurui2, burui1, burui2, userId);
            da.Close();
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
            var result = da.UpdSaibanBunrui3(saibanSyurui, atoBurui3, burui1, burui2, burui3, userId);
            da.Close();
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
            var result = da.UpdateSaiban3(saibanSyurui, atoBurui3, burui1, burui2, burui3, userId);
            da.Close();
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
            var result = da.UpdSaibanBunrui4(saibanSyurui, atoBurui4, burui1, burui2, burui3, burui4, userId);
            da.Close();
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
            var result = da.UpdateSaiban4(saibanSyurui, atoBurui4, burui1, burui2, burui3, burui4, userId);
            da.Close();
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
            var result = da.UpdSaibanBunrui5(saibanSyurui, atoBurui5, burui1, burui2, burui3, burui4, burui5, userId);
            da.Close();
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

            var result = da.UpdateSaiban5(saibanSyurui, atoBurui5, burui1, burui2, burui3, burui4, burui5, userId);
            da.Close();
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
            var result = da.GetUpdSaibanBunrui1(saibanSyurui, atoBurui1);
            da.Close();
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
            var result = da.GetUpdSaibanBunrui2(saibanSyurui, burui1, atoBurui2);
            da.Close();
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
            var result = da.GetUpdSaibanBunrui3(saibanSyurui, burui1, burui2, atoBurui3);
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
        /// <param name="atoBurui4">変更後の分類名</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<SAIBAN_BUNRUI> GetUpdSaibanBunrui4(string saibanSyurui, string burui1, string burui2, string burui3, string atoBurui4)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            var result = da.GetUpdSaibanBunrui4(saibanSyurui, burui1, burui2, burui3, atoBurui4);
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
        /// <param name="atoBurui5">変更後の分類名</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<SAIBAN_BUNRUI> GetUpdSaibanBunrui5(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string atoBurui5)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            var result = da.GetUpdSaibanBunrui5(saibanSyurui, burui1, burui2, burui3, burui4, atoBurui5);
            da.Close();
            return result;
        }

        /// <summary>
        /// 採番マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="atoBurui1">変更後の分類名</param>
        /// <param name="burui1">採番用分類１</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<string> UpdateSaibanAndSaibanBunrui1(string saibanSyurui, string atoBurui1, string burui1, string userId)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<string> result = new List<string>();

            using (NpgsqlTransaction scope = SqlManager.BeginTransaction)
            {
                int updSaibanResult = 0;
                int updSaibanbunruiResult = 0;
                List<SAIBAN> saibandata = da.GetSaiban1(saibanSyurui, burui1, false);
                int saibanCount = saibandata.Count;
                List<SAIBAN> saibanResult = new List<SAIBAN>();
                if (saibanCount > 0)
                    // 採番マスタを検索する
                    saibanResult = da.GetSaiban1(saibanSyurui, burui1, true);

                if (saibanCount > 0)
                {
                    if (saibanResult.Count > 0)
                    {
                        // 採番マスタを更新する
                        updSaibanResult = da.UpdateSaiban1(saibanSyurui, atoBurui1, burui1, userId);
                        // 失敗の場合
                        if (updSaibanResult == 0)
                        {
                            da.Close();
                            scope.Dispose();
                            result.Add(string.Empty);
                            result.Add(string.Format(Utilities.MessageConst.MSG_COMM_141, "採番マスタ"));
                            return result;
                        }
                    }
                    else
                    {
                        // 存在しない場合
                        scope.Dispose();
                        result.Add(string.Empty);
                        result.Add(string.Format(Utilities.MessageConst.MSG_COMM_149));
                        return result;
                    }
                }

                // 採番分類マスタを検索する
                List<SAIBAN_BUNRUI> saibanbunruiResult = da.GetSaibanBunrui1(saibanSyurui, burui1, true);
                // 採番分類テーブルを更新する
                if (saibanbunruiResult.Count > 0)
                {
                    updSaibanbunruiResult = da.UpdSaibanBunrui1(saibanSyurui, atoBurui1, burui1, userId);
                    if (updSaibanbunruiResult == 0)
                    {
                        // 失敗の場合
                        da.Close();
                        scope.Dispose();
                        result.Add(string.Empty);
                        result.Add(string.Format(Utilities.MessageConst.MSG_COMM_141, "採番分類マスタ"));
                        return result;
                    }
                }
                else
                {
                    // 存在しない場合
                    scope.Dispose();
                    result.Add(string.Empty);
                    result.Add(string.Format(Utilities.MessageConst.MSG_COMM_149));
                    return result;
                }

                da.Close();
                scope.Commit();
                result.Add(updSaibanbunruiResult.ToString());
                result.Add(string.Empty);
            }
            return result;
        }

        /// <summary>
        /// 採番マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="atoBurui2">変更後の分類名</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<string> UpdateSaibanAndSaibanBunrui2(string saibanSyurui, string atoBurui2, string burui1, string burui2, string userId)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<string> result = new List<string>();
            using (NpgsqlTransaction scope = SqlManager.BeginTransaction)
            {
                int updSaibanResult = 0;
                int updSaibanbunruiResult = 0;
                List<SAIBAN> saibandata = da.GetSaiban2(saibanSyurui, burui1, burui2, false);
                int saibanCount = saibandata.Count;
                List<SAIBAN> saibanResult = new List<SAIBAN>();
                if (saibanCount > 0)
                    // 採番マスタを検索する
                    saibanResult = da.GetSaiban2(saibanSyurui, burui1, burui2, true);

                if (saibanCount > 0)
                {
                    if (saibanResult.Count > 0)
                    {
                        // 採番マスタを更新する
                        updSaibanResult = da.UpdateSaiban2(saibanSyurui, atoBurui2, burui1, burui2, userId);
                        if (updSaibanResult == 0)
                        {
                            // 失敗の場合
                            da.Close();
                            scope.Dispose();
                            result.Add(string.Empty);
                            result.Add(string.Format(Utilities.MessageConst.MSG_COMM_141, "採番マスタ"));
                            return result;
                        }
                    }
                    else
                    {
                        // 存在しない場合
                        da.Close();
                        scope.Dispose();
                        result.Add(string.Empty);
                        result.Add(string.Format(Utilities.MessageConst.MSG_COMM_149));
                        return result;
                    }
                }

                // 採番分類マスタを検索する
                List<SAIBAN_BUNRUI> saibanbunruiResult = da.GetSaibanBunrui2(saibanSyurui, burui1, burui2, true);
                if (saibanbunruiResult.Count > 0)
                {
                    // 採番分類テーブルを更新する
                    updSaibanbunruiResult = da.UpdSaibanBunrui2(saibanSyurui, atoBurui2, burui1, burui2, userId);
                    if (updSaibanbunruiResult == 0)
                    {
                        // 失敗の場合
                        da.Close();
                        scope.Dispose();
                        result.Add(string.Empty);
                        result.Add(string.Format(Utilities.MessageConst.MSG_COMM_141, "採番分類マスタ"));
                        return result;
                    }
                }
                else
                {
                    // 存在しない場合
                    da.Close();
                    scope.Dispose();
                    result.Add(string.Empty);
                    result.Add(string.Format(Utilities.MessageConst.MSG_COMM_149));
                    return result;
                }

                da.Close();
                scope.Commit();
                result.Add(updSaibanbunruiResult.ToString());
                result.Add(string.Empty);
            }
            return result;
        }

        /// <summary>
        /// 採番マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="atoBurui3">変更後の分類名</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<string> UpdateSaibanAndSaibanBunrui3(string saibanSyurui, string atoBurui3, string burui1, string burui2, string burui3, string userId)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<string> result = new List<string>();

            using (NpgsqlTransaction scope = SqlManager.BeginTransaction)
            {
                int updSaibanResult = 0;
                int updSaibanbunruiResult = 0;
                List<SAIBAN> saibandata = da.GetSaiban3(saibanSyurui, burui1, burui2, burui3, false);
                int saibanCount = saibandata.Count;
                List<SAIBAN> saibanResult = new List<SAIBAN>();
                if (saibanCount > 0)
                    // 採番マスタを検索する
                    saibanResult = da.GetSaiban3(saibanSyurui, burui1, burui2, burui3, true);

                if (saibanCount > 0)
                {
                    if (saibanResult.Count > 0)
                    {
                        // 採番マスタを更新する
                        updSaibanResult = da.UpdateSaiban3(saibanSyurui, atoBurui3, burui1, burui2, burui3, userId);
                        if (updSaibanResult == 0)
                        {
                            // 失敗の場合
                            da.Close();
                            scope.Dispose();
                            result.Add(string.Empty);
                            result.Add(string.Format(Utilities.MessageConst.MSG_COMM_141, "採番マスタ"));
                            return result;
                        }
                    }
                    else
                    {
                        // 存在しない場合
                        da.Close();
                        scope.Dispose();
                        result.Add(string.Empty);
                        result.Add(string.Format(Utilities.MessageConst.MSG_COMM_149));
                        return result;
                    }
                }
                // 採番分類マスタを検索する
                List<SAIBAN_BUNRUI> saibanbunruiResult = da.GetSaibanBunrui3(saibanSyurui, burui1, burui2, burui3, true);
                if (saibanbunruiResult.Count > 0)
                {
                    // 採番分類テーブルを更新する
                    updSaibanbunruiResult = da.UpdSaibanBunrui3(saibanSyurui, atoBurui3, burui1, burui2, burui3, userId);
                    if (updSaibanbunruiResult == 0)
                    {
                        // 失敗の場合
                        da.Close();
                        scope.Dispose();
                        result.Add(string.Empty);
                        result.Add(string.Format(Utilities.MessageConst.MSG_COMM_141, "採番分類マスタ"));
                        return result;
                    }
                }
                else
                {
                    // 存在しない場合
                    da.Close();
                    scope.Dispose();
                    result.Add(string.Empty);
                    result.Add(string.Format(Utilities.MessageConst.MSG_COMM_149));
                    return result;
                }
                da.Close();
                scope.Commit();
                result.Add(updSaibanbunruiResult.ToString());
                result.Add(string.Empty);
            }
            return result;
        }

        /// <summary>
        /// 採番マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="atoBurui4">変更後の分類名</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<string> UpdateSaibanAndSaibanBunrui4(string saibanSyurui, string atoBurui4, string burui1, string burui2, string burui3, string burui4, string userId)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<string> result = new List<string>();
            using (NpgsqlTransaction scope = SqlManager.BeginTransaction)
            {
                int updSaibanResult = 0;
                int updSaibanbunruiResult = 0;
                List<SAIBAN> saibandata = da.GetSaiban4(saibanSyurui, burui1, burui2, burui3, burui4, false);
                int saibanCount = saibandata.Count;
                List<SAIBAN> saibanResult = new List<SAIBAN>();
                if (saibanCount > 0)
                    // 採番マスタを検索する
                    saibanResult = da.GetSaiban4(saibanSyurui, burui1, burui2, burui3, burui4, true);

                if (saibanCount > 0)
                {
                    if (saibanResult.Count > 0)
                    {
                        // 採番マスタを更新する
                        updSaibanResult = da.UpdateSaiban4(saibanSyurui, atoBurui4, burui1, burui2, burui3, burui4, userId);
                        if (updSaibanResult == 0)
                        {
                            // 失敗の場合
                            da.Close();
                            scope.Dispose();
                            result.Add(string.Empty);
                            result.Add(string.Format(Utilities.MessageConst.MSG_COMM_141, "採番マスタ"));
                            return result;
                        }
                    }
                    else
                    {
                        // 存在しない場合
                        da.Close();
                        scope.Dispose();
                        result.Add(string.Empty);
                        result.Add(string.Format(Utilities.MessageConst.MSG_COMM_149));
                        return result;
                    }
                }
                // 採番分類マスタを検索する
                List<SAIBAN_BUNRUI> saibanbunruiResult = da.GetSaibanBunrui4(saibanSyurui, burui1, burui2, burui3, burui4, true);
                if (saibanbunruiResult.Count > 0)
                {
                    // 採番分類テーブルを更新する
                    updSaibanbunruiResult = da.UpdSaibanBunrui4(saibanSyurui, atoBurui4, burui1, burui2, burui3, burui4, userId);
                    if (updSaibanbunruiResult == 0)
                    {
                        // 失敗の場合
                        da.Close();
                        scope.Dispose();
                        result.Add(string.Empty);
                        result.Add(string.Format(Utilities.MessageConst.MSG_COMM_141, "採番分類マスタ"));
                        return result;
                    }
                }
                else
                {
                    // 存在しない場合
                    da.Close();
                    scope.Dispose();
                    result.Add(string.Empty);
                    result.Add(string.Format(Utilities.MessageConst.MSG_COMM_149));
                    return result;
                }
                da.Close();
                scope.Commit();
                result.Add(updSaibanbunruiResult.ToString());
                result.Add(string.Empty);
            }
            return result;
        }

        /// <summary>
        /// 採番マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="atoBurui5">変更後の分類名</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <param name="burui5">採番用分類５</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<string> UpdateSaibanAndSaibanBunrui5(string saibanSyurui, string atoBurui5, string burui1, string burui2, string burui3, string burui4, string burui5, string userId)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<string> result = new List<string>();
            using (NpgsqlTransaction scope = SqlManager.BeginTransaction)
            {
                int updSaibanResult = 0;
                int updSaibanbunruiResult = 0;
                List<SAIBAN> saibandata = da.GetSaiban5(saibanSyurui, burui1, burui2, burui3, burui4, burui5, false);
                int saibanCount = saibandata.Count;
                List<SAIBAN> saibanResult = new List<SAIBAN>();
                if (saibanCount > 0)
                    // 採番マスタを検索する
                    saibanResult = da.GetSaiban5(saibanSyurui, burui1, burui2, burui3, burui4, burui5, true);

                if (saibanCount > 0)
                {
                    if (saibanResult.Count > 0)
                    {
                        // 採番マスタを更新する
                        updSaibanResult = da.UpdateSaiban5(saibanSyurui, atoBurui5, burui1, burui2, burui3, burui4, burui5, userId);
                        if (updSaibanResult == 0)
                        {
                            // 失敗の場合
                            da.Close();
                            scope.Dispose();
                            result.Add(string.Empty);
                            result.Add(string.Format(Utilities.MessageConst.MSG_COMM_141, "採番マスタ"));
                            return result;
                        }
                    }
                    else
                    {
                        // 存在しない場合
                        da.Close();
                        scope.Dispose();
                        result.Add(string.Empty);
                        result.Add(string.Format(Utilities.MessageConst.MSG_COMM_149));
                        return result;
                    }
                }
                // 採番分類マスタを検索する
                List<SAIBAN_BUNRUI> saibanbunruiResult = da.GetSaibanBunrui5(saibanSyurui, burui1, burui2, burui3, burui4, burui5, true);
                if (saibanbunruiResult.Count > 0)
                {
                    // 採番分類テーブルを更新する
                    updSaibanbunruiResult = da.UpdSaibanBunrui5(saibanSyurui, atoBurui5, burui1, burui2, burui3, burui4, burui5, userId);
                    if (updSaibanbunruiResult == 0)
                    {
                        // 失敗の場合
                        da.Close();
                        scope.Dispose();
                        result.Add(string.Empty);
                        result.Add(string.Format(Utilities.MessageConst.MSG_COMM_141, "採番分類マスタ"));
                        return result;
                    }
                }
                else
                {
                    // 存在しない場合
                    da.Close();
                    scope.Dispose();
                    result.Add(string.Empty);
                    result.Add(string.Format(Utilities.MessageConst.MSG_COMM_149));
                    return result;
                }

                da.Close();
                scope.Commit();
                result.Add(updSaibanbunruiResult.ToString());
                result.Add(string.Empty);
            }
            return result;
        }

        /// <summary>
        /// 採番マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<SAIBAN> GetSaiban1(string saibanSyurui, string burui1)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<SAIBAN> result;
            using (NpgsqlTransaction scope = SqlManager.BeginTransaction)
            {
                result = da.GetSaiban1(saibanSyurui, burui1, false);
                if (result.Count == 0)
                {
                    da.Close();
                    scope.Dispose();
                    return result;
                }
                da.Close();
                scope.Commit();
            }
            return result;
        }

        /// <summary>
        /// 採番の分類マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<SAIBAN_BUNRUI> GetSaibanBunrui1(string saibanSyurui, string burui1)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<SAIBAN_BUNRUI> result;
            using (NpgsqlTransaction scope = SqlManager.BeginTransaction)
            {
                result = da.GetSaibanBunrui1(saibanSyurui, burui1, false);
                if (result.Count == 0)
                {
                    da.Close();
                    scope.Dispose();
                    return result;
                }
                da.Close();
                scope.Commit();
            }
            return result;
        }

        /// <summary>
        /// 採番マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<SAIBAN> GetSaiban2(string saibanSyurui, string burui1, string burui2)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<SAIBAN> result;
            using (NpgsqlTransaction scope = SqlManager.BeginTransaction)
            {
                result = da.GetSaiban2(saibanSyurui, burui1, burui2, false);
                if (result.Count == 0)
                {
                    da.Close();
                    scope.Dispose();
                    return result;
                }
                da.Close();
                scope.Commit();
            }
            return result;
        }

        /// <summary>
        /// 採番の分類マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<SAIBAN_BUNRUI> GetSaibanBunrui2(string saibanSyurui, string burui1, string burui2)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<SAIBAN_BUNRUI> result;
            using (NpgsqlTransaction scope = SqlManager.BeginTransaction)
            {
                result = da.GetSaibanBunrui2(saibanSyurui, burui1, burui2, false);
                if (result.Count == 0)
                {
                    da.Close();
                    scope.Dispose();
                    return result;
                }
                da.Close();
                scope.Commit();
            }
            return result;
        }

        /// <summary>
        /// 採番マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<SAIBAN> GetSaiban3(string saibanSyurui, string burui1, string burui2, string burui3)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<SAIBAN> result;
            using (NpgsqlTransaction scope = SqlManager.BeginTransaction)
            {
                result = da.GetSaiban3(saibanSyurui, burui1, burui2, burui3, false);
                if (result.Count == 0)
                {
                    da.Close();
                    scope.Dispose();
                    return result;
                }
                da.Close();
                scope.Commit();
            }
            return result;
        }

        /// <summary>
        /// 採番の分類マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <returns>採番の分類マスタ情報</returns>
        public List<SAIBAN_BUNRUI> GetSaibanBunrui3(string saibanSyurui, string burui1, string burui2, string burui3)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<SAIBAN_BUNRUI> result;
            using (NpgsqlTransaction scope = SqlManager.BeginTransaction)
            {
                result = da.GetSaibanBunrui3(saibanSyurui, burui1, burui2, burui3, false);
                if (result.Count == 0)
                {
                    da.Close();
                    scope.Dispose();
                    return result;
                }
                da.Close();
                scope.Commit();
            }
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
        /// <returns>採番の分類マスタ情報</returns>
        public List<SAIBAN> GetSaiban4(string saibanSyurui, string burui1, string burui2, string burui3, string burui4)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<SAIBAN> result;
            using (NpgsqlTransaction scope = SqlManager.BeginTransaction)
            {
                result = da.GetSaiban4(saibanSyurui, burui1, burui2, burui3, burui4, false);
                if (result.Count == 0)
                {
                    da.Close();
                    scope.Dispose();
                    return result;
                }
                da.Close();
                scope.Commit();
            }
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
        /// <returns>採番の分類マスタ情報</returns>
        public List<SAIBAN_BUNRUI> GetSaibanBunrui4(string saibanSyurui, string burui1, string burui2, string burui3, string burui4)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<SAIBAN_BUNRUI> result;
            using (NpgsqlTransaction scope = SqlManager.BeginTransaction)
            {
                result = da.GetSaibanBunrui4(saibanSyurui, burui1, burui2, burui3, burui4, false);
                if (result.Count == 0)
                {
                    da.Close();
                    scope.Dispose();
                    return result;
                }
                da.Close();
                scope.Commit();
            }
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
        /// <returns>採番の分類マスタ情報</returns>
        public List<SAIBAN> GetSaiban5(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<SAIBAN> result;
            using (NpgsqlTransaction scope = SqlManager.BeginTransaction)
            {
                result = da.GetSaiban5(saibanSyurui, burui1, burui2, burui3, burui4, burui5, false);
                if (result.Count == 0)
                {
                    da.Close();
                    scope.Dispose();
                    return result;
                }
                da.Close();
                scope.Commit();
            }
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
        public List<SAIBAN_BUNRUI> GetSaibanBunrui5(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<SAIBAN_BUNRUI> result;
            using (NpgsqlTransaction scope = SqlManager.BeginTransaction)
            {
                result = da.GetSaibanBunrui5(saibanSyurui, burui1, burui2, burui3, burui4, burui5, false);
                if (result.Count == 0)
                {
                    da.Close();
                    scope.Dispose();
                    return result;
                }
                da.Close();
                scope.Commit();
            }
            return result;
        }

    }
}
