using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lixil.SNOW.Webservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class P030304Controller : ControllerBase
    {
        /// <summary>
        /// 配布履歴更新
        /// </summary>
        /// <param name="kaiSyuBi">回収日</param>
        /// <param name="wcEcnNo">変更通知番号</param>
        /// <param name="wcObjNo">図面・ドキュメントの番号</param>
        /// <param name="gyosyaID">業者ID</param>
        /// <param name="userID">ユーザーID</param>
        /// <param name="PGM">機能ID</param>
        /// <returns>処理結果</returns>
        /// <remarks>20181015 修(大連) 新規作成</remarks>
        [HttpPost(Name = "UpdHaifuDetailDate/{kaiSyuBi}/{wcEcnNo}/{wcObjNo}/{gyosyaID}/{userID}/{PGM}")]
        public int UpdHaifuDetailDate(string kaiSyuBi, string wcEcnNo, string wcObjNo, string gyosyaID, string userID, string PGM)
        {
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            var result = new P030304_BizLogic().UpdHaifuDetailDate(kaiSyuBi, wcEcnNo, wcObjNo, gyosyaID, userID, PGM);

            return result;
        }


    }
}
