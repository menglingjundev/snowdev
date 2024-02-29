using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Lixil.SNOW.Webservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SeppennoController : ControllerBase
    {

		/// <summary>
		/// 採番結果を返す
		/// </summary>
		/// <param name="colname"></param>
		/// <returns></returns>
		[HttpPost(Name = "Numbering/{saibanSyurui}/{burui1}/{burui2}/{burui3}/{burui4}/{burui5}/{kijunbi}/{saibanSuu}/{syozoku}/{sakuseiPerson}/{partName}/{reason}/{tenkai}/{userID}/{PGM}")]
		public List<string> Numbering(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5, string? kijunbi, int saibanSuu, string? syozoku, string? sakuseiPerson, string? partName, string? reason, string? tenkai, string? userID, string? PGM)
		{

			var result = new P130102_BizLogic().Saiban(saibanSyurui, burui1, burui2, burui3, burui4, burui5, kijunbi, saibanSuu, syozoku, sakuseiPerson, partName, reason, tenkai, userID, PGM);

			return result;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		[HttpPost(Name = "GetDataByFile/{filePath}")]
		public List<Object> GetDataByFile(string filePath)
		{
			List<Object> result = new Seppenno_BizLogic().GetDataByFile(filePath);

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		[HttpPost(Name = "SetDataByFile/{filePath}")]
		public int SetDataByFile(string filePath)
		{
			var result = new Seppenno_BizLogic().SetDataByFile(filePath);

			return result;

		}
	}
}
