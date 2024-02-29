using Dapper;
using Lixil.Snow.DataAccess;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.BizLogic
{
    /// <summary>
    /// 採番の種類マスタのデータアクセス
    /// </summary>
    public class Seppenno_BizLogic
	{

        //SQL文実行用
        private Seppenno_DataAccess da;

        public Seppenno_BizLogic()
        {
            da = new Seppenno_DataAccess();
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public List<Object> GetDataByFile(string filePath)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			var result = da.GetDataByFile(filePath);
			da.Close();
			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public int SetDataByFile(string filePath)
		{
			// イベントログ追加
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			var result = da.SetDataByFile(filePath);
			da.Close();
			return result;
		}
	}
}
