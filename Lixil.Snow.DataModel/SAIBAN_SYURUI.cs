namespace Lixil.Snow.DataModel
{
    /// <summary>
    /// 採番分類マスタ
    /// </summary>
    public class SAIBANSYURUI
    {
        /// <summary>
        /// 採番の種類
        /// </summary>
        public string SAIBAN_SYURUI { get; set; }
        /// <summary>
        /// 採番用分類１要否
        /// </summary>
        public string BURUI_1_FLG { get; set; }
        /// <summary>
        /// 採番用分類２要否
        /// </summary>
        public string BURUI_2_FLG { get; set; }
        /// <summary>
        /// 採番用分類３要否
        /// </summary>
        public string BURUI_3_FLG { get; set; }
        /// <summary>
        /// 採番用分類４要否
        /// </summary>
        public string BURUI_4_FLG { get; set; }
        /// <summary>
        /// 採番用分類５要否
        /// </summary>
        public string BURUI_5_FLG { get; set; }
        /// <summary>
        /// 採番履歴要否
        /// </summary>
        public string RIREKI_FLG { get; set; }
        /// <summary>
        /// 採番画面可否
        /// </summary>
        public string ENTRY_FLG { get; set; }
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