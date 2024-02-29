using Lixil.Snow.DataAccess;
using Lixil.Snow.DataModel;
using Lixil.Snow.Utilities;
using System.Data;
using System;
using System.Reflection;
using System.Transactions;
using Npgsql;

namespace Lixil.Snow.BizLogic
{
    /// <summary>
    /// 採番の種類マスタのデータアクセス
    /// </summary>
    public class P130102_BizLogic
    {

        //SQL文実行用
        private P130102_DataAccess da;

        public P130102_BizLogic()
        {
            da = new P130102_DataAccess();
        }

        /// <summary>
        /// 採番マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <param name="burui5">採番用分類５</param>
        /// <param name="maeMoji">前部文字列</param>
        /// <param name="isLock">ロック用</param>
        /// <returns>採番マスタ情報</returns>
        /// <remarks>20231208 孟(大連) 新規作成</remarks>
        public List<SAIBAN> GetSaiban(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5, string maeMoji, bool isLock)
        {

            // イベントログ追加System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            List<SAIBAN> result = new List<SAIBAN>();
            result = da.GetSaiban(saibanSyurui, burui1, burui2, burui3, burui4, burui5, maeMoji, isLock);
            da.Close();
            return result;
        }

        /// <summary>
        /// 採番マスタのデータを登録
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <param name="burui5">採番用分類５</param>
        /// <param name="maeMoji">前部文字列</param>
        /// <param name="kijunbi">基準日</param>
        /// <param name="seqLast">最終番号</param>
        /// <returns>影響行数</returns>
        /// <param name="userID">ユーザーID</param>
        /// <param name="PGM">機能ID</param>
        /// <remarks>20231208 孟(大連) 新規作成</remarks>
        public int InsertSaiban(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5, string maeMoji, DateTime kijunbi, long seqLast, string userID, string PGM)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            var result = da.InsertSaiban(saibanSyurui, burui1, burui2, burui3, burui4, burui5, maeMoji, kijunbi, seqLast, userID, PGM);

            return result;
        }

        /// <summary>
        /// 採番マスタのデータを更新
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <param name="burui5">採番用分類５</param>
        /// <param name="maeMoji">前部文字列</param>
        /// <param name="kijunbi">基準日</param>
        /// <param name="seqLast">最終番号</param>
        /// <returns>影響行数</returns>
        /// <param name="userID">ユーザーID</param>
        /// <param name="PGM">機能ID</param>
        /// <remarks>20231208 孟(大連) 新規作成</remarks>
        public int UpdateSaiban(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5, string maeMoji, DateTime kijunbi, long seqLast, string userID, string PGM)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            var result = da.UpdateSaiban(saibanSyurui, burui1, burui2, burui3, burui4, burui5, maeMoji, kijunbi, seqLast, userID, PGM);

