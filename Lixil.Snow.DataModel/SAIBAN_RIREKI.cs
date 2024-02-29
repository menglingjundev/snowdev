namespace Lixil.Snow.DataModel
{
    /// <summary>
    /// 採番分類マスタ
    /// </summary>
    public class SAIBAN_RIREKI
    {
        /// <summary>
        /// 品番
        /// </summary>
        public string PART_NUMBER { get; set; }

        /// <summary>
        /// 品名
        /// </summary>
        public string PART_NAME { get; set; }

        /// <summary>
        /// 新設理由
        /// </summary>
        public string REASON { get; set; }

        /// <summary>
        /// 今後の展開
        /// </summary>
        public string TENKAI { get; set; }

        /// <summary>
        /// 所属
        /// </summary>
        public string SYOZOKU { get; set; }

        /// <summary>
        /// 作成者
        /// </summary>
        public string SAKUSEI_PERSON { get; set; }

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