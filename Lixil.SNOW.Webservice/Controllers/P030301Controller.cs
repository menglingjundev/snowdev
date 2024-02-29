using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lixil.SNOW.Webservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class P030301Controller : ControllerBase
    {
        //TODO
        /// <summary>
        /// 変更通知番号の取得
        /// </summary>
        /// <param name="contestInfo">コンテキスト</param>
        /// <returns>業者配布履歴・ヘッダテーブル</returns>
        /// <remarks>20181015 修(大連) 新規作成</remarks>
     	[HttpGet(Name = "SelContestData1/{contestInfo}")]
        public List<HAIFU_HEADER> SelContestData1([FromBody] List<string> contestInfo)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<HAIFU_HEADER> result = new List<HAIFU_HEADER>();
            result = new P030301_BizLogic().SelContestData(contestInfo);
           
            return result;
        }

        /// <summary>
        /// 業者配布履歴の取得
        /// </summary>
        /// <param name="contestInfo">コンテキスト</param>
        /// <param name="wcEcnNo">変更通知番号</param>
        /// <param name="txtZuban">図番</param>
        /// <param name="txtFile">ファイル名</param>
        /// <param name="gyosyaID">業者ID</param>
        /// <param name="rdoStatus">配布区分</param>
        /// <param name="kensakuKensu">検索件数</param>
        /// <param name="haifumoto">配布元</param>
        /// <returns>業者配布履歴・ヘッダテーブル</returns>
        /// <remarks>20181015 修(大連) 新規作成</remarks>
      	[HttpGet(Name = "SelHaifuData/{contestInfo}/{wcEcnNo}/{txtZuban}/{txtFile}/{gyosyaID}/{RdoStatus}/{kensakuKensu}/{haifumoto}")]
        public List<HAIFU_HEADER> SelHaifuData([FromBody]List<string> contestInfo, string wcEcnNo, string txtZuban, string txtFile, string gyosyaID, bool RdoStatus, int kensakuKensu, string haifumoto)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<HAIFU_HEADER> result = new List<HAIFU_HEADER>();
            result = new P030301_BizLogic().SelHaifuData(contestInfo, wcEcnNo, txtZuban, txtFile, gyosyaID, RdoStatus, kensakuKensu, haifumoto);
           
            return result;
        }

        /// <summary>
        /// 業者配布履歴検索件数の取得
        /// </summary>
        /// <param name="contestInfo">コンテキスト</param>
        /// <param name="wcEcnNo">変更通知番号</param>
        /// <param name="txtZuban">図番</param>
        /// <param name="txtFile">ファイル名</param>
        /// <param name="gyosyaID">業者ID</param>
        /// <param name="haifumoto">配布元</param>
        /// <returns>業者配布履歴検索件数</returns>
        /// <remarks>20190718 修(大連) 新規作成</remarks>
       	[HttpGet(Name = "SelHaifuDataCnt/{contestInfo}/{wcEcnNo}/{txtZuban}/{txtFile}/{gyosyaID}/{haifumoto}")]
        public int SelHaifuDataCnt([FromBody] List<string> contestInfo, string wcEcnNo, string txtZuban, string txtFile, string gyosyaID, string haifumoto)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            var result = new P030301_BizLogic().SelHaifuDataCnt(contestInfo, wcEcnNo, txtZuban, txtFile, gyosyaID, haifumoto);

            return result;
        }
    }
}
