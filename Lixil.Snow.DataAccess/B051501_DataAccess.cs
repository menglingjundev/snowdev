using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.VisualBasic;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{
	/// <summary>
	/// 部品更新(洗面)
	/// </summary>
	/// <remarks>20240109 劉  新規作成</remarks>
	public class B051501_DataAccess : SqlManager
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
		/// 最大件数取得
		/// </summary>
		/// <returns></returns>
		public int GetPartUpdateRirekiMaxID()
		{
			// イベントログ追加
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
		/// <param name="kousingo">インプットファイルの値</param>
		/// <returns>影響行数</returns>
		/// <remarks>20240109 劉  新規作成</remarks>
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
			str += "    ,MODIFY_DATE";         // 更新日時
			str += "VALUES";
			str += "   (@ID";
			str += "   ,@UPDATE_FLG";
			str += "   ,@UPDATE_PERSON";
			str += "   ,@UPDATE_DATE";
			str += "   ,@HINBAN";
			str += "   ,@HINMEI";
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
