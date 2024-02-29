using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lixil.SNOW.Webservice.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class P030201Controller : ControllerBase
	{
		/// <summary>
		/// 変更通知番号の取得
		/// </summary>
		/// <param name="contestInfo">コンテキスト</param>
		/// <returns>業者配布履歴・ヘッダテーブル</returns>
		[HttpPost(Name = "SelContestData/{contestInfo}")]
		public List<HAIFU_HEADER> SelContestData(List<string> contestInfo)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<HAIFU_HEADER> result = new List<HAIFU_HEADER>();
			result = new P030201_BizLogic().SelContestData(contestInfo);
			return result;
		}

		/// <summary>
		/// 業者配布履歴の取得
		/// </summary>
		/// <param name="contestInfo">コンテキスト</param>
		/// <param name="wcEcnNo">変更通知番号</param>
		/// <param name="txtZuban">図番</param>
		/// <param name="txtFile">ファイル名</param>
		/// <param name="rdoStatus">配布区分</param>
		/// <param name="kensakuKensu">検索件数</param>
		/// <param name="haifumoto">配布元</param>
		/// <returns>業者配布履歴・ヘッダテーブル</returns>
		/// <remarks>20240109 劉 新規作成</remarks>
		[HttpPost(Name = "SelHaifuData/{contestInfo}/{wcEcnNo}/{txtZuban}/{txtFile}/{rdoStatus}/{kensakuKensu}/{Haifumoto}")]
		public List<P030201_RESULT> SelHaifuData(List<string> contestInfo, string wcEcnNo, string txtZuban, string txtFile, bool rdoStatus, int kensakuKensu, string Haifumoto)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<P030201_RESULT> result = new List<P030201_RESULT>();
			result = new P030201_BizLogic().SelHaifuData(contestInfo, wcEcnNo, txtZuban, txtFile, rdoStatus, kensakuKensu, Haifumoto);
			return result;
		}

		/// <summary>
		/// 業者配布履歴検索件数の取得
		/// </summary>
		/// <param name="contestInfo">コンテキスト</param>
		/// <param name="wcEcnNo">変更通知番号</param>
		/// <param name="txtZuban">図番</param>
		/// <param name="txtFile">ファイル名</param>
		/// <returns>業者配布履歴検索件数</returns>
		///  <remarks>20240109 劉 新規作成</remarks>
		[HttpPost(Name = "SelHaifuDataCnt/{contestInfo}/{wcEcnNo}/{txtZuban}/{txtFile}")]
		public int SelHaifuDataCnt(List<string> contestInfo, string wcEcnNo, string txtZuban, string txtFile)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			var result = new P030201_BizLogic().SelHaifuDataCnt(contestInfo, wcEcnNo, txtZuban, txtFile);

			return result;
		}

	}
}
