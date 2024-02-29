using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lixil.SNOW.Webservice.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class P030203Controller : ControllerBase
	{
		/// <summary>
		/// 業者配布履歴・明細を削除する
		/// </summary>
		/// <param name="wcEcnNo">変更通知番号</param>
		/// <param name="wcObjNo">図面・ドキュメント番号</param>
		/// <param name="haifumoto">配布元</param>
		/// <returns>処理結果</returns>
		/// <remarks>20240115 劉 新規作成</remarks>
		[HttpPost(Name = "DelHaifuDetailData/{wcEcnNo}/{wcObjNo}/{haifumoto}")]
		public int DelHaifuDetailData(string wcEcnNo, string wcObjNo, string haifumoto)
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			var result = new P030203_BizLogic().DelHaifuDetailData(wcEcnNo, wcObjNo, haifumoto);
			return result;
		}

		/// <summary>
		/// 業者配布履歴・明細を登録する
		/// </summary>
		/// <param name="wcEcnNo">変更通知番号</param>
		/// <param name="wcObjNo">図面・ドキュメント番号</param>
		/// <param name="gyasyaID">業者ID</param>
		/// <param name="gyasyaName">業者名</param>
		/// <param name="busuu">部数</param>
		/// <param name="userID">ユーザーID</param>
		/// <param name="PGM">機能ID</param>
		/// <param name="haifumoto">配布元</param>
		/// <returns>処理結果</returns>
		/// <remarks>20240115 劉 新規作成</remarks>
		[HttpPost(Name = "InsHaifuDetailData/{wcEcnNo}/{wcObjNo}/{gyasyaID}/{gyasyaName}/{busuu}/{userID}/{PGM}/{haifumoto}")]
		public int InsHaifuDetailData(string wcEcnNo, string wcObjNo, string gyasyaID, string gyasyaName, string busuu, string userID, string PGM, string haifumoto)
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			var result = new P030203_BizLogic().InsHaifuDetailData(wcEcnNo, wcObjNo, gyasyaID, gyasyaName, busuu, userID, PGM, haifumoto);
			return result;
		}

		/// <summary>
		/// 業者配布履歴（最新）を検索する
		/// </summary>
		/// <param name="wcObjNo">図面・ドキュメント番号</param>
		/// <param name="haifumoto">配布元</param>
		/// <returns>業者配布履歴（最新）テーブル</returns>
		/// <remarks>20240115 劉 新規作成</remarks>
		[HttpGet(Name = "SelHaifuDetailLastData/{wcObjNo}/{haifumoto}")]
		public List<HAIFU_DETAIL_LAST> SelHaifuDetailLastData(string wcObjNo, string haifumoto)
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<HAIFU_DETAIL_LAST> result = new List<HAIFU_DETAIL_LAST>();
			result = new P030203_BizLogic().SelHaifuDetailLastData(wcObjNo, haifumoto);
		
			return result;
		}

		/// <summary>
		/// 業者配布履歴（最新）を更新する
		/// </summary>
		/// <param name="wcobjno">図面・ドキュメントの番号</param>
		/// <param name="bumon">部門</param>
		/// <param name="gyasyaList">業者List</param>
		/// <param name="busuuList">部数List</param>
		/// <param name="userID">ユーザーID</param>
		/// <param name="PGM">機能ID</param>
		/// <param name="haifumoto">配布元</param>
		/// <returns>処理結果</returns>
		/// <remarks>20240115 劉 新規作成</remarks>
		//[HttpPost(Name = "UpdHaifuDetailLastData/{wcobjno}/{bumon}/{gyasyaList}/{busuuList}/{userID}/{PGM}/{haifumoto}")]
		//public int UpdHaifuDetailLastData(string wcobjno, string bumon,[FromBody] List<string> gyasyaList, [FromBody] List<string> busuuList, string userID, string PGM, string haifumoto)
		//{
		//	Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
		//	var result = new P030203_BizLogic().UpdHaifuDetailLastData(wcobjno, bumon, gyasyaList, busuuList, userID, PGM, haifumoto);

		//	return result;
		//}

		/// <summary>
		/// 業者配布履歴（最新）を登録する
		/// </summary>
		/// <param name="wcobjno">図面・ドキュメントの番号</param>
		/// <param name="bumon">部門</param>
		/// <param name="gyasyaList">業者List</param>
		/// <param name="busuuList">部数List</param>
		/// <param name="userID">ユーザーID</param>
		/// <param name="PGM">機能ID</param>
		/// <param name="haifumoto">配布元</param>
		/// <returns>処理結果</returns>
		/// <remarks>20240115 劉 新規作成</remarks>
		//[HttpPost(Name = "InsHaifuDetailLastData/{wcobjno}/{bumon}/{gyasyaList}/{busuuList}/{userID}/{PGM}/{haifumoto}")]
		//public int InsHaifuDetailLastData(string wcobjno, string bumon, [FromBody] List<string> gyasyaList, [FromBody] List<string> busuuList, string userID, string PGM, string haifumoto)
		//{
		//	Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
		//	var result = new P030203_BizLogic().InsHaifuDetailLastData(wcobjno, bumon, gyasyaList, busuuList, userID, PGM, haifumoto);

		//	return result;
		//}


		//TODO
		//InsHaifuDetailAndLastData



	}
}
