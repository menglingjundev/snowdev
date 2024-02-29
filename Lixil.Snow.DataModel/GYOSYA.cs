using System.Net.NetworkInformation;
using System;

namespace Lixil.Snow.DataModel
{
    /// <summary>
    /// Snow業者マスタ
    /// </summary>
    public class GYOSYA
    {
        /// <summary>
        /// 部門
        /// </summary>
        public string BUMON { get; set; }

        /// <summary>
        /// 業者ID
        /// </summary>
        public string GYOSYA_ID { get; set; }

        /// <summary>
        /// 業者名
        /// </summary>
        public string GYOSYA_NAME { get; set; }

        /// <summary>
        /// 業者名（カナ）
        /// </summary>
        public string KANA_NAME { get; set; }

        /// <summary>
        /// 子図面配布フラグ
        /// </summary>
        public string MULTI_FLG { get; set; }

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