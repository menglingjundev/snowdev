using System.Net.NetworkInformation;
using System;

namespace Lixil.Snow.DataModel
{
	/// <summary>
	/// コンテキストマスタ
	/// </summary>
	public class S_SEKKEI_HENKOU_RIREKI
	{
		public string IDENTIFICATION { get; set; }
		public string SUPER_IDENTIFICATION { get; set; }
		public string ITEM_NUMBER { get; set; }
		public string PART_NUMBER { get; set; }
		public string KAIRYO_TSUUCHI_NUMBER { get; set; }
		public string KAIRYO_TEIAN_NUMBER { get; set; }
		public string KANRI_NO { get; set; }
		public string VERSION { get; set; }
		public string VERSION_MARK { get; set; }
		public string FULL_NAME { get; set; }
		public string SYOZOKU { get; set; }
		public string TOUROKUBI { get; set; }
		public string MOKUTEKI { get; set; }
		public string HENKOU_NAIYOU { get; set; }
		public string BIKO { get; set; }
		public string LANK { get; set; }
		public string FILE_NAME { get; set; }
		public string FILE_DATA { get; set; }
		public string PORTRAIT { get; set; }
		public string CREATE_PGM { get; set; }
		public string CREATE_PERSON { get; set; }
		public string CREATE_DATE { get; set; }
		public string MODIFY_PGM { get; set; }
		public string MODIFY_PERSON { get; set; }
		public string MODIFY_DATE { get; set; }
	}
}