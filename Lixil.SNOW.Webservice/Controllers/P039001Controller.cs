using Lixil.Snow.BizLogic;
using Lixil.Snow.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lixil.SNOW.Webservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class P039001Controller : ControllerBase
    {
        /// <summary>
        /// 業者配布履歴・明細を検索して、件数を取得する
        /// </summary>
        /// <param name="txtGyosyaID">業者ID</param>
        /// <returns>取得件数</returns>
        /// <remarks>20190729 王(大連) 新規作成</remarks>
        [HttpGet(Name = "CntHaifudetailByID/{txtGyosyaID}")]
        public int CntHaifudetailByID(string txtGyosyaID)
        {
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            var result = new P039001_BizLogic().CntHaifudetailByID(txtGyosyaID);
            return result;
        }

        /// <summary>
        /// 業者配布履歴（最新）を検索して、件数を取得する
        /// </summary>
        /// <param name="txtGyosyaID">業者ID</param>
        /// <returns>取得件数</returns>
        /// <remarks>20190729 王(大連) 新規作成</remarks>
        [HttpGet(Name = "CntHaifudetailLastByID/{txtGyosyaID}")]
        public int CntHaifudetailLastByID(string txtGyosyaID)
        {
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            var result = new P039001_BizLogic().CntHaifudetailLastByID(txtGyosyaID);
            return result;

        }

        /// <summary>
        /// 業者配布履歴・明細と業者配布履歴（最新）を更新する
        /// </summary>
        /// <param name="TxtGyousyaMaeID">変更前業者ID</param>
        /// <param name="TxtGyousyaAtoID">変更後業者ID</param>
        /// <param name="TxtGyousyaAtoMei">変更後業者名</param>
        /// <param name="userID">ユーザーID</param>
        /// <param name="PGM">機能ID</param>
        /// <returns>処理結果</returns>
        /// <remarks>20181015 陳(大連) 新規作成</remarks>
        [HttpPost(Name = "UpdHaifuDetailDataByID/{TxtGyousyaMaeID}/{TxtGyousyaAtoID}/{TxtGyousyaAtoMei}/{userID}/{PGM}")]
        public int UpdHaifuDetailDataByID(string TxtGyousyaMaeID, string TxtGyousyaAtoID, string TxtGyousyaAtoMei, string userID, string PGM)
        {
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            var result = new P039001_BizLogic().UpdHaifuDetailDataByID(TxtGyousyaMaeID, TxtGyousyaAtoID, TxtGyousyaAtoMei, userID, PGM);

            return result;
        }
    }
}
