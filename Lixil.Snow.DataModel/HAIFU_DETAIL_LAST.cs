namespace Lixil.Snow.DataModel
{
    /// <summary>
    /// 業者配布履歴（最新）
    /// </summary>
    public class HAIFU_DETAIL_LAST
    {
        /// <summary>
        ///図面・ドキュメントの番号
        /// </summary>
        public string WC_OBJ_NO { get; set; }
        /// <summary>
        ///配布元
        /// </summary>
        public string HAIFUMOTO { get; set; }
        /// <summary>
        ///部門
        /// </summary>
        public string BUMON { get; set; }
        /// <summary>
        ///業者ID1
        /// </summary>
        public string GYOSYA_ID_1 { get; set; }
        /// <summary>
        ///業者名１
        /// </summary>
        public string GYOSYA_NAME_1 { get; set; }
        /// <summary>
        ///部数１
        /// </summary>
        public int BUSUU_1 { get; set; }
        /// <summary>
        ///業者ID２
        /// </summary>
        public string GYOSYA_ID_2 { get; set; }
        /// <summary>
        ///業者名２
        /// </summary>
        public string GYOSYA_NAME_2 { get; set; }
        /// <summary>
        ///部数２
        /// </summary>
        public int BUSUU_2 { get; set; }
        /// <summary>
        ///業者ID３
        /// </summary>
        public string GYOSYA_ID_3 { get; set; }
        /// <summary>
        ///業者名３
        /// </summary>
        public string GYOSYA_NAME_3 { get; set; }
        /// <summary>
        ///部数３
        /// </summary>
        public int BUSUU_3 { get; set; }
        /// <summary>
        ///業者ID４
        /// </summary>
        public string GYOSYA_ID_4 { get; set; }
        /// <summary>
        ///業者名４
        /// </summary>
        public string GYOSYA_NAME_4 { get; set; }
        /// <summary>
        ///部数４
        /// </summary>
        public int BUSUU_4 { get; set; }
        /// <summary>
        ///業者ID５
        /// </summary>
        public string GYOSYA_ID_5 { get; set; }
        /// <summary>
        ///業者名５
        /// </summary>
        public string GYOSYA_NAME_5 { get; set; }
        /// <summary>
        ///部数５
        /// </summary>
        public int BUSUU_5 { get; set; }
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