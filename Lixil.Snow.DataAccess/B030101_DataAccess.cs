using Dapper;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Reflection;

namespace Lixil.Snow.DataAccess
{
	/// <summary>
	///業者配布履歴作成
	/// </summary>
	public class B030101_DataAccess : SqlManager
    {
        // 属性名
        private const string KEY_PROPERTY_NAME = "name";
        // 属性名
        private const string KEY_PROPERTY_ZUBAN = "ZUBAN";
        // ｵﾌﾞｼﾞｪｸﾄﾀｲﾌﾟ
        private const string KEY_OBJECT_TYPE_CHANGE_NOTICE = "com.lixil.ChangeNotice1";
        // ｵﾌﾞｼﾞｪｸﾄﾀｲﾌﾟ
        private const string KEY_OBJECT_TYPE_WT_DOCUMENT = "com.lixil.Document1";
        // ｵﾌﾞｼﾞｪｸﾄﾀｲﾌﾟ
        private const string KEY_OBJECT_TYPE_EPM_DOCUMENT = "com.lixil.DefaultEPMDocument";

        /// <summary>
        /// システム属性テーブルからコンテキスト、変更通知番号を取得する。
        /// </summary>
        /// <param name="lxExportSeq">取得された連携シーケンス</param>
        /// <returns>システム属性テーブル</returns>
        /// <remarks>20240101 劉(大連) 新規作成</remarks>
        public List<V_LX_SYSTEM_ATT> SelVLxSystemAttMngData(string lxExportSeq)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            var result = db.Query<V_LX_SYSTEM_ATT>($"SELECT VLSA.LX_CONTEXT, VLSA.LX_ECN_NO FROM V_LX_SYSTEM_ATT VLSA WHERE VLSA.LX_EXPORT_SEQ = '{lxExportSeq}'").ToList();

            return result;
        }


