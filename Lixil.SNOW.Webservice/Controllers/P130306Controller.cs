using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Lixil.SNOW.Webservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class P130306Controller : ControllerBase
    {
        ///// <summary>
        ///// 採番分類マスタ
        ///// </summary>
        ///// <param name="saibanSyurui">採番の種類</param>
        ///// <param name="burui1">採番用分類１</param>
        ///// <param name="burui2">採番用分類２</param>
        ///// <param name="burui3">採番用分類３</param>
        ///// <param name="burui4">採番用分類４</param>
        ///// <param name="burui5">採番用分類５</param>
        ///// <param name="maeMoji">前部文字列</param>
        ///// <param name="kijunbiFlg">基準日要否</param>
        ///// <param name="sqlLength">連番桁数</param>
        ///// <param name="sqlStart">連番範囲(開始)</param>
        ///// <param name="sqlEnd">連番範囲(終了)</param>
        ///// <param name="overFlg">終了値超えの処理</param>
        ///// <param name="deleteFlg">削除フラグ</param> 
        ///// <param name="userId">ユーザーID</param>
        ///// <returns>処理結果</returns>
        ///// <remarks>20231211 孟(大連) 新規作成</remarks>
        //[HttpPost(Name = "UpdSaibanBunrui2/{saibanSyurui}/{burui1}/{burui2}/{burui3}/{burui4}/{burui5}/{maeMoji}/{kijunbiFlg}/{sqlLength}/{sqlStart}/{sqlEnd}/{overFlg}/{deleteFlg}/{userId}")]
        //public int UpdSaibanBunrui(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5, string maeMoji, string kijunbiFlg, int sqlLength, long sqlStart, long sqlEnd, string overFlg, string deleteFlg, string userId)
        //{
        //    int result = new P130304_BizLogic().UpdSaibanBunrui(saibanSyurui, burui1, burui2, burui3, burui4, burui5, maeMoji, kijunbiFlg, sqlLength, sqlStart, sqlEnd, overFlg, deleteFlg, userId);

        //    return result;
        //}

        ///// <summary>
        ///// 採番マスタのデータの取得
        ///// </summary>
        ///// <param name="saibanSyurui">採番の種類</param>
        ///// <param name="burui1">採番用分類１</param>
        ///// <param name="isLock">ロック用</param>
        ///// <returns>採番マスタ情報</returns>
        //[HttpGet(Name = "GetSaiban1/{saibanSyurui}/{burui1}/{isLock}")]
        //public List<SAIBAN> GetSaiban1(string saibanSyurui, string burui1, bool isLock = false)
        //{
        //    List<SAIBAN> result = new P130306_BizLogic().GetSaiban1(saibanSyurui, burui1, isLock);

        //    return result;
        //}

        ///// <summary>
        ///// 採番の分類マスタのデータの取得
        ///// </summary>
        ///// <param name="saibanSyurui">採番の種類</param>
        ///// <param name="burui1">採番用分類１</param>
        ///// <param name="isLock">ロック用</param>
        ///// <returns>採番の分類マスタ情報</returns>
        //[HttpGet(Name = "GetSaibanBunrui1/{saibanSyurui}/{burui1}/{isLock}")]

        //public List<SAIBAN_BUNRUI> GetSaibanBunrui1(string saibanSyurui, string burui1, bool isLock)
        //{
        //    List<SAIBAN_BUNRUI> result = new P130306_BizLogic().GetSaibanBunrui1(saibanSyurui, burui1, isLock);

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
        //[HttpGet(Name = "GetSaiban2/{saibanSyurui}/{burui1}/{burui2}/{isLock}")]

        //public List<SAIBAN> GetSaiban2(string saibanSyurui, string burui1, string burui2, bool isLock)
        //{
        //    List<SAIBAN> result = new P130306_BizLogic().GetSaiban2(saibanSyurui, burui1, burui2, isLock);

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
        //[HttpGet(Name = "GetSaibanBunrui2/{saibanSyurui}/{burui1}/{burui2}/{isLock}")]
        //public List<SAIBAN_BUNRUI> GetSaibanBunrui2(string saibanSyurui, string burui1, string burui2, bool isLock)
        //{
        //    List<SAIBAN_BUNRUI> result = new P130306_BizLogic().GetSaibanBunrui2(saibanSyurui, burui1, burui2, isLock);

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
        //[HttpGet(Name = "GetSaiban3/{saibanSyurui}/{burui1}/{burui2}/{burui3}/{isLock}")]
        //public List<SAIBAN> GetSaiban3(string saibanSyurui, string burui1, string burui2, string burui3, bool isLock)
        //{
        //    List<SAIBAN> result = new P130306_BizLogic().GetSaiban3(saibanSyurui, burui1, burui2, burui3, isLock);

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
        //[HttpGet(Name = "GetSaibanBunrui3/{saibanSyurui}/{burui1}/{burui2}/{burui3}/{isLock}")]
        //public List<SAIBAN_BUNRUI> GetSaibanBunrui3(string saibanSyurui, string burui1, string burui2, string burui3, bool isLock)
        //{
        //    List<SAIBAN_BUNRUI> result = new P130306_BizLogic().GetSaibanBunrui3(saibanSyurui, burui1, burui2, burui3, isLock);

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
        //[HttpGet(Name = "GetSaiban4/{saibanSyurui}/{burui1}/{burui2}/{burui3}/{burui4}/{isLock}")]
        //public List<SAIBAN> GetSaiban4(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, bool isLock)
        //{
        //    List<SAIBAN> result = new P130306_BizLogic().GetSaiban4(saibanSyurui, burui1, burui2, burui3, burui4, isLock);

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
        //[HttpGet(Name = "GetSaibanBunrui4/{saibanSyurui}/{burui1}/{burui2}/{burui3}/{burui4}/{isLock}")]
        //public List<SAIBAN_BUNRUI> GetSaibanBunrui4(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, bool isLock)
        //{
        //    List<SAIBAN_BUNRUI> result = new P130306_BizLogic().GetSaibanBunrui4(saibanSyurui, burui1, burui2, burui3, burui4, isLock);

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
        //[HttpGet(Name = "GetSaiban5/{saibanSyurui}/{burui1}/{burui2}/{burui3}/{burui4}/{burui5}/{isLock}")]

        //public List<SAIBAN> GetSaiban5(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5, bool isLock)
        //{
        //    List<SAIBAN> result = new P130306_BizLogic().GetSaiban5(saibanSyurui, burui1, burui2, burui3, burui4, burui5, isLock);

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
        //[HttpGet(Name = "GetSaibanBunrui5/{saibanSyurui}/{burui1}/{burui2}/{burui3}/{burui4}/{burui5}/{isLock}")]

        //public List<SAIBAN_BUNRUI> GetSaibanBunrui5(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5, bool isLock)
        //{
        //    List<SAIBAN_BUNRUI> result = new P130306_BizLogic().GetSaibanBunrui5(saibanSyurui, burui1, burui2, burui3, burui4, burui5, isLock);

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
        [HttpPost(Name = "UpdSaibanBunrui1/{saibanSyurui}/{atoBurui1}/{burui1}/{userId}")]
        public int UpdSaibanBunrui1(string saibanSyurui, string atoBurui1, string burui1, string userId)
        {
            int result = new P130306_BizLogic().UpdSaibanBunrui1(saibanSyurui, atoBurui1, burui1, userId);

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
        [HttpPost(Name = "UpdateSaiban1/{saibanSyurui}/{atoBurui1}/{burui1}/{userId}")]
        public int UpdateSaiban1(string saibanSyurui, string atoBurui1, string burui1, string userId)
        {
            int result = new P130306_BizLogic().UpdateSaiban1(saibanSyurui, atoBurui1, burui1, userId);

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
        [HttpPost(Name = "UpdSaibanBunrui2/{saibanSyurui}/{atoBurui1}/{burui1}/{userId}")]
        public int UpdSaibanBunrui2(string saibanSyurui, string atoBurui1, string burui1, string burui2, string userId)
        {
            int result = new P130306_BizLogic().UpdSaibanBunrui2(saibanSyurui, atoBurui1, burui1, burui2, userId);

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
        [HttpPost(Name = "UpdateSaiban2/{saibanSyurui}/{atoBurui2}/{burui1}/{burui2}/{userId}")]
        public int UpdateSaiban2(string saibanSyurui, string atoBurui2, string burui1, string burui2, string userId)
        {
            int result = new P130306_BizLogic().UpdateSaiban2(saibanSyurui, atoBurui2, burui1, burui2, userId);

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
        [HttpPost(Name = "UpdateSaiban2/{saibanSyurui}/{atoBurui3}/{burui1}/{burui2}/{burui3}/{userId}")]
        public int UpdSaibanBunrui3(string saibanSyurui, string atoBurui3, string burui1, string burui2, string burui3, string userId)
        {
            int result = new P130306_BizLogic().UpdSaibanBunrui3(saibanSyurui, atoBurui3, burui1, burui2, burui3, userId);

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
        [HttpPost(Name = "UpdateSaiban3/{saibanSyurui}/{atoBurui3}/{burui1}/{burui2}/{burui3}/{userId}")]
        public int UpdateSaiban3(string saibanSyurui, string atoBurui3, string burui1, string burui2, string burui3, string userId)
        {
            int result = new P130306_BizLogic().UpdateSaiban3(saibanSyurui, atoBurui3, burui1, burui2, burui3, userId);

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
        [HttpPost(Name = "UpdSaibanBunrui4/{saibanSyurui}/{atoBurui4}/{burui1}/{burui2}/{burui3}/{userId}")]
        public int UpdSaibanBunrui4(string saibanSyurui, string atoBurui4, string burui1, string burui2, string burui3, string burui4, string userId)
        {
            int result = new P130306_BizLogic().UpdSaibanBunrui4(saibanSyurui, atoBurui4, burui1, burui2, burui3, burui4, userId);

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
        [HttpPost(Name = "UpdateSaiban4/{saibanSyurui}/{atoBurui4}/{burui1}/{burui2}/{burui3}/{burui4}/{userId}")]
        public int UpdateSaiban4(string saibanSyurui, string atoBurui4, string burui1, string burui2, string burui3, string burui4, string userId)
        {
            int result = new P130306_BizLogic().UpdateSaiban4(saibanSyurui, atoBurui4, burui1, burui2, burui3, burui4, userId);

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
        [HttpPost(Name = "UpdateSaiban4/{saibanSyurui}/{atoBurui5}/{burui1}/{burui2}/{burui3}/{burui4}/{burui5}/{userId}")]
        public int UpdSaibanBunrui5(string saibanSyurui, string atoBurui5, string burui1, string burui2, string burui3, string burui4, string burui5, string userId)
        {
            int result = new P130306_BizLogic().UpdSaibanBunrui5(saibanSyurui, atoBurui5, burui1, burui2, burui3, burui4, burui5, userId);

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
        [HttpPost(Name = "UpdateSaiban5/{saibanSyurui}/{atoBurui5}/{burui1}/{burui2}/{burui3}/{burui4}/{burui5}/{userId}")]
        public int UpdateSaiban5(string saibanSyurui, string atoBurui5, string burui1, string burui2, string burui3, string burui4, string burui5, string userId)
        {

            int result = new P130306_BizLogic().UpdateSaiban5(saibanSyurui, atoBurui5, burui1, burui2, burui3, burui4, burui5, userId);

            return result;
        }

        /// <summary>
        /// 採番の分類マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="atoBurui1">変更後の分類名</param>
        /// <returns>採番の分類マスタ情報</returns>
        [HttpGet(Name = "GetUpdSaibanBunrui1/{saibanSyurui}/{atoBurui1}")]
        public List<SAIBAN_BUNRUI> GetUpdSaibanBunrui1(string saibanSyurui, string atoBurui1)
        {
            List<SAIBAN_BUNRUI> result = new P130306_BizLogic().GetUpdSaibanBunrui1(saibanSyurui, atoBurui1);

            return result;
        }

        /// <summary>
        /// 採番の分類マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="atoBurui2">変更後の分類名</param>
        /// <returns>採番の分類マスタ情報</returns>
        [HttpGet(Name = "GetUpdSaibanBunrui2/{saibanSyurui}/{burui1}/{atoBurui2}")]
        public List<SAIBAN_BUNRUI> GetUpdSaibanBunrui2(string saibanSyurui, string burui1, string atoBurui2)
        {
            List<SAIBAN_BUNRUI> result = new P130306_BizLogic().GetUpdSaibanBunrui2(saibanSyurui, burui1, atoBurui2);

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
        [HttpGet(Name = "GetUpdSaibanBunrui3/{saibanSyurui}/{burui1}/{burui2}/{atoBurui3}")]
        public List<SAIBAN_BUNRUI> GetUpdSaibanBunrui3(string saibanSyurui, string burui1, string burui2, string atoBurui3)
        {
            List<SAIBAN_BUNRUI> result = new P130306_BizLogic().GetUpdSaibanBunrui3(saibanSyurui, burui1, burui2, atoBurui3);

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
        [HttpGet(Name = "GetUpdSaibanBunrui4/{saibanSyurui}/{burui1}/{burui2}/{burui3}/{atoBurui4}")]
        public List<SAIBAN_BUNRUI> GetUpdSaibanBunrui4(string saibanSyurui, string burui1, string burui2, string burui3, string atoBurui4)
        {
            List<SAIBAN_BUNRUI> result = new P130306_BizLogic().GetUpdSaibanBunrui4(saibanSyurui, burui1, burui2, burui3, atoBurui4);

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
        [HttpGet(Name = "GetUpdSaibanBunrui5/{saibanSyurui}/{burui1}/{burui2}/{burui3}/{burui4}/{atoBurui5}")]
        public List<SAIBAN_BUNRUI> GetUpdSaibanBunrui5(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string atoBurui5)
        {
            List<SAIBAN_BUNRUI> result = new P130306_BizLogic().GetUpdSaibanBunrui5(saibanSyurui, burui1, burui2, burui3, burui4, atoBurui5);

            return result;
        }

        /// <summary>
        /// 採番マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="atoBurui1">変更後の分類名</param>
        /// <param name="burui1">採番用分類１</param>
        /// <returns>採番の分類マスタ情報</returns>
        [HttpPost(Name = "UpdateSaibanAndSaibanBunrui1/{saibanSyurui}/{atoBurui1}/{burui1}/{userId}")]
        public List<string> UpdateSaibanAndSaibanBunrui1(string saibanSyurui, string atoBurui1, string burui1, string userId)
        {
            List<string> result = new P130306_BizLogic().UpdateSaibanAndSaibanBunrui1(saibanSyurui, atoBurui1, burui1, userId);

            return result;
        }
        [HttpPost(Name = "UpdateSaibanAndSaibanBunrui2/{saibanSyurui}/{atoBurui2}/{burui1}/{burui2}/{userId}")]
        public List<string> UpdateSaibanAndSaibanBunrui2(string saibanSyurui, string atoBurui2, string burui1, string burui2, string userId)

        {
            List<string> result = new P130306_BizLogic().UpdateSaibanAndSaibanBunrui2(saibanSyurui, atoBurui2, burui1, burui2, userId);

            return result;
        }
        [HttpPost(Name = "UpdateSaibanAndSaibanBunrui3/{saibanSyurui}/{atoBurui3}/{burui1}/{burui2}/{burui3}/{userId}")]
        public List<string> UpdateSaibanAndSaibanBunrui3(string saibanSyurui, string atoBurui3, string burui1, string burui2, string burui3, string userId)
        {
            List<string> result = new P130306_BizLogic().UpdateSaibanAndSaibanBunrui3(saibanSyurui, atoBurui3, burui1, burui2, burui3, userId);

            return result;
        }
        [HttpPost(Name = "UpdateSaibanAndSaibanBunrui4/{saibanSyurui}/{atoBurui4}/{burui1}/{burui2}/{burui3}/{burui4}/{userId}")]
        public List<string> UpdateSaibanAndSaibanBunrui4(string saibanSyurui, string atoBurui4, string burui1, string burui2, string burui3, string burui4, string userId)
        {
            List<string> result = new P130306_BizLogic().UpdateSaibanAndSaibanBunrui4(saibanSyurui, atoBurui4, burui1, burui2, burui3, burui4, userId);

            return result;
        }
        [HttpPost(Name = "UpdateSaibanAndSaibanBunrui5/{saibanSyurui}/{atoBurui5}/{burui1}/{burui2}/{burui3}/{burui4}/{burui5}/{userId}")]
        public List<string> UpdateSaibanAndSaibanBunrui5(string saibanSyurui, string atoBurui5, string burui1, string burui2, string burui3, string burui4, string burui5, string userId)
        {
            List<string> result = new P130306_BizLogic().UpdateSaibanAndSaibanBunrui5(saibanSyurui, atoBurui5, burui1, burui2, burui3, burui4, burui5, userId);

            return result;
        }
    }
}
