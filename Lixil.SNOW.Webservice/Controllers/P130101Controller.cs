using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Lixil.SNOW.Webservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class P130101Controller : ControllerBase
    {
        /// <summary>
        /// 採番用分類１の取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <returns>採番用分類１情報</returns>
        /// <remarks>20231205 孟(大連) 新規作成</remarks>
        [HttpGet(Name = "GetBurui1/{saibanSyurui}")]
        public List<string> GetBurui1([FromQuery] string saibanSyurui)
        {
            List<string> saibanList = new P130101_BizLogic().GetBurui1(saibanSyurui);

            return saibanList;
        }

        /// <summary>
        /// 採番用分類２の取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <returns>採番用分類２情報</returns>
        /// <remarks>20231205 孟(大連) 新規作成</remarks>
        [HttpGet(Name = "GetBurui2/{saibanSyurui}/{burui1}")]

        public List<string> GetBurui2([FromQuery] string saibanSyurui, [FromQuery] string burui1)
        {
            List<string> saibanList = new P130101_BizLogic().GetBurui2(saibanSyurui, burui1);

            return saibanList;
        }

        /// <summary>
        ///採番用分類３の取得
        ///</summary>
        ///<param name="saibanSyurui">採番の種類</param>
        ///<param name="burui1">採番用分類１</param>
        ///<param name="burui2">採番用分類２</param>
        ///<returns>採番用分類３情報</returns>
        ///<remarks>20231205 孟(大連) 新規作成</remarks>
        [HttpGet(Name = "GetBurui3/{saibanSyurui}/{burui1}/{burui2}")]
        public List<string> GetBurui3([FromQuery] string saibanSyurui, [FromQuery] string burui1, [FromQuery] string burui2)
        {
            List<string> saibanList = new P130101_BizLogic().GetBurui3(saibanSyurui, burui1, burui2);

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
        [HttpGet(Name = "GetBurui4/{saibanSyurui}/{burui1}/{burui2}/{burui3}")]
        public List<string> GetBurui4([FromQuery] string saibanSyurui, [FromQuery] string burui1, [FromQuery] string burui2, [FromQuery] string burui3)
        {
            List<string> saibanList = new P130101_BizLogic().GetBurui4(saibanSyurui, burui1, burui2, burui3);

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
        [HttpGet(Name = "GetBurui5/{saibanSyurui}/{burui1}/{burui2}/{burui3}/{burui4}")]
        public List<string> GetBurui5([FromQuery] string saibanSyurui, [FromQuery] string burui1, [FromQuery] string burui2, [FromQuery] string burui3, [FromQuery] string burui4)
        {
            List<string> saibanList = new P130101_BizLogic().GetBurui5(saibanSyurui, burui1, burui2, burui3, burui4);

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
        [HttpGet(Name = "GetSaibanBunrui1/{saibanSyurui}/{burui1}/{burui2}/{burui3}/{burui4}/{burui5}")]
        public List<SAIBAN_BUNRUI> GetSaibanBunrui1(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5)
        {
            List<SAIBAN_BUNRUI> saibanList = new P130101_BizLogic().GetSaibanBunrui(saibanSyurui, burui1, burui2, burui3, burui4, burui5);

            return saibanList;
        }

        /// <summary>
        /// 採番の種類の取得
        /// </summary>
        /// <returns>採番種類マスタ情報</returns>
        [HttpGet(Name = "GetSaibanSyurui")]
        public List<string> GetSaibanSyurui()
        {
            List<string> saibanList = new P130101_BizLogic().GetSaibanSyurui();

            return saibanList;
        }

    }
}
