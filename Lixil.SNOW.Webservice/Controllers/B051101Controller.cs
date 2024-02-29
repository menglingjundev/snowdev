using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lixil.SNOW.Webservice.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class B051101Controller : ControllerBase
	{

		/// <summary>
		/// SNOWユーザーマスタの取得
		/// </summary>
		/// <param name="userID">ユーザーID</param>
		/// <returns></returns>
		/// <remarks>20181015 修(大連) 新規作成</remarks>
		[HttpGet(Name = "SelSnowUser1/{userID}")]
		public List<SNOW_USER> SelSnowUser1(string userID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<SNOW_USER> result = new List<SNOW_USER>();
			result = new B051101_BizLogic().SelSnowUser(userID);
			return result;
		}

		/// <summary>
		/// 部品(浴室)テーブルマスタの取得
		/// </summary>
		/// <param name="hinban">品番</param>
		/// <returns>部品(浴室)テーブルデータ</returns>
		/// <remarks>20181015 修(大連) 新規作成</remarks>
		[HttpGet(Name = "SelBPART/{hinban}")]
		public List<B_PART> SelBPART(string hinban)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<B_PART> result = new List<B_PART>();
			result = new B051101_BizLogic().SelBPART(hinban);
			return result;
		}

		//TODO
		//TODO
		///// <summary>
		///// チェック属性を取得
		///// </summary>
		///// <param name="sqlStr">SQL文</param>
		///// <param name="partNumberEntity">品番</param>
		///// <param name="bumonCdEntity"></param>
		///// <param name="partNumber"></param>
		///// <param name="bumonCd"></param>
		///// <returns></returns>
		///// <remarks></remarks>
		//public void SelCheckParam(string sqlStr, Utilities.ConfigFileCommon.ConfigFileEntity partNumberEntity, Utilities.ConfigFileCommon.ConfigFileEntity bumonCdEntity, string partNumber, string bumonCd)
		//{
		// イベントログ追加
		//Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
		//	List<B_PART> result = new List<B_PART>();
		//result = new B051101_BizLogic().SelCheckParam(string sqlStr, Utilities.ConfigFileCommon.ConfigFileEntity partNumberEntity, Utilities.ConfigFileCommon.ConfigFileEntity bumonCdEntity, string partNumber, string bumonCd);
		//	return result;
		//}

	}
}
