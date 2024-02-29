namespace Lixil.Snow.DataModel
{
    /// <summary>
    /// 業者配布履歴・ヘッダ(削除済)
    /// </summary>
    public class DELETE_HAIFU_HEADER
    {
        /// <summary>
        /// 変更通知番号
        /// </summary>
        public string WC_ECN_NO { get; set; }
        /// <summary>
        /// 変更通知の名前
        /// </summary>
        public string ECN_NAME { get; set; }
        /// <summary>
        /// コンテキスト
        /// </summary>
        public string CONTEXT { get; set; }
        /// <summary>
        /// 図面・ドキュメントの番号
        /// </summary>
        public string WC_OBJ_NO { get; set; }
        /// <summary>
        /// オブジェクトタイプ
        /// </summary>
        public string WC_OBJ_TYPE { get; set; }
        /// <summary>
        /// 図番
        /// </summary>
        public string ZUBAN { get; set; }
        /// <summary>
        /// 改訂
        /// </summary>
        public string ZUBAN_VERSION { get; set; }
        /// <summary>
        /// ドキュメントファイルパス
        /// </summary>
        public string FILE_PATH { get; set; }
        /// <summary>
        /// ドキュメントファイル名
        /// </summary>
        public string FILE_NAME { get; set; }
        /// <summary>
        /// 業者配布履歴・明細
        /// </summary>
        public List<HAIFU_DETAIL> DETAIL { get; set; }
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