using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{
    /// <summary>
    /// 図面・ドキュメント履歴削除機能の表示／更新用のデータアクセス
    /// </summary>
    public class P099002_DataAccess : SqlManager
    {
        /// <summary>
        /// 採番の種類マスタを更新
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="saibanBunruiFlg1">採番用分類１要否</param>
        /// <param name="saibanBunruiFlg2">採番用分類２要否</param>
        /// <param name="saibanBunruiFlg3">採番用分類３要否</param>
        /// <param name="saibanBunruiFlg4">採番用分類４要否</param>
        /// <param name="saibanBunruiFlg5">採番用分類５要否</param>
        /// <param name="saibanRirekiFlg">採番履歴要否</param>
        /// <param name="saibanGamenFlg">採番画面可否</param> 
        /// <param name="deleteFlg">削除</param> 
        /// <param name="userId">ユーザーID</param>  
        /// <returns>影響行数</returns>
        public List<HAIFU_HEADER> SelHaifuHeaderByWcEcnNo(string txtTxtWcEcnNo)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            List<HAIFU_HEADER> headerList = new List<HAIFU_HEADER>();
            var result = db.Query<HAIFU_HEADER, HAIFU_DETAIL, HAIFU_HEADER>(@"SELECT HF_HEADER.WC_ECN_NO,HF_HEADER.WC_OBJ_NO,HF_HEADER.ZUBAN,HF_HEADER.FILE_NAME,HF_HEADER.ZUBAN_VERSION,to_char(HF_HEADER.CREATE_DATE,'yyyy/mm/dd hh24:mi:ss') AS CREATE_DATE" +
                $" ,HF_HEADER.CONTEXT,to_char(HF_DETAIL.HAIFUBI,'yyyy/mm/dd') AS HAIFUBI,HF_DETAIL.STATUS ,HF_DETAIL.GYOSYA_ID || '   ' || HF_DETAIL.GYOSYA_NAME AS GYOSYA ,HF_HEADER.WC_ECN_NO,HF_HEADER.ECN_NAME,HF_DETAIL.HAIFUMOTO " +
                $" FROM HAIFU_HEADER  HF_HEADER LEFT JOIN HAIFU_DETAIL  HF_DETAIL ON HF_HEADER.WC_ECN_NO = HF_DETAIL.WC_ECN_NO AND  HF_HEADER.WC_OBJ_NO = HF_DETAIL.WC_OBJ_NO " +
                $" WHERE HF_HEADER.WC_ECN_NO  ='{txtTxtWcEcnNo}'", (header, detail) =>
                {
                    if (!headerList.Exists(x => x.WC_ECN_NO == header.WC_ECN_NO && x.WC_OBJ_NO == header.WC_OBJ_NO))
                    {
                        header.DETAIL = header.DETAIL ?? new List<HAIFU_DETAIL>();
                        header.DETAIL.Add(detail);
                        headerList.Add(header);
                    }
                    else
                    {
                        HAIFU_HEADER oheader = headerList.FirstOrDefault(x => x.WC_ECN_NO == header.WC_ECN_NO && x.WC_OBJ_NO == header.WC_OBJ_NO);
                        oheader.DETAIL = oheader.DETAIL ?? new List<HAIFU_DETAIL>();
                        oheader.DETAIL.Add(detail);
                    }
                    return null;
                }, splitOn: "WC_ECN_NO").AsQueryable().ToList();

            return headerList;
        }

        /// <summary>
        /// 図番一覧画面（洗面）表示用データを取得する
        /// </summary>
        /// <param name="txtTxtWcEcnNo">変更通知番号</param>
        /// <returns>取得更新件数</returns>
        public List<DOCUMENT_VERSION> SelDocumentVersionByWcEcnNo(string txtTxtWcEcnNo)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            var result = db.Query<DOCUMENT_VERSION, DOCUMENT, DOCUMENT_VERSION>(@"SELECT DO.WTNUMBER,DO.DOCUMENT_NUMBER,DV.DC_DW_03_13,DE.FILE_NAME,DV.VERSION_MARK,DV.CREATE_DATE,DV.WC_ECN_NO" +
                $" FROM DOCUMENT_VERSION DV INNER JOIN DOCUMENT DO ON DO.IDENTIFICATION = DV.SUPER_IDENTIFICATION LEFT JOIN DOCUMENT_ENTRY DE ON DE.SUPER_IDENTIFICATION = DV.IDENTIFICATION" +
                $" WHERE DV.WC_ECN_NO ='{txtTxtWcEcnNo}' AND DV.DC_DW_03_13 IS NOT NULL  ORDER BY DV.DC_DW_03_13 ", (docVersion, detail) =>
                {
                    docVersion.document = docVersion.document ?? new DOCUMENT();

                    return docVersion;
                }).AsQueryable().ToList();

            return result;

            //{
            //    var withBlock = sb;
            //    withBlock.AppendLine(" SELECT ");
            //    withBlock.AppendLine(" DO.WTNUMBER ");                 // 番号
            //    withBlock.AppendLine(" ,DO.DOCUMENT_NUMBER ");         // ドキュメント番号
            //    withBlock.AppendLine(" ,DV.DC_DW_03_13 ");             // 図番
            //    withBlock.AppendLine(" ,DE.FILE_NAME ");               // ファイル名
            //    withBlock.AppendLine(" ,DV.VERSION_MARK ");            // VERSION_MARK
            //    withBlock.AppendLine(" ,DV.CREATE_DATE ");             // 登録日時
            //    withBlock.AppendLine(" ,DV.WC_ECN_NO ");               // 変更通知番号
            //    withBlock.AppendLine(" FROM DOCUMENT_VERSION DV ");    // ドキュメント履歴
            //    withBlock.AppendLine(" INNER JOIN DOCUMENT DO ");      // ドキュメント
            //    withBlock.AppendLine(" ON DO.IDENTIFICATION = DV.SUPER_IDENTIFICATION ");
            //    withBlock.AppendLine(" LEFT JOIN DOCUMENT_ENTRY DE"); // ドキュメントエントリー
            //                                                          // .AppendLine("   (SELECT * ")
            //                                                          // .AppendLine("     FROM  DOCUMENT_ENTRY ")
            //                                                          // .AppendLine("     WHERE IDENTIFICATION IN ")
            //                                                          // .AppendLine("         (SELECT MAX(IDENTIFICATION) AS IDENTIFICATION ")
            //                                                          // .AppendLine("          FROM DOCUMENT_ENTRY  ")
            //                                                          // .AppendLine("          GROUP BY SUPER_IDENTIFICATION) ")
            //                                                          // .AppendLine("   ) DE ")
            //    withBlock.AppendLine(" ON DE.SUPER_IDENTIFICATION = DV.IDENTIFICATION ");
            //    withBlock.AppendLine(" WHERE ");
            //    withBlock.AppendLine(" DV.WC_ECN_NO  = :WC_ECN_NO ");  // 変更通知番号
            //    withBlock.AppendLine(" AND DV.DC_DW_03_13 IS NOT NULL ");
            //    withBlock.AppendLine(" ORDER BY DV.DC_DW_03_13 ");     // 図番
            //}

            //List<OracleParameter> @params = new List<OracleParameter>();
            //{
            //    var withBlock = @params;
            //    withBlock.Add(new OracleParameter() { ParameterName = "WC_ECN_NO", OracleDbType = OracleDbType.Varchar2, Size = 256, Value = txtTxtWcEcnNo });
            //}
            //return Search(sb.ToString(), @params);
        }


        /// <summary>
        /// 業者配布履歴・ヘッダから業者配布履歴・ヘッダ(削除済)を登録する
        /// </summary>
        /// <param name="txtTxtWcEcnNo">変更通知番号</param>
        /// <param name="userID">ユーザーID</param>
        /// <param name="PGM">機能ID</param>    
        /// <returns>表示用データ</returns>
        public int InsertDeleteHHByWcEcnNo(string txtTxtWcEcnNo, string userID, string PGM)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;
            DELETE_HAIFU_HEADER header = new DELETE_HAIFU_HEADER
            {
                WC_ECN_NO = txtTxtWcEcnNo,
                MODIFY_PGM = PGM,
                MODIFY_PERSON = userID
            };

            var result = db.Execute($"INSERT INTO DELETE_HAIFU_HEADER (WC_ECN_NO,ECN_NAME,CONTEXT,WC_OBJ_NO,WC_OBJ_TYPE,ZUBAN,ZUBAN_VERSION,FILE_PATH,FILE_NAME" +
                $" ,CREATE_PGM ,CREATE_PERSON ,CREATE_DATE ,MODIFY_PGM , MODIFY_PERSON ,MODIFY_DATE)" +
                $" SELECT WC_ECN_NO,ECN_NAME,CONTEXT,WC_OBJ_NO,WC_OBJ_TYPE,ZUBAN,ZUBAN_VERSION,FILE_PATH,FILE_NAME,CREATE_PGM ,CREATE_PERSON ,CREATE_DATE ,@MODIFY_PGM , @MODIFY_PERSON ,NOW()" +
                $" FROM HAIFU_HEADER WHERE WC_ECN_NO  = @WC_ECN_NO ", header);

            return result;
        }

        /// <summary>
        /// 業者配布履歴・明細から業者配布履歴・明細(削除済)を登録する
        /// </summary>
        /// <param name="txtTxtWcEcnNo">変更通知番号</param>
        /// <param name="userID">ユーザーID</param>
        /// <param name="PGM">機能ID</param>    
        /// <returns>表示用データ</returns>
        public int InsertDeleteHDByWcEcnNo(string txtTxtWcEcnNo, string userID, string PGM)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            DELETE_HAIFU_DETAIL detail = new DELETE_HAIFU_DETAIL
            {
                WC_ECN_NO = txtTxtWcEcnNo,
                MODIFY_PGM = PGM,
                MODIFY_PERSON = userID
            };

            using var db = SqlManager.GetConnection;
            var result = db.Execute($"INSERT INTO DELETE_HAIFU_DETAIL (WC_ECN_NO,WC_OBJ_NO,ECN_NAME,GYOSYA_ID,GYOSYA_NAME,BUSUU,STATUS,HAIFUBI,KAISYUBI" +
                $" ,CREATE_PGM ,CREATE_PERSON ,CREATE_DATE ,MODIFY_PGM , MODIFY_PERSON ,MODIFY_DATE,HAIFUMOTO)" +
                $" SELECT WC_ECN_NO,WC_OBJ_NO,ECN_NAME,GYOSYA_ID,GYOSYA_NAME,BUSUU,STATUS,HAIFUBI,KAISYUBI,CREATE_PGM ,CREATE_PERSON ,CREATE_DATE ,@MODIFY_PGM , @MODIFY_PERSON ,NOW(),HAIFUMOTO" +
                $" FROM HAIFU_DETAIL WHERE WC_ECN_NO  = @WC_ECN_NO ", detail);

            return result;
        }

        /// <summary>
        /// 業者配布履歴・ヘッダを削除する
        /// </summary>
        /// <param name="wcEcnNo">変更通知番号</param>
        /// <returns>処理結果</returns>
        public int DelHHDataByWcEcnNo(string wcEcnNo)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            var result = db.Execute($"DELETE HAIFU_HEADER WHERE WC_ECN_NO = '{wcEcnNo}'");

            return result;
        }

        /// <summary>
        /// 業者配布履歴・明細を削除する
        /// </summary>
        /// <param name="wcEcnNo">変更通知番号</param>
        /// <returns>処理結果</returns>
        public int DelHDDataByWcEcnNo(string wcEcnNo)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            var result = db.Execute($"DELETE HAIFU_DETAIL WHERE WC_ECN_NO = '{wcEcnNo}'");

            return result;
        }

        /// <summary>
        /// ドキュメント履歴を更新する
        /// ※「【補足】ドキュメント履歴の更新について」の同時に更新する（ケース１）：FIRST→ALONE
        /// </summary>
        /// <param name="txtTxtWcEcnNo">変更通知番号</param>
        /// <returns>処理結果</returns>
        public int UpdDVFirstToAloneByWcEcnNo(string txtTxtWcEcnNo)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            using var db = SqlManager.GetConnection;
            var result = db.Execute($"UPDATE DOCUMENT_VERSION DV SET VERSION_MARK = 'ALONE' WHERE EXISTS ( SELECT 1 FROM (SELECT DV2.SUPER_IDENTIFICATION MAX_DV2_SID, max(DV2.VERSION) MAX_DV2_VER " +
               $" FROM DOCUMENT_VERSION DV2, DOCUMENT_VERSION DV3,DOCUMENT D2, DOCUMENT D3" +
               $" WHERE DV2.SUPER_IDENTIFICATION = DV3.SUPER_IDENTIFICATION AND DV2.SUPER_IDENTIFICATION = D2.IDENTIFICATION AND DV2.VERSION < DV3.VERSION" +
               $" AND DV3.WC_ECN_NO = '{txtTxtWcEcnNo}' AND DV3.SUPER_IDENTIFICATION = D3.IDENTIFICATION AND DV3.VERSION_MARK = 'LAST' GROUP BY DV2.SUPER_IDENTIFICATION )" +
               $" WHERE DV.SUPER_IDENTIFICATION = MAX_DV2_SID AND DV.VERSION = MAX_DV2_VER AND DV.VERSION_MARK = 'FIRST' )");

            return result;
        }

    }
}
