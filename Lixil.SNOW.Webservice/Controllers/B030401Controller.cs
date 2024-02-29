using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lixil.SNOW.Webservice.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class B030401Controller : ControllerBase
	{

		// <summary>
		// Snow業者マスタテーブルから指定された部門により、データを取得する
		// </summary>
		// <param name="bumon">部門</param>
		// <returns>処理結果</returns>
		// <remarks>20240101 劉(大連) 新規作成</remarks>
		[HttpGet(Name = "SelGyosyaByBomon/{bumon}")]
		public List<GYOSYA> SelGyosyaByBomon(string bumon)
		{

			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

			List<GYOSYA> result = new List<GYOSYA>();
			result = new B030401_BizLogic().SelGyosyaByBomon(bumon);

			return result;
		}

		// <summary>
		// Snow業者マスタテーブルから指定された部門により、データを削除する
		// </summary>
		// <param name="bumon">部門</param>
		// <returns>処理結果</returns>
		// <remarks>20240101 劉(大連) 新規作成</remarks>
		[HttpPost(Name = "DelGyosyaByBomon/{bumon}")]
		public int DelGyosyaByBomon(string bumon)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

			int result = 0;
			result = new B030401_BizLogic().DelGyosyaByBomon(bumon);

			return result;
		}

		// <summary>
		// Snow業者マスタテーブル登録
		// </summary>
		// <param name="kinouId">機能ID</param>
		// <param name="userId">ユーザーID</param>
		// <param name="bumon">部門</param>
		// <param name="gyosyaID">業者ID</param>
		// <param name="gyosyaName">業者名</param>
		// <param name="kanaName">業者名（カナ</param>
		// <param name="multiFlg">子図面配布フラグ</param>
		// <returns>影響行数</returns>
		// <remarks>20240101 劉(大連) 新規作成</remarks>
		[HttpPost(Name = "InsGyosya/{kinouId}/{userId}/{bumon}/{gyosyaID}/{gyosyaName}/{kanaName}/{multiFlg}")]
		public int InsGyosya(string kinouId, string userId, string bumon, string gyosyaID, string gyosyaName, string kanaName, string multiFlg)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

			int result = 0;
			result = new B030401_BizLogic().InsGyosya(kinouId, userId, bumon, gyosyaID, gyosyaName, kanaName, multiFlg);

			return result;
		}

	}
}
