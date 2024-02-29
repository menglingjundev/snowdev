using System.Net.NetworkInformation;
using System;

namespace Lixil.Snow.DataModel
{
    /// <summary>
    /// 業者配布履歴・明細
    /// </summary>
    public class DOCUMENT_VERSION
    {
        /// <summary>
        /// 変更通知番号
        /// </summary>
        public string WC_ECN_NO { get; set; }
        /// <summary>
        /// 図面・ドキュメントの番号
        /// </summary>
        public string WC_OBJ_NO { get; set; }
        /// <summary>
        /// 配布元
        /// </summary>
        public string HAIFUMOTO { get; set; }
        /// <summary>
        /// 業者ID
        /// </summary>
        public string GYOSYA_ID { get; set; }
        /// <summary>
        /// 業者名
        /// </summary>
        public string GYOSYA_NAME { get; set; }
        /// <summary>
        /// 部数
        /// </summary>
        public int? BUSUU { get; set; }
        /// <summary>
        /// 配布区分
        /// </summary>
        public string STATUS { get; set; }
        /// <summary>
        /// 配布日
        /// </summary>
        public DateTime HAIFUBI { get; set; }
        /// <summary>
        /// 回収日
        /// </summary>
        public DateTime KAISYUBI { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DOCUMENT document { get; set; }
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