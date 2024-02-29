using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.VisualBasic;
using System.Data;
using System.Globalization;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{
	/// <summary>
	/// BOM更新(洗面)
	/// </summary>
	/// <remarks>20240109 劉  新規作成</remarks>
	public class B051601_DataAccess : SqlManager
	{
		/// <summary>
		/// SNOWユーザーマスタの取得
		/// </summary>
		/// <param name="userID">ユーザーID</param>
		/// <returns>ユーザー</returns>
		/// <remarks>20240109 劉  新規作成</remarks>
		public List<SNOW_USER> SelSnowUser(string userId)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Query<SNOW_USER>($"SELECT SU.MAIL_ADDRESS FROM SNOW_USER SU WHERE SU.USER_ID ='{userId}'").ToList();

			return result;
		}

		/// <summary>
		/// 部品(洗面)と部品履歴(洗面)テーブルを検索し、部品履歴情報を取得する
		/// </summary>
		/// <param name="hinban">品番</param>
		/// <returns>部品履歴情報</returns>
		/// <remarks>20210216 修(ATO) 新規作成</remarks>
		public List<V_PART> SelBuhinRirekiID(string hinban)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Query<V_PART>($"Select VPV.IDENTIFICATION, VPV.KAIHATSU_TANTOU , VPV.DELIVELY_TANTOU , VPV.SERIES , VPV.HINMEI  , VPV.MBOMFLG , VP.PART_NUMBER  FROM V_PART VP INNER JOIN V_PART_VERSION VPV ON VP.IDENTIFICATION = VPV.SUPER_IDENTIFICATION  WHERE VP.PART_NUMBER = '{hinban}'").ToList();

			return result;
		}

		/// <summary>
		/// BOM(洗面)と部品履歴(洗面)テーブルを検索し、直下の下位部品履歴情報を取得する
		/// </summary>
		/// <param name="oyaBuhinRirekiID">上位部品履歴ID</param>
		/// <returns>部品履歴情報</returns>
		/// <remarks>20210416 修(ATO) 新規作成</remarks>
		public List<V_PART> SelKoBuhinRirekiJyoho(string oyaBuhinRirekiID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Query<V_PART>($"Select VPV.IDENTIFICATION, VPV.KAIHATSU_TANTOU , VPV.DELIVELY_TANTOU , VPV.SERIES , VPV.HINMEI  , VPV.MBOMFLG , VP.PART_NUMBER  FROM V_PART VP  ON VP.IDENTIFICATION = VPV.SUPER_IDENTIFICATION INNER JOIN V_ASSEMBLY_COMPONENT VAC ON VPV.IDENTIFICATION = VAC.LOWER_IDENTIFICATIONWHERE VAC.UPPER_IDENTIFICATION = '{oyaBuhinRirekiID}'").ToList();

			return result;
		}

		/// <summary>
		/// BOM(洗面)テーブルから指定された品番を削除する
		/// </summary>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <returns>処理結果</returns>
		/// <remarks>20210216 修(ATO) 新規作成</remarks>
		public int DelBACByOyaID(long oyaBuhinRirekiID)
		{

			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Execute($"DELETE V_ASSEMBLY_COMPONENT WHERE UPPER_IDENTIFICATION =   '{oyaBuhinRirekiID}'");

			return result;
		}

		/// <summary>
		/// BOM(洗面)テーブルから指定された品番を削除する
		/// </summary>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <param name="koBuhinRirekiID">子部品履歴ID</param>
		/// <returns>処理結果</returns>
		/// <remarks>20210216 修(ATO) 新規作成</remarks>
		public int DelBACByOyaAndKoID(long oyaBuhinRirekiID, long koBuhinRirekiID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Execute($"DELETE V_ASSEMBLY_COMPONENT WHERE UPPER_IDENTIFICATION = '{oyaBuhinRirekiID}' AND LOWER_IDENTIFICATION = '{koBuhinRirekiID}'");

			return result;
		}

		/// <summary>
		/// BOM(洗面)テーブルを検索し、BOM(洗面)情報を取得する
		/// </summary>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <param name="koBuhinRirekiID">子部品履歴ID</param>
		/// <returns>BOM(洗面)情報</returns>
		/// <remarks>20210216 修(ATO) 新規作成</remarks>
		public List<V_ASSEMBLY_COMPONENT> SelBACByOyaAndKoID(long oyaBuhinRirekiID, long koBuhinRirekiID)
		{

			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Query<V_ASSEMBLY_COMPONENT>($"Select VAC.IDENTIFICATION FROM V_ASSEMBLY_COMPONENT VAC WHERE VAC.UPPER_IDENTIFICATION = '{oyaBuhinRirekiID}' AND   VAC.LOWER_IDENTIFICATION = '{koBuhinRirekiID}'").ToList();

			return result;

		}

		/// <summary>
		/// 親部品履歴IDにより、BOM(洗面)テーブルを検索し、BOM(洗面)情報を取得する
		/// </summary>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <returns>BOM(洗面)情報</returns>
		/// <remarks>20210216 修(ATO) 新規作成</remarks>
		public List<V_ASSEMBLY_COMPONENT> SelBACByOyaID(long oyaBuhinRirekiID)
		{

			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Query<V_ASSEMBLY_COMPONENT>($"Select VAC.IDENTIFICATION FROM V_ASSEMBLY_COMPONENT VAC WHERE VAC.UPPER_IDENTIFICATION = '{oyaBuhinRirekiID}' ").ToList();

			return result;
		}

		/// <summary>
		/// BOM(洗面)情報を登録する
		/// </summary>
		/// <param name="identification">ID</param>
		/// <param name="oyaBuhinRirekiID">親部品履歴ID</param>
		/// <param name="koBuhinRirekiID">子部品履歴ID</param>
		/// <param name="amount">員数</param>
		/// <param name="lineNumber">行番号</param>
		/// <returns>BOM(洗面)情報</returns>
		/// <remarks>20210216 修(ATO) 新規作成</remarks>
		public int InsertBAC(long identification, long oyaBuhinRirekiID, long koBuhinRirekiID, long amount, long lineNumber)
		{

			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			var str = $"";
			str += " INSERT INTO V_ASSEMBLY_COMPONENT ";
			str += " (IDENTIFICATION, UPPER_IDENTIFICATION, LOWER_IDENTIFICATION, STRUCT_ORDER, NUM_OF_USE, PARTVERSION, MODIFY_COUNTER, SENSITIVITY";
			str += " VALUES(";
			str += "  :IDENTIFICATION, :UPPER_IDENTIFICATION, :LOWER_IDENTIFICATION, :STRUCT_ORDER, :NUM_OF_USE, :PARTVERSION, 0, 'AccessControl:assembly_component'";

			using var db = SqlManager.GetConnection;
			V_ASSEMBLY_COMPONENT v_assembly_component = new V_ASSEMBLY_COMPONENT
			{
				IDENTIFICATION = identification,
				UPPER_IDENTIFICATION = oyaBuhinRirekiID,
				LOWER_IDENTIFICATION = koBuhinRirekiID,
				STRUCT_ORDER = lineNumber,
				NUM_OF_USE = amount,
				PARTVERSION = "PartVersion:Vault:00001:" + oyaBuhinRirekiID
			};

			var result = db.Execute(str, v_assembly_component);
			return result;
		}


		/// <summary>
		/// 最大件数取得
		/// </summary>
		/// <returns></returns>
		public int GetPartUpdateRirekiMaxID()
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			var result = db.Query<int>($"SELECT isnull(MAX(ID), 0) FROM PART_UPDATERIREKI").ToList();

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
		/// <param name="kaihatuPerson">開発担当者</param>
		/// <param name="deliveryPerson">ﾃﾞﾘﾊﾞﾘｰ担当者</param>
		/// <param name="series">商品ｼﾘｰｽﾞ名</param>
		/// <param name="kousinkoumokumei">更新属性名</param>
		/// <param name="kousinmae">更新前のDBの値</param>
		/// <param name="kousingo">更新後の値</param>
		/// <returns>影響行数</returns>
		/// <remarks>20210406 修(ATO) 新規作成</remarks>
		public int InsPartUpdateRireki(string kinouId, string userName, string userId, string hinban, string hinmei, string kaihatuPerson, string deliveryPerson, string series, string kousinkoumokumei, string kousinmae, string kousingo)
		{

			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

			var str = $"";
			str += "INSERT INTO Part_UpdateRireki";
			str += "    (ID";                  // ID
			str += "    ,UPDATE_FLG";          // 種別
			str += "    ,UPDATE_PERSON";       // 更新者
			str += "    ,UPDATE_DATE";         // 更新日時
			str += "    ,HINBAN";              // 品番
			str += "    ,HINMEI";              // 部品名称
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
			str += "    ,MODIFY_DATE";        // 更新日時
			str += "VALUES";
			str += "   (:ID";
			str += "   ,:UPDATE_FLG";
			str += "   ,:UPDATE_PERSON";
			str += "   ,:UPDATE_DATE";
			str += "   ,:HINBAN";
			str += "   ,:HINMEI";
			str += "   ,:KAIHATSU_PERSON";
			str += "   ,:DELIVERY_PERSON";
			str += "   ,:UPDATE_PROPERTY";
			str += "   ,:MAE_DATA";
			str += "   ,:ATO_DATA";
			str += "   ,:SERIES";
			str += "   ,:CREATE_PGM";
			str += "   ,:CREATE_PERSON";
			str += "   , NOW()";
			str += "   ,:MODIFY_PGM";
			str += "   ,:MODIFY_PERSON";
			str += "   , NOW()";

			using var db = SqlManager.GetConnection;
			var maxID = GetPartUpdateRirekiMaxID();

			Part_UpdateRireki Part_UpdateRireki = new Part_UpdateRireki
			{
				ID = maxID + 1,
				UPDATE_FLG = "更新",
				UPDATE_PERSON = userName,
				UPDATE_DATE = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd")),
				HINBAN = hinban,
				HINMEI = hinmei,
				KAIHATSU_PERSON = kaihatuPerson,
				DELIVERY_PERSON = deliveryPerson,
				UPDATE_PROPERTY = kousinkoumokumei,
				MAE_DATA = kousinmae,
				ATO_DATA = kousingo,
				SERIES = series,
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
