using System.Net.NetworkInformation;
using System;

namespace Lixil.Snow.DataModel
{
    /// <summary>
    /// システム属性
    /// </summary>
    public class V_LX_SYSTEM_ATT
    {
        /// <summary>
        /// 連携先システムID
        /// </summary>
        public string LX_SYSTEM_ID { get; set; }
        /// <summary>
        /// 連携シーケンス
        /// </summary>
        public int LX_EXPORT_SEQ { get; set; }
        /// <summary>
        /// 指定ｵﾌﾞｼﾞｪｸﾄﾀｲﾌﾟ
        /// </summary>
        public string LX_OBJ_TYPE { get; set; }
        /// <summary>
        /// 指定ｵﾌﾞｼﾞｪｸﾄNo
        /// </summary>
        public string LX_OBJ_NO { get; set; }
        /// <summary>
        /// 指定ｵﾌﾞｼﾞｪｸﾄﾊﾞｰｼﾞｮﾝ
        /// </summary>
        public string LX_OBJ_VERSION { get; set; }
        /// <summary>
        /// 連携日時
        /// </summary>
        public DateTime LX_EXPORT_DATE { get; set; }
        /// <summary>
        /// 取り込みフラグ
        /// </summary>
        public string LX_IMPORT_STATUS_FLG { get; set; }
        /// <summary>
        /// 取り込み日時
        /// </summary>
        public DateTime LX_IMPORT_DATE { get; set; }
        /// <summary>
        /// コンテキスト
        /// </summary>
        public string LX_CONTEXT { get; set; }
        /// <summary>
        /// 変更通知番号
        /// </summary>
        public string LX_ECN_NO { get; set; }
        /// <summary>
        /// 起票者
        /// </summary>
        public string LX_ORIGINATOR_ID { get; set; }
        /// <summary>
        /// 起票者メールアドレス
        /// </summary>
        public string LX_ORIGINATOR_MAIL_ADDRESS { get; set; }
        /// <summary>
        /// 承認者
        /// </summary>
        public string LX_APPROVER_ID { get; set; }
        /// <summary>
        /// 承認者メールアドレス
        /// </summary>
        public string LX_APPROVER_MAIL_ADDRESS { get; set; }
        /// <summary>
        /// バリエーション情報連携番号
        /// </summary>
        public string LX_SEQ_NUM { get; set; }

    }
}