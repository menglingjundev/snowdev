using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{
	/// <summary>
	/// 業者割当検索
	/// </summary>
	/// <remarks>20181015 陳(大連) 新規作成</remarks>
	public class P030203_DataAccess : SqlManager
	{
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
			using var db = SqlManager.GetConnection;
			var result = db.Execute($"DELETE HAIFU_DETAIL WHERE WC_ECN_NO = '{wcEcnNo}' AND WC_OBJ_NO ='{wcObjNo}' AND STATUS = '{Utilities.AppConst.Status.HAIFUYOTEI}' AND HAIFUMOTO ='{haifumoto}' ");
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

			var str = "";
			str += " INSERT INTO";
			str += " HAIFU_DETAIL";
			str += " VALUES ( ";
			str += " @WC_ECN_NO, ";                // 変更通知番号
			str += " @WC_OBJ_NO, ";                // 図面・ドキュメントの番号
			str += " @GYOSYA_ID, ";                // 業者ID
			str += " @GYOSYA_NAME, ";              // 業者名
			str += " @BUSUU, ";                    // 部数
			str += " '" + Utilities.AppConst.Status.HAIFUYOTEI + "', ";                // 配布区分
			str += " '', ";                        // 配布日
			str += " '', ";                        // 回収日
			str += " @CREATE_PGM, ";               // 登録機能ID
			str += " @CREATE_PERSON, ";            // 登録ユーザーID
			str += " NOW(), ";                 // 登録日時
			str += " @MODIFY_PGM, ";              // 更新機能ID
			str += " @MODIFY_PERSON, ";           // 更新ユーザーID
			str += " NOW(), ";                  // 更新日時
			str += " @HAIFUMOTO";                // 配布元
			str += ")";

			using var db = SqlManager.GetConnection;
			HAIFU_DETAIL haifu_detail = new HAIFU_DETAIL
			{
				WC_ECN_NO = wcEcnNo,
				WC_OBJ_NO = wcObjNo,
				GYOSYA_ID = gyasyaID,
				GYOSYA_NAME = gyasyaName,
				BUSUU = Int32.Parse(busuu),
				@CREATE_PGM = PGM,
				@CREATE_PERSON = userID,
				@MODIFY_PGM = PGM,
				@MODIFY_PERSON = userID,
				@HAIFUMOTO = haifumoto
			};

			var result = db.Execute(str, haifu_detail);

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
			using var db = SqlManager.GetConnection;
			var result = db.Query<HAIFU_DETAIL_LAST>($" SELECT HDL.WC_OBJ_NO FROM HAIFU_DETAIL_LAST HDL WHERE HDL.WC_OBJ_NO = '{wcObjNo}' AND HDL.HAIFUMOTO = '{haifumoto}'").ToList();
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

			var str = $"";
			str += " UPDATE ";
			str += " HAIFU_DETAIL_LAST ";                      // 業者配布履歴（最新）
			str += " SET ";                                    // 
			str += " BUMON = @BUMON, ";                        // 部門
			str += " GYOSYA_ID_1 = @GYOSYA_ID_1, ";            // 業者ID1
			str += " GYOSYA_NAME_1 = @GYOSYA_NAME_1, ";        // 業者名1
			str += " BUSUU_1 = @BUSUU_1, ";                    // 部数１
			str += " GYOSYA_ID_2 = @GYOSYA_ID_2, ";            // 業者ID2
			str += " GYOSYA_NAME_2 = @GYOSYA_NAME_2, ";        // 業者名2
			str += " BUSUU_2 = @BUSUU_2, ";                    // 部数2
			str += " GYOSYA_ID_3 = @GYOSYA_ID_3, ";            // 業者ID3
			str += " GYOSYA_NAME_3 = @GYOSYA_NAME_3, ";        // 業者名3
			str += " BUSUU_3 = @BUSUU_3, ";                    // 部数3
			str += " GYOSYA_ID_4 = @GYOSYA_ID_4, ";            // 業者ID4
			str += " GYOSYA_NAME_4 = @GYOSYA_NAME_4, ";        // 業者名4
			str += " BUSUU_4 = @BUSUU_4, ";                    // 部数4
			str += " GYOSYA_ID_5 = @GYOSYA_ID_5, ";            // 業者ID5
			str += " GYOSYA_NAME_5 = @GYOSYA_NAME_5, ";        // 業者名5
			str += " BUSUU_5 = @BUSUU_5, ";                    // 部数5
			str += " MODIFY_PGM = @MODIFY_PGM, ";
			str += " MODIFY_PERSON = @MODIFY_PERSON, ";
			str += " MODIFY_DATE = NOW() ";
			str += " WHERE ";
			str += " WC_OBJ_NO = @WC_OBJ_NO ";
			str += " AND HAIFUMOTO = @HAIFUMOTO ";

			using var db = SqlManager.GetConnection;


			HAIFU_DETAIL_LAST haifu_detail_last = new HAIFU_DETAIL_LAST
			{
				BUMON = bumon,
				GYOSYA_ID_1 = gyasyaList[0],
				GYOSYA_NAME_1 = gyasyaList[1],
				BUSUU_1 = Int32.Parse(busuuList[0]),
				GYOSYA_ID_2 = gyasyaList[2],
				GYOSYA_NAME_2 = gyasyaList[3],
				BUSUU_2 = Int32.Parse(busuuList[1]),
				GYOSYA_ID_3 = gyasyaList[4],
				GYOSYA_NAME_3 = gyasyaList[5],
				BUSUU_3 = Int32.Parse(busuuList[2]),
				GYOSYA_ID_4 = gyasyaList[6],
				GYOSYA_NAME_4 = gyasyaList[7],
				BUSUU_4 = Int32.Parse(busuuList[3]),
				GYOSYA_ID_5 = gyasyaList[8],
				GYOSYA_NAME_5 = gyasyaList[9],
				BUSUU_5 = Int32.Parse(busuuList[4]),
				MODIFY_PGM = PGM,
				MODIFY_PERSON = userID,
				WC_OBJ_NO = wcobjno,
				HAIFUMOTO = haifumoto,
			};

			var result = db.Execute(str, haifu_detail_last);

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
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

			var str = $"";
			str += " INSERT INTO ";
			str += " HAIFU_DETAIL_LAST ";           // 業者配布履歴（最新）
			str += " VALUES ( ";                    // 
			str += " @WC_OBJ_NO, ";                 // 部門
			str += " @BUMON, ";                     // 業者ID1
			str += " @GYOSYA_ID_1, ";               // 業者名1
			str += " @GYOSYA_NAME_1, ";             // 部数１
			str += " @BUSUU_1, ";                   // 業者ID2
			str += " @GYOSYA_ID_2, ";               // 業者名2
			str += " @GYOSYA_NAME_2, ";             // 部数2
			str += " @BUSUU_2, ";                   // 業者ID3
			str += " @GYOSYA_ID_3, ";               // 業者名3
			str += " @GYOSYA_NAME_3, ";             // 部数3
			str += " @BUSUU_3, ";                   // 業者ID4
			str += " @GYOSYA_ID_4, ";               // 業者名4
			str += " @GYOSYA_NAME_4, ";             // 部数4
			str += " @BUSUU_4, ";                   // 業者ID5
			str += " @GYOSYA_ID_5, ";               // 業者名5
			str += " @GYOSYA_NAME_5, ";             // 部数5
			str += " @BUSUU_5, ";
			str += " @CREATE_PGM, ";
			str += " @CREATE_PERSON, ";
			str += " NOW(), ";
			str += " @MODIFY_PGM, ";
			str += " @MODIFY_PERSON, ";
			str += " NOW(), ";
			str += " @HAIFUMOTO ";
			str += " ) ";


			using var db = SqlManager.GetConnection;
			HAIFU_DETAIL_LAST haifu_detail_last = new HAIFU_DETAIL_LAST
			{
				WC_OBJ_NO = wcobjno,
				BUMON = bumon,
				GYOSYA_ID_1 = gyasyaList[0],
				GYOSYA_NAME_1 = gyasyaList[1],
				BUSUU_1 = Int32.Parse( busuuList[0]),
				GYOSYA_ID_2 = gyasyaList[2],
				GYOSYA_NAME_2 = gyasyaList[3],
				BUSUU_2 = Int32.Parse(busuuList[1]),
				GYOSYA_ID_3 = gyasyaList[4],
				GYOSYA_NAME_3 = gyasyaList[5],
				BUSUU_3 = Int32.Parse(busuuList[2]),
				GYOSYA_ID_4 = gyasyaList[6],
				GYOSYA_NAME_4 = gyasyaList[7],
				BUSUU_4 = Int32.Parse(busuuList[3]),
				GYOSYA_ID_5 = gyasyaList[8],
				GYOSYA_NAME_5 = gyasyaList[9],
				BUSUU_5 = Int32.Parse(busuuList[4]),
				CREATE_PGM = PGM,
				CREATE_PERSON = userID,
				MODIFY_PGM = PGM,
				MODIFY_PERSON = userID,
				HAIFUMOTO = haifumoto,
			};

			var result = db.Execute(str, haifu_detail_last);

			return result;
		}

	}
}
