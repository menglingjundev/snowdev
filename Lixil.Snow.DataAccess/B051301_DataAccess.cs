using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{
	/// <summary>
	/// BOM更新(浴室)
	/// </summary>
	/// <remarks>20181015 修(大連) 新規作成</remarks>
	public class B051301_DataAccess : SqlManager
	{
		/// <summary>
		/// SNOWユーザーマスタの取得
		/// </summary>
		/// <param name="userID">ユーザーID</param>
		/// <returns>ユーザー</returns>
		/// <remarks>20240101 劉(大連) 新規作成</remarks>
		public List<SNOW_USER> SelSnowUser(string userId)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Query<SNOW_USER>($"SELECT SU.MAIL_ADDRESS FROM SNOW_USER SU WHERE SU.USER_ID ='{userId}'").ToList();

			return result;
		}

		/// <summary>
		/// 部品(浴室)と部品履歴(浴室)テーブルを検索し、部品履歴情報を取得する
		/// </summary>
		/// <param name="hinban">品番</param>
		/// <returns>部品履歴情報</returns>
		/// <remarks>20240109 劉 新規作成</remarks>
		public List<B_PART> SelBuhinRerekiID(string hinban)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Query<B_PART>($"Select BPV.IDENTIFICATION FROM B_PART BP INNER JOIN B_PART_VERSION BPV  ON BP.IDENTIFICATION = BPV.SUPER_IDENTIFICATION WHERE BP.PART_NUMBER = '{hinban}'").ToList();

			return result;
		}

		/// <summary>
		/// BOM(浴室)テーブルから指定された品番を削除する
		/// </summary>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <returns>処理結果</returns>
		/// <remarks>20240109 劉 新規作成</remarks>
		public int DelBACByOyaID(long oyaBuhinRirekiID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Execute($"DELETE B_ASSEMBLY_COMPONENT WHERE UPPER_IDENTIFICATION ='{oyaBuhinRirekiID}'");

			return result;
		}


		/// <summary>
		/// BOM(浴室)テーブルを検索し、BOM(浴室)情報を取得する
		/// </summary>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <param name="koBuhinRirekiID">子部品履歴ID</param>
		/// <returns>BOM(浴室)情報</returns>
		/// <remarks>20240109 劉 新規作成</remarks>
		public List<B_ASSEMBLY_COMPONENT> SelBACByOyaAndKoID(long oyaBuhinRirekiID, long koBuhinRirekiID)
		{

			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Query<B_ASSEMBLY_COMPONENT>($"Select BAC.IDENTIFICATION FROM B_ASSEMBLY_COMPONENT BAC WHERE BAC.UPPER_IDENTIFICATION = '{oyaBuhinRirekiID}' AND   BAC.LOWER_IDENTIFICATION ='{koBuhinRirekiID}'").ToList();

			return result;
		}

		/// <summary>
		/// 親部品履歴IDにより、BOM(浴室)テーブルを検索し、BOM(浴室)情報を取得する
		/// </summary>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <returns>BOM(浴室)情報</returns>
		/// <remarks>20240109 劉 新規作成</remarks>
		public List<B_ASSEMBLY_COMPONENT> SelBACByOyaID(long oyaBuhinRirekiID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Query<B_ASSEMBLY_COMPONENT>($"Select BAC.IDENTIFICATION FROM B_ASSEMBLY_COMPONENT BAC WHERE BAC.UPPER_IDENTIFICATION =  '{oyaBuhinRirekiID}'").ToList();

			return result;
		}


	}
}
