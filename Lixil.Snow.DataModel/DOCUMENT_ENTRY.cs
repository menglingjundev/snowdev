using System.Net.NetworkInformation;
using System;
using System.Xml.Linq;

namespace Lixil.Snow.DataModel
{
    /// <summary>
    /// 業者配布履歴
    /// </summary>
    public class DOCUMENT_ENTRY
    {
        /// <summary>
        /// 部品履歴ID
        /// </summary>
        public string IDENTIFICATION { get; set; }
        /// <summary>
        /// 部品ID
        /// </summary>
        public string SUPER_IDENTIFICATION { get; set; }
        /// <summary>
        /// 配布区分
        /// </summary>
        public string STATUS { get; set; }
        /// <summary>
        /// ドキュメント番号
        /// </summary>
        public string DOCUMENT_NUMBER { get; set; }
        public string MODIFY_COUNTER { get; set; }
        /// <summary>
        /// ドキュメントファイル名
        /// </summary>
        public string NAME { get; set; }
        public string IS_TEMPLATE { get; set; }
        public string CAD_DATA_TYPE { get; set; }
        /// <summary>
        /// 番号
        /// </summary>
        public string WTNUMBER { get; set; }

    }
}