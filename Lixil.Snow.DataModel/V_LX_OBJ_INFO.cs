namespace Lixil.Snow.DataModel
{
    /// <summary>
    /// リンク
    /// </summary>
    public class V_LX_OBJ_INFO
    {

        /// <summary>
        /// 連携シーケンス
        /// </summary>
        public int LX_EXPORT_SEQ { get; set; }

        /// <summary>
        /// ｵﾌﾞｼﾞｪｸﾄﾀｲﾌﾟ
        /// </summary>
        public int LX_OBJ_TYPE { get; set; }
        /// <summary>
        /// ｵﾌﾞｼﾞｪｸﾄNo
        /// </summary>
        public int LX_OBJ_NO { get; set; }
        /// <summary>
        /// ｵﾌﾞｼﾞｪｸﾄﾊﾞｰｼﾞｮﾝ
        /// </summary>
        public int LX_OBJ_VERSION { get; set; }
        /// <summary>
        /// 品番
        /// </summary>
        public int LX_PART_NUMBER { get; set; }
        /// <summary>
        /// ステータス
        /// </summary>
        public int LX_OBJ_STATUS { get; set; }
        /// <summary>
        /// 基準ｵﾌﾞｼﾞｪｸﾄNo
        /// </summary>
        public int LX_BASE_OBJ_NO { get; set; }

    }
}