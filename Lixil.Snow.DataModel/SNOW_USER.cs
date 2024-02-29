namespace Lixil.Snow.DataModel
{
	/// <summary>
	/// ユーザーマスタ
	/// </summary>
	public class SNOW_USER
	{
		/// <summary>
		/// ユーザーマスタID
		/// </summary>
		public string IDENTIFICATION { get; set; }
		/// <summary>
		/// SnowユーザーID
		/// </summary>
		public string USER_ID { get; set; }
		/// <summary>
		/// ユーザー名
		/// </summary>
		public string USER_NAME { get; set; }
		/// <summary>
		/// メールアドレス
		/// </summary>
		public string MAIL_ADDRESS { get; set; }
		/// <summary>
		/// 表示用姓
		/// </summary>
		public string USER_NAME_SEI { get; set; }
		/// <summary>
		/// 表示用名
		/// </summary>
		public string USER_NAME_MEI { get; set; }
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