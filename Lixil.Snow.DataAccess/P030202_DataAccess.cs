using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{

	/// <summary>
	/// コンテキストマスタのデータアクセス
	/// </summary>
	/// <remarks>20240109 劉 新規作成</remarks>
	public class P030202_DataAccess : SqlManager
	{
		/// <summary>
		/// コンテキストマスタの取得
		/// </summary>
		/// <returns>コンテキストマスタ</returns>
		public List<CONTEXT> SelHaifuHeaderData()
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Query<CONTEXT>($"SELECT CT.CONTEXT FROM CONTEXT CT ORDER BY CT.CONTEXT  ").ToList();
			return result;
		}
	}
}
