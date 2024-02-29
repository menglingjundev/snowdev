using Lixil.Snow.DataAccess;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.VisualBasic;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.BizLogic
{
	/// <summary>
	/// 部品更新(洗面)
	/// </summary>
	public class B051501_BizLogic
	{

		//SQL文実行用
		private B051501_DataAccess da;

		public B051501_BizLogic()
		{
			da = new B051501_DataAccess();
		}

		/// <summary>
		/// SNOWユーザーマスタの取得
		/// </summary>
		/// <param name="userID">ユーザーID</param>
		/// <returns></returns>
		/// <remarks>20240109 劉 新規作成</remarks>
		public List<SNOW_USER> SelSnowUser(string userID)
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<SNOW_USER> result = new List<SNOW_USER>();
			result = da.SelSnowUser(userID);
			da.Close();
			return result;
		}

		//TODO
		/// <summary>
		/// 部品(洗面)テーブルマスタの取得
		/// </summary>
		/// <param name="partNumberEntity">品番</param>
		/// <param name="partNumber">品番</param>
		/// <param name="entities">検索対象</param>
		/// <returns>部品(洗面)テーブルデータ</returns>
		/// <remarks>20240109 劉 新規作成</remarks>
		//    Public Function SelVPART(ByVal partNumberEntity As Utilities.ConfigFileCommon.ConfigFileEntity,
		//							 ByVal partNumber As String,
		//							 ByVal entities As List(Of Utilities.ConfigFileCommon.ConfigFileEntity)) As DataTable
		//        'イベントログ追加

		//		Inspector.Add(MyMethod.GetCurrentMethod.DeclaringType.FullName & "." & MyMethod.GetCurrentMethod.Name)

		//        Dim keyParams = Utilities.SqlConst.GetTableDefinition(Utilities.SqlConst.TableName.V_PART.ToString).KeyParams

		//		entities.InsertRange(0, keyParams.Select(Function(x) New Utilities.ConfigFileCommon.ConfigFileEntity(x)))

		//        Dim selSql = Utilities.ConfigFileCommon.GetSelectSQL(entities)

		//		Dim whereStr = New System.Text.StringBuilder
		//		With whereStr
		//			.AppendLine(" FROM V_PART VP ")      '部品(洗面)テーブル
		//            .AppendLine(" WHERE VP.PART_NUMBER = :PART_NUMBER ")

		//		End With

		//		selSql &= vbCrLf & whereStr.ToString
		//		Dim params = Utilities.ConfigFileCommon.GetParams({partNumberEntity
		//	}.ToList, {partNumber
		//})

		//        Dim result As New DataTable
		//        result = sqlManager.ExecuteReader(selSql, params)
		//        sqlManager.Close()
		//        Return result
		//    End Function


		/// <summary>
		/// 部品履歴(洗面)テーブルの取得
		/// </summary>
		/// <param name="partNumberEntity">品番</param>
		/// <param name="partNumber">品番</param>
		/// <param name="entities">検索対象</param>
		/// <returns>工場部品履歴(洗面)データ</returns>
		/// <remarks>20240109 劉 新規作成</remarks>
		//    Public Function SelVPartVersion(ByVal partNumberEntity As Utilities.ConfigFileCommon.ConfigFileEntity,
		//									ByVal partNumber As String,
		//									ByVal entities As List(Of Utilities.ConfigFileCommon.ConfigFileEntity)) As DataTable
		//        'イベントログ追加

		//		Inspector.Add(MyMethod.GetCurrentMethod.DeclaringType.FullName & "." & MyMethod.GetCurrentMethod.Name)

		//        Dim keyParams = Utilities.SqlConst.GetTableDefinition(Utilities.SqlConst.TableName.V_PART_VERSION.ToString).KeyParams

		//		entities.InsertRange(0, keyParams.Select(Function(x) New Utilities.ConfigFileCommon.ConfigFileEntity(x)))
		//        Dim kaihatuTantouEntity = Utilities.SqlConst.GetTableDefinition(Utilities.SqlConst.TableName.V_PART_VERSION.ToString).columns.Item("KAIHATU_TANTOU")

		//		Dim deliveryPersonEntity = Utilities.SqlConst.GetTableDefinition(Utilities.SqlConst.TableName.V_PART_VERSION.ToString).columns.Item("DELIVELY_TANTOU")

		//		Dim seriesEntity = Utilities.SqlConst.GetTableDefinition(Utilities.SqlConst.TableName.V_PART_VERSION.ToString).columns.Item("SERIES")

		//		entities.Insert(0, New Utilities.ConfigFileCommon.ConfigFileEntity(seriesEntity))
		//        entities.Insert(0, New Utilities.ConfigFileCommon.ConfigFileEntity(deliveryPersonEntity))
		//        entities.Insert(0, New Utilities.ConfigFileCommon.ConfigFileEntity(kaihatuTantouEntity))

		//        Dim selSql = Utilities.ConfigFileCommon.GetSelectSQL(entities)

		//		Dim whereStr = New System.Text.StringBuilder
		//		With whereStr
		//			.AppendLine(" FROM V_PART VP ")                                     '部品(洗面)テーブル
		//            .AppendLine(" INNER JOIN V_PART_VERSION VPV ")                      '部品履歴(洗面)テーブル
		//            .AppendLine(" ON VP.IDENTIFICATION = VPV.SUPER_IDENTIFICATION ")    '部品ID
		//            .AppendLine(" WHERE VP.PART_NUMBER = :PART_NUMBER ")                '品番
		//        End With

		//		selSql &= vbCrLf & whereStr.ToString
		//		Dim params = Utilities.ConfigFileCommon.GetParams({partNumberEntity
		//	}.ToList, {partNumber
		//})

		//        Dim result As New DataTable
		//        result = sqlManager.ExecuteReader(selSql, params)
		//        sqlManager.Close()
		//        Return result
		//    End Function

		/// <summary>
		/// 部品更新履歴テーブル登録(部品登録)
		/// </summary>
		/// <param name="kinouId">機能ID</param>
		/// <param name="userName">ユーザー名</param>
		/// <param name="userId">ユーザーID</param>
		/// <param name="hinban">品番</param>
		/// <param name="hinmei">部品名称</param>
		/// <param name="kaihatuTantou">開発担当者</param>
		/// <param name="deliveryPerson">デリバリー担当者</param>
		/// <param name="series">ｼﾘｰｽﾞ名</param>
		/// <param name="kousinkoumokumei">更新属性名</param>
		/// <param name="kousinmae">更新前のDBの値</param>
		/// <param name="kousingo">インプットファイルの値</param>
		/// <returns>影響行数</returns>
		/// <remarks>20240109 劉 新規作成</remarks>
		public int InsPartUpdateRireki(string kinouId, string userName, string userId, string hinban, string hinmei, string kaihatuTantou, string deliveryPerson, string series, string kousinkoumokumei, string kousinmae, string kousingo)
		{

			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			int result = 0;
			result = da.InsPartUpdateRireki(kinouId, userName, userId, hinban, hinmei, kaihatuTantou, deliveryPerson, series, kousinkoumokumei, kousinmae, kousingo);
			da.Close();
			return result;
		}
	}
}
