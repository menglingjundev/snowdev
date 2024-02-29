using Lixil.Snow.DataAccess;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.BizLogic
{
	/// <summary>
	/// バッチB200101用
	/// </summary>
	public class P030201_BizLogic
	{

		//SQL文実行用
		private P030201_DataAccess da;

		public P030201_BizLogic()
		{
			da = new P030201_DataAccess();
		}

		/// <summary>
		/// 変更通知番号の取得
		/// </summary>
		/// <param name="contestInfo">コンテキスト</param>
		/// <returns>業者配布履歴・ヘッダテーブル</returns>
		public List<HAIFU_HEADER> SelContestData(List<string> contestInfo)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<HAIFU_HEADER> result = new List<HAIFU_HEADER>();
			result = da.SelContestData(contestInfo);
			da.Close();
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
		/// <remarks>20240109 劉 新規作成</remarks>
		public List<P030201_RESULT> SelHaifuData(List<string> contestInfo, string wcEcnNo, string txtZuban, string txtFile, bool rdoStatus, int kensakuKensu, string Haifumoto)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<P030201_RESULT> result = new List<P030201_RESULT>();
			result = da.SelHaifuData(contestInfo, wcEcnNo, txtZuban, txtFile, rdoStatus, kensakuKensu, Haifumoto);
			da.Close();
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
		///  <remarks>20240109 劉 新規作成</remarks>
		public int SelHaifuDataCnt(List<string> contestInfo, string wcEcnNo, string txtZuban, string txtFile)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			var result = da.SelHaifuDataCnt(contestInfo, wcEcnNo, txtZuban, txtFile);
			da.Close();
			return result;
		}
	}
}
