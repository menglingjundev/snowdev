namespace Lixil.Snow.DataModel
{
    /// <summary>
    /// 採番分類マスタ
    /// </summary>
    public class SAIBAN_BUNRUI
    {
        /// <summary>
        /// 採番の種類
        /// </summary>
        public string SAIBAN_SYURUI { get; set; }

        /// <summary>
        /// 採番用分類１
        /// </summary>
        public string BURUI_1 { get; set; }
        /// <summary>
        /// 採番用分類２
        /// </summary>
        public string BURUI_2 { get; set; }
        /// <summary>
        /// 採番用分類３
        /// </summary>
        public string BURUI_3 { get; set; }
        /// <summary>
        /// 採番用分類４
        /// </summary>
        public string BURUI_4 { get; set; }
        /// <summary>
        /// 採番用分類５
        /// </summary>
        public string BURUI_5 { get; set; }
        /// <summary>
        /// 前部文字列
        /// </summary>
        public string MAE_MOJI { get; set; }
        /// <summary>
        /// 基準日要否
        /// </summary>
        public string KIJUNBI_FLG { get; set; }
        /// <summary>
        /// 連番桁数
        /// </summary>
        public int? SEQ_LENGTH { get; set; }
        /// <summary>
        /// 連番範囲(開始)  
        /// </summary>
        public Int64? SEQ_START { get; set; }
        /// <summary>
        /// 連番範囲(終了)
        /// </summary>
        public Int64? SEQ_END { get; set; }
        /// <summary>
        /// 終了値超えの処理
        /// </summary>
        public string OVER_FLG { get; set; }
        /// <summary>
        ///  削除フラグ
        /// </summary>
        public string DELETE_FLG { get; set; }
        /// <summary>
        /// 登録機能ID
        /// </summary>
        public string? CREATE_PGM { get; set; }
        /// <summary>
        /// 登録ユーザーID
        /// </summary>
        public string? CREATE_PERSON { get; set; }
        /// <summary>
        /// 登録日時
        /// </summary>
        public DateTime? CREATE_DATE { get; set; }
        /// <summary>
        /// 更新機能ID
        /// </summary>
        public string? MODIFY_PGM { get; set; }
        /// <summary>
        /// 更新ユーザーID
        /// </summary>
        public string? MODIFY_PERSON { get; set; }
        /// <summary>
        /// 更新日時
        /// </summary>
        public DateTime? MODIFY_DATE { get; set; }
        /// <summary>
        /// 最終番号
        /// </summary>
        public long? SEQ_LAST { get; set; }
    }
}