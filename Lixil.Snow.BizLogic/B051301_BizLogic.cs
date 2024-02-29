using Lixil.Snow.DataAccess;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.VisualBasic;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.BizLogic
{
	/// <summary>
	/// 採番の種類マスタのデータアクセス
	/// </summary>
	public class B051301_BizLogic
	{

		//SQL文実行用
		private B051301_DataAccess da;

		public B051301_BizLogic()
		{
			da = new B051301_DataAccess();
		}

		/// <summary>
		/// SNOWユーザーマスタの取得
		/// </summary>
		/// <param name="userID">ユーザーID</param>
		/// <returns></returns>
		/// <remarks>20240109 劉 新規作成</remarks>
		public List<SNOW_USER> SelSnowUser(string userID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<SNOW_USER> result = new List<SNOW_USER>();
			result = da.SelSnowUser(userID);
			da.Close();
			return result;
		}

		/// <summary>
		/// 部品履歴ID(浴室)の取得
		/// </summary>
		/// <param name="partNumber">品番</param>
		/// <returns>部品部品履歴データ</returns>
		/// <remarks>20181215 修(大連) 新規作成</remarks>
		public List<B_PART> SelBuhinRerekiID(string partNumber)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<B_PART> result = new List<B_PART>();
			result = da.SelBuhinRerekiID(partNumber);
			da.Close();
			return result;
		}

		/// <summary>
		/// BOM(浴室)テーブルから指定された品番を削除する
		/// </summary>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <returns>処理結果</returns>
		/// <remarks>20181215 修(大連) 新規作成</remarks>
		public int DelBACByOyaID(long oyaBuhinRirekiID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			int result = new int();
			result = da.DelBACByOyaID(oyaBuhinRirekiID);
			da.Close();
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
		public List<B_ASSEMBLY_COMPONENT> SelBACByOyaAndKoID(long oyaBuhinRirekiID, long koBuhinRirekiID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<B_ASSEMBLY_COMPONENT> result = new List<B_ASSEMBLY_COMPONENT>();
			result = da.SelBACByOyaAndKoID(oyaBuhinRirekiID, koBuhinRirekiID);
			da.Close();
			return result;
		}

		/// <summary>
		/// 親部品履歴IDにより、BOM(浴室)情報を取得する
		/// </summary>
		/// </summary>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <returns>BOM(浴室)情報</returns>
		/// <remarks>20181215 修(大連) 新規作成</remarks>
		public List<B_ASSEMBLY_COMPONENT> SelBACByOyaID(long oyaBuhinRirekiID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<B_ASSEMBLY_COMPONENT> result = new List<B_ASSEMBLY_COMPONENT>();
			result = da.SelBACByOyaID(oyaBuhinRirekiID);
			da.Close();
			return result;
		}
	}
}
