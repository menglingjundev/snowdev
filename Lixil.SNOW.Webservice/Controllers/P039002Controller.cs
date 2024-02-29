using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lixil.SNOW.Webservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class P039002Controller : ControllerBase
    {
        /// <summary>
        /// Snow業者マスタの取得
        /// </summary>
        /// <param name="drpBumon">部門</param>
        /// <param name="txtGyosyaName">業者名</param>
        /// <param name="txtCanaName">業者名</param>
        /// <returns>業者マスタ</returns>
        /// <remarks>20190729 王(大連) 新規作成</remarks>
        [HttpGet(Name = "SelectGyosyaData/{drpBumon}/{txtGyosyaName}/{txtCanaName}")]
        public List<GYOSYA> SelectGyosyaData(string drpBumon, string txtGyosyaName, string txtCanaName)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            var result = new P039002_BizLogic().SelectGyosyaData(drpBumon, txtGyosyaName, txtCanaName);

            return result;
        }
    }
}
