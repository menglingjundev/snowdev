using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Lixil.SNOW.Webservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class P130304Controller : ControllerBase
    {
        /// <summary>
        /// 採番分類マスタ
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <param name="burui5">採番用分類５</param>
        /// <param name="maeMoji">前部文字列</param>
        /// <param name="kijunbiFlg">基準日要否</param>
        /// <param name="sqlLength">連番桁数</param>
        /// <param name="sqlStart">連番範囲(開始)</param>
        /// <param name="sqlEnd">連番範囲(終了)</param>
        /// <param name="overFlg">終了値超えの処理</param>
        /// <param name="deleteFlg">削除フラグ</param> 
        /// <param name="userId">ユーザーID</param>
        /// <returns>処理結果</returns>
        /// <remarks>20231211 孟(大連) 新規作成</remarks>
        [HttpPost(Name = "UpdSaibanBunrui1/{saibanSyurui}/{saibanList}/{userId}")]
        public int UpdSaibanBunrui(string saibanSyurui, List<SAIBAN_BUNRUI> saibanList, string userId)
        {
            int result = new P130304_BizLogic().UpdSaibanBunrui(saibanSyurui, saibanList, userId);

            return result;
        }
    }
}