            return result;
        }

        /// <summary>
        /// 採番種類の取得
        /// </summary>
        /// <param name="saibanSyurui">採番種類</param>
        /// <returns>採番種類マスタ情報</returns>
        /// <remarks>20231208 孟(大連) 新規作成</remarks>
        public List<SAIBANSYURUI> GetSaiBanSyurui(string saibanSyurui)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            List<SAIBANSYURUI> result = new List<SAIBANSYURUI>();
            result = da.GetSaiBanSyurui(saibanSyurui);
            da.Close();
            return result;
        }

        /// <summary>
        /// 採番の分類マスタのデータの取得
        /// </summary>
        /// <param name="saibanSyurui">採番の種類</param>
        /// <param name="burui1">採番用分類１</param>
        /// <param name="burui2">採番用分類２</param>
        /// <param name="burui3">採番用分類３</param>
        /// <param name="burui4">採番用分類４</param>
        /// <param name="burui5">採番用分類５</param>
        /// <returns>採番の分類マスタ情報</returns>
        /// <remarks>20231208 孟(大連) 新規作成</remarks>
        public List<SAIBAN_BUNRUI> GetSaibanBunrui(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            List<SAIBAN_BUNRUI> result = new List<SAIBAN_BUNRUI>();
            result = da.GetSaibanBunrui(saibanSyurui, burui1, burui2, burui3, burui4, burui5);
            da.Close();
            return result;
        }

        /// <summary>
        /// 採番履歴マスタのデータを登録
        /// </summary>
        /// <param name="partNumber">品番</param>
        /// <param name="partName">品名</param>
        /// <param name="reason">新設理由</param>
        /// <param name="tenkai">今後の展開</param>
        /// <param name="syozoku">所属</param>
        /// <param name="sakuseiPerson">作成者</param>
        /// <returns>影響行数</returns>
        /// <param name="userID">ユーザーID</param>
        /// <param name="PGM">機能ID</param>
        /// <remarks>20231208 孟(大連) 新規作成</remarks>
        public int InsertSaibanRireki(string partNumber, string partName, string reason, string tenkai, string syozoku, string sakuseiPerson, string userID, string PGM)
        {
            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            var result = da.InsertSaibanRireki(partNumber, partName, reason, tenkai, syozoku, sakuseiPerson, userID, PGM);

            return result;
        }

        /// <summary>
        /// 採番処理
        /// </summary>
        /// <param name="saibanSyurui">採番種類</param>
        /// <param name="burui1">採番の種類1</param>
        /// <param name="burui2">採番の種類2</param>
        /// <param name="burui3">採番の種類3</param>
        /// <param name="burui4">採番の種類4</param>
        /// <param name="burui5">採番の種類5</param>
        /// <param name="kijunbi">基準日</param>
        /// <param name="saibanSuu">採番数</param>
        /// <param name="syozoku">所属</param>
        /// <param name="sakuseiPerson">作成者</param>
        /// <param name="partName">品名</param>
        /// <param name="reason">新設の理由</param>
        /// <param name="tenkai">今後の展開</param>
        /// <param name="userID">ユーザーID</param>
        /// <param name="PGM">機能ID</param>
        /// <returns>採番結果</returns>
        public List<string> Saiban(string saibanSyurui, string burui1, string burui2, string burui3, string burui4, string burui5, string kijunbi, int saibanSuu, string syozoku, string sakuseiPerson, string partName, string reason, string tenkai, string userID, string PGM)
        {

            // イベントログ追加
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            // 採番結果
            List<string> result = new List<string>();

            // 採番用分類１が空白の場合、
            if (string.IsNullOrWhiteSpace(burui1))
                burui1 = Utilities.AppConst.HYPHEN;
            // 採番用分類２が空白の場合、
            if (string.IsNullOrWhiteSpace(burui2))
                burui2 = Utilities.AppConst.HYPHEN;
            // 採番用分類３が空白の場合、
            if (string.IsNullOrWhiteSpace(burui3))
                burui3 = Utilities.AppConst.HYPHEN;
            // 採番用分類４が空白の場合、
            if (string.IsNullOrWhiteSpace(burui4))
                burui4 = Utilities.AppConst.HYPHEN;
            // 採番用分類５が空白の場合、
            if (string.IsNullOrWhiteSpace(burui5))
                burui5 = Utilities.AppConst.HYPHEN;

            // マスタ情報取得
            // 採番の種類を取得する。
            List<SAIBANSYURUI> saibanSyuruiDt = da.GetSaiBanSyurui(saibanSyurui);
            if (saibanSyuruiDt.Count == 0)
            {
                da.Close();
                result.Add(string.Empty);
                result.Add(Utilities.MessageConst.MSG_COMM_020);
                return result;
            }
            // 採番分類マスタから、採番履歴データを取得する。
            List<SAIBAN_BUNRUI> saibanBunruiDT = da.GetSaibanBunrui(saibanSyurui, burui1, burui2, burui3, burui4, burui5);
            if (saibanBunruiDT.Count == 0)
            {
                da.Close();
                result.Add(string.Empty);
                result.Add(Utilities.MessageConst.MSG_COMM_017);
                return result;
            }

            // 基準日チェック
            string kijunbiFLg = saibanBunruiDT[0].KIJUNBI_FLG;
            // 前文字
            var maeMojiDB = saibanBunruiDT[0].MAE_MOJI;
            string maeMoji = string.IsNullOrEmpty(maeMojiDB) ? string.Empty : maeMojiDB.ToString();
            // 連番桁数
            int seqLength = Convert.ToInt32(saibanBunruiDT[0].SEQ_LENGTH);

            if ("1".Equals(kijunbiFLg))
            {
                // 存在性チェック
                if (string.IsNullOrWhiteSpace(kijunbi))
                {
                    da.Close();
                    result.Add(string.Empty);
                    result.Add(string.Format(Utilities.MessageConst.MSG_COMM_015, "基準日"));
                    return result;
                }
                // フォーマットチェック
                if (kijunbi.Length != 8)
                {
                    da.Close();
                    result.Add(string.Empty);
                    result.Add(string.Format(Utilities.MessageConst.MSG_COMM_021, "基準日(yyyymmdd)"));
                    return result;
                }
                string monthStr = kijunbi.Substring(4, 2);
                int resultInt;
                if (!int.TryParse(monthStr, out resultInt))
                {
                    da.Close();
                    result.Add(string.Empty);
                    result.Add(string.Format(string.Format(Utilities.MessageConst.MSG_COMM_021, "基準日(yyyymmdd)の月")));
                    return result;
                }
                else
                {
                    int month = int.Parse(monthStr);
                    if (!(month > 0 && month <= 12))
                    {
                        da.Close();
                        result.Add(string.Empty);
                        result.Add(string.Format(Utilities.MessageConst.MSG_COMM_021, "基準日(yyyymmdd)の月"));
                        return result;
                    }
                }
                // 前文字処理
                maeMoji = maeMoji.Replace("%yyyy%", kijunbi.Substring(0, 4));
                maeMoji = maeMoji.Replace("%yymm%", kijunbi.Substring(2, 4));
            }

            // 採番履歴属性チェック
            string rirekiFlg = saibanSyuruiDt[0].RIREKI_FLG;
            if ("1".Equals(rirekiFlg))
            {
                if (string.IsNullOrWhiteSpace(syozoku))
                {
                    da.Close();
                    result.Add(string.Empty);
                    result.Add(string.Format(Utilities.MessageConst.MSG_COMM_015, "所属"));
                    return result;
                }
                if (string.IsNullOrWhiteSpace(sakuseiPerson))
                {
                    da.Close();
                    result.Add(string.Empty);
                    result.Add(string.Format(Utilities.MessageConst.MSG_COMM_015, "作成者"));
                    return result;
                }
                if (string.IsNullOrWhiteSpace(partName))
                {
                    da.Close();
                    result.Add(string.Empty);
                    result.Add(string.Format(Utilities.MessageConst.MSG_COMM_015, "品名"));
                    return result;
                }
                if (string.IsNullOrWhiteSpace(reason))
                {
                    da.Close();
                    result.Add(string.Empty);
                    result.Add(string.Format(Utilities.MessageConst.MSG_COMM_015, "新設の理由"));
                    return result;
                }
                if (string.IsNullOrWhiteSpace(tenkai))
                {
                    da.Close();
                    result.Add(string.Empty);
                    result.Add(string.Format(Utilities.MessageConst.MSG_COMM_015, "今後の展開"));
                    return result;
                }
            }

            // 最終番号
            long seqLast = 0;
            long seqStart = Convert.ToInt64(saibanBunruiDT[0].SEQ_START);
            long seqEnd = Convert.ToInt64(saibanBunruiDT[0].SEQ_END);
            string overFlg = saibanBunruiDT[0].OVER_FLG;
            
            using (NpgsqlTransaction scope = SqlManager.BeginTransaction)
            {
                // 最終番号取得
                List<SAIBAN> saibanDT = da.GetSaiban(saibanSyurui, burui1, burui2, burui3, burui4, burui5, maeMoji, true);

                if (saibanDT.Count > 0)
                    seqLast = Convert.ToInt64(saibanDT[0].SEQ_LAST);

                if ("1".Equals(rirekiFlg))
                {
                    if (saibanDT.Count > 0)
                    {
                        // 採番テーブルから最終番号が取得できた場合、かつ、採番分類マスタ.終了値超えの処理 = エラーにする の場合
                        if ("1".Equals(overFlg))
                        {
                            if (saibanSuu < 1 || saibanSuu > seqEnd - seqLast)
                            {
                                da.Close();
                                result.Add(string.Empty);
                                result.Add(string.Format(Utilities.MessageConst.MSG_COMM_018, seqEnd - seqLast));
                                scope.Dispose();
                                return result;
                            }
                        }
                    }
                    else
                    {
                        // 採番テーブルから最終番号が取得できなかった場合
                        if (saibanSuu < 1 || saibanSuu > seqEnd - seqStart + 1)
                        {
                            da.Close();
                            result.Add(string.Empty);
                            result.Add(string.Format(Utilities.MessageConst.MSG_COMM_018, seqEnd - seqStart + 1));
                            scope.Dispose();
                            return result;
                        }
                    }
                }

                // 採番
                // 日付型に変換
                DateTime kijunbiDate = default(DateTime);
                if (!string.IsNullOrWhiteSpace(kijunbi))
                {
                    string kijunbi_ = kijunbi.Insert(6, Utilities.AppConst.SLASH);
                    kijunbi_ = kijunbi_.Insert(4, Utilities.AppConst.SLASH);
                    kijunbiDate = DateTime.Parse(kijunbi_);
                }

                int dbResult = 0;
                if (seqLast + saibanSuu <= seqEnd)
                {
                    // 最終番号を取得できなかった場合
                    if (saibanDT.Count == 0)
                        // 取得した最終番号に採番数を加算し、採番テーブルの採番数を更新する
                        dbResult = da.InsertSaiban(saibanSyurui, burui1, burui2, burui3, burui4, burui5, maeMoji, kijunbiDate, seqLast + saibanSuu, userID, PGM);
                    else
                        // 取得した最終番号に採番数を加算し、採番テーブルの採番数を更新する
                        dbResult = da.UpdateSaiban(saibanSyurui, burui1, burui2, burui3, burui4, burui5, maeMoji, kijunbiDate, seqLast + saibanSuu, userID, PGM);
                }
                else if (saibanDT.Count == 0)
                    // 取得した最終番号に採番数を加算し、採番テーブルの採番数を更新する
                    dbResult = da.InsertSaiban(saibanSyurui, burui1, burui2, burui3, burui4, burui5, maeMoji, kijunbiDate, seqLast + saibanSuu - seqEnd + seqStart - 1, userID, PGM);
                else
                    // 取得した最終番号に採番数を加算し、採番テーブルの採番数を更新する
                    dbResult = da.UpdateSaiban(saibanSyurui, burui1, burui2, burui3, burui4, burui5, maeMoji, kijunbiDate, seqLast + saibanSuu - seqEnd + seqStart - 1, userID, PGM);

                if (dbResult == 0)
                {
                    da.Close();
                    result.Add(string.Empty);
                    result.Add(string.Format(Utilities.MessageConst.MSG_COMM_079, "採番テーブル"));
                    scope.Dispose();
                    return result;
                }

                // 採番結果作成
                string saibanCd = string.Empty;
                List<string> saibanCds = new List<string>();
                if (seqLast + saibanSuu <= seqEnd)
                {
                    for (var index = seqLast + 1; index <= seqLast + saibanSuu; index++)
                    {
                        // 連番桁数＝0の場合は、前ゼロなし
                        if (seqLength == 0)
                            saibanCds.Add(maeMoji + index.ToString());
                        else
                        {
                            string str = index.ToString().PadLeft(seqLength, '0');
                            saibanCds.Add(maeMoji + str);
                        }
                    }
                }
                else
                {
                    for (var index = seqLast + 1; index <= seqEnd; index++)
                    {
                        // 連番桁数＝0の場合は、前ゼロなし
                        if (seqLength == 0)
                            saibanCds.Add(maeMoji + index.ToString());
                        else
                        {
                            string str = index.ToString().PadLeft(seqLength, '0');
                            saibanCds.Add(maeMoji + str);
                        }
                    }
                    for (var index = 1; index <= seqLast + saibanSuu - seqEnd + seqStart - 1; index++)
                    {
                        // 連番桁数＝0の場合は、前ゼロなし
                        if (seqLength == 0)
                            saibanCds.Add(maeMoji + index.ToString());
                        else
                        {
                            string str = index.ToString().PadLeft(seqLength, '0');
                            saibanCds.Add(maeMoji + str);
                        }
                    }
                }
                saibanCd = string.Join("|", saibanCds);

                // 採番履歴作成
                if ("1".Equals(saibanSyuruiDt[0].RIREKI_FLG))
                    dbResult = da.InsertSaibanRireki(saibanCd, partName, reason, tenkai, syozoku, sakuseiPerson, userID, PGM);
                if (dbResult == 0)
                {
                    da.Close();
                    result.Add(string.Empty);
                    result.Add(string.Format(Utilities.MessageConst.MSG_COMM_079, "採番履歴テーブル"));
                    scope.Dispose();
                    return result;
                }
                result.Add(saibanCd);
                result.Add(string.Empty);
                da.Close();
                scope.Commit();
            }

            return result;
        }


    }
}
