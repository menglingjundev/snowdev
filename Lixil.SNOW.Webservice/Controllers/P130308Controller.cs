using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Lixil.SNOW.Webservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class P130308Controller : ControllerBase
    {
        /// <summary>
        /// 採番の種類マスタを登録
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="saibanBunruiFlg1">採番用分類１要否</param>
        /// <param name="saibanBunruiFlg2">採番用分類２要否</param>
        /// <param name="saibanBunruiFlg3">採番用分類３要否</param>
        /// <param name="saibanBunruiFlg4">採番用分類４要否</param>
        /// <param name="saibanBunruiFlg5">採番用分類５要否</param>
        /// <param name="saibanRirekiFlg">採番履歴要否</param>
        /// <param name="saibanGamenFlg">採番画面可否</param>   
        /// <param name="userId">ユーザーID</param>
        /// <returns>影響行数</returns>
        [HttpPost(Name = "InsSaibanSyurui/{saibanSyurui}/{saibanBunruiFlg1}/{saibanBunruiFlg2}/{saibanBunruiFlg3}/{saibanBunruiFlg4}/{saibanBunruiFlg5}/{saibanRirekiFlg}/{saibanGamenFlg}/{userId}")]
        public int InsSaibanSyurui(string saibanSyurui, string saibanBunruiFlg1, string saibanBunruiFlg2, string saibanBunruiFlg3, string saibanBunruiFlg4, string saibanBunruiFlg5, string saibanRirekiFlg, string saibanGamenFlg, string userId)
        {
            int result = new P130308_BizLogic().InsSaibanSyurui(saibanSyurui, saibanBunruiFlg1, saibanBunruiFlg2, saibanBunruiFlg3, saibanBunruiFlg4, saibanBunruiFlg5, saibanRirekiFlg, saibanGamenFlg, userId);

            return result;
        }
    }
}
