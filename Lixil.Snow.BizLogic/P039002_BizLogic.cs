using Lixil.Snow.DataAccess;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.BizLogic
{
    /// <summary>
    /// 配布実施
    /// </summary>
    /// <remarks>20181015 修(大連) 新規作成</remarks>
    public class P039002_BizLogic
    {
        //SQL文実行用
        private P039002_DataAccess da;

        public P039002_BizLogic()
        {
            da = new P039002_DataAccess();
        }

        /// <summary>
        /// Snow業者マスタの取得
        /// </summary>
        /// <param name="drpBumon">部門</param>
        /// <param name="txtGyosyaName">業者名</param>
        /// <param name="txtCanaName">業者名</param>
        /// <returns>業者マスタ</returns>
        /// <remarks>20190729 王(大連) 新規作成</remarks>
        public List<GYOSYA> SelectGyosyaData(string drpBumon, string txtGyosyaName, string txtCanaName)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            var result = da.SelGyosyaData(drpBumon, txtGyosyaName, txtCanaName);
            da.Close();
            return result;
        }
    }
}
