using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lixil.SNOW.Webservice.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class B051201Controller : ControllerBase
	{

		/// <summary>
		/// SNOWユーザーマスタの取得
		/// </summary>
		/// <param name="userID">ユーザーID</param>
		/// <returns></returns>
		/// <remarks>20181015 修(大連) 新規作成</remarks>
		[HttpGet(Name = "SelSnowUser2/{userID}")]
		public List<SNOW_USER> SelSnowUser2(string userID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<SNOW_USER> result = new List<SNOW_USER>();
			result = new B051201_BizLogic().SelSnowUser(userID);
			return result;
		}


		//TODO
		//	/// <summary>
		//	/// 部品(浴室)テーブルマスタの取得
		//	/// </summary>
		//	/// <param name="partNumber">品番</param>
		//	/// <returns>部品(浴室)テーブルデータ</returns>
		//	/// <remarks>20181015 修(大連) 新規作成</remarks>
		//	public DataTable SelBPART(Utilities.ConfigFileCommon.ConfigFileEntity partNumberEntity, string partNumber, List<Utilities.ConfigFileCommon.ConfigFileEntity> entities)
		//	{
		//		// イベントログ追加
		//		Inspector.Add(MyMethod.GetCurrentMethod.DeclaringType.FullName + "." + MyMethod.GetCurrentMethod.Name);

		//		var keyParams = Utilities.SqlConst.GetTableDefinition(Utilities.SqlConst.TableName.B_PART.ToString).KeyParams;
		//		entities.InsertRange(0, keyParams.Select(x => new Utilities.ConfigFileCommon.ConfigFileEntity(x)));

		//		var selSql = Utilities.ConfigFileCommon.GetSelectSQL(entities);
		//		var whereStr = new System.Text.StringBuilder();
		//		{
		//			var withBlock = whereStr;
		//			withBlock.AppendLine(" FROM B_PART BP ");      // 部品(浴室)テーブル
		//			withBlock.AppendLine(" WHERE BP.PART_NUMBER = :PART_NUMBER ");
		//		}
		//		selSql += Constants.vbCrLf + whereStr.ToString();
		//		var @params = Utilities.ConfigFileCommon.GetParams(new[] { partNumberEntity }.ToList,

		//{
		//			partNumber

		//});

		//		DataTable result = new DataTable();
		//		result = sqlManager.ExecuteReader(selSql, @params);
		//		sqlManager.Close();
		//		return result;
		//	}

		//	/// <summary>
		//	/// /// 部品履歴(浴室)テーブルの取得
		//	/// /// </summary>
		//	/// /// <param name="partNumber">品番</param>
		//	/// /// <returns>部品履歴(浴室)データ</returns>
		//	/// /// <remarks>20181015 修(大連) 新規作成</remarks>
		//	public void SelBPartVersion(Utilities.ConfigFileCommon.ConfigFileEntity partNumberEntity, string partNumber, List<Utilities.ConfigFileCommon.ConfigFileEntity> entities)
		//	{
		//		// イベントログ追加
		//		Inspector.Add(MyMethod.GetCurrentMethod.DeclaringType.FullName + "." + MyMethod.GetCurrentMethod.Name);

		//		var keyParams = Utilities.SqlConst.GetTableDefinition(Utilities.SqlConst.TableName.B_PART_VERSION.ToString).KeyParams;
		//		entities.InsertRange(0, keyParams.Select(x => new Utilities.ConfigFileCommon.ConfigFileEntity(x)));
		//		var tanaNoEntity = Utilities.SqlConst.GetTableDefinition(Utilities.SqlConst.TableName.B_PART_VERSION.ToString).columns.Item("TANA_NO");
		//		var kaihatuPersonEntity = Utilities.SqlConst.GetTableDefinition(Utilities.SqlConst.TableName.B_PART_VERSION.ToString).columns.Item("KAIHATU_PERSON");
		//		entities.Insert(0, new Utilities.ConfigFileCommon.ConfigFileEntity(kaihatuPersonEntity));
		//		entities.Insert(0, new Utilities.ConfigFileCommon.ConfigFileEntity(tanaNoEntity));

		//		var selSql = Utilities.ConfigFileCommon.GetSelectSQL(entities);
		//		var whereStr = new System.Text.StringBuilder();
		//		{
		//			var withBlock = whereStr;
		//			withBlock.AppendLine(" FROM B_PART BP ");                    // 部品(浴室)テーブル
		//			withBlock.AppendLine(" INNER JOIN B_PART_VERSION BPV ");     // 部品履歴(浴室)テーブル
		//			withBlock.AppendLine(" ON BP.IDENTIFICATION = BPV.SUPER_IDENTIFICATION ");   // 部品ID
		//			withBlock.AppendLine(" WHERE BP.PART_NUMBER = :PART_NUMBER ");    // 品番
		//		}
		//		selSql += Constants.vbCrLf + whereStr.ToString();
		//		var @params = Utilities.ConfigFileCommon.GetParams(new[] { partNumberEntity }.ToList,

		//{
		//			partNumber

		//});

		//		DataTable result = new DataTable();
		//		result = sqlManager.ExecuteReader(selSql, @params);
		//		sqlManager.Close();
		//		return result;
		//	}

		///// <summary>
		/////  /// 工場部品履歴(浴室)テーブル
		/////  /// </summary>
		/////  /// <param name="partNumber">品番</param>
		/////  /// <param name="bumonCd">(納入)部門ｺｰﾄﾞ</param>
		/////  /// <returns>工場部品履歴(浴室)データ</returns>
		/////  /// <remarks>20181015 修(大連) 新規作成</remarks>
		//public DataTable SelBKoujyouV(Utilities.ConfigFileCommon.ConfigFileEntity partNumberEntity, Utilities.ConfigFileCommon.ConfigFileEntity bumonCdEntity, string partNumber, string bumonCd, List<Utilities.ConfigFileCommon.ConfigFileEntity> entities)
		//{
		//	// イベントログ追加
		//	Inspector.Add(MyMethod.GetCurrentMethod.DeclaringType.FullName + "." + MyMethod.GetCurrentMethod.Name);

		//	var keyParams = Utilities.SqlConst.GetTableDefinition(Utilities.SqlConst.TableName.B_KOUJYOU__V.ToString).KeyParams;
		//	entities.InsertRange(0, keyParams.Select(x => new Utilities.ConfigFileCommon.ConfigFileEntity(x)));
		//	var supplierEntity = Utilities.SqlConst.GetTableDefinition(Utilities.SqlConst.TableName.B_KOUJYOU__V.ToString).columns.Item("SUPPLIER");
		//	var deliveryPersonEntity = Utilities.SqlConst.GetTableDefinition(Utilities.SqlConst.TableName.B_KOUJYOU__V.ToString).columns.Item("DELIVERY_PERSON");
		//	entities.Insert(0, new Utilities.ConfigFileCommon.ConfigFileEntity(deliveryPersonEntity));
		//	entities.Insert(0, new Utilities.ConfigFileCommon.ConfigFileEntity(supplierEntity));

		//	var selSql = Utilities.ConfigFileCommon.GetSelectSQL(entities);
		//	var whereStr = new System.Text.StringBuilder();
		//	{
		//		var withBlock = whereStr;
		//		withBlock.AppendLine(" FROM B_PART BP ");                     // 部品(浴室)テーブル
		//		withBlock.AppendLine(" INNER JOIN B_PART_VERSION BPV ");      // 部品履歴(浴室)テーブル
		//		withBlock.AppendLine(" ON BP.IDENTIFICATION = BPV.SUPER_IDENTIFICATION ");     // 部品ID
		//		withBlock.AppendLine(" INNER JOIN B_KIKAKU_PARTVERSION_KOUJYOU BKPK ");        // 部品履歴・工場部品履歴(浴室)テーブル
		//		withBlock.AppendLine(" ON BPV.IDENTIFICATION = BKPK.PLUS_IDENTIFICATION ");    // 部品履歴ID
		//		withBlock.AppendLine(" INNER JOIN B_KOUJYOU__V BKV ");        // 工場部品履歴(浴室)テーブル
		//		withBlock.AppendLine(" ON BKPK.MINUS_IDENTIFICATION = BKV.IDENTIFICATION ");   // 工場部品履歴ID
		//		withBlock.AppendLine(" WHERE BP.PART_NUMBER = :PART_NUMBER ");     // 品番
		//		withBlock.AppendLine("   AND BKV.BUMON_CD = :BUMON_CD ");    // (納入)部門ｺｰﾄﾞ
		//	}
		//	selSql += Constants.vbCrLf + whereStr.ToString();

		//	DataTable result = new DataTable();
		//	result = sqlManager.ExecuteReader(selSql, da.GetBKoujyouVParameter(partNumber, bumonCd));
		//	sqlManager.Close();
		//	return result;
		//}

		/// <summary>
		/// 工場マスタの取得
		/// </summary>
		/// <param name="bumon">部門</param>
		/// <param name="bumonCd">工場ID</param>
		/// <returns>工場マスタデータ</returns>
		/// <remarks>20181015 修(大連) 新規作成</remarks>
		[HttpGet(Name = "SelBUMON/{bumon}/{bumonCd}")]
		public List<BUMON_KOUJYOU> SelBUMON(string bumon, string bumonCd)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<BUMON_KOUJYOU> result = new List<BUMON_KOUJYOU>();
			result = new B051201_BizLogic().SelBUMON(bumon, bumonCd);

			return result;
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
		[HttpPost(Name = "InsPartUpdateRireki/{kinouId}/{userName}/{userId}/{hinban}/{hinmei}/{bumonCd}/{kaihatuPerson}/{series}")]
		public int InsPartUpdateRireki1(string kinouId, string userName, string userId, string hinban, string hinmei, string bumonCd, string kaihatuPerson, string series)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			var result = new B051201_BizLogic().InsPartUpdateRireki(kinouId, userName, userId, hinban, hinmei, bumonCd, kaihatuPerson, series);

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
		[HttpPost(Name = "InsPartUpdateRireki/{kinouId}/{userName}/{userId}/{tanaNo}/{hinban}/{hinmei}/{bumonCd}/{supplier}/{kaihatuPerson}/{deliveryPerson}/{updateProperty}/{maeData}/{atoData}/{{}")]
		public int InsPartUpdateRireki2(string kinouId, string userName, string userId, string tanaNo, string hinban, string hinmei, string bumonCd, string supplier, string kaihatuPerson, string deliveryPerson, string updateProperty, string maeData, string atoData, string series)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			var result = new B051201_BizLogic().InsPartUpdateRireki(kinouId, userName, userId, tanaNo, hinban, hinmei, bumonCd, supplier, kaihatuPerson, deliveryPerson, updateProperty, maeData, atoData, series);

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
		[HttpPost(Name = "InsPartUpdateRireki/{kinouId}/{userName}/{userId}/{hinban}/{hinmei}/{kaihatuPerson}/{updateProperty}/{atoData}/{series}")]
		public int InsPartUpdateRireki3(string kinouId, string userName, string userId, string hinban, string hinmei, string kaihatuPerson, string updateProperty, string atoData, string series)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			var result = new B051201_BizLogic().InsPartUpdateRireki(kinouId, userName, userId, hinban, hinmei, kaihatuPerson, updateProperty, atoData, series);

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
		[HttpPost(Name = "InsPartUpdateRireki/{kinouId}/{userName}/{userId}/{tanaNo}/{hinban}/{hinmei}/{bumonCd}/{kaihatuPerson}/{updateProperty}/{atoData}/{series}")]
		public int InsPartUpdateRireki4(string kinouId, string userName, string userId, string tanaNo, string hinban, string hinmei, string bumonCd, string kaihatuPerson, string updateProperty, string atoData, string series)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			var result = new B051201_BizLogic().InsPartUpdateRireki(kinouId, userName, userId, tanaNo, hinban, hinmei, bumonCd, kaihatuPerson, updateProperty, atoData, series);

			return result;
		}
	}
}
