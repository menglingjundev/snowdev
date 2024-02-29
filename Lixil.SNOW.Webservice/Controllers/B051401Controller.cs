using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lixil.SNOW.Webservice.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class B051401Controller : ControllerBase
	{
		/// <summary>
		/// SNOWユーザーマスタの取得
		/// </summary>
		/// <param name="userID">ユーザーID</param>
		/// <returns></returns>
		/// <remarks>20181015 修(大連) 新規作成</remarks>
		[HttpGet(Name = "SelSnowUser4/{userID}")]
		public List<SNOW_USER> SelSnowUser(string userID)
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<SNOW_USER> result = new List<SNOW_USER>();
			result = new B051401_BizLogic().SelSnowUser(userID);
			return result;
		}

		/// <summary>
		/// 部品(浴室)テーブルマスタの取得
		/// </summary>
		/// <param name="hinban">品番</param>
		/// <returns>部品(浴室)テーブルデータ</returns>
		/// <remarks>20181015 修(大連) 新規作成</remarks>
		[HttpGet(Name = "SelVPART/{hinban}")]
		public List<V_PART> SelVPART(string hinban)
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<V_PART> result = new List<V_PART>();
			result = new B051401_BizLogic().SelVPART(hinban);
			return result;
		}

		//TODO
		/// <summary>
		/// チェック属性を取得
		/// </summary>
		/// <param name="sqlStr">SQL文</param>
		/// <param name="partNumberEntity">品番</param>
		/// <param name="bumonCdEntity"></param>
		/// <param name="partNumber"></param>
		/// <param name="bumonCd"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		//public List<V_PART> SelVPART(string hinban)
		//{
		//	Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
		//	List<V_PART> result = new List<V_PART>();
		//	result = new B051401_BizLogic().SelVPART(hinban);
		//	return result;
		//}


	}
}
