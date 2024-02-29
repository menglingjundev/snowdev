using Lixil.Snow.BizLogic;
using Lixil.Snow.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lixil.SNOW.Webservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class P030305Controller : ControllerBase
    {

        /// <summary>
        /// 配布履歴更新
        /// </summary>
        /// <param name="kaiSyuBi">回収日</param>
        /// <param name="gyosyaInfoList">業者情報リスト</param>
        /// <param name="userID">ユーザーID</param>
        /// <param name="PGM">機能ID</param>
        /// <returns>登録結果</returns>
        /// <remarks>20181015 修(大連) 新規作成</remarks>
        [HttpPost(Name = "UpdHaifuDetailList/{kaiSyuBi}/{gyosyaInfoList}/{userID}/{PGM}")]
        public int UpdHaifuDetailList(string kaiSyuBi,[FromBody] List<string> gyosyaInfoList, string userID, string PGM)
        {
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            var result = new P030305_BizLogic().UpdHaifuDetailList(kaiSyuBi, gyosyaInfoList, userID, PGM);

            return result;
        }

    }
}
