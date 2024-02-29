using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{
	/// <summary>
	/// Snow業者マスタのデータアクセス
	/// </summary>
	/// <remarks>20181015 陳(大連) 新規作成</remarks>
	public class P030204_DataAccess : SqlManager
	{
		/// <summary>
		/// Snow業者マスタの取得
		/// </summary>
		/// <param name="drpBumon">部門</param>
		/// <param name="txtGyosyaName">業者名</param>
		/// <param name="txtCanaName">業者名</param>
		/// <returns>業者マスタ</returns>
		/// <remarks>20181015 陳(大連) 新規作成</remarks>
		public List<GYOSYA> SelGyosyaData(string drpBumon, string txtGyosyaName, string txtCanaName)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;

			var result = db.Query<GYOSYA>($"SELECT GS.BUMON ,GS.GYOSYA_ID ,GS.GYOSYA_NAME FROM GYOSYA GS WHERE GS.BUMON  = '{drpBumon}' AND GS.GYOSYA_NAME like '%'{txtGyosyaName}'%' AND GS.KANA_NAME like '%'{txtCanaName}'%'  ").ToList();

			return result;
		}
	}
}
