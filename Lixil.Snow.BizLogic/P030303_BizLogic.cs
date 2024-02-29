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
    public class P030303_BizLogic
    {
        //SQL文実行用
        private P030303_DataAccess da;

        public P030303_BizLogic()
        {
            da = new P030303_DataAccess();
        }

        /// <summary>
        /// Snow業者マスタの取得
        /// </summary>
        /// <param name="drpBumon">部門</param>
        /// <param name="txtGyosyaName">業者名</param>
        /// <param name="txtCanaName">業者名</param>
        /// <returns>業者マスタ</returns>
        /// <remarks>20181015 修(大連) 新規作成</remarks>
        public List<GYOSYA> SelGyosyaData(string drpBumon, string txtGyosyaName, string txtCanaName)
        {
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<GYOSYA> result = new List<GYOSYA>();
            result = da.SelGyosyaData(drpBumon, txtGyosyaName, txtCanaName);
            da.Close();
            return result;
        }
    }
}
