using Lixil.Snow.DataAccess;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.BizLogic
{
	/// <summary>
	/// バッチB030401用
	/// </summary>
	public class B030401_BizLogic
	{

		//SQL文実行用
		private B030401_DataAccess da;

		public B030401_BizLogic()
		{
			da = new B030401_DataAccess();
		}

		// <summary>
		// Snow業者マスタテーブルから指定された部門により、データを取得する
		// </summary>
		// <param name="bumon">部門</param>
		// <returns>処理結果</returns>
		// <remarks>20240101 劉(大連) 新規作成</remarks>
		public List<GYOSYA> SelGyosyaByBomon(string bumon)
		{

			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<GYOSYA> result = new List<GYOSYA>();
			result = da.SelGyosyaByBomon(bumon);
			da.Close();
			return result;
		}

		// <summary>
		// Snow業者マスタテーブルから指定された部門により、データを削除する
		// </summary>
		// <param name="bumon">部門</param>
		// <returns>処理結果</returns>
		// <remarks>20240101 劉(大連) 新規作成</remarks>
		public int DelGyosyaByBomon(string bumon)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			int result = 0;
			result = da.DelGyosyaByBomon(bumon);
			da.Close();
			return result;
		}

		// <summary>
		// Snow業者マスタテーブル登録
		// </summary>
		// <param name="kinouId">機能ID</param>
		// <param name="userId">ユーザーID</param>
		// <param name="bumon">部門</param>
		// <param name="gyosyaID">業者ID</param>
		// <param name="gyosyaName">業者名</param>
		// <param name="kanaName">業者名（カナ</param>
		// <param name="multiFlg">子図面配布フラグ</param>
		// <returns>影響行数</returns>
		// <remarks>20240101 劉(大連) 新規作成</remarks>
		public int InsGyosya(string kinouId, string userId, string bumon, string gyosyaID, string gyosyaName, string kanaName, string multiFlg)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

			int result = 0;
			result = da.InsGyosya(kinouId, userId, bumon, gyosyaID, gyosyaName, kanaName, multiFlg);
			da.Close();
			return result;
		}

	}
}
