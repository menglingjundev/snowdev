using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{
	/// <summary>
	/// バッチB030401 データアクセス
	/// </summary>
	/// <param name="bumon">部門</param>
	/// <returns>処理結果</returns>
	/// <remarks>20240101 劉(大連) 新規作成</remarks>
	public class B030401_DataAccess : SqlManager
	{

		/// <summary>
		/// Snow業者マスタテーブルから指定された部門により、データを取得する
		/// </summary>
		/// <param name="bumon">部門</param>
		/// <returns>処理結果</returns>
		/// <remarks>20240101 劉(大連) 新規作成</remarks>
		public List<GYOSYA> SelGyosyaByBomon(string bumon)
		{

			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Query<GYOSYA>($"SELECT * FROM GYOSYA WHERE BUMON= '{bumon}'").ToList();

			return result;

		}

		/// <summary>
		/// Snow業者マスタテーブルから指定された部門により、データを削除する
		/// </summary>
		/// <param name="bumon">部門</param>
		/// <returns>処理結果</returns>
		/// <remarks>20240101 劉(大連) 新規作成</remarks>
		public int DelGyosyaByBomon(string bumon)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Execute($"DELETE GYOSYA WHERE BUMON= '{bumon}'");

			return result;
		}


		/// <summary>
		/// Snow業者マスタテーブル登録
		/// </summary>
		/// <param name="kinouId">機能ID</param>
		/// <param name="userId">ユーザーID</param>
		/// <param name="bumon">部門</param>
		/// <param name="gyosyaID">業者ID</param>
		/// <param name="gyosyaName">業者名</param>
		/// <param name="kanaName">業者名（カナ）</param>
		/// <param name="multiFlg">子図面配布フラグ</param>
		/// <returns>影響行数</returns>
		/// <remarks>20240101 劉(大連) 新規作成</remarks>
		public int InsGyosya(string kinouId, string userId, string bumon, string gyosyaID, string gyosyaName, string kanaName, string multiFlg)
		{

			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			GYOSYA saiban = new GYOSYA
			{
				BUMON = bumon,
				GYOSYA_ID = gyosyaID,
				GYOSYA_NAME = gyosyaName,
				KANA_NAME = kanaName,
				MULTI_FLG = multiFlg,
				CREATE_PGM = kinouId,
				CREATE_PERSON = userId,
				MODIFY_PGM = kinouId,
				MODIFY_PERSON = userId
			};

			var result = db.Execute($"INSERT INTO GYOSYA VALUES" +
				$" (@BUMON, @GYOSYA_ID, @GYOSYA_NAME, @KANA_NAME, @MULTI_FLG" +
				$",CREATE_PGM, @CREATE_PERSON,NOW(), @MODIFY_PGM,@MODIFY_PERSON,NOW()) ", saiban);

			return result;
		}

	}
}
