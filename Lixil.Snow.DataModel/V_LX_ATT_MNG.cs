namespace Lixil.Snow.DataModel
{
    /// <summary>
    /// 属性管理
    /// </summary>
    public class V_LX_ATT_MNG
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
        /// 属性名
        /// </summary>
        public string LX_WC_ATT_NAME { get; set; }
        /// <summary>
        /// 属性値
        /// </summary>
        public string LX_WC_ATT_VALUE { get; set; }


    }
}