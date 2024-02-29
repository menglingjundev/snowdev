using Lixil.Snow.DataAccess;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Data;
using System.Reflection;
using System.Transactions;

namespace Lixil.Snow.BizLogic
{
	/// <summary>
	/// バッチB200101用
	/// </summary>
	public class P030203_BizLogic
	{

		//SQL文実行用
		private P030203_DataAccess da;

		public P030203_BizLogic()
		{
			da = new P030203_DataAccess();
		}
		
		/// <summary>
		/// 業者配布履歴・明細を削除する
		/// </summary>
		/// <param name="wcEcnNo">変更通知番号</param>
		/// <param name="wcObjNo">図面・ドキュメント番号</param>
		/// <param name="haifumoto">配布元</param>
		/// <returns>処理結果</returns>
		/// <remarks>20181015 陳(大連) 新規作成</remarks>
		public int DelHaifuDetailData(string wcEcnNo, string wcObjNo, string haifumoto)
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			var result = da.DelHaifuDetailData(wcEcnNo, wcObjNo, haifumoto);
			da.Close();
			return result;
		}

		/// <summary>
		/// 業者配布履歴・明細を登録する
		/// </summary>
		/// <param name="wcEcnNo">変更通知番号</param>
		/// <param name="wcObjNo">図面・ドキュメント番号</param>
		/// <param name="gyasyaID">業者ID</param>
		/// <param name="gyasyaName">業者名</param>
		/// <param name="busuu">部数</param>
		/// <param name="userID">ユーザーID</param>
		/// <param name="PGM">機能ID</param>
		/// <param name="haifumoto">配布元</param>
		/// <returns>処理結果</returns>
		/// <remarks>20181015 陳(大連) 新規作成</remarks>
		public int InsHaifuDetailData(string wcEcnNo, string wcObjNo, string gyasyaID, string gyasyaName, string busuu, string userID, string PGM, string haifumoto)
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			var result = da.InsHaifuDetailData(wcEcnNo, wcObjNo, gyasyaID, gyasyaName, busuu, userID, PGM, haifumoto);
			da.Close();
			return result;
		}

		/// <summary>
		/// 業者配布履歴（最新）を検索する
		/// </summary>
		/// <param name="wcObjNo">図面・ドキュメント番号</param>
		/// <param name="haifumoto">配布元</param>
		/// <returns>業者配布履歴（最新）テーブル</returns>
		/// <remarks>20181015 陳(大連) 新規作成</remarks>
		public List<HAIFU_DETAIL_LAST> SelHaifuDetailLastData(string wcObjNo, string haifumoto)
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<HAIFU_DETAIL_LAST> result = new List<HAIFU_DETAIL_LAST>();
			result = da.SelHaifuDetailLastData(wcObjNo, haifumoto);
			da.Close();
			return result;
		}

		/// <summary>
		/// 業者配布履歴（最新）を更新する
		/// </summary>
		/// <param name="wcobjno">図面・ドキュメントの番号</param>
		/// <param name="bumon">部門</param>
		/// <param name="gyasyaList">業者List</param>
		/// <param name="busuuList">部数List</param>
		/// <param name="userID">ユーザーID</param>
		/// <param name="PGM">機能ID</param>
		/// <param name="haifumoto">配布元</param>
		/// <returns>処理結果</returns>
		/// <remarks>20181015 陳(大連) 新規作成</remarks>
		public int UpdHaifuDetailLastData(string wcobjno, string bumon, List<string> gyasyaList, List<string> busuuList, string userID, string PGM, string haifumoto)
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			var result = da.UpdHaifuDetailLastData(wcobjno, bumon, gyasyaList, busuuList, userID, PGM, haifumoto);
			da.Close();
			return result;
		}

		/// <summary>
		/// 業者配布履歴（最新）を登録する
		/// </summary>
		/// <param name="wcobjno">図面・ドキュメントの番号</param>
		/// <param name="bumon">部門</param>
		/// <param name="gyasyaList">業者List</param>
		/// <param name="busuuList">部数List</param>
		/// <param name="userID">ユーザーID</param>
		/// <param name="PGM">機能ID</param>
		/// <param name="haifumoto">配布元</param>
		/// <returns>処理結果</returns>
		/// <remarks>20181015 陳(大連) 新規作成</remarks>
		public int InsHaifuDetailLastData(string wcobjno, string bumon, List<string> gyasyaList, List<string> busuuList, string userID, string PGM, string haifumoto)
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			var result = da.InsHaifuDetailLastData(wcobjno, bumon, gyasyaList, busuuList, userID, PGM, haifumoto);
			da.Close();
			return result;
		}



        //TODO
        //public int InsHaifuDetailAndLastData(List<HAIFU_DETAIL_LAST> dataList, string userId, string PGM)
        //{
        //	// イベントログ追加
        //	Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
        //	int result = 0;

        //	using (Transactions.TransactionScope scope = new Transactions.TransactionScope())
        //	{
        //		for (int columnCount = 0; columnCount <= datatable.Rows.Count - 1; columnCount++)
        //		{
        //			string wcEcnNo = datatable.Rows(columnCount).Item(17).ToString;
        //			string wcObjNo = datatable.Rows(columnCount).Item(1).ToString;
        //			string bumon = datatable.Rows(columnCount).Item(19).ToString;
        //			// 20190923 大連 韓  配布元を追加 start
        //			string haifumoto = datatable.Rows(columnCount).Item(5).ToString;
        //			// 20190923 大連 韓  配布元を追加 end
        //			// 業者配布履歴・明細を削除する
        //			result = da.DelHaifuDetailData(wcEcnNo, wcObjNo, haifumoto);

        //			List<string> gyasyaList = new List<string>();
        //			List<string> busuuList = new List<string>();
        //			for (var cnt = 0; cnt <= 4; cnt++)
        //			{
        //				// 一覧の業者情報取得
        //				string gyasya1 = datatable.Rows(columnCount).Item(6 + cnt * 2).ToString;
        //				string gyasyaID1 = null;
        //				string gyasyaNanme1 = null;
        //				if (!string.IsNullOrEmpty(gyasya1))
        //				{
        //					gyasyaID1 = gyasya1.Substring(0, gyasya1.IndexOf(" "));
        //					gyasyaNanme1 = gyasya1.Substring(gyasyaID1.Length + 3);
        //				}

        //				string haifukbn = datatable.Rows(columnCount).Item(21 + cnt).ToString;
        //				string busuu = datatable.Rows(columnCount).Item(7 + cnt * 2).ToString;

        //				if (!string.IsNullOrEmpty(datatable.Rows(columnCount).Item(6 + cnt * 2).ToString) && !Utilities.AppConst.Status.HAIFUZUMI.Equals(haifukbn) && !Utilities.AppConst.Status.KAISYUZUMI.Equals(haifukbn))
        //				{

        //					// 業者配布履歴・明細を登録する
        //					result = da.InsHaifuDetailData(wcEcnNo, wcObjNo, gyasyaID1, gyasyaNanme1, busuu, userId, PGM, haifumoto);
        //					if (result == 0)
        //					{
        //						da.Close();
        //						scope.Dispose();
        //						return result;
        //					}
        //					gyasyaList.Add(gyasyaID1);
        //					gyasyaList.Add(gyasyaNanme1);
        //					busuuList.Add(busuu);
        //				}
        //				else if (string.IsNullOrEmpty(datatable.Rows(columnCount).Item(6 + cnt * 2).ToString))
        //				{
        //					// 空白の場合
        //					gyasyaList.Add("");
        //					gyasyaList.Add("");
        //					busuuList.Add(busuu);
        //				}
        //				else
        //				{
        //					// 配布済、または、回収済の場合
        //					gyasyaList.Add(gyasyaID1);
        //					gyasyaList.Add(gyasyaNanme1);
        //					busuuList.Add(busuu);
        //				}
        //			}

        //			// 業者配布履歴（最新）を検索する
        //			DataTable gyosyaDt = da.SelHaifuDetailLastData(wcObjNo, haifumoto);
        //			if (gyosyaDt.Rows.Count > 0)
        //				// 業者配布履歴（最新）を更新する
        //				result = da.UpdHaifuDetailLastData(wcObjNo, bumon, gyasyaList, busuuList, userId, PGM, haifumoto);
        //			else
        //				// 業者配布履歴（最新）を登録する
        //				result = da.InsHaifuDetailLastData(wcObjNo, bumon, gyasyaList, busuuList, userId, PGM, haifumoto);
        //			if (result == 0)
        //			{
        //				da.Close();
        //				scope.Dispose();
        //				return result;
        //			}
        //		}
        //		da.Close();
        //		scope.Complete();
        //	}

        //	return result;
        //}





    }
}
