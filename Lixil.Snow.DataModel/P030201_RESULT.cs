namespace Lixil.Snow.DataModel
{
	/// <summary>
	/// 工場マスタ
	/// </summary>
	public class P030201_RESULT
	{
		/// <summary>
		/// 図面・ドキュメントの番号
		/// </summary>
		public string WC_OBJ_NO { get; set; }
		/// <summary>
		/// 図番
		/// </summary>
		public string ZUBAN { get; set; }
		/// <summary>
		/// ドキュメントファイル名
		/// </summary>
		public string FILE_NAME { get; set; }
		/// <summary>
		/// 改訂
		/// </summary>
		public string ZUBAN_VERSION { get; set; }
		/// <summary>
		/// コンテキスト
		/// </summary>
		public string CONTEXT { get; set; }
		/// <summary>
		/// 変更通知番号
		/// </summary>
		public string WC_ECN_NO { get; set; }
		/// <summary>
		/// 変更通知の名前
		/// </summary>
		public string ECN_NAME { get; set; }
		/// <summary>
		/// 業者ID
		/// </summary>
		public string GYOSYA_ID { get; set; }
		/// <summary>
		/// 業者名
		/// </summary>
		public string GYOSYA_NAME { get; set; }
		/// <summary>
		/// 部数
		/// </summary>
		public int BUSUU { get; set; }
		/// <summary>
		/// 配布区分
		/// </summary>
		public string STATUS { get; set; }
		/// <summary>
		/// 配布元
		/// </summary>
		public string HAIFUMOTO { get; set; }

	}
}