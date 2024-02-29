namespace Lixil.Snow.DataModel
{
    /// <summary>
    /// ドキュメントファイルリンク
    /// </summary>
    public class V_LX_FILE_LINK_INFO
    {
        /// <summary>
        /// 連携シーケンス
        /// </summary>
        public int LX_EXPORT_SEQ { get; set; }
        /// <summary>
        /// ｵﾌﾞｼﾞｪｸﾄﾀｲﾌﾟ
        /// </summary>

        public string LX_OBJ_TYPE { get; set; }
        /// <summary>
        /// ｵﾌﾞｼﾞｪｸﾄNo
        /// </summary>

        public string LX_OBJ_NO { get; set; }
        /// <summary>
        /// ｵﾌﾞｼﾞｪｸﾄﾊﾞｰｼﾞｮﾝ
        /// </summary>

        public string LX_OBJ_VERSION { get; set; }
        /// <summary>
        /// 変更通知番号
        /// </summary>

        public string WC_ECN_NO { get; set; }
        /// <summary>
        /// 図面・ドキュメントの番号
        /// </summary>

        public string WC_OBJ_NO { get; set; }
        /// <summary>
        /// ドキュメントファイルパス
        /// </summary>

        public string FILE_PATH { get; set; }
        /// <summary>
        /// ドキュメントファイル名
        /// </summary>

        public string FILE_NAME { get; set; }

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