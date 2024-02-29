using Lixil.Snow.DataAccess;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Reflection;

namespace Lixil.Snow.BizLogic
{
	/// <summary>
	/// バッチB200101用
	/// </summary>
	public class B200101_BizLogic
	{

		//SQL文実行用
		private B200101_DataAccess da;

		public B200101_BizLogic()
		{
			da = new B200101_DataAccess();
		}

		/// <summary>
		/// 部品(浴室)と部品履歴(浴室)テーブルを検索し、部材マスタCSV情報を取得する
		/// </summary>
		/// <param name="zenkaiSyoriHitsuke">前回処理日時</param>
		/// <param name="konkaiSyoriHitsuke">今回処理日時</param>
		/// <returns>部材マスタCSV情報</returns>
		/// <remarks>20240109劉 新規作成</remarks>
		public List<B_PART> SelBuzaiMasterCSVData(string zenkaiSyoriHitsuke, string konkaiSyoriHitsuke)
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<B_PART> result = new List<B_PART>();
			result = da.SelBuzaiMasterCSVData(zenkaiSyoriHitsuke, konkaiSyoriHitsuke);
			da.Close();
			return result;
		}

		/// <summary>
		/// BOM(浴室)テーブル、部品(浴室)と部品履歴(浴室)テーブルを検索し、展開マスタCSV情報を取得する
		/// </summary>
		/// <returns>展開マスタCSV情報</returns>
		/// <remarks>20240109劉 新規作成</remarks>
		public List<B_PART_VERSION> SelTenkaiMasterCSVData()
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<B_PART_VERSION> result = new List<B_PART_VERSION>();
			result = da.SelTenkaiMasterCSVData();
			da.Close();
			return result;
		}

	}
}
