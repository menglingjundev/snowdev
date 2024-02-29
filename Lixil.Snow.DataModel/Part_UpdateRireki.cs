namespace Lixil.Snow.DataModel
{
	/// <summary>
	/// 部品更新履歴
	/// </summary>
	public class Part_UpdateRireki
	{

		/// <summary>
		/// 更新履歴ID
		/// </summary>
		public int ID { get; set; }
		/// <summary>
		/// 種別
		/// </summary>
		public string UPDATE_FLG { get; set; }
		/// <summary>
		/// 	更新者
		/// </summary>
		public string UPDATE_PERSON { get; set; }
		/// <summary>
		/// 更新日時
		/// </summary>
		public DateTime UPDATE_DATE { get; set; }
		/// <summary>
		/// 	棚NO
		/// </summary>
		public string TANA_NO { get; set; }
		/// <summary>
		/// 品番
		/// </summary>
		public string HINBAN { get; set; }
		/// <summary>
		/// 部品名称
		/// </summary>
		public string HINMEI { get; set; }
		/// <summary>
		/// （納入)部門CD
		/// </summary>
		public string BUMON_CD { get; set; }
		/// <summary>
		/// 仕入先名
		/// </summary>
		public string SUPPLIER { get; set; }
		/// <summary>
		/// 開発担当者
		/// </summary>
		public string KAIHATSU_PERSON { get; set; }
		/// <summary>
		/// ﾃﾞﾘﾊﾞﾘｰ担当者
		/// </summary>
		public string DELIVERY_PERSON { get; set; }
		/// <summary>
		/// 更新項目
		/// </summary>
		public string UPDATE_PROPERTY { get; set; }
		/// <summary>
		/// 更新前
		/// </summary>
		public string MAE_DATA { get; set; }
		/// <summary>
		/// 更新後
		/// </summary>
		public string ATO_DATA { get; set; }
		/// <summary>
		/// 商品ｼﾘｰｽﾞ
		/// </summary>
		public string SERIES { get; set; }
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