namespace Lixil.Snow.DataModel
{
	/// <summary>
	/// 工場マスタ
	/// </summary>
	public class BUMON_KOUJYOU
	{
		/// <summary>
		/// 部門 
		/// </summary>
		public string BUMON { get; set; }
		/// <summary>
		/// 工場ID
		/// </summary>
		public string BUMON_CD { get; set; }
		/// <summary>
		/// 工場名 
		/// </summary>
		public string BUMON_NAME { get; set; }
		/// <summary>
		/// 地区ｺｰﾄﾞ 
		/// </summary>
		public string TIKU_CD { get; set; }
		/// <summary>
		/// 削除フラグ 
		/// </summary>
		public string DELETE_FLG { get; set; }
		/// <summary>
		/// 登録機能ID
		/// </summary>
		public string CREATE_PGM { get; set; }
		/// <summary>
		/// 登録ユーザーID
		/// </summary>
		public string CREATE_PERSON { get; set; }
		/// <summary>
		/// 登録日時
		/// </summary>
		public DateTime CREATE_DATE { get; set; }
		/// <summary>
		/// 更新機能ID
		/// </summary>
		public string MODIFY_PGM { get; set; }
		/// <summary>
		/// 更新ユーザーID
		/// </summary>
		public string MODIFY_PERSON { get; set; }
		/// <summary>
		/// 更新日時
		/// </summary>
		public DateTime MODIFY_DATE { get; set; }

	}
}