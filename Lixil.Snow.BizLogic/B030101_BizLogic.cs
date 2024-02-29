using Lixil.Snow.DataAccess;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Lixil.Snow.BizLogic
{
	/// <summary>
	/// 業者配布履歴作成
	/// </summary>
	public class B030101_BizLogic
    {
        //SQL文実行用
        private B030101_DataAccess da;

        public B030101_BizLogic()
        {
            da = new B030101_DataAccess();
        }

        /// <summary>
        ///システム属性テーブルからコンテキスト、変更通知番号を取得する。
        ///</summary>
        ///<param name="lxExportSeq">取得された連携シーケンス</param>
        ///<returns>システム属性テーブル</returns>
        ///<remarks>20240101 劉(大連) 新規作成</remarks>
        public List<V_LX_SYSTEM_ATT> SelVLxSystemAttMngData(string lxExportSeq)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<V_LX_SYSTEM_ATT> result = new List<V_LX_SYSTEM_ATT>();
            result = da.SelVLxSystemAttMngData(lxExportSeq);
            da.Close();
            return result;

        }

        /// <summary>
        ///属性管理テーブルから属性値を取得して、変更通知の名前に設定する。
        ///</summary>
        ///<param name="lxExportSeq">取得された連携シーケンス</param>
        ///<returns>属性管理テーブル</returns>
        ///<remarks>20240101 劉(大連) 新規作成</remarks>
        public List<V_LX_ATT_MNG> SelVLxAttMng1Data(string lxExportSeq)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<V_LX_ATT_MNG> result = new List<V_LX_ATT_MNG>();
            result = da.SelVLxAttMng1Data(lxExportSeq);
            da.Close();
            return result;
        }

        /// <summary>
        ///業者配布履歴・ヘッダを検索する。
        ///</summary>
        ///<param name="wcEcnNo">変更通知番号</param>
        ///<returns>業者配布履歴・ヘッダテーブル</returns>
        ///<remarks>20240101 劉(大連) 新規作成</remarks>
        public List<HAIFU_HEADER> SelHaifuHeaderData(string wcEcnNo)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<HAIFU_HEADER> result = new List<HAIFU_HEADER>();
            result = da.SelHaifuHeaderData(wcEcnNo);
            da.Close();
            return result;
        }

        /// <summary>
        ///オブジェクトデータを取得する。
        ///</summary>
        ///<param name="lxExportSeq">取得された連携シーケンス</param>
        ///<returns>オブジェクトテーブル</returns>
        ///<remarks>20240101 劉(大連) 新規作成</remarks>
        public List<V_LX_OBJ_INFO> SelVLxObjInfoData(string lxExportSeq)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<V_LX_OBJ_INFO> result = new List<V_LX_OBJ_INFO>();
            result = da.SelVLxObjInfoData(lxExportSeq);
            da.Close();
            return result;
        }

        /// <summary>
        ///属性管理データを取得する。
        ///</summary>
        ///<param name="lxExportSeq">取得された連携シーケンス</param>
        ///<param name="lxObjType">ｵﾌﾞｼﾞｪｸﾄﾀｲﾌﾟ</param>
        ///<param name="lxObjNo">ｵﾌﾞｼﾞｪｸﾄNo</param>
        ///<param name="lxObjVersion">ｵﾌﾞｼﾞｪｸﾄﾊﾞｰｼﾞｮﾝ</param>
        ///<returns>属性管理テーブル</returns>
        ///<remarks>20240101 劉(大連) 新規作成</remarks>
        public List<V_LX_ATT_MNG> SelVLxAttMng2Data(string lxExportSeq, string lxObjType, string lxObjNo, string lxObjVersion)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<V_LX_ATT_MNG> result = new List<V_LX_ATT_MNG>();
            result = da.SelVLxAttMng2Data(lxExportSeq, lxObjType, lxObjNo, lxObjVersion);
            da.Close();
            return result;
        }

        /// <summary>
        ///ドキュメントファイルリンクデータを取得する。
        ///</summary>
        ///<param name="lxExportSeq">取得された連携シーケンス</param>
        ///<param name="lxObjType">ｵﾌﾞｼﾞｪｸﾄﾀｲﾌﾟ</param>
        ///<param name="lxObjNo">ｵﾌﾞｼﾞｪｸﾄNo</param>
        ///<param name="lxObjVersion">ｵﾌﾞｼﾞｪｸﾄﾊﾞｰｼﾞｮﾝ</param>
        ///<returns>ドキュメントファイルリンクテーブル</returns>
        ///<remarks>20240101 劉(大連) 新規作成</remarks>
        public List<V_LX_FILE_LINK_INFO> SelVFileObjInfoData(string lxExportSeq, string lxObjType, string lxObjNo, string lxObjVersion)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<V_LX_FILE_LINK_INFO> result = new List<V_LX_FILE_LINK_INFO>();
            result = da.SelVFileObjInfoData(lxExportSeq, lxObjType, lxObjNo, lxObjVersion);
            da.Close();
            return result;
        }

        /// <summary>
        ///業者配布履歴・ヘッダを登録する
        ///</summary>
        ///<param name="wcEcnNo">変更通知番号</param>
        ///<param name="lxWcAttValue">変更通知の名前</param>
        ///<param name="lxConent">コンテキスト</param>
        ///<param name="lxObjN0">図面・ドキュメントの番号</param>
        ///<param name="lxObjType">オブジェクトタイプ</param>
        ///<param name="lxWcAttValue2">図番</param>
        ///<param name="lxObjVersion">改訂</param>
        ///<param name="filePath">ドキュメントファイルパス</param>
        ///<param name="fileName">ドキュメントファイル名</param>
        ///<returns>登録結果</returns>
        ///<remarks>20240101 劉(大連) 新規作成</remarks>
        public int InsHaifuHeaderData(string wcEcnNo, string lxWcAttValue, string lxConent, string lxObjN0, string lxObjType, string lxWcAttValue2, string lxObjVersion, string filePath, string fileName)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            int result = 0;
            result = da.InsHaifuHeaderData(wcEcnNo, lxWcAttValue, lxConent, lxObjN0, lxObjType, lxWcAttValue2, lxObjVersion, filePath, fileName);
            da.Close();
            return result;
        }

        /// <summary>
        ///業者配布履歴・明細の登録用データを取得する。
        ///</summary>
        ///<param name="lxObjN0">図面・ドキュメントの番号</param>
        ///<returns>業者配布履歴(最新)テーブル</returns>
        ///<remarks>20240101 劉(大連) 新規作成</remarks>
        public List<HAIFU_DETAIL_LAST> SelDetailLastData(string lxObjN0)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            List<HAIFU_DETAIL_LAST> result =new List<HAIFU_DETAIL_LAST>();
            result = da.SelDetailLastData(lxObjN0);
            da.Close();
            return result;
        }

        /// <summary>
        ///業者配布履歴・明細を登録する
        ///</summary>
        ///<param name="wcEcnNo">変更通知番号</param>
        ///<param name="lxObjN0">図面・ドキュメントの番号</param>
        ///<param name="gyosyaID">業者ID</param>
        ///<param name="gyosyaName">業者名</param>
        ///<param name="busuu">部数</param>
        ///<param name="haifumoto">配布元</param>
        ///<returns>登録結果</returns>
        ///<remarks>20240101 劉(大連) 新規作成</remarks>
        ///<remarks>20190923 大連 韓  配布元を追加</remarks>
        public int InsHaifuDetailData(string wcEcnNo, string lxObjN0, string gyosyaID, string gyosyaName, string busuu, string haifumoto)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);
            int result = 0;
            result = da.InsHaifuDetailData(wcEcnNo, lxObjN0, gyosyaID, gyosyaName, busuu, haifumoto);
            da.Close();
            return result;
        }
    }

}
