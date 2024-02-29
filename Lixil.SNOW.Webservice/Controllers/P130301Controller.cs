using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Lixil.SNOW.Webservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class P130301Controller : ControllerBase
    {
        /// <summary>
        /// 採番用分類１の取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <returns>採番用分類１情報</returns>
        /// <remarks>20231205 孟(大連) 新規作成</remarks>
        [HttpGet(Name = "GetDistinctBunrui1/{saibanSyurui}")]
        public List<string> GetDistinctBunrui1(string saibanSyurui)
        {
            List<string> saibanList = new P130301_BizLogic().GetDistinctBunrui1(saibanSyurui);

            return saibanList;
        }
        /// <summary>
        /// 採番用分類２の取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <returns>採番用分類２情報</returns>
        /// <remarks>20231205 孟(大連) 新規作成</remarks>
        [HttpGet(Name = "GetDistinctBunrui2/{saibanSyurui}/{burui1}")]
        public List<string> GetDistinctBunrui2(string saibanSyurui, string burui1)
        {
            List<string> saibanList = new P130301_BizLogic().GetDistinctBunrui2(saibanSyurui, burui1);

            return saibanList;
        }
        /// <summary>
        /// 採番用分類３の取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <returns>採番用分類３情報</returns>
        /// <remarks>20231205 孟(大連) 新規作成</remarks>
        [HttpGet(Name = "GetDistinctBunrui3/{saibanSyurui}/{burui1}/{burui2}")]
        public List<string> GetDistinctBunrui3(string saibanSyurui, string burui1, string burui2)
        {
            List<string> saibanList = new P130301_BizLogic().GetDistinctBunrui3(saibanSyurui, burui1, burui2);

            return saibanList;
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
        [HttpGet(Name = "GetDistinctBunrui4/{saibanSyurui}/{burui1}/{burui2}/{burui3}")]
        public List<string> GetDistinctBunrui4(string saibanSyurui, string burui1, string burui2, string burui3)
        {
            List<string> saibanList = new P130301_BizLogic().GetDistinctBunrui4(saibanSyurui, burui1, burui2, burui3);

            return saibanList;
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
        [HttpGet(Name = "GetDistinctBunrui5/{saibanSyurui}/{burui1}/{burui2}/{burui3}/{burui4}")]
        public List<string> GetDistinctBunrui5(string saibanSyurui, string burui1, string burui2, string burui3, string burui4)
        {
            List<string> saibanList = new P130301_BizLogic().GetDistinctBunrui5(saibanSyurui, burui1, burui2, burui3, burui4);

            return saibanList;
        }

        /// <summary>
        /// 採番の種類の取得
        /// </summary>
        /// <returns>採番種類マスタ情報</returns>
        /// <remarks>20231205 孟(大連) 新規作成</remarks>
        [HttpGet(Name = "GetDistinctSyurui")]
        public List<string> GetDistinctSyurui()
        {
            List<string> saibanList = new P130301_BizLogic().GetDistinctSyurui();

            return saibanList;
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
        [HttpGet(Name = "GetSaibanBunruiAndSaiban/{saibanSyurui}/{burui1}/{burui2}/{burui3}/{burui4}/{burui5}")]
        public List<SAIBAN_BUNRUI> GetSaibanBunruiAndSaiban(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5)
        {
            List<SAIBAN_BUNRUI> saibanList = new P130301_BizLogic().GetSaibanBunruiAndSaiban(saibanSyurui, burui1, burui2, burui3, burui4, burui5);

            return saibanList;
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
        [HttpGet(Name = "GetBunrui/{saibanSyurui}/{burui1}/{burui2}/{burui3}/{burui4}/{burui5}")]
        public List<SAIBAN_BUNRUI> GetBunrui(string? saibanSyurui, string? burui1, string? burui2, string? burui3, string? burui4, string? burui5)
        {
            List<SAIBAN_BUNRUI> saibanList = new P130301_BizLogic().GetBunrui(saibanSyurui, burui1, burui2, burui3, burui4, burui5);

            return saibanList;
        }

        /// <summary>
        /// 採番の種類マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <returns>採番の種類マスタ情報</returns>
        /// <remarks>20231205 孟(大連) 新規作成</remarks>
        [HttpGet(Name = "GetSaiBanSyuruiAll/{saibanSyurui}")]
        public List<SAIBANSYURUI> GetSaiBanSyuruiAll(string saibanSyurui)
        {
            List<SAIBANSYURUI> saibanList = new P130301_BizLogic().GetSaiBanSyuruiAll(saibanSyurui);

            return saibanList;
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
        [HttpGet(Name = "GetSaibanAll/{saibanSyurui}/{burui1}/{burui2}/{burui3}/{burui4}/{burui5}")]
        public List<SAIBAN> GetSaibanAll(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5)
        {
            List<SAIBAN> saibanList = new P130301_BizLogic().GetSaibanAll(saibanSyurui, burui1, burui2, burui3, burui4, burui5);

            return saibanList;
        }
    }
}
