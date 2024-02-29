using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{
	/// <summary>
	/// 部品更新属性チェック(浴室)
	/// </summary>
	/// <remarks>20240109 劉 新規作成</remarks>
	public class B051401_DataAccess : SqlManager
	{
		/// <summary>
		/// SNOWユーザーマスタの取得
		/// </summary>
		/// <param name="userID">ユーザーID</param>
		/// <returns>ユーザー</returns>
		/// <remarks>20240109 劉 新規作成</remarks>
		public List<SNOW_USER> SelSnowUser(string userID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Query<SNOW_USER>($"SELECT  SU.USER_ID SU.MAIL_ADDRESS FROM SNOW_USER SU WHERE SU.USER_ID ='{userID}'").ToList();

			return result;

		}

		/// <summary>
		/// 部品(洗面)テーブルの取得
		/// </summary>
		/// <param name="HINBAN">品番</param>
		/// <returns>部品(洗面)テーブルデータ</returns>
		/// <remarks>20240109 劉 新規作成</remarks>
		public List<V_PART> SelVPART(string hinban)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Query<V_PART>($"SELECT VP.PART_NUMBER FROM V_PART VP WHERE VP.PART_NUMBER = '{hinban}'").ToList();

			return result;
		}

	}
}
