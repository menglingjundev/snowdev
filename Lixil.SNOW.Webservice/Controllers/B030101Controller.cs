using Lixil.Snow.BizLogic;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lixil.SNOW.Webservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class B030101Controller : ControllerBase
    {

		/// <summary>
		///システム属性テーブルからコンテキスト、変更通知番号を取得する。
		///</summary>
		///<param name="lxExportSeq">取得された連携シーケンス</param>
		///<returns>システム属性テーブル</returns>
		///<remarks>20240101 劉(大連) 新規作成</remarks>
		[HttpGet(Name = "SelVLxSystemAttMngData/{lxExportSeq}")]
		public List<V_LX_SYSTEM_ATT> SelVLxSystemAttMngData(string lxExportSeq)
        {
            List<V_LX_SYSTEM_ATT> result = new List<V_LX_SYSTEM_ATT>();
            result = new B030101_BizLogic().SelVLxSystemAttMngData(lxExportSeq);

            return result;

        }

		/// <summary>
		///属性管理テーブルから属性値を取得して、変更通知の名前に設定する。
		///</summary>
		///<param name="lxExportSeq">取得された連携シーケンス</param>
		///<returns>属性管理テーブル</returns>
		///<remarks>20240101 劉(大連) 新規作成</remarks>
		[HttpGet(Name = "SelVLxAttMng1Data/{lxExportSeq}")]
		public List<V_LX_ATT_MNG> SelVLxAttMng1Data(string lxExportSeq)
        {
            List<V_LX_ATT_MNG> result = new List<V_LX_ATT_MNG>();
            result = new B030101_BizLogic().SelVLxAttMng1Data(lxExportSeq);

            return result;
        }

		/// <summary>
		///業者配布履歴・ヘッダを検索する。
		///</summary>
		///<param name="wcEcnNo">変更通知番号</param>
		///<returns>業者配布履歴・ヘッダテーブル</returns>
		///<remarks>20240101 劉(大連) 新規作成</remarks>
		[HttpGet(Name = "SelHaifuHeaderData/{wcEcnNo}")]
		public List<HAIFU_HEADER> SelHaifuHeaderData(string wcEcnNo)
        {
            List<HAIFU_HEADER> result = new List<HAIFU_HEADER>();
            result = new B030101_BizLogic().SelHaifuHeaderData(wcEcnNo);

            return result;
        }

		/// <summary>
		///オブジェクトデータを取得する。
		///</summary>
		///<param name="lxExportSeq">取得された連携シーケンス</param>
		///<returns>オブジェクトテーブル</returns>
		///<remarks>20240101 劉(大連) 新規作成</remarks>
		[HttpGet(Name = "SelVLxObjInfoData/{lxExportSeq}")]
		public List<V_LX_OBJ_INFO> SelVLxObjInfoData(string lxExportSeq)
        {
            List<V_LX_OBJ_INFO> result = new List<V_LX_OBJ_INFO>();
            result = new B030101_BizLogic().SelVLxObjInfoData(lxExportSeq);

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
		[HttpGet(Name = "SelVLxAttMng2Data/{lxExportSeq}/{lxObjType}/{lxObjNo}/{lxObjVersion}")]
		public List<V_LX_ATT_MNG> SelVLxAttMng2Data(string lxExportSeq, string lxObjType, string lxObjNo, string lxObjVersion)
        {
            List<V_LX_ATT_MNG> result = new List<V_LX_ATT_MNG>();
            result = new B030101_BizLogic().SelVLxAttMng2Data(lxExportSeq, lxObjType, lxObjNo, lxObjVersion);

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
		[HttpGet(Name = "SelVFileObjInfoData/{lxExportSeq}/{lxObjType}/{lxObjNo}/{lxObjVersion}")]
		public List<V_LX_FILE_LINK_INFO> SelVFileObjInfoData(string lxExportSeq, string lxObjType, string lxObjNo, string lxObjVersion)
        {
            List<V_LX_FILE_LINK_INFO> result = new List<V_LX_FILE_LINK_INFO>();
            result = new B030101_BizLogic().SelVFileObjInfoData(lxExportSeq, lxObjType, lxObjNo, lxObjVersion);

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
		[HttpPost(Name = "SelVFileObjInfoData/{wcEcnNo}/{lxWcAttValue}/{lxConent}/{lxObjN0}/{lxObjType}/{lxWcAttValue2}/{lxObjVersion}/{filePath}/{fileName}")]
		public int InsHaifuHeaderData(string wcEcnNo, string lxWcAttValue, string lxConent, string lxObjN0, string lxObjType, string lxWcAttValue2, string lxObjVersion, string filePath, string fileName)
        {
            int result = 0;
            result = new B030101_BizLogic().InsHaifuHeaderData(wcEcnNo, lxWcAttValue, lxConent, lxObjN0, lxObjType, lxWcAttValue2, lxObjVersion, filePath, fileName);

            return result;
        }

		/// <summary>
		///業者配布履歴・明細の登録用データを取得する。
		///</summary>
		///<param name="lxObjN0">図面・ドキュメントの番号</param>
		///<returns>業者配布履歴(最新)テーブル</returns>
		///<remarks>20240101 劉(大連) 新規作成</remarks>
		[HttpPost(Name = "SelDetailLastData/{lxObjN0}")]
		public List<HAIFU_DETAIL_LAST> SelDetailLastData(string lxObjN0)
        {
            List<HAIFU_DETAIL_LAST> result = new List<HAIFU_DETAIL_LAST>();
            result = new B030101_BizLogic().SelDetailLastData(lxObjN0);

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
		[HttpPost(Name = "InsHaifuDetailData/{lxObjN0}/{lxObjN0}/{gyosyaID}/{gyosyaName}/{busuu}/{haifumoto}")]
		public int InsHaifuDetailData(string wcEcnNo, string lxObjN0, string gyosyaID, string gyosyaName, string busuu, string haifumoto)
        {
            int result = 0;
            result = new B030101_BizLogic().InsHaifuDetailData(wcEcnNo, lxObjN0, gyosyaID, gyosyaName, busuu, haifumoto);

            return result;
        }

    }
}
