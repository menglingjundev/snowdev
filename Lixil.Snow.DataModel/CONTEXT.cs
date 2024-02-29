namespace Lixil.Snow.DataModel
{
	/// <summary>
	/// 
	/// </summary>
	public class CONTEXT
	{

		/// <summary>
		/// コンテキスト
		/// </summary>
		public string context { get; set; }


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