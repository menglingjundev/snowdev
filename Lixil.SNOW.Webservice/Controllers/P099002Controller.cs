using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Lixil.SNOW.Webservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class P099002Controller : ControllerBase
    {
        /// <summary>
        /// 業者配布履歴・ヘッダを検索して、表示用データを取得する
        /// </summary>
        /// <param name="txtTxtWcEcnNo">変更通知番号</param>
        /// <returns>表示用データ</returns>
        [HttpGet(Name = "SelHaifuHeaderByWcEcnNo/{txtTxtWcEcnNo}")]
        public List<HAIFU_HEADER> SelHaifuHeaderByWcEcnNo(string txtTxtWcEcnNo)
        {
            var result = new P099002_BizLogic().SelHaifuHeaderByWcEcnNo(txtTxtWcEcnNo);

            return result;
        }

        /// <summary>
        /// 業者配布履歴・ヘッダから業者配布履歴・ヘッダ(削除済)を登録する
        /// </summary>
        /// <param name="txtTxtWcEcnNo">変更通知番号</param>
        /// <param name="userID">ユーザーID</param>
        /// <param name="PGM">機能ID</param>    
        /// <returns>表示用データ</returns>
        [HttpPost(Name = "InsertDeleteHHByWcEcnNo/{txtTxtWcEcnNo}/{userID}/{PGM}")]
        public int InsertDeleteHHByWcEcnNo(string txtTxtWcEcnNo, string userID, string PGM)
        {
            var result = new P099002_BizLogic().InsertDeleteHHByWcEcnNo(txtTxtWcEcnNo, userID, PGM);

            return result;
        }

    }
}
