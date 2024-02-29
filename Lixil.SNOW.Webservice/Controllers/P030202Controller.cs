using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lixil.SNOW.Webservice.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class P030202Controller : ControllerBase
	{

		/// <summary>
		/// コンテキストマスタの取得
		/// </summary>
		/// <returns>コンテキストマスタ</returns>
		/// <remarks>20240109 劉 新規作成</remarks>
		[HttpPost(Name = "SelHaifuHeaderData")]
		public List<CONTEXT> SelHaifuHeaderData()
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<CONTEXT> result = new List<CONTEXT>();
			result = new P030202_BizLogic().SelHaifuHeaderData();
			
			return result;
		}

	}
}
