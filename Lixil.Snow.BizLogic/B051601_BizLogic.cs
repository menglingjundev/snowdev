using Lixil.Snow.DataAccess;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Reflection;

namespace Lixil.Snow.BizLogic
{
	/// <summary>
	/// BOM更新(洗面)
	/// </summary>
	public class B051601_BizLogic
	{

		//SQL文実行用
		private B051601_DataAccess da;

		public B051601_BizLogic()
		{
			da = new B051601_DataAccess();
		}

		/// <summary>
		/// SNOWユーザーマスタの取得
		/// </summary>
		/// <param name="userID">ユーザーID</param>
		/// <returns></returns>
		/// <remarks>20240109 劉 新規作成</remarks>
		public List<SNOW_USER> SelSnowUser(string userID)
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<SNOW_USER> result = new List<SNOW_USER>();
			result = da.SelSnowUser(userID);
			da.Close();
			return result;
		}

		/// <summary>
		/// 部品履歴ID(洗面)の取得
		/// </summary>
		/// <param name="partNumber">品番</param>
		/// <returns>部品部品履歴データ</returns>
		/// <remarks>20240109 劉 新規作成</remarks>
		public List<V_PART> SelBuhinRirekiID(string partNumber)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<V_PART> result = new List<V_PART>();
			result = da.SelBuhinRirekiID(partNumber);
			da.Close();
			return result;
		}

		/// <summary>
		/// 子部品履歴情報(洗面)の取得
		/// </summary>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <returns>部品履歴データ</returns>
		/// <remarks>20210416 修(ATO) 新規作成</remarks>
		public List<V_PART> SelKoBuhinRirekiJyoho(string oyaBuhinRirekiID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<V_PART> result = new List<V_PART>();
			result = da.SelKoBuhinRirekiJyoho(oyaBuhinRirekiID);
			da.Close();
			return result;
		}

		/// <summary>
		/// BOM(洗面)テーブルから指定された品番を削除する
		/// </summary>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <returns>処理結果</returns>
		/// <remarks>20240109 劉 新規作成</remarks>
		public int DelBACByOyaID(long oyaBuhinRirekiID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			int result = 0;
			result = da.DelBACByOyaID(oyaBuhinRirekiID);
			da.Close();
			return result;
		}

		/// <summary>
		/// BOM(洗面)情報を取得する
		/// 
		/// </summary>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <param name="koBuhinRirekiID">子部品履歴ID</param>
		/// <returns>BOM(洗面)情報</returns>
		/// <remarks>20240109 劉 新規作成</remarks>
		public List<V_ASSEMBLY_COMPONENT> SelBACByOyaAndKoID(long oyaBuhinRirekiID, long koBuhinRirekiID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<V_ASSEMBLY_COMPONENT> result = new List<V_ASSEMBLY_COMPONENT>();
			result = da.SelBACByOyaAndKoID(oyaBuhinRirekiID, koBuhinRirekiID);
			da.Close();
			return result;
		}

		/// <summary>
		/// 親部品履歴IDにより、BOM(洗面)情報を取得する
		/// </summary>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <returns>BOM(洗面)情報</returns>
		/// <remarks>20240109 劉 新規作成</remarks>
		public List<V_ASSEMBLY_COMPONENT> SelBACByOyaID(long oyaBuhinRirekiID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<V_ASSEMBLY_COMPONENT> result = new List<V_ASSEMBLY_COMPONENT>();
			result = da.SelBACByOyaID(oyaBuhinRirekiID);
			da.Close();
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
		/// <remarks>20240109 劉 新規作成</remarks>
		public int InsertBAC(long identification, long oyaBuhinRirekiID, long koBuhinRirekiID, long amount, long lineNumber)
		{

			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			int result = 0;
			result = da.InsertBAC(identification, oyaBuhinRirekiID, koBuhinRirekiID, amount, lineNumber);
			da.Close();
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
		public int InsPartUpdateRireki(string kinouId, string userName, string userId, string hinban, string hinmei, string kaihatuTantou, string deliveryPerson, string series, string kousinkoumokumei, string kousinmae, string kousingo)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			int result = 0;
			result = da.InsPartUpdateRireki(kinouId, userName, userId, hinban, hinmei, kaihatuTantou, deliveryPerson, series, kousinkoumokumei, kousinmae, kousingo);
			da.Close();
			return result;
		}

	}
}
