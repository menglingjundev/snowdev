using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lixil.SNOW.Webservice.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class B200101Controller : ControllerBase
	{
		/// <summary>
		/// 部品(浴室)と部品履歴(浴室)テーブルを検索し、部材マスタCSV情報を取得する
		/// </summary>
		/// <param name="zenkaiSyoriHitsuke">前回処理日時</param>
		/// <param name="konkaiSyoriHitsuke">今回処理日時</param>
		/// <returns>部材マスタCSV情報</returns>
		/// <remarks>20181215 陳(大連) 新規作成</remarks>
		[HttpGet(Name = "SelBuzaiMasterCSVData/{zenkaiSyoriHitsuke}/{konkaiSyoriHitsuke}")]
		public List<B_PART> SelBuzaiMasterCSVData(string zenkaiSyoriHitsuke, string konkaiSyoriHitsuke)
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<B_PART> result = new List<B_PART>();
			result = new B200101_BizLogic().SelBuzaiMasterCSVData(zenkaiSyoriHitsuke, konkaiSyoriHitsuke);

			return result;
		}

		/// <summary>
		/// BOM(浴室)テーブル、部品(浴室)と部品履歴(浴室)テーブルを検索し、展開マスタCSV情報を取得する
		/// </summary>
		/// <returns>展開マスタCSV情報</returns>
		/// <remarks>20181215 陳(大連) 新規作成</remarks>
		[HttpGet(Name = "SelTenkaiMasterCSVData")]
		public List<B_PART_VERSION> SelTenkaiMasterCSVData()
		{
			Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
			List<B_PART_VERSION> result = new List<B_PART_VERSION>();
			result = new B200101_BizLogic().SelTenkaiMasterCSVData();

			return result;
		}

	}
}
