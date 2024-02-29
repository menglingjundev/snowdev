using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace Lixil.Snow.DataAccess
{
	/// <summary>
	/// バッチB051201 データアクセス
	/// </summary>
	/// <remarks>20240109 劉  新規作成</remarks>
	public class P030201_DataAccess : SqlManager
	{
		/// <summary>
		/// 変更通知番号の取得
		/// </summary>
		/// <param name="contestInfo">コンテキスト</param>
		/// <returns>業者配布履歴・ヘッダテーブル</returns>
		/// <remarks>20240109 劉  新規作成</remarks>
		public List<HAIFU_HEADER> SelContestData(List<string> contestInfo)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;

			var wherestr = string.Empty;
			for (int i = 0; i < contestInfo.Count; i++)
			{
				if (i == 0)
				{
					wherestr = "(HAIFU_HEADER.CONTEXT = '" + contestInfo[i] + "'";
				}
				else
				{
					wherestr += " OR HAIFU_HEADER.CONTEXT = '" + contestInfo[i] + "'";
				}

			}
			wherestr += ")";


			var result = db.Query<HAIFU_HEADER>($"SELECT DISTINCT(HAIFU_HEADER.WC_ECN_NO FROM HAIFU_HEADER HAIFU_HEADER LEFT JOIN ( SELECT HD_DETAIL.KBN, HD.* FROM HAIFU_DETAIL HD LEFT JOIN ( SELECT DISTINCT DETAIL.WC_ECN_NO, DETAIL.WC_OBJ_NO, 1 AS KBN FROM HAIFU_DETAIL DETAIL WHERE DETAIL.STATUS = '{AppConst.Status.HAIFUYOTEI}' HD_DETAIL ON HD.WC_ECN_NO = HD_DETAIL.WC_ECN_NO AND HD.WC_OBJ_NO = HD_DETAIL.WC_OBJ_NO HAIFU_DETAIL ON HAIFU_HEADER.WC_ECN_NO = HAIFU_DETAIL.WC_ECN_NO AND HAIFU_HEADER.WC_OBJ_NO = HAIFU_DETAIL.WC_OBJ_NO WHERE " + wherestr + "AND (HAIFU_DETAIL.WC_ECN_NO IS NULL OR HAIFU_DETAIL.KBN = 1)  ORDER BY HAIFU_HEADER.WC_ECN_NO").ToList();
			return result;
		}

		/// <summary>
		/// 業者配布履歴の取得
		/// </summary>
		/// <param name="contestInfo">コンテキスト</param>
		/// <param name="wcEcnNo">変更通知番号</param>
		/// <param name="txtZuban">図番</param>
		/// <param name="txtFile">ファイル名</param>
		/// <param name="rdoStatus">配布区分</param>
		/// <param name="kensakuKensu">検索件数</param>
		/// <param name="haifumoto">配布元</param>
		/// <returns>業者配布履歴・ヘッダテーブル</returns>
		/// <remarks> 新規作成</remarks>
		public List<P030201_RESULT> SelHaifuData(List<string> contestInfo, string wcEcnNo, string txtZuban, string txtFile, bool rdoStatus, int kensakuKensu, string haifumoto)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;
			StringBuilder withBlock = new StringBuilder();

			// コンテキスト(リストBOX)で選択したコンテキスがある場合
			if (contestInfo != null && contestInfo.Count > 0)
			{
				for (int columnCount = 0; columnCount <= contestInfo.Count - 1; columnCount++)
				{
					if (columnCount == 0)
					{
						withBlock.AppendLine("AND ( HAIFU_HEADER.CONTEXT = '" + contestInfo[columnCount] + "'  ");
					}
					else
					{
						withBlock.AppendLine(" OR HAIFU_HEADER.CONTEXT = '" + contestInfo[columnCount] + "'  ");
					}
				}
				withBlock.AppendLine(" ) ");
			}
			// 変更通知番号(コンボBOX)で選択、または、変更通知番号(テキストBOX)で入力した変更通知番号がある場合
			if (!string.IsNullOrEmpty(wcEcnNo))
			{
				withBlock.AppendLine(" AND HAIFU_HEADER.WC_ECN_NO = @WC_ECN_NO ");
			}
			// 図番(テキストBOX)で入力した図番がある場合
			if (!string.IsNullOrEmpty(txtZuban))
			{
				if (txtZuban.Substring(txtZuban.Length - 1, 1) == AppConst.HOSHI)
				{   // 入力した図番に「*」がある場合
					withBlock.AppendLine(" AND HAIFU_HEADER.ZUBAN Like @ZUBAN ");
				}
				else
				// 入力した図番に「*」がない場合
				{
					withBlock.AppendLine(" AND HAIFU_HEADER.ZUBAN = @ZUBAN ");
				}
			}
			// ファイル名(テキストBOX)で入力したファイル名がある場合
			if (!string.IsNullOrEmpty(txtFile))
			{
				if (txtFile.Substring(txtFile.Length - 1, 1) == AppConst.HOSHI)
				{
					// 入力したファイル名に「*」がある場合
					withBlock.AppendLine(" AND HAIFU_HEADER.FILE_NAME Like @FILE_NAME ");
				}
				else
				{
					// 入力したファイル名に「*」がない場合
					withBlock.AppendLine(" AND HAIFU_HEADER.FILE_NAME = @FILE_NAME ");
				}
			}
			withBlock.AppendLine("           ORDER BY HAIFU_HEADER.WC_OBJ_NO ASC, HAIFU_HEADER.WC_ECN_NO ASC ,HAIFU_HEADER.ZUBAN_VERSION ASC ");
			withBlock.AppendLine("         ) HAIFU_HEADER_MIAN ");
			if (rdoStatus == false)
			{
				withBlock.AppendLine("  WHERE  ROWNUM <= @ROW_NUM ");
				withBlock.AppendLine("       ) HH_MIAN ");
				withBlock.AppendLine("       LEFT JOIN ");
				withBlock.AppendLine("          HAIFU_DETAIL HAIFU_DETAIL  ");
				withBlock.AppendLine("       ON  HH_MIAN.WC_ECN_NO = HAIFU_DETAIL.WC_ECN_NO ");
				withBlock.AppendLine("       AND HH_MIAN.WC_OBJ_NO = HAIFU_DETAIL.WC_OBJ_NO ");
				withBlock.AppendLine("       AND HAIFU_DETAIL.HAIFUMOTO = @HAIFUMOTO_1 ");
			}
			if (rdoStatus)
			{
				withBlock.AppendLine("       WHERE ");
				withBlock.AppendLine("          EXISTS(SELECT 1 FROM HAIFU_DETAIL HD WHERE HD.WC_ECN_NO = HH_MIAN.WC_ECN_NO ");
				withBlock.AppendLine("                 AND HD.WC_OBJ_NO = HH_MIAN.WC_OBJ_NO AND (HD.STATUS = '" + AppConst.Status.HAIFUYOTEI + "' OR HD.STATUS IS NULL)");
				withBlock.AppendLine("                 AND HD.HAIFUMOTO = @HAIFUMOTO_2");
				withBlock.AppendLine("          ) ");
				withBlock.AppendLine("         OR ");
				withBlock.AppendLine("          NOT EXISTS(SELECT 1 FROM HAIFU_DETAIL HD WHERE HD.WC_ECN_NO = HH_MIAN.WC_ECN_NO ");
				withBlock.AppendLine("                     AND HD.WC_OBJ_NO = HH_MIAN.WC_OBJ_NO ");
				withBlock.AppendLine("                     AND HD.HAIFUMOTO = @HAIFUMOTO_3");
				withBlock.AppendLine("          ) ");
			}
			withBlock.AppendLine("       ORDER BY HH_MIAN.WC_OBJ_NO ASC, HH_MIAN.WC_ECN_NO ASC ,HH_MIAN.ZUBAN_VERSION ASC ,HAIFU_DETAIL.GYOSYA_ID ");


			Dictionary<string, string> param = new Dictionary<string, string>();

			if (!string.IsNullOrEmpty(wcEcnNo))
			{
				param.Add("WC_ECN_NO", wcEcnNo);
			}

			if (!string.IsNullOrEmpty(txtZuban))
			{
				//入力した図番に「*」がある場合
				if (txtZuban.Substring(txtZuban.Length - 1, 1) == AppConst.HOSHI)
				{
					//{入力した図番}%
					var hoshiName = txtZuban.Substring(0, txtZuban.LastIndexOf(AppConst.HOSHI));
					param.Add("ZUBAN", hoshiName + "%");
				}
				else
				{
					//入力した図番に「*」がない場合
					//入力した図番
					param.Add("ZUBAN", txtZuban + "%");
				}
			}

			if (!string.IsNullOrEmpty(txtFile))
			{
				//入力した図番に「*」がある場合
				if (txtFile.Substring(txtFile.Length - 1, 1) == AppConst.HOSHI)
				{
					//{入力した図番}%
					var hoshiName = txtFile.Substring(0, txtFile.LastIndexOf(AppConst.HOSHI));
					param.Add("FILE_NAME", hoshiName + "%");
				}
				else
				{
					//入力した図番に「*」がない場合
					//入力した図番
					param.Add("FILE_NAME", txtFile + "%");
				}
			}

			if (!rdoStatus)
			{
				//	検索件数
				param.Add("ROW_NUM", kensakuKensu.ToString());
			}
			param.Add("HAIFUMOTO_1", haifumoto);


			if (rdoStatus)
			{
				param.Add("HAIFUMOTO_2", haifumoto);
				param.Add("HAIFUMOTO_3", haifumoto);
			}

			//TODO
			var result = db.Query<P030201_RESULT>($" SELECT HH_MIAN.WC_OBJ_NO ,HH_MIAN.ZUBAN ,HH_MIAN.FILE_NAME ,HH_MIAN.ZUBAN_VERSION ,HH_MIAN.CONTEXT ,HH_MIAN.WC_ECN_NO ,HH_MIAN.ECN_NAME ,HAIFU_DETAIL.GYOSYA_ID ,HAIFU_DETAIL.GYOSYA_NAME ,HAIFU_DETAIL.BUSUU ,HAIFU_DETAIL.STATUS ,HAIFU_DETAIL.HAIFUMOTO FROM ( SELECT HAIFU_HEADER_MIAN.WC_OBJ_NO ,HAIFU_HEADER_MIAN.ZUBAN ,HAIFU_HEADER_MIAN.FILE_NAME ,HAIFU_HEADER_MIAN.ZUBAN_VERSION ,HAIFU_HEADER_MIAN.CONTEXT ,HAIFU_HEADER_MIAN.WC_ECN_NO ,HAIFU_HEADER_MIAN.ECN_NAME FROM ( SELECT HAIFU_HEADER.WC_OBJ_NO ,HAIFU_HEADER.ZUBAN ,HAIFU_HEADER.FILE_NAME ,HAIFU_HEADER.ZUBAN_VERSION ,HAIFU_HEADER.CONTEXT ,HAIFU_HEADER.WC_ECN_NO ,HAIFU_HEADER.ECN_NAME FROM HAIFU_HEADER HAIFU_HEADER WHERE 1=1" + withBlock, param).ToList();


			return result;
		}

		/// <summary>
		/// 業者配布履歴検索件数の取得
		/// </summary>
		/// <param name="contestInfo">コンテキスト</param>
		/// <param name="wcEcnNo">変更通知番号</param>
		/// <param name="txtZuban">図番</param>
		/// <param name="txtFile">ファイル名</param>
		/// <returns>業者配布履歴検索件数</returns>
		/// <remarks>20240109 劉  新規作成</remarks>
		public int SelHaifuDataCnt(List<string> contestInfo, string wcEcnNo, string txtZuban, string txtFile)
		{

			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			using var db = SqlManager.GetConnection;

			StringBuilder withBlock = new StringBuilder();

			withBlock.AppendLine(" SELECT ");
			withBlock.AppendLine(" COUNT(1) ");                         // 検索件数
			withBlock.AppendLine(" FROM  ");
			withBlock.AppendLine(" HAIFU_HEADER HAIFU_HEADER ");                      // 業者配布履歴・ヘッダ
			withBlock.AppendLine(" WHERE 1=1 ");

			// コンテキスト(リストBOX)で選択したコンテキスがある場合
			if (contestInfo != null && contestInfo.Count > 0)
			{
				for (int columnCount = 0; columnCount <= contestInfo.Count - 1; columnCount++)
				{
					if (columnCount == 0)
						withBlock.AppendLine(" AND ( HAIFU_HEADER.CONTEXT = '" + contestInfo[columnCount] + "'  ");
					else
						withBlock.AppendLine(" OR HAIFU_HEADER.CONTEXT = '" + contestInfo[columnCount] + "'  ");
				}
				withBlock.AppendLine(" ) ");
			}
			// 変更通知番号(コンボBOX)で選択、または、変更通知番号(テキストBOX)で入力した変更通知番号がある場合
			if (!string.IsNullOrEmpty(wcEcnNo))
				withBlock.AppendLine(" AND HAIFU_HEADER.WC_ECN_NO = @WC_ECN_NO ");
			// 図番(テキストBOX)で入力した図番がある場合
			if (!string.IsNullOrEmpty(txtZuban))
			{
				if (txtZuban.Substring(txtZuban.Length - 1, 1) == AppConst.HOSHI)
					// 入力した図番に「*」がある場合
					withBlock.AppendLine(" AND HAIFU_HEADER.ZUBAN Like @ZUBAN ");
				else
					// 入力した図番に「*」がない場合
					withBlock.AppendLine(" AND HAIFU_HEADER.ZUBAN = @ZUBAN ");
			}
			// ファイル名(テキストBOX)で入力したファイル名がある場合
			if (!string.IsNullOrEmpty(txtFile))
			{
				if (txtFile.Substring(txtFile.Length - 1, 1) == AppConst.HOSHI)
					// 入力したファイル名に「*」がある場合
					withBlock.AppendLine(" AND HAIFU_HEADER.FILE_NAME Like @FILE_NAME ");
				else
					// 入力したファイル名に「*」がない場合
					withBlock.AppendLine(" AND HAIFU_HEADER.FILE_NAME = @FILE_NAME ");
			}


			Dictionary<string, string> param = new Dictionary<string, string>();
			if (string.IsNullOrEmpty(wcEcnNo))
			{
				param.Add("WC_ECN_NO", wcEcnNo);
			}

			if (string.IsNullOrEmpty(txtZuban))
			{
				//入力した図番に「*」がある場合
				if (txtZuban.Substring(txtZuban.Length - 1, 1) == AppConst.HOSHI)
				{
					//{入力した図番}%
					var hoshiName = txtZuban.Substring(0, txtZuban.LastIndexOf(AppConst.HOSHI));
					param.Add("ZUBAN", hoshiName + "%");
				}
				else
				{
					//入力した図番に「*」がない場合
					//入力した図番
					param.Add("ZUBAN", txtZuban + "%");
				}
			}

			if (!string.IsNullOrEmpty(txtFile))
			{
				//入力した図番に「*」がある場合
				if (txtFile.Substring(txtFile.Length - 1, 1) == AppConst.HOSHI)
				{
					//{入力した図番}%
					var hoshiName = txtFile.Substring(0, txtFile.LastIndexOf(AppConst.HOSHI));
					param.Add("FILE_NAME", hoshiName + "%");
				}
				else
				{
					//入力した図番に「*」がない場合
					//入力した図番
					param.Add("FILE_NAME", txtFile + "%");
				}
			}

			var result = db.Query<int>(withBlock.ToString(), param).ToList();

			return result[0];

		}
	}
}