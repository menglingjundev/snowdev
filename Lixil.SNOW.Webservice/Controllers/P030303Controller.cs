using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lixil.SNOW.Webservice.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class P030303Controller : ControllerBase
	{
        //TODO
        /// <summary>
        /// Snow業者マスタの取得
        /// </summary>
        /// <param name="drpBumon">部門</param>
        /// <param name="txtGyosyaName">業者名</param>
        /// <param name="txtCanaName">業者名</param>
        /// <returns>業者マスタ</returns>
        /// <remarks>20181015 修(大連) 新規作成</remarks>
        [HttpGet(Name = "SelGyosyaData1/{drpBumon}/{txtGyosyaName}/{txtCanaName}")]
        public List<GYOSYA> SelGyosyaData1(string drpBumon, string txtGyosyaName, string txtCanaName)
        {
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<GYOSYA> result = new List<GYOSYA>();
            result = new P030303_BizLogic().SelGyosyaData(drpBumon, txtGyosyaName, txtCanaName);
            return result;
        }
    }
}
