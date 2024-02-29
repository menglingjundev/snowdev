using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.VisualBasic;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{

	/// <summary>
	/// バッチB051201 データアクセス
	/// </summary>
	/// <remarks>20181015 修(大連) 新規作成</remarks>
	public class B051201_DataAccess : SqlManager
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


		//TODO
		/// <summary>
		///工場部品履歴(浴室)テーブル
		///</summary>
		///<param name="partNumber">品番</param>
		///<param name="bumonCd">(納入)部門ｺｰﾄﾞ</param>
		///<returns>工場部品履歴(浴室)用パラメータ</returns>
		///<remarks>20181015 修(大連) 新規作成</remarks>
		//public IEnumerable<object> GetBKoujyouVParameter(string partNumber, string bumonCd)
		//{
		//	// イベントログ追加
		//	Inspector.Add(MyMethod.GetCurrentMethod.DeclaringType.FullName + "." + MyMethod.GetCurrentMethod.Name);

		//	List<OracleParameter> @params = new List<OracleParameter>();
		//	{
		//		var withBlock = @params;
		//		// 部門
		//		withBlock.Add(new OracleParameter() { ParameterName = "PART_NUMBER", OracleDbType = OracleDbType.Varchar2, Size = 60, Value = partNumber });
		//		// 工場ID
		//		withBlock.Add(new OracleParameter() { ParameterName = "BUMON_CD", OracleDbType = OracleDbType.Varchar2, Size = 6, Value = bumonCd });
		//	}

		//	return @params;
		//}


		/// <summary>
		///工場マスタの取得
		///</summary>
		///<param name="bumon">部門</param>
		///<param name="bumonCd">工場ID</param>
		///<returns>工場マスタデータ</returns>
		///<remarks>20181015 修(大連) 新規作成</remarks>
		public List<BUMON_KOUJYOU> SelBUMON(string bumon, string bumonCd)
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Query<BUMON_KOUJYOU>($"SELECT BK.BUMON_CD ,BK.TIKU_CD FROM BUMON_KOUJYOU BK WHERE BK.BUMON ='{bumon}'  AND BK.BUMON_CD = '{bumonCd}'  AND BK.DELETE_FLG = 0").ToList();

			return result;
		}


		/// <summary>
		/// 最大件数取得
		/// </summary>
		/// <returns></returns>
		public string GetPartUpdateRirekiMaxID()
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Query<string>($"SELECT isnull(MAX(ID), 0) FROM PART_UPDATERIREKI").ToList();

			return result[0];
		}


		/// <summary>
		/// 部品更新履歴テーブル登録(部品登録)
		/// </summary>
		/// <param name="kinouId">機能ID</param>
		/// <param name="userName">ユーザー名</param>
		/// <param name="userId">ユーザーID</param>
		/// <param name="hinban">品番</param>
		/// <param name="hinmei">部品名称</param>
		/// <param name="bumonCd">（納入)部門CD (※工場部品履歴登録時のみ)</param>
		/// <param name="kaihatuPerson">開発担当者</param>
		/// <param name="series">商品ｼﾘｰｽﾞ名</param>
		/// <returns>影響行数</returns>
		/// <remarks>20181015 修(大連) 新規作成</remarks>
		public int InsPartUpdateRireki(string kinouId, string userName, string userId, object hinban, object hinmei, object bumonCd, object kaihatuPerson, object series)
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

			var str = $"";
			str += "INSERT INTO Part_UpdateRireki";
			str += "    (ID";                  // ID
			str += "    ,UPDATE_FLG";          // 種別
			str += "    ,UPDATE_PERSON";       // 更新者
			str += "    ,UPDATE_DATE";         // 更新日時
			str += "    ,HINBAN";              // 品番
			str += "    ,HINMEI";              // 部品名称
			str += "    ,BUMON_CD";            // （納入)部門CD
			str += "    ,KAIHATSU_PERSON";     // 開発担当者
			str += "    ,SERIES";              // 商品ｼﾘｰｽﾞ名
			str += "    ,CREATE_PGM";          // 登録機能ID
			str += "    ,CREATE_PERSON";       // 登録ユーザーID
			str += "    ,CREATE_DATE";         // 登録日時
			str += "    ,MODIFY_PGM";          // 更新機能I	D
			str += "    ,MODIFY_PERSON";       // 更新ユーザーID
			str += "    ,MODIFY_DATE)";        // 更新日時
			str += "VALUES";
			str += "   (@ID";
			str += "   ,@UPDATE_FLG";
			str += "   ,@UPDATE_PERSON";
			str += "   ,@UPDATE_DATE";
			str += "   ,@HINBAN";
			str += "   ,@HINMEI";
			str += "   ,@BUMON_CD";
			str += "   ,@KAIHATSU_PERSON";
			str += "   ,@SERIES";
			str += "   ,@CREATE_PGM";
			str += "   ,@CREATE_PERSON";
			str += "   ,NOW()";
			str += "   ,@MODIFY_PGM";
			str += "   ,@MODIFY_PERSON";
			str += "   ,NOW())";

			var maxID = GetPartUpdateRirekiMaxID();

			using var db = SqlManager.GetConnection;
			Part_UpdateRireki Part_UpdateRireki = new Part_UpdateRireki
			{
				ID = Int32.Parse(maxID) + 1,
				UPDATE_FLG = "追加",
				UPDATE_PERSON = userName,
				UPDATE_DATE = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd")),
				HINBAN = (string)hinban,
				HINMEI = (string)hinmei,
				BUMON_CD = (string)bumonCd,
				KAIHATSU_PERSON = (string)kaihatuPerson,
				SERIES = (string)series,
				CREATE_PGM = kinouId,
				CREATE_PERSON = userId + ":" + userName,
				MODIFY_PGM = kinouId,
				MODIFY_PERSON = userId + ":" + userName,
			};

			var result = db.Execute(str, Part_UpdateRireki);

			return result;
		}


		/// <summary>
		/// 部品更新履歴テーブル登録(部品登録以外)
		/// </summary>
		/// <param name="kinouId">機能ID</param>
		/// <param name="userName">ユーザー名</param>
		/// <param name="userId">ユーザーID</param>
		/// <param name="tanaNo">棚NO (部品履歴(浴室))</param>
		/// <param name="hinban">品番</param>
		/// <param name="hinmei">部品名称</param>
		/// <param name="bumonCd">（納入)部門CD</param>
		/// <param name="supplier">仕入先名称 (工場部品履歴(浴室))</param>
		/// <param name="kaihatuPerson">開発担当者 (部品履歴(浴室))</param>
		/// <param name="deliveryPerson">ﾃﾞﾘﾊﾞﾘｰ担当者 (工場部品履歴(浴室))</param>
		/// <param name="updateProperty">更新項目</param>
		/// <param name="maeData">更新前</param>
		/// <param name="atoData">更新後</param>
		/// <param name="series">商品ｼﾘｰｽﾞ名</param>
		/// <returns>影響行数</returns>
		/// <remarks>20181015 修(大連) 新規作成</remarks>
		public int InsPartUpdateRireki(string kinouId, string userName, string userId, object tanaNo, object hinban, object hinmei, object bumonCd, object supplier, object kaihatuPerson, object deliveryPerson, object updateProperty, object maeData, object atoData, object series)
		{

			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

			var str = $"";
			str += "INSERT INTO Part_UpdateRireki";
			str += "    (ID";                  // ID
			str += "    ,UPDATE_FLG";          // 種別
			str += "    ,UPDATE_PERSON";       // 更新者
			str += "    ,UPDATE_DATE";         // 更新日時
			str += "    ,TANA_NO";             // 棚NO
			str += "    ,HINBAN";              // 品番
			str += "    ,HINMEI";              // 部品名称
			str += "    ,BUMON_CD";            // （納入部門CD
			str += "    ,SUPPLIER";            // 仕入先名称
			str += "    ,KAIHATSU_PERSON";     // 開発担当者
			str += "    ,DELIVERY_PERSON";     // ﾃﾞﾘﾊﾞﾘｰ担当者
			str += "    ,UPDATE_PROPERTY";     // 更新項目
			str += "    ,MAE_DATA";            // 更新前
			str += "    ,ATO_DATA";            // 更新後
			str += "    ,SERIES";              // 商品ｼﾘｰｽﾞ名
			str += "    ,CREATE_PGM";          // 登録機能ID
			str += "    ,CREATE_PERSON";       // 登録ユーザーID
			str += "    ,CREATE_DATE";         // 登録日時
			str += "    ,MODIFY_PGM";          // 更新機能ID
			str += "    ,MODIFY_PERSON";       // 更新ユーザーID
			str += "    ,MODIFY_DATE";         // 更新日時
			str += "VALUES";
			str += "   (@ID";
			str += "   ,@UPDATE_FLG";
			str += "   ,@UPDATE_PERSON";
			str += "   ,@UPDATE_DATE";
			str += "   ,@TANA_NO";
			str += "   ,@HINBAN";
			str += "   ,@HINMEI";
			str += "   ,@BUMON_CD";
			str += "   ,@SUPPLIER";
			str += "   ,@KAIHATSU_PERSON";
			str += "   ,@DELIVERY_PERSON";
			str += "   ,@UPDATE_PROPERTY";
			str += "   ,@MAE_DATA";
			str += "   ,@ATO_DATA";
			str += "   ,@SERIES";
			str += "   ,@CREATE_PGM";
			str += "   ,@CREATE_PERSON";
			str += "   ,NOW()";
			str += "   ,@MODIFY_PGM";
			str += "   ,@MODIFY_PERSON";
			str += "   ,NOW()";

			var maxID = GetPartUpdateRirekiMaxID();

			using var db = SqlManager.GetConnection;
			Part_UpdateRireki Part_UpdateRireki = new Part_UpdateRireki
			{
				ID = Int32.Parse(maxID) + 1,
				UPDATE_FLG = "更新",
				UPDATE_PERSON = userName,
				UPDATE_DATE = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd")),
				TANA_NO = (string)tanaNo,
				HINBAN = (string)hinban,
				HINMEI = (string)hinmei,
				BUMON_CD = (string)bumonCd,
				SUPPLIER = (string)supplier,
				KAIHATSU_PERSON = (string)kaihatuPerson,
				DELIVERY_PERSON = (string)deliveryPerson,
				UPDATE_PROPERTY = (string)updateProperty,
				MAE_DATA = (string)maeData,
				ATO_DATA = (string)atoData,
				SERIES = (string)series,
				CREATE_PGM = kinouId,
				CREATE_PERSON = userId + ":" + userName,
				MODIFY_PGM = kinouId,
				MODIFY_PERSON = userId + ":" + userName,
			};

			var result = db.Execute(str, Part_UpdateRireki);

			return result;
		}

		/// <summary>
		/// 部品更新履歴テーブル登録(部品登録時の工場部品履歴登録)
		/// </summary>
		/// <param name="kinouId">機能ID</param>
		/// <param name="userName">ユーザー名</param>
		/// <param name="userId">ユーザーID</param>
		/// <param name="hinban">品番</param>
		/// <param name="hinmei">部品名称</param>
		/// <param name="kaihatuPerson">開発担当者 (部品履歴(浴室))</param>
		/// <param name="updateProperty">更新項目</param>
		/// <param name="atoData">更新後</param>
		/// <param name="series">商品ｼﾘｰｽﾞ名</param>
		/// <returns>影響行数</returns>
		/// <remarks>20181015 修(大連) 新規作成</remarks>
		public int InsPartUpdateRireki(string kinouId, string userName, string userId, object hinban, object hinmei, object kaihatuPerson, object updateProperty, object atoData, object series)
		{

			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

			var str = $"";
			str += "INSERT INTO Part_UpdateRireki";
			str += "    (ID";          // ID
			str += "    ,UPDATE_FLG";          // 種別
			str += "    ,UPDATE_PERSON";       // 更新者
			str += "    ,UPDATE_DATE";         // 更新日時
			str += "    ,HINBAN";              // 品番
			str += "    ,HINMEI";              // 部品名称
			str += "    ,KAIHATSU_PERSON";     // 開発担当者
			str += "    ,UPDATE_PROPERTY";     // 更新項目
			str += "    ,ATO_DATA";            // 更新後
			str += "    ,SERIES";              // 商品ｼﾘｰｽﾞ名
			str += "    ,CREATE_PGM";          // 登録機能ID
			str += "    ,CREATE_PERSON";       // 登録ユーザーID
			str += "    ,CREATE_DATE";         // 登録日時
			str += "    ,MODIFY_PGM";          // 更新機能ID
			str += "    ,MODIFY_PERSON";       // 更新ユーザーID
			str += "    ,MODIFY_DATE";        // 更新日時
			str += "VALUES";
			str += "   (@ID";
			str += "   ,@UPDATE_FLG";
			str += "   ,@UPDATE_PERSON";
			str += "   ,@UPDATE_DATE";
			str += "   ,@HINBAN";
			str += "   ,@HINMEI";
			str += "   ,@KAIHATSU_PERSON";
			str += "   ,@UPDATE_PROPERTY";
			str += "   ,@ATO_DATA";
			str += "   ,@SERIES";
			str += "   ,@CREATE_PGM";
			str += "   ,@CREATE_PERSON";
			str += "   ,NOW()";
			str += "   ,@MODIFY_PGM";
			str += "   ,@MODIFY_PERSON";
			str += "   ,NOW()";

			var maxID = GetPartUpdateRirekiMaxID();

			using var db = SqlManager.GetConnection;
			Part_UpdateRireki Part_UpdateRireki = new Part_UpdateRireki
			{
				ID = Int32.Parse(maxID) + 1,
				UPDATE_FLG = "追加",
				UPDATE_PERSON = userName,
				UPDATE_DATE = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd")),
				HINBAN = (string)hinban,
				HINMEI = (string)hinmei,
				KAIHATSU_PERSON = (string)kaihatuPerson,
				UPDATE_PROPERTY = (string)updateProperty,
				ATO_DATA = (string)atoData,
				SERIES = (string)series,
				CREATE_PGM = kinouId,
				CREATE_PERSON = userId + ":" + userName,
				MODIFY_PGM = userId,
				MODIFY_PERSON = userId + ":" + userName,
			};
			var result = db.Execute(str, Part_UpdateRireki);

			return result;
		}


		/// <summary>
		/// 部品更新履歴テーブル登録(部品登録以外時の工場部品履歴登録)
		/// </summary>
		/// <param name="kinouId">機能ID</param>
		/// <param name="userName">ユーザー名</param>
		/// <param name="userId">ユーザーID</param>
		/// <param name="tanaNo">棚NO</param>
		/// <param name="hinban">品番</param>
		/// <param name="hinmei">部品名称</param>
		/// <param name="bumonCd">（納入)部門CD</param>
		/// <param name="kaihatuPerson">開発担当者 (部品履歴(浴室))</param>
		/// <param name="updateProperty">更新項目</param>
		/// <param name="atoData">更新後</param>
		/// <param name="series">商品ｼﾘｰｽﾞ名</param>
		/// <returns>影響行数</returns>
		/// <remarks>20181015 修(大連) 新規作成</remarks>
		public int InsPartUpdateRireki(string kinouId, string userName, string userId, object tanaNo, object hinban, object hinmei, object bumonCd, object kaihatuPerson, object updateProperty, object atoData, object series)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

			var str = $"";
			str += "INSERT INTO Part_UpdateRireki";
			str += "    (ID";          // 種別
			str += "    ,UPDATE_FLG";          // 種別
			str += "    ,UPDATE_PERSON";       // 更新者
			str += "    ,UPDATE_DATE";         // 更新日時
			str += "    ,TANA_NO";              // 棚NO
			str += "    ,HINBAN";              // 品番
			str += "    ,HINMEI";              // 部品名称
			str += "    ,BUMON_CD";            // （納入部門CD
			str += "    ,KAIHATSU_PERSON";     // 開発担当者
			str += "    ,UPDATE_PROPERTY";     // 更新項目
			str += "    ,ATO_DATA";            // 更新後
			str += "    ,SERIES";              // 商品ｼﾘｰｽﾞ名
			str += "    ,CREATE_PGM";          // 登録機能ID
			str += "    ,CREATE_PERSON";       // 登録ユーザーID
			str += "    ,CREATE_DATE";         // 登録日時
			str += "    ,MODIFY_PGM";          // 更新機能ID
			str += "    ,MODIFY_PERSON";       // 更新ユーザーID
			str += "    ,MODIFY_DATE";        // 更新日時
			str += "VALUES";
			str += "   (@ID";
			str += "   ,@UPDATE_FLG";
			str += "   ,@UPDATE_PERSON";
			str += "   ,@UPDATE_DATE";
			str += "   ,@TANA_NO";
			str += "   ,@HINBAN";
			str += "   ,@HINMEI";
			str += "   ,@BUMON_CD";
			str += "   ,@KAIHATSU_PERSON";
			str += "   ,@UPDATE_PROPERTY";
			str += "   ,@ATO_DATA";
			str += "   ,@SERIES";
			str += "   ,@CREATE_PGM";
			str += "   ,@CREATE_PERSON";
			str += "   ,NOW()";
			str += "   ,@MODIFY_PGM";
			str += "   ,@MODIFY_PERSON";
			str += "   ,NOW()";

			var maxID = GetPartUpdateRirekiMaxID();

			using var db = SqlManager.GetConnection;
			Part_UpdateRireki Part_UpdateRireki = new Part_UpdateRireki
			{
				ID = Int32.Parse(maxID) + 1,
				UPDATE_FLG = "更新",
				UPDATE_PERSON = userName,
				UPDATE_DATE = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd")),
				TANA_NO = (string)tanaNo,
				HINBAN = (string)hinban,
				HINMEI = (string)hinmei,
				BUMON_CD = (string)bumonCd,
				KAIHATSU_PERSON = (string)kaihatuPerson,
				UPDATE_PROPERTY = (string)updateProperty,
				ATO_DATA = (string)atoData,
				SERIES = (string)series,
				CREATE_PGM = kinouId,
				CREATE_PERSON = userId + ":" + userName,
				MODIFY_PGM = kinouId,
				MODIFY_PERSON = userId + ":" + userName,
			};
			var result = db.Execute(str, Part_UpdateRireki);

			return result;
		}

	}
}
