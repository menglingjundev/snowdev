using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lixil.SNOW.Webservice.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class B051501Controller : ControllerBase
	{
		/// <summary>
		/// SNOWユーザーマスタの取得
		/// </summary>
		/// <param name="userID">ユーザーID</param>
		/// <returns></returns>
		/// <remarks>20181015 修(大連) 新規作成</remarks>
		[HttpGet(Name = "SelSnowUser5/{userID}")]
		public List<SNOW_USER> SelSnowUser(string userID)
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<SNOW_USER> result = new List<SNOW_USER>();
			result = new B051501_BizLogic().SelSnowUser(userID);
		
			return result;
		}

		//TODO
		/// <summary>
		/// 部品(洗面)テーブルマスタの取得
		/// </summary>
		/// <param name="partNumberEntity">品番</param>
		/// <param name="partNumber">品番</param>
		/// <param name="entities">検索対象</param>
		/// <returns>部品(洗面)テーブルデータ</returns>
		/// <remarks>20181015 修(大連) 新規作成</remarks>


		//TODO
		/// <summary>
		/// 部品履歴(洗面)テーブルの取得
		/// </summary>
		/// <param name="partNumberEntity">品番</param>
		/// <param name="partNumber">品番</param>
		/// <param name="entities">検索対象</param>
		/// <returns>工場部品履歴(洗面)データ</returns>
		/// <remarks>20181015 修(大連) 新規作成</remarks>


		/// <summary>
		/// 部品更新履歴テーブル登録(部品登録)
		/// </summary>
		/// <param name="kinouId">機能ID</param>
		/// <param name="userName">ユーザー名</param>
		/// <param name="userId">ユーザーID</param>
		/// <param name="hinban">品番</param>
		/// <param name="hinmei">部品名称</param>
		/// <param name="kaihatuTantou">開発担当者</param>
		/// <param name="deliveryPerson">デリバリー担当者</param>
		/// <param name="series">ｼﾘｰｽﾞ名</param>
		/// <param name="kousinkoumokumei">更新属性名</param>
		/// <param name="kousinmae">更新前のDBの値</param>
		/// <param name="kousingo">インプットファイルの値</param>
		/// <returns>影響行数</returns>
		/// <remarks>20181015 修(大連) 新規作成</remarks>
		[HttpGet(Name = "InsPartUpdateRireki1/{kinouId}/{userName}/{userId}/{hinban}/{hinmei}/{kaihatuTantou}/{deliveryPerson}/{series}/{kousinkoumokumei}/{kousinmae}/{kousingo}")]
		public int InsPartUpdateRireki1(string kinouId, string userName, string userId, string hinban, string hinmei, string kaihatuTantou, string deliveryPerson, string series, string kousinkoumokumei, string kousinmae, string kousingo)
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			int result = 0;
			result = new B051501_BizLogic().InsPartUpdateRireki(kinouId, userName, userId, hinban, hinmei, kaihatuTantou, deliveryPerson, series, kousinkoumokumei, kousinmae, kousingo);
			return result;
		}



	}
}
