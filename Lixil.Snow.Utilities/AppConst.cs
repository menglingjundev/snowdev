using System.Runtime.CompilerServices;

namespace Lixil.Snow.Utilities
{
    public static class AppConst
    {
        /// <summary>
        /// 固定文字"-"
        /// </summary>
        public const string HYPHEN = "-";
        /// <summary>
        /// slash(/)
        /// </summary>
        public const string SLASH = "/";

        /// <summary>
        /// [*]
        /// </summary>
        public const string HOSHI = "*";

        /// <summary>
        /// なかてん [.]
        /// </summary>
        public const string PERIOD = ".";

        /// <summary>
        /// コンマ [,]
        /// </summary>
        public const string COMMA = ",";

        /// <summary>
        /// 下線 [_]
        /// </summary>
        public const string UNDERLINE = "_";

        /// <summary>
        /// コロン [:]
        /// </summary>
        public const string COLON = ":";

        /// <summary>
        /// セミコロン [;]
        /// </summary>
        public const string SEMICOLON = ";";

        /// <summary>
        /// イコール [=]
        /// </summary>
        public const string EQUAL = "=";

        /// <summary>
        /// シンブル引用符号 [=]
        /// </summary>
        public const string SINGLE_QUAT = "'";

        /// <summary>
        /// [@]
        /// </summary>
        public const string AT = "@";

        /// <summary>
        /// 実行結果フラグ
        /// </summary>
        /// <remarks></remarks>
        public class ResultFlg
        {
            public const Int32 SUCCESS = 0;
            public const Int32 FAILURE = 1;
        }

        /// <summary>
        /// ステータス
        /// </summary>
        /// <remarks></remarks>
        public class Status
        {
            //回収済
            public const string KAISYUZUMI = "回収済";
            //配布予定
            public const string HAIFUYOTEI = "配布予定";
            //配布済
            public const string HAIFUZUMI = "配布済";
        }

        /// <summary>
        /// 浴室
        /// </summary>
        public const string YOKUSHITSU = "浴室";

        /// <summary>
        /// 洗面
        /// </summary>
        public const string SENMEN = "洗面";

        /// <summary>
        /// 新品番
        /// </summary>
        public const string SINHINBAN = "新品番";

        /// <summary>
        /// 業者割当機能ID
        /// </summary>
        public const string PGM_P030201 = "P030201";

        /// <summary>
        /// 配布履歴機能ID
        /// </summary>
        public const string PGM_P030301 = "P030301";

        /// <summary>
        /// 採番機能ID
        /// </summary>
        public const string PGM_P130101 = "P130101";

        /// <summary>
        /// 採番EXE機能ID
        /// </summary>
        public const string PGM_P130201 = "P130201";

        /// <summary>
        /// 部品更新(浴室)機能ID
        /// </summary>
        public const string PGM_B051201 = "B051201";

        /// <summary>
        /// BOM更新(浴室)機能ID
        /// </summary>
        public const string PGM_B0513 = "B051301";

        /// <summary>
        /// 部品更新(洗面)機能ID
        /// </summary>
        public const string PGM_B0515 = "B051501";

        /// <summary>
        /// BOM更新(洗面)機能ID
        /// </summary>
        public const string PGM_B0516 = "B051601";

        /// <summary>
        /// 工場マスタの機能ID
        /// </summary>
        public const string PGM_P0590 = "P059001";

        /// <summary>
        /// 業者マスタインポート機能ID
        /// </summary>
        public const string PGM_B0304 = "B030401";

        /// <summary>
        /// 業者ID変更
        /// </summary>
        public const string PGM_P039001 = "P039001";

        /// <summary>
        /// 図面・ドキュメント履歴削除
        /// </summary>
        public const string PGM_P099001 = "P099001";

        /// <summary>
        /// ファイル名拡張子 テキストファイル
        /// </summary>
        public const string TEXT_FILE_EXTENSION = "txt";

        /// <summary>
        /// ファイル名拡張子 Excelファイル
        /// </summary>
        public const string EXCEL_FILE_EXTENSION = "xlsx";

        /// <summary>
        /// ファイル名拡張子 テキストファイル
        /// </summary>
        public const string FILE_NAME_EXTENSION_TEXT = ".txt";

        /// <summary>
        /// ファイル名拡張子 Excelファイル
        /// </summary>
        public const string FILE_NAME_EXTENSION_EXCEL = ".xlsx";

        /// <summary>
        /// ファイル名拡張子 エンドファイル
        /// </summary>
        public const string FILE_NAME_EXTENSION_END = ".end";

        /// <summary>
        /// ファイル名拡張子 リクエストファイル
        /// </summary>
        public const string FILE_NAME_EXTENSION_REQUEST = ".req";

        /// <summary>
        /// ファイル名拡張子 リクエストファイル
        /// </summary>
        public const string FILE_NAME_EXTENSION_CSV = ".csv";

        /// <summary>
        /// ファイル名拡張子 Initialization
        /// </summary>
        public const string FILE_NAME_EXTENSION_INI = ".ini";

        /// <summary>
        /// BOM更新
        /// </summary>
        public const string UPDATE_BOM = "BOM更新";

        /// <summary>
        /// backslash(\)
        /// </summary>
        public const string BACKSLASH = "\\";

        /// <summary>
        /// エラーファイル名
        /// </summary>
        public const string ERROR_FILE = "_ERROR";

        /// <summary>
        /// 採番用分類1
        /// </summary>
        public const string SAIBANBUNRUI1 = "採番用分類1";

        /// <summary>
        /// 採番用分類2
        /// </summary>
        public const string SAIBANBUNRUI2 = "採番用分類2";

        /// <summary>
        /// 採番用分類3
        /// </summary>
        public const string SAIBANBUNRUI3 = "採番用分類3";

        /// <summary>
        /// 採番用分類4
        /// </summary>
        public const string SAIBANBUNRUI4 = "採番用分類4";

        /// <summary>
        /// 採番用分類5
        /// </summary>
        public const string SAIBANBUNRUI5 = "採番用分類5";

        /// <summary>
        /// 必要
        /// </summary>
        public const string HITUYOU = "必要";

        /// <summary>
        /// 不要
        /// </summary>
        public const string HUYOU = "不要";

        /// <summary>
        /// エラーにする
        /// </summary>
        public const string ERR = "エラーにする";

        /// <summary>
        /// 開始値に戻る
        /// </summary>
        public const string STARTVALUE = "開始値に戻る";

        /// <summary>
        /// 必要/可/削除
        /// </summary>
        public const string HITUYOU_FLG = "1";

        /// <summary>
        /// 不要/否/有効
        /// </summary>
        public const string HUYOU_FLG = "0";

        /// <summary>
        /// 配布元ファイル名
        /// </summary>
        public const string FILE_NAME_HAIFUMOTO = "HAIFUMOTO";
    }
}
