using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Lixil.SNOW.Webservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class P130302Controller : ControllerBase
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
        /// <param name="userId">ユーザーID</param>
        /// <returns>影響行数</returns>
        /// <remarks>20231211 孟(大連) 新規作成</remarks>
        [HttpPost(Name = "InsSaibanBunrui/{saibanSyurui}/{burui1}/{burui2}/{burui3}/{burui4}/{burui5}/{maeMoji}/{kijunbiFlg}/{sqlLength}/{sqlStart}/{sqlEnd}/{overFlg}/{userId}")]
        public int InsSaibanBunrui(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5, string maeMoji, string kijunbiFlg, int sqlLength, long sqlStart, long sqlEnd, string overFlg, string userId)
        {
            int result = new P130302_BizLogic().InsSaibanBunrui(saibanSyurui, burui1, burui2, burui3, burui4, burui5, maeMoji, kijunbiFlg, sqlLength, sqlStart, sqlEnd, overFlg, userId);

            return result;
        }
    }
}