        /// <summary>
        /// 属性管理テーブルから属性値を取得して、変更通知の名前に設定する。
        /// </summary>
        /// <param name="lxExportSeq">取得された連携シーケンス</param>
        /// <returns>属性管理テーブル</returns>
        /// <remarks>20240101 劉(大連) 新規作成</remarks>
        public List<V_LX_ATT_MNG> SelVLxAttMng1Data(string lxExportSeq)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            var result = db.Query<V_LX_ATT_MNG>($"SELECT VLAM.LX_WC_ATT_VALUE FROM V_LX_ATT_MNG VLAM WHERE VLAM.LX_EXPORT_SEQ = '{lxExportSeq}' AND VLAM.LX_OBJ_TYPE = '{KEY_OBJECT_TYPE_CHANGE_NOTICE}' AND VLAM.LX_WC_ATT_NAME ='{KEY_PROPERTY_NAME}'").ToList();
            return result;
        }


        /// <summary>
        /// 業者配布履歴・ヘッダを検索する。
        /// </summary>
        /// <param name="wcEcnNo">変更通知番号</param>
        /// <returns>業者配布履歴・ヘッダテーブル</returns>
        /// <remarks>20240101 劉(大連) 新規作成</remarks>
        public List<HAIFU_HEADER> SelHaifuHeaderData(string wcEcnNo)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            var result = db.Query<HAIFU_HEADER>($"SELECT HH.WC_ECN_NO FROM HAIFU_HEADER HH WHERE HH.WC_ECN_NO ='{wcEcnNo}'").ToList();
            return result;
        }

        /// <summary>
        /// オブジェクトデータを取得する。
        /// </summary>
        /// <param name="lxExportSeq">取得された連携シーケンス</param>
        /// <returns>オブジェクトテーブル</returns>
        /// <remarks>20240101 劉(大連) 新規作成</remarks>
        public List<V_LX_OBJ_INFO> SelVLxObjInfoData(string lxExportSeq)
        {
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            var result = db.Query<V_LX_OBJ_INFO>($" SELECT VLOI.LX_EXPORT_SEQ, VLOI.LX_OBJ_TYPE, VLOI.LX_OBJ_NO, VLOI.LX_OBJ_VERSION FROM V_LX_OBJ_INFO VLOIWHERE VLOI.LX_EXPORT_SEQ = :LX_EXPORT_SEQ AND (VLOI.LX_OBJ_TYPE = '{KEY_OBJECT_TYPE_WT_DOCUMENT}' OR VLOI.LX_OBJ_TYPE = '{KEY_OBJECT_TYPE_EPM_DOCUMENT}') ORDER BY VLOI.LX_EXPORT_SEQ, VLOI.LX_OBJ_TYPE, VLOI.LX_OBJ_NO, VLOI.LX_OBJ_VERSION ").ToList();
            return result;

        }

        /// <summary>
        /// 属性管理データを取得する。
        /// </summary>
        /// <param name="lxExportSeq">取得された連携シーケンス</param>
        /// <param name="lxObjType">ｵﾌﾞｼﾞｪｸﾄﾀｲﾌﾟ</param>
        /// <param name="lxObjNo">ｵﾌﾞｼﾞｪｸﾄNo</param>
        /// <param name="lxObjVersion">ｵﾌﾞｼﾞｪｸﾄﾊﾞｰｼﾞｮﾝ</param>
        /// <returns>属性管理テーブル</returns>
        /// <remarks>20240101 劉(大連) 新規作成</remarks>
        public List<V_LX_ATT_MNG> SelVLxAttMng2Data(string lxExportSeq, string lxObjType, string lxObjNo, string lxObjVersion)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            var result = db.Query<V_LX_ATT_MNG>($"SELECT VLAM.LX_WC_ATT_VALUE FROM V_LX_ATT_MNG VLAM WHERE VLAM.LX_EXPORT_SEQ = '{lxExportSeq}' AND VLAM.LX_OBJ_TYPE = '{lxObjType}' VLAM.LX_OBJ_NO = '{lxObjNo}' AND VLAM.LX_OBJ_VERSION = '{lxObjVersion}' AND VLAM.LX_WC_ATT_NAME = '{KEY_PROPERTY_ZUBAN}'").ToList();
            return result;
        }


        /// <summary>
        /// ドキュメントファイルリンクデータを取得する。
        /// </summary>
        /// <param name="lxExportSeq">取得された連携シーケンス</param>
        /// <param name="lxObjType">ｵﾌﾞｼﾞｪｸﾄﾀｲﾌﾟ</param>
        /// <param name="lxObjNo">ｵﾌﾞｼﾞｪｸﾄNo</param>
        /// <param name="lxObjVersion">ｵﾌﾞｼﾞｪｸﾄﾊﾞｰｼﾞｮﾝ</param>
        /// <returns>ドキュメントファイルリンクテーブル</returns>
        /// <remarks>20240101 劉(大連) 新規作成</remarks>
        public List<V_LX_FILE_LINK_INFO> SelVFileObjInfoData(string lxExportSeq, string lxObjType, string lxObjNo, string lxObjVersion)
        {
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            var result = db.Query<V_LX_FILE_LINK_INFO>($"SELECT VLFLI.FILE_PATH,VLFLI.FILE_NAME FROM V_LX_FILE_LINK_INFO VLFLI WHERE VLFLI.LX_EXPORT_SEQ = '{lxExportSeq}' AND VLFLI.LX_OBJ_TYPE = '{lxObjType}' AND VLFLI.LX_OBJ_NO = '{lxObjNo}' AND VLFLI.LX_OBJ_VERSION = '{lxObjVersion}' ").ToList();
            return result;
        }


        /// <summary>
        /// 業者配布履歴・ヘッダを登録する
        /// </summary>
        /// <param name="wcEcnNo">変更通知番号</param>
        /// <param name="lxWcAttValue">変更通知の名前</param>
        /// <param name="lxConent">コンテキスト</param>
        /// <param name="lxObjN0">図面・ドキュメントの番号</param>
        /// <param name="lxObjType">オブジェクトタイプ</param>
        /// <param name="lxWcAttValue2">図番</param>
        /// <param name="lxObjVersion">改訂</param>
        /// <param name="filePath">ドキュメントファイルパス</param>
        /// <param name="fileName">ドキュメントファイル名</param>
        /// <returns>登録結果</returns>
        /// <remarks>20240101 劉(大連) 新規作成</remarks>
        public int InsHaifuHeaderData(string wcEcnNo, string lxWcAttValue, string lxConent, string lxObjN0, string lxObjType, string lxWcAttValue2, string lxObjVersion, string filePath, string fileName)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            HAIFU_HEADER parm = new HAIFU_HEADER
            {
                WC_ECN_NO = wcEcnNo,
                ECN_NAME = lxWcAttValue,
                CONTEXT = lxConent,
                WC_OBJ_NO = lxObjN0,
                WC_OBJ_TYPE = lxObjType,
                ZUBAN = lxWcAttValue2,
                ZUBAN_VERSION = lxObjVersion,
                FILE_PATH = filePath,
                FILE_NAME = fileName,
                CREATE_PGM = "B030101",
                CREATE_PERSON = Environment.GetEnvironmentVariable("USERNAME", EnvironmentVariableTarget.Machine),
                MODIFY_PGM = "B030101",
                MODIFY_PERSON = Environment.GetEnvironmentVariable("USERNAME", EnvironmentVariableTarget.Machine)

			};

            var result = db.Execute($"insert into HAIFU_HEADER VALUES" +
                $" (@WC_ECN_NO, @ECN_NAME, @CONTEXT, @WC_OBJ_NO, @WC_OBJ_TYPE, @ZUBAN, @ZUBAN_VERSION, @FILE_PATH, @FILE_NAME" +
                $", @CREATE_PGM, @CREATE_PERSON,NOW(), @MODIFY_PGM,@MODIFY_PERSON,NOW()) ", parm);

            return result;
        }

        /// <summary>
        /// 業者配布履歴・明細の登録用データを取得する。
        /// </summary>
        /// <param name="lxObjN0">図面・ドキュメントの番号</param>
        /// <returns>業者配布履歴(最新)テーブル</returns>
        /// <remarks>20240101 劉(大連) 新規作成</remarks>
        /// <remarks>20190923 大連 韓  配布元を追加</remarks>
        public List<HAIFU_DETAIL_LAST> SelDetailLastData(string lxObjN0)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            var str = $"";
            str += " SELECT ";
            str += " HDL.GYOSYA_ID, ";
            str += " GS.GYOSYA_NAME, ";
            str += " HDL.BUSUU ";
            str += " ,HDL.HAIFUMOTO ";
            str += " FROM ( ";
            str += " SELECT ";
            str += " WC_OBJ_NO, ";
            str += " HAIFUMOTO, ";
            str += " BUMON, ";
            str += " GYOSYA_ID, ";
            str += " GYOSYA_NAME, ";
            str += " BUSUU ";
            str += " FROM  ";
            str += " HAIFU_DETAIL_LAST ";
            str += " unpivot( ";
            str += " (GYOSYA_ID,GYOSYA_NAME,BUSUU ";
            str += " for quarter in ";
            str += " ((GYOSYA_ID_1,GYOSYA_NAME_1,BUSUU_1 ";
            str += " ,(GYOSYA_ID_2,GYOSYA_NAME_2,BUSUU_2 ";
            str += " ,(GYOSYA_ID_3,GYOSYA_NAME_3,BUSUU_3 ";
            str += " ,(GYOSYA_ID_4,GYOSYA_NAME_4,BUSUU_4 ";
            str += " ,(GYOSYA_ID_5,GYOSYA_NAME_5,BUSUU_5 ";
            str += "  ";
            str += "  ";
            str += "  HDL ";
            str += " INNER JOIN GYOSYA GS ";
            str += " ON HDL.GYOSYA_ID = GS.GYOSYA_ID ";
            str += " AND HDL.BUMON = GS.BUMON ";
            str += " WHERE ";
            str += " HDL.WC_OBJ_NO = :LX_OBJ_NO ";

            using var db = SqlManager.GetConnection;
            var result = db.Query<HAIFU_DETAIL_LAST>(str).ToList();
            return result;
        }

        /// <summary>
        /// 業者配布履歴・明細を登録する
        /// </summary>
        /// <param name="wcEcnNo">変更通知番号</param>
        /// <param name="lxObjN0">図面・ドキュメントの番号</param>
        /// <param name="gyosyaID">業者ID</param>
        /// <param name="gyosyaName">業者名</param>
        /// <param name="busuu">部数</param>
        /// <param name="haifumoto">配布元</param>
        /// <returns>登録結果</returns>
        /// <remarks>20240101 劉(大連) 新規作成</remarks>
        /// <remarks>20190923 大連 韓  配布元を追加</remarks>
        public int InsHaifuDetailData(string wcEcnNo, string lxObjN0, string gyosyaID, string gyosyaName, string busuu, string haifumoto)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            using var db = SqlManager.GetConnection;
            HAIFU_DETAIL parm = new HAIFU_DETAIL
            {
                WC_ECN_NO = wcEcnNo,
                WC_OBJ_NO = lxObjN0,
                HAIFUMOTO = haifumoto,
                GYOSYA_ID = gyosyaID,
                GYOSYA_NAME = gyosyaName,
                BUSUU = Int32.Parse(busuu),
                //TODO
                //STATUS = Utilities.AppConst.Status.HAIFUYOTE,
                HAIFUBI = null,
                KAISYUBI = null,
                CREATE_PGM = "B030101",
                CREATE_PERSON = Environment.GetEnvironmentVariable("USERNAME", EnvironmentVariableTarget.Machine),
                MODIFY_PGM = "B030101",
                MODIFY_PERSON = Environment.GetEnvironmentVariable("USERNAME",EnvironmentVariableTarget.Machine)

            };

            var result = db.Execute($"insert into HAIFU_HEADER VALUES" +
                $" (@WC_ECN_NO, @WC_OBJ_NO, @HAIFUMOTO, @GYOSYA_ID, @GYOSYA_NAME, @BUSUU, @STATUS, @HAIFUBI, @KAISYUBI" +
                $", @CREATE_PGM, @CREATE_PERSON,NOW(), @MODIFY_PGM,@MODIFY_PERSON,NOW()) ", parm);

            return result;



            //System.Text.StringBuilder sb = new System.Text.StringBuilder();         // ＳＱＬ文
            //DataTable dt = new DataTable();                         // 戻り値のデータテーブル

            //{
            //    var withBlock = sb;
            //    withBlock.AppendLine(" INSERT INTO ");
            //    withBlock.AppendLine(" HAIFU_DETAIL ");               // 業者配布履歴・明細
            //    withBlock.AppendLine(" VALUES ( ");                   // 
            //    withBlock.AppendLine(" :WC_ECN_NO, ");                // 変更通知番号
            //    withBlock.AppendLine(" :LX_OBJ_NO, ");                // 図面・ドキュメントの番号
            //    withBlock.AppendLine(" :GYOSYA_ID, ");                // 業者ID
            //    withBlock.AppendLine(" :GYOSYA_NAME, ");              // 業者名
            //    withBlock.AppendLine(" :BUSUU, ");                    // 部数
            //    withBlock.AppendLine(" '" + Utilities.AppConst.Status.HAIFUYOTEI + "', ");                // 配布区分
            //    withBlock.AppendLine(" '', ");                        // 配布日
            //    withBlock.AppendLine(" '', ");                        // 回収日

            //    withBlock.AppendLine(" 'B030101', ");                 // 登録機能ID
            //    withBlock.AppendLine(" :CREATE_PERSON, ");            // 登録ユーザーID
            //    withBlock.AppendLine(" SYSDATE, ");  // 登録日時
            //    withBlock.AppendLine(" 'B030101', ");                             // 更新機能ID
            //    withBlock.AppendLine(" :MODIFY_PERSON, ");                        // 更新ユーザーID
            //    withBlock.AppendLine(" SYSDATE, ");   // 更新日時
            //                                          // 20190923 大連 韓  配布元を追加 start
            //    withBlock.AppendLine(" :HAIFUMOTO ");                // 業者ID
            //                                                         // 20190923 大連 韓  配布元を追加 end
            //    withBlock.AppendLine(" ) ");
            //}

            //List<OracleParameter> @params = new List<OracleParameter>();
            //{
            //    var withBlock = @params;
            //    // 変更通知番号
            //    withBlock.Add(new OracleParameter() { ParameterName = "WC_ECN_NO", OracleDbType = OracleDbType.Varchar2, Size = 256, Value = wcEcnNo });
            //    // ドキュメントの番号
            //    withBlock.Add(new OracleParameter() { ParameterName = "LX_OBJ_NO", OracleDbType = OracleDbType.Varchar2, Size = 256, Value = lxObjN0 });
            //    // 業者ID
            //    withBlock.Add(new OracleParameter() { ParameterName = "GYOSYA_ID", OracleDbType = OracleDbType.Varchar2, Size = 11, Value = gyosyaID });
            //    // 業者名
            //    withBlock.Add(new OracleParameter() { ParameterName = "GYOSYA_NAME", OracleDbType = OracleDbType.Varchar2, Size = 256, Value = gyosyaName });
            //    // 部数
            //    withBlock.Add(new OracleParameter() { ParameterName = "BUSUU", OracleDbType = OracleDbType.Varchar2, Size = 3, Value = busuu });
            //    // 登録ユーザーID
            //    withBlock.Add(new OracleParameter() { ParameterName = "CREATE_PERSON", OracleDbType = OracleDbType.Varchar2, Size = 256, Value = Interaction.Environ("USERNAME") });
            //    // 更新ユーザーID
            //    withBlock.Add(new OracleParameter() { ParameterName = "MODIFY_PERSON", OracleDbType = OracleDbType.Varchar2, Size = 256, Value = Interaction.Environ("USERNAME") });
            //    // 20190923 大連 韓  配布元を追加 start
            //    // 配布元
            //    withBlock.Add(new OracleParameter() { ParameterName = "HAIFUMOTO", OracleDbType = OracleDbType.Varchar2, Size = 20, Value = haifumoto });
            //}

            //return Insert(sb.ToString(), @params);
        }


    }
}
