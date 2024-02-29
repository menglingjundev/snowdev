using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{
	/// <summary>
	/// バッチB051101 データアクセス
	/// </summary>
	/// <remarks>20181015 修(大連) 新規作成</remarks>
	public class B051101_DataAccess : SqlManager
	{



		/// <summary>
		/// SNOWユーザーマスタの取得
		/// </summary>
		/// <param name="userID">ユーザーID</param>
		/// <returns>ユーザー</returns>
		/// <remarks>20240101 劉(大連) 新規作成</remarks>
		public List<SNOW_USER> SelSnowUser(string userID)
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Query<SNOW_USER>($"SELECT SU.USER_ID,SU.MAIL_ADDRESS FROM SNOW_USER SU WHERE SU.USER_ID ='{userID}'").ToList();

			return result;
		}

		/// <summary>
		/// 部品(浴室)テーブルの取得
		/// </summary>
		/// <param name="hinban">品番</param>
		/// <returns>部品(浴室)テーブルデータ</returns>
		/// <remarks>20240101 劉(大連) 新規作成</remarks>
		public List<B_PART> SelBPART(string hinban)
		{

			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Query<B_PART>($"SELECT BP.PART_NUMBER  FROM B_PART BP WHERE BP.PART_NUMBER = '{hinban}'").ToList();

			return result;
		}
	}
}
