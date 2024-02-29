using Lixil.Snow.DataAccess;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.VisualBasic;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.BizLogic
{
	/// <summary>
	///  部品更新属性チェック(浴室)
	/// </summary>
	public class B051101_BizLogic
	{

		//SQL文実行用
		private B051101_DataAccess da;

		public B051101_BizLogic()
		{
			da = new B051101_DataAccess();
		}

		/// <summary>
		/// SNOWユーザーマスタの取得
		/// </summary>
		/// <param name="userID">ユーザーID</param>
		/// <returns></returns>
		/// <remarks>20240109 劉 新規作成</remarks>
		public List<SNOW_USER> SelSnowUser(string userID)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<SNOW_USER> result = new List<SNOW_USER>();
			result = da.SelSnowUser(userID);
			da.Close();
			return result;
		}

		/// <summary>
		/// 部品(浴室)テーブルマスタの取得
		/// </summary>
		/// <param name="hinban">品番</param>
		/// <returns>部品(浴室)テーブルデータ</returns>
		/// <remarks>20240109 劉 新規作成</remarks>
		public List<B_PART> SelBPART(string hinban)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<B_PART> result = new List<B_PART>();
			result = da.SelBPART(hinban);
			da.Close();
			return result;
		}

		//TODO
		///// <summary>
		///// チェック属性を取得
		///// </summary>
		///// <param name="sqlStr">SQL文</param>
		///// <param name="partNumberEntity">品番</param>
		///// <param name="bumonCdEntity"></param>
		///// <param name="partNumber"></param>
		///// <param name="bumonCd"></param>
		///// <returns></returns>
		///// <remarks></remarks>
		//public void SelCheckParam(string sqlStr, Utilities.ConfigFileCommon.ConfigFileEntity partNumberEntity, Utilities.ConfigFileCommon.ConfigFileEntity bumonCdEntity, string partNumber, string bumonCd)
		//{
		//	// イベントログ追加
		//	Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

		//	System.Text.StringBuilder whereStr = new System.Text.StringBuilder();
		//	{
		//		var withBlock = whereStr;
		//		withBlock.AppendLine(" FROM B_PART BP ");                    // 部品(浴室)テーブル
		//		withBlock.AppendLine(" INNER JOIN B_PART_VERSION BPV ");      // 部品履歴(浴室)テーブル
		//		withBlock.AppendLine(" ON BP.IDENTIFICATION = BPV.SUPER_IDENTIFICATION ");     // 部品ID
		//		withBlock.AppendLine(" INNER JOIN B_KIKAKU_PARTVERSION_KOUJYOU BKPK ");        // 部品履歴・工場部品履歴(浴室)テーブル
		//		withBlock.AppendLine(" ON BPV.IDENTIFICATION = BKPK.PLUS_IDENTIFICATION ");     // 部品履歴ID
		//		withBlock.AppendLine(" INNER JOIN B_KOUJYOU__V BKV ");        // 工場部品履歴(浴室)テーブル
		//		withBlock.AppendLine(" ON BKPK.MINUS_IDENTIFICATION = BKV.IDENTIFICATION ");          // 工場部品履歴ID
		//		withBlock.AppendLine(" WHERE BP.PART_NUMBER = :PART_NUMBER ");     // 品番
		//		withBlock.AppendLine("   AND BKV.BUMON_CD = :BUMON_CD ");    // (納入)部門ｺｰﾄﾞ
		//	}
		//	sqlStr += Constants.vbCrLf + whereStr.ToString();
		//	var @params = Utilities.ConfigFileCommon.GetParams(new[] { partNumberEntity, bumonCdEntity }.ToList,{ partNumber,bumonCd });
		//	DataTable result = new DataTable();
		//	result = sqlManager.ExecuteReader(sqlStr, @params);
		//	sqlManager.Close();

		//	return result;
		//}



	}
}
