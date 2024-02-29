using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lixil.SNOW.Webservice.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class B051601Controller : ControllerBase
	{
		/// <summary>
		/// SNOWユーザーマスタの取得
		/// </summary>
		/// <param name="userID">ユーザーID</param>
		/// <returns></returns>
		/// <remarks>20210216 修(ATO) 新規作成</remarks>
		[HttpGet(Name = "SelSnowUser6/{userID}")]
		public List<SNOW_USER> SelSnowUser(string userID)
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<SNOW_USER> result = new List<SNOW_USER>();
			result =  new B051601_BizLogic().SelSnowUser(userID);
			
			return result;
		}

		/// <summary>
		/// 部品履歴ID(洗面)の取得
		/// </summary>
		/// <param name="partNumber">品番</param>
		/// <returns>部品部品履歴データ</returns>
		/// <remarks>20210216 修(ATO) 新規作成</remarks>
		[HttpGet(Name = "SelBuhinRirekiID/{partNumber}")]
		public List<V_PART> SelBuhinRirekiID(string partNumber)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<V_PART> result = new List<V_PART>();
			result =  new B051601_BizLogic().SelBuhinRirekiID(partNumber);
			
			return result;
		}

		/// <summary>
		/// 子部品履歴情報(洗面)の取得
		/// </summary>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <returns>部品履歴データ</returns>
		/// <remarks>20210416 修(ATO) 新規作成</remarks>
		[HttpGet(Name = "SelKoBuhinRirekiJyoho/{oyaBuhinRirekiID}")]
		public List<V_PART> SelKoBuhinRirekiJyoho(string oyaBuhinRirekiID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<V_PART> result = new List<V_PART>();
			result =  new B051601_BizLogic().SelKoBuhinRirekiJyoho(oyaBuhinRirekiID);
			
			return result;
		}

		/// <summary>
		/// BOM(洗面)テーブルから指定された品番を削除する
		/// </summary>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <returns>処理結果</returns>
		/// <remarks>20210216 修(ATO) 新規作成</remarks>
		[HttpPost(Name = "DelBACByOyaID2/{oyaBuhinRirekiID}")]
		public int DelBACByOyaID2(long oyaBuhinRirekiID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			int result = 0;
			result =  new B051601_BizLogic().DelBACByOyaID(oyaBuhinRirekiID);
			
			return result;
		}

		/// <summary>
		/// BOM(洗面)情報を取得する
		/// 
		/// </summary>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <param name="koBuhinRirekiID">子部品履歴ID</param>
		/// <returns>BOM(洗面)情報</returns>
		/// <remarks>20210216 修(ATO) 新規作成</remarks>
		[HttpGet(Name = "SelBACByOyaAndKoID2/{oyaBuhinRirekiID}/{koBuhinRirekiID}")]
		public List<V_ASSEMBLY_COMPONENT> SelBACByOyaAndKoID2(long oyaBuhinRirekiID, long koBuhinRirekiID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<V_ASSEMBLY_COMPONENT> result = new List<V_ASSEMBLY_COMPONENT>();
			result =  new B051601_BizLogic().SelBACByOyaAndKoID(oyaBuhinRirekiID, koBuhinRirekiID);
			
			return result;
		}

		/// <summary>
		/// 親部品履歴IDにより、BOM(洗面)情報を取得する
		/// </summary>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <returns>BOM(洗面)情報</returns>
		/// <remarks>20210216 修(ATO) 新規作成</remarks>
		[HttpGet(Name = "SelBACByOyaID2/{oyaBuhinRirekiID}")]
		public List<V_ASSEMBLY_COMPONENT> SelBACByOyaID2(long oyaBuhinRirekiID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<V_ASSEMBLY_COMPONENT> result = new List<V_ASSEMBLY_COMPONENT>();
			result =  new B051601_BizLogic().SelBACByOyaID(oyaBuhinRirekiID);
			
			return result;
		}



		/// <summary>
		/// BOM(洗面)情報を登録する
		/// </summary>
		/// <param name="identification">ID</param>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <param name="koBuhinRirekiID">子部品履歴ID</param>
		/// <param name="amount">員数</param>
		/// <param name="lineNumber">行番号</param>
		/// <returns>BOM(洗面)情報</returns>
		/// <remarks>20210216 修(ATO) 新規作成</remarks>
		[HttpPost(Name = "InsertBAC/{identification}/{oyaBuhinRirekiID}/{koBuhinRirekiID}/{amount}/{lineNumber}")]
		public int InsertBAC(long identification, long oyaBuhinRirekiID, long koBuhinRirekiID, long amount, long lineNumber)
		{

			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			int result = 0;
			result =  new B051601_BizLogic().InsertBAC(identification, oyaBuhinRirekiID, koBuhinRirekiID, amount, lineNumber);
			
			return result;
		}

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
		/// <param name="kousingo">更新後の値</param>
		/// <returns>影響行数</returns>
		/// <remarks>20210406 修(ATO) 新規作成</remarks>
		[HttpPost(Name = "InsPartUpdateRireki2/{kinouId}/{userName}/{userId}/{hinban}/{hinmei}/{kaihatuTantou}/{deliveryPerson}/{series}/{kousinkoumokumei}/{kousinmae}/{kousingo}")]
		public int InsPartUpdateRireki2(string kinouId, string userName, string userId, string hinban, string hinmei, string kaihatuTantou, string deliveryPerson, string series, string kousinkoumokumei, string kousinmae, string kousingo)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			int result = 0;
			result =  new B051601_BizLogic().InsPartUpdateRireki(kinouId, userName, userId, hinban, hinmei, kaihatuTantou, deliveryPerson, series, kousinkoumokumei, kousinmae, kousingo);
			
			return result;
		}

	}
}
