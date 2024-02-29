using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{
	/// <summary>
	/// バッチB051201 データアクセス
	/// </summary>
	/// <remarks>20240109 劉  新規作成</remarks>
	public class B200101_DataAccess : SqlManager
	{

		/// <summary>
		/// 部品(浴室)と部品履歴(浴室)テーブルを検索し、部材マスタCSV情報を取得する
		/// </summary>
		/// <param name="zenkaiSyoriHitsuke">前回処理日時</param>
		/// <param name="konkaiSyoriHitsuke">今回処理日時</param>
		/// <returns>部材マスタCSV情報</returns>
		/// <remarks>20240109 劉  新規作成</remarks>
		public List<B_PART> SelBuzaiMasterCSVData(string zenkaiSyoriHitsuke, string konkaiSyoriHitsuke)
		{

			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;

			var result = db.Query<B_PART>($"Select BPV.HINMOKU ,BP.PART_NUMBER  ,BP.NAME ,BPV.SIYO  ,BPV.BUNRUI_CD ,BPV.NINTEI  ,CASE WHEN  BPV.CREATE_DATE >= to_timestamp( '{zenkaiSyoriHitsuke}' , 'yyyy/MM/dd hh24:mi:ss' ) THEN 'T'  ELSE 'S'  END AS KOUSINKUBUN FROM B_PART BP  INNER JOIN B_PART_VERSION BPV  ON BP.IDENTIFICATION = BPV.SUPER_IDENTIFICATION  WHERE BPV.MODIFY_DATE >= to_timestamp( '{zenkaiSyoriHitsuke}' , 'yyyy/MM/dd hh24:mi:ss' ) AND BPV.MODIFY_DATE < to_timestamp( '{konkaiSyoriHitsuke}' , 'yyyy/MM/dd hh24:mi:ss')  AND (BPV.PB_FLG = '1' OR BPV.UF_FLG = '1')  ").ToList();

			return result;
		}

		/// <summary>
		/// BOM(浴室)テーブル、部品(浴室)と部品履歴(浴室)テーブルを検索し、展開マスタCSV情報を取得する
		/// </summary>
		/// <returns>展開マスタCSV情報</returns>
		/// <remarks>20240109 劉  新規作成</remarks>
		public List<B_PART_VERSION> SelTenkaiMasterCSVData()
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;

			var result = db.Query<B_PART_VERSION>($" Select BPV.HINMOKU  ,BP.PART_NUMBER AS OYA_PART_NUMBER  ,BP_KO.PART_NUMBER AS KO_PART_NUMBER  ,BAC.NUM_OF_USE   ,BAC.SIYO   ,BPV_KO.BUNRUI_CD   FROM B_PART_VERSION BPV   INNER JOIN B_PART BP  ON BP.IDENTIFICATION = BPV.SUPER_IDENTIFICATION   INNER JOIN B_ASSEMBLY_COMPONENT BAC  ON BPV.IDENTIFICATION = BAC.UPPER_IDENTIFICATION   INNER JOIN B_PART_VERSION BPV_KO  ON BPV_KO.IDENTIFICATION = BAC.LOWER_IDENTIFICATION   INNER JOIN B_PART BP_KO   ON BP_KO.IDENTIFICATION = BPV_KO.SUPER_IDENTIFICATION   WHERE (BPV.PB_FLG = '1' OR BPV.UF_FLG = '1') ").ToList();

			return result;
		}

	}
}
