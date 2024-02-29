namespace Lixil.Snow.DataModel
{
    /// <summary>
    /// リンク
    /// </summary>
    public class V_LX_LINK_INFO
    {

        /// <summary>
        /// 連携シーケンス
        /// </summary>
        public int LX_EXPORT_SEQ { get; set; }
        /// <summary>
        /// ﾘﾝｸｵﾌﾞｼﾞｪｸﾄﾀｲﾌﾟ
        /// </summary>
        public string LX_LINK_TYPE { get; set; }
        /// <summary>
        /// ﾘﾝｸｵﾌﾞｼﾞｪｸﾄNo
        /// </summary>
        public string LX_LINK_NO { get; set; }
        /// <summary>
        /// 親ｵﾌﾞｼﾞｪｸﾄﾀｲﾌﾟ
        /// </summary>
        public string LX_PARENT_OBJ_TYPE { get; set; }
        /// <summary>
        /// 親ｵﾌﾞｼﾞｪｸﾄNo
        /// </summary>
        public string LX_PARENT_OBJ_NO { get; set; }
        /// <summary>
        /// 親ｵﾌﾞｼﾞｪｸﾄﾊﾞｰｼﾞｮﾝ
        /// </summary>
        public string LX_PARENT_OBJ_VERSION { get; set; }

        /// <summary>
        /// 子ｵﾌﾞｼﾞｪｸﾄﾀｲﾌﾟ
        /// </summary>
        public string LX_CHILD_OBJ_TYPE { get; set; }
        /// <summary>
        /// 子ｵﾌﾞｼﾞｪｸﾄNo
        /// </summary>
        public string LX_CHILD_OBJ_NO { get; set; }

        /// <summary>
        /// 子ｵﾌﾞｼﾞｪｸﾄﾊﾞｰｼﾞｮﾝ
        /// </summary>
        public string LX_CHILD_OBJ_VERSION { get; set; }
        /// <summary>
        /// 親オブジェクト品番
        /// </summary>
        public string LX_PARENT_OBJ_PART_NO { get; set; }
        /// <summary>
        /// 子オブジェクト品番
        /// </summary>
        public string LX_CHILD_OBJ_PART_NO { get; set; }
        /// <summary>
        /// 基準ﾘﾝｸｵﾌﾞｼﾞｪｸﾄNo
        /// </summary>
        public string LX_BASE_LINK_NO { get; set; }

    }
}