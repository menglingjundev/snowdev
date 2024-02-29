using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lixil.SNOW.Webservice.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class B051301Controller : ControllerBase
	{

		/// <summary>
		/// SNOWユーザーマスタの取得
		/// </summary>
		/// <param name="userID">ユーザーID</param>
		/// <returns></returns>
		/// <remarks>20181015 修(大連) 新規作成</remarks>
		[HttpGet(Name = "SelSnowUser3/{userID}")]
		public List<SNOW_USER> SelSnowUser3(string userID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<SNOW_USER> result = new List<SNOW_USER>();
			result = new B051301_BizLogic().SelSnowUser(userID);
			return result;
		}

		/// <summary>
		/// 部品履歴ID(浴室)の取得
		/// </summary>
		/// <param name="partNumber">品番</param>
		/// <returns>部品部品履歴データ</returns>
		/// <remarks>20181215 修(大連) 新規作成</remarks>
		[HttpGet(Name = "SelBuhinRerekiID/{partNumber}")]
		public List<B_PART> SelBuhinRerekiID(string partNumber)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<B_PART> result = new List<B_PART>();
			result = new B051301_BizLogic().SelBuhinRerekiID(partNumber);
			return result;
		}

		/// <summary>
		/// BOM(浴室)テーブルから指定された品番を削除する
		/// </summary>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <returns>処理結果</returns>
		/// <remarks>20181215 修(大連) 新規作成</remarks>
		[HttpPost(Name = "DelBACByOyaID1/{oyaBuhinRirekiID}")]
		public int DelBACByOyaID1(long oyaBuhinRirekiID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			int result = new int();
			result = new B051301_BizLogic().DelBACByOyaID(oyaBuhinRirekiID);
			return result;
		}


		/// <summary>
		/// BOM(浴室)情報を取得する
		/// </summary>
		/// </summary>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <param name="koBuhinRirekiID">子部品履歴ID</param>
		/// <returns>BOM(浴室)情報</returns>
		/// <remarks>20181215 修(大連) 新規作成</remarks>
		[HttpGet(Name = "SelBACByOyaAndKoID1/{oyaBuhinRirekiID}/{koBuhinRirekiID}")]
		public List<B_ASSEMBLY_COMPONENT> SelBACByOyaAndKoID1(long oyaBuhinRirekiID, long koBuhinRirekiID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<B_ASSEMBLY_COMPONENT> result = new List<B_ASSEMBLY_COMPONENT>();
			result = new B051301_BizLogic().SelBACByOyaAndKoID(oyaBuhinRirekiID, koBuhinRirekiID);
			return result;
		}

		/// <summary>
		/// 親部品履歴IDにより、BOM(浴室)情報を取得する
		/// </summary>
		/// </summary>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <returns>BOM(浴室)情報</returns>
		/// <remarks>20181215 修(大連) 新規作成</remarks>
		[HttpGet(Name = "SelBACByOyaID1/{oyaBuhinRirekiID}")]
		public List<B_ASSEMBLY_COMPONENT> SelBACByOyaID1(long oyaBuhinRirekiID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<B_ASSEMBLY_COMPONENT> result = new List<B_ASSEMBLY_COMPONENT>();
			result = new B051301_BizLogic().SelBACByOyaID(oyaBuhinRirekiID);
			return result;
		}



	}
}
