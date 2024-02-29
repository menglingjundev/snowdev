using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Lixil.SNOW.Webservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class P130102Controller : ControllerBase
    {
        /// <summary>
        /// 採番マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <param name="burui5">採番用分類５</param>
        /// <param name="maeMoji">前部文字列</param>
        /// <param name="isLock">ロック用</param>
        /// <returns>採番マスタ情報</returns>
        /// <remarks>20231208 孟(大連) 新規作成</remarks>
        [HttpGet(Name = "GetSaiban/{saibanSyurui}/{burui1}/{burui2}/{burui3}/{burui4}/{burui5}/{maeMoji}/{isLock}")]
        public List<SAIBAN> GetSaiban(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5, string maeMoji, bool isLock = false)
        {
            List<SAIBAN> saibanList = new P130102_BizLogic().GetSaiban(saibanSyurui, burui1, burui2, burui3, burui4, burui5, maeMoji, isLock);

            return saibanList;
        }

        /// <summary>
        /// 採番マスタのデータを登録
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <param name="burui5">採番用分類５</param>
        /// <param name="maeMoji">前部文字列</param>
        /// <param name="kijunbi">基準日</param>
        /// <param name="seqLast">最終番号</param>
        /// <returns>影響行数</returns>
        /// <param name="userID">ユーザーID</param>
        /// <param name="PGM">機能ID</param>
        /// <remarks>20231208 孟(大連) 新規作成</remarks>
        [HttpPost(Name = "InsertSaiban/{saibanSyurui}/{burui1}/{burui2}/{burui3}/{burui4}/{burui5}/{maeMoji}/{kijunbi}/{seqLast}/{userID}/{PGM}")]
        public int InsertSaiban(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5, string maeMoji, DateTime kijunbi, long seqLast, string userID, string PGM)
        {
            var result = new P130102_BizLogic().InsertSaiban(saibanSyurui, burui1, burui2, burui3, burui4, burui5, maeMoji, kijunbi, seqLast, userID, PGM);

            return result;
        }

        /// <summary>
        /// 採番マスタのデータを更新
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <param name="burui5">採番用分類５</param>
        /// <param name="maeMoji">前部文字列</param>
        /// <param name="kijunbi">基準日</param>
        /// <param name="seqLast">最終番号</param>
        /// <returns>影響行数</returns>
        /// <param name="userID">ユーザーID</param>
        /// <param name="PGM">機能ID</param>
        /// <remarks>20231208 孟(大連) 新規作成</remarks>
        [HttpPost(Name = "UpdateSaiban/{saibanSyurui}/{burui1}/{burui2}/{burui3}/{burui4}/{burui5}/{maeMoji}/{kijunbi}/{seqLast}/{userID}/{PGM}")]
        public int UpdateSaiban(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5, string maeMoji, DateTime kijunbi, long seqLast, string userID, string PGM)
        {
            var result = new P130102_BizLogic().UpdateSaiban(saibanSyurui, burui1, burui2, burui3, burui4, burui5, maeMoji, kijunbi, seqLast, userID, PGM);

            return result;
        }

        /// <summary>
        /// 採番種類の取得
        /// </summary>
        /// <param name="saibanSyurui">採番種類</param>
        /// <returns>採番種類マスタ情報</returns>
        /// <remarks>20231208 孟(大連) 新規作成</remarks>
        [HttpGet(Name = "GetSaiBanSyurui/{saibanSyurui}")]
        public List<SAIBANSYURUI> GetSaiBanSyurui(string saibanSyurui)
        {
            List<SAIBANSYURUI> saibanList = new P130102_BizLogic().GetSaiBanSyurui(saibanSyurui);

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
        /// <remarks>20231208 孟(大連) 新規作成</remarks>
        [HttpGet(Name = "GetSaibanBunrui2/{saibanSyurui}/{burui1}/{burui2}/{burui3}/{burui4}/{burui5}")]
        public List<SAIBAN_BUNRUI> GetSaibanBunrui2(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5)
        {
            List<SAIBAN_BUNRUI> saibanList = new P130102_BizLogic().GetSaibanBunrui(saibanSyurui, burui1, burui2, burui3, burui4, burui5);

            return saibanList;
        }
        /// <summary>
        /// 採番履歴マスタのデータを登録
        /// </summary>
        /// <param name="partNumber">品番</param>
        /// <param name="partName">品名</param>
        /// <param name="reason">新設理由</param>
        /// <param name="tenkai">今後の展開</param>
        /// <param name="syozoku">所属</param>
        /// <param name="sakuseiPerson">作成者</param>
        /// <returns>影響行数</returns>
        /// <param name="userID">ユーザーID</param>
        /// <param name="PGM">機能ID</param>
        /// <remarks>20231208 孟(大連) 新規作成</remarks>
        [HttpPost(Name = "InsertSaibanRireki/{partNumber}/{partName}/{reason}/{tenkai}/{syozoku}/{sakuseiPerson}/{PGM}")]
        public int InsertSaibanRireki(string partNumber, string partName, string reason, string tenkai, string syozoku, string sakuseiPerson, string userID, string PGM)
        {
            var result = new P130102_BizLogic().InsertSaibanRireki(partNumber, partName, reason, tenkai, syozoku, sakuseiPerson, userID, PGM);

            return result;
        }

        /// <summary>
        /// 採番処理
        /// </summary>
        /// <param name="saibanSyurui">採番種類</param>
        /// <param name="burui1">採番の種類1</param>
        /// <param name="burui2">採番の種類2</param>
        /// <param name="burui3">採番の種類3</param>
        /// <param name="burui4">採番の種類4</param>
        /// <param name="burui5">採番の種類5</param>
        /// <param name="kijunbi">基準日</param>
        /// <param name="saibanSuu">採番数</param>
        /// <param name="syozoku">所属</param>
        /// <param name="sakuseiPerson">作成者</param>
        /// <param name="partName">品名</param>
        /// <param name="reason">新設の理由</param>
        /// <param name="tenkai">今後の展開</param>
        /// <param name="userID">ユーザーID</param>
        /// <param name="PGM">機能ID</param>
        /// <returns>採番結果</returns>
        [HttpPost(Name = "Saiban/{saibanSyurui/{burui1}/{burui2}/{burui3}/{burui4}/{burui5}/{kijunbi}/{saibanSuu}/{syozoku}/{sakuseiPerson}/{partName}/{reason}/{tenkai}/{userID}/{PGM}")]
        public List<string> Saiban(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5, string? kijunbi, int saibanSuu, string? syozoku, string? sakuseiPerson, string? partName, string? reason, string? tenkai, string? userID, string? PGM)
        {
            var result = new P130102_BizLogic().Saiban(saibanSyurui, burui1, burui2, burui3, burui4, burui5, kijunbi, saibanSuu, syozoku, sakuseiPerson, partName, reason, tenkai, userID, PGM);

            return result;
        }
    }
}
