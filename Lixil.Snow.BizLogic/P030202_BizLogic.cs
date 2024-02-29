using Lixil.Snow.DataAccess;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.BizLogic
{
	/// <summary>
	/// コンテキストマスタのデータアクセス
	/// </summary>
	/// <remarks>20240109 劉 新規作成</remarks>
	public class P030202_BizLogic
	{

		//SQL文実行用
		private P030202_DataAccess da;

		public P030202_BizLogic()
		{
			da = new P030202_DataAccess();
		}

		/// <summary>
		/// コンテキストマスタの取得
		/// </summary>
		/// <returns>コンテキストマスタ</returns>
		/// <remarks>20240109 劉 新規作成</remarks>
		public List<CONTEXT> SelHaifuHeaderData()
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<CONTEXT> result = new List<CONTEXT>();
			result = da.SelHaifuHeaderData();
			da.Close();
			return result;
		}
	}
}
