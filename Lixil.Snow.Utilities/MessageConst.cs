using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lixil.Snow.Utilities
{
    public class MessageConst
    {
        private static string MSG_COMM_001Value = "起動パラメータとしての連携シーケンスは必須入力です。";
        private static string MSG_COMM_002Value = "連携シーケンス{0}がシステム属性テーブルに存在しません。";
        private static string MSG_COMM_003Value = "連携シーケンス{0}の変更通知名が取得出来ませんでした。";
        private static string MSG_COMM_004Value = "連携シーケンス{0}の変更通知番号{1}は、業者配布履歴に既に存在しています。";
        private static string MSG_COMM_005Value = "連携シーケンス{0}に{1}、{2}、{3}のファイルリンクが存在していません。";
        private static string MSG_COMM_006Value = "対象の業者配布履歴が存在していません。";
        private static string MSG_COMM_007Value = "{0}を選択してください。";
        private static string MSG_COMM_008Value = "配布業者数が5業者を超えるため、業者を追加できません。";
        private static string MSG_COMM_009Value = "修正された業者配布履歴が存在していません。";

        private static string MSG_COMM_011Value = "回収済の図面は、配布実施できません。";
        private static string MSG_COMM_012Value = "{0}を指定して下さい。";
        private static string MSG_COMM_013Value = "サブフォルダーが作成できませんでした。";
        private static string MSG_COMM_014Value = "{0}が取得できませんでした。";
        private static string MSG_COMM_015Value = "{0}を入力して下さい。";
        private static string MSG_COMM_016Value = "{0}を登録失敗します。";
        private static string MSG_COMM_017Value = "採番分類マスタが存在していません。";
        private static string MSG_COMM_018Value = "採番数が多すぎるため、採番出来ません。(最大{0}です。)";
        private static string MSG_COMM_019Value = "採番時にエラーが発生しました。(エラーメッセージ：{0})";
        private static string MSG_COMM_020Value = "採番の種類マスタが存在していません。";
        private static string MSG_COMM_021Value = "{0}が正しくありません。";
        private static string MSG_COMM_022Value = "{0}が存在していません。";
        private static string MSG_COMM_023Value = "{0}が読み込めません。";
        private static string MSG_COMM_024Value = "作成フォルダで指定したフォルダに部品更新編集シートが作成できません。";
        private static string MSG_COMM_025Value = "インポートファイルのフォーマット名(1行目のA列の値)が画面で選択したフォーマット名と一致していません。";
        private static string MSG_COMM_026Value = "インポートファイルがコピーできませんでした。";
        private static string MSG_COMM_027Value = "Snowの処理中フォルダ検索でエラーが発生しました。";
        private static string MSG_COMM_028Value = "Snowの処理中フォルダでエンドファイル「99999999.end」が削除できませんでした。";
        private static string MSG_COMM_029Value = "Windchillの監視フォルダ検索でエラーが発生しました。";
        private static string MSG_COMM_030Value = "Windchillの監視フォルダでリクエストファイル「{0}.req」が削除できませんでした。";
        private static string MSG_COMM_031Value = "Snowの監視フォルダ検索でエラーが発生しました。";
        private static string MSG_COMM_032Value = "Snowの監視フォルダでリクエストファイル「{0}.req」が削除できませんでした。";
        private static string MSG_COMM_033Value = "リクエストファイル「{0}.req」の読み込みでエラーが発生しました。(エラーメッセージ：{1})";
        private static string MSG_COMM_034Value = "リクエストファイル「{0}.req」の読み込みでエラーが発生しました。(異常終了)";
        private static string MSG_COMM_035Value = "リクエストファイル「{0}.req」に対応するインプットファイルが存在していません。";
        private static string MSG_COMM_036Value = "部品属性チェック(浴室)のエラー終了後に処理中フォルダのリクエストファイル「{0}.req」が削除できませんでした。";
        private static string MSG_COMM_037Value = "インプットファイル「{0}」の部品属性チェックでエラーが発生しました。(異常終了)";
        private static string MSG_COMM_038Value = "部品更新(浴室)の正常終了後に処理中フォルダのリクエストファイル「{0}.req」が削除できませんでした。";
        private static string MSG_COMM_039Value = "部品更新(浴室)のエラー終了後に処理中フォルダのリクエストファイル「{0}.req」が削除できませんでした。";
        private static string MSG_COMM_040Value = "インプットファイル「{0}」の部品更新でエラーが発生しました。(異常終了)";
        private static string MSG_COMM_041Value = "部品更新(浴室)の異常終了後に処理中フォルダのリクエストファイル「{0}.req」が削除できませんでした。";
        private static string MSG_COMM_042Value = "BOM更新(浴室)の正常終了後に処理中フォルダのリクエストファイル「{0}.req」が削除できませんでした。";
        private static string MSG_COMM_043Value = "BOM更新(浴室)のエラー終了後に処理中フォルダのリクエストファイル「{0}.req」が削除できませんでした。";
        private static string MSG_COMM_044Value = "インプットファイル「{0}」のBOM更新でエラーが発生しました。(異常終了)";
        private static string MSG_COMM_045Value = "BOM更新(浴室)の異常終了後に処理中フォルダのリクエストファイル「{0}.req」が削除できませんでした。";
        private static string MSG_COMM_046Value = "部品属性チェック(洗面)のエラー終了後に処理中フォルダのリクエストファイル「{0}.req」が削除できませんでした。";
        private static string MSG_COMM_047Value = "部品属性チェック(洗面)の異常終了後に処理中フォルダのリクエストファイル「{0}.req」が削除できませんでした。";
        private static string MSG_COMM_048Value = "部品属性チェック(洗面)の正常終了(スキップ)後に処理中フォルダのリクエストファイル「{0}.req」が削除できませんでした。";
        private static string MSG_COMM_049Value = "部品更新(洗面)の正常終了後に処理中フォルダのリクエストファイル「{0}.req」が削除できませんでした。";
        private static string MSG_COMM_050Value = "部品更新(洗面)のエラー終了後に処理中フォルダのリクエストファイル「{0}.req」が削除できませんでした。";
        private static string MSG_COMM_051Value = "部品更新(洗面)の異常終了後に処理中フォルダのリクエストファイル「{0}.req」が削除できませんでした。";
        private static string MSG_COMM_052Value = "更新処理のスキップ(更新対象部門以外)で処理中フォルダのリクエストファイル「{0}.req」が削除できませんでした。";
        private static string MSG_COMM_053Value = "インプットファイル「{0}」で部品更新(浴室)処理が部門「{1}」で呼び出されました。";
        private static string MSG_COMM_054Value = "インプットファイル「{0}」で部品更新(浴室)処理が存在しないユーザーID「{1}」で呼び出されました。";
        private static string MSG_COMM_055Value = "インプットファイル「{0}」が存在していません。";
        private static string MSG_COMM_056Value = "インプットファイル「{0}」の拡張子が正しくありません。(対応している拡張子は .txt または .xlsx です。)";
        private static string MSG_COMM_057Value = "インプットファイル「{0}」がテキストデータとして読み込めませんでした。";
        private static string MSG_COMM_058Value = "インプットファイル「{0}」に入力データがありませんでした。";
        private static string MSG_COMM_059Value = "インプットファイル「{0}」のファイル形式(タブ区切りテキスト)が正しくありません。";
        private static string MSG_COMM_060Value = "{0}がExcel(xlsx)ファイルとして読み込めませんでした。";
        private static string MSG_COMM_061Value = "{0}に入力データがありませんでした。(1行目のA列が空白です。)";
        private static string MSG_COMM_062Value = "{0}に入力データがありませんでした。";
        private static string MSG_COMM_063Value = "{0}のフォーマット名(1行目)は更新対象のフォーマット名ではありません。";
        private static string MSG_COMM_064Value = "{0}にフォーマット「{1}」で定義されていない属性があります。(属性名：{2})";
        private static string MSG_COMM_065Value = "部品属性更新の{0}の入力値でエラーがありました。添付ファイルを参照して下さい。";
        private static string MSG_COMM_066Value = "品番：{0}は、登録済みです。";
        private static string MSG_COMM_067Value = "工場マスタに工場ID：{0}が登録されていません。";
        private static string MSG_COMM_068Value = "品番：{0}の登録で登録テーブルのIDが採番できませんでした。{1}";
        private static string MSG_COMM_069Value = "品番：{0}の登録でDB登録エラーが発生しました。{1}";
        private static string MSG_COMM_070Value = "品番：{0}は、登録されていません。";
        private static string MSG_COMM_071Value = "品番：{0}の更新で部品データが見つかりませんでした。";
        private static string MSG_COMM_072Value = "品番：{0}の更新で部品履歴データが見つかりませんでした。";
        private static string MSG_COMM_073Value = "品番：{0}、(納入)部門ｺｰﾄﾞ：{1}の更新で工場部品履歴データが見つかりませんでした。";
        private static string MSG_COMM_074Value = "品番：{0}の部品更新でDB更新エラーが発生しました。{1}";
        private static string MSG_COMM_075Value = "品番：{0}の部品履歴更新でDB更新エラーが発生しました。{1}";
        private static string MSG_COMM_076Value = "品番：{0}、(納入)部門ｺｰﾄﾞ：{1}の工場部品履歴更新でDB更新エラーが発生しました。{2}";
        private static string MSG_COMM_077Value = "品番：{0}の工場部品登録でDB登録エラーが発生しました。{1}";
        private static string MSG_COMM_078Value = "品番：{0}の部品更新履歴登録でDB登録エラーが発生しました。{1}";
        private static string MSG_COMM_079Value = "{0}でDB登録エラーが発生しました。";
        private static string MSG_COMM_080Value = "{0}を入力して下さい。";
        private static string MSG_COMM_081Value = "品番：{0}の工場部品履歴削除でDB削除エラーが発生しました。{1}";
        private static string MSG_COMM_082Value = "必須項目です。";
        private static string MSG_COMM_083Value = "入力文字数が多すぎます。(最大：{0})";
        private static string MSG_COMM_084Value = "数字以外の文字が入力されています。数字だけを入力して下さい。";
        private static string MSG_COMM_085Value = "正しい日付(yyyy/mm/dd形式)を入力して下さい。";
        // 20191121 大連 韓  (浴室)新規部材リスト改善を追加 Start
        // Private Shared MSG_COMM_086Value As String = "半角数字{0}桁で入力して下さい。"
        private static string MSG_COMM_086Value = "半角{0}桁で入力して下さい。";
        // 20191121 大連 韓  (浴室)新規部材リスト改善を追加 End
        private static string MSG_COMM_087Value = "正しい日付(yyyymmdd形式)を入力して下さい。";
        private static string MSG_COMM_089Value = "選択した業者が5業者を超えています。";
        private static string MSG_COMM_090Value = "web禁止文字( \" && ' , < > )が含まれています。";
        private static string MSG_COMM_091Value = "1以上の半角数字を入力してください。";
        private static string MSG_COMM_092Value = "インプットファイル「{0}」の入力値でエラーがありました";
        private static string MSG_COMM_093Value = "インプットファイル「{0}」でBOM更新(浴室)処理が部門「{1}」で呼び出されました。";
        private static string MSG_COMM_094Value = "インプットファイル「{0}」でBOM更新(浴室)処理が存在しないユーザーID「{1}」で呼び出されました。";
        private static string MSG_COMM_095Value = "インプットファイル「{0}」の拡張子が正しくありません。(対応している拡張子は .txtです。)";
        private static string MSG_COMM_096Value = "品番：<属性名「PART_NUMBER」の属性値>は、登録されていません。";
        private static string MSG_COMM_097Value = "親部品履歴ID：{0}の削除でDB更新エラーが発生しました。";
        private static string MSG_COMM_098Value = "親部品履歴ID：{0}、子部品履歴ID：{1}は、登録済みです。";
        private static string MSG_COMM_099Value = "BOM登録で登録テーブルのIDが採番できませんでした。{0}";
        private static string MSG_COMM_100Value = "BOM登録でDB登録エラーが発生しました。{0}";
        private static string MSG_COMM_101Value = "インプットファイル「{0}」で部品更新(洗面)処理が部門「{1}」で呼び出されました。";
        private static string MSG_COMM_102Value = "インプットファイル「{0}」で部品更新(洗面)処理が存在しないユーザーID「{1}」で呼び出されました。";
        private static string MSG_COMM_103Value = "半角数字、\",\"(カンマ)、\".\"(小数点)以外の文字が入力されています。数値を表現する文字だけを入力して下さい。";
        private static string MSG_COMM_104Value = "小数部の入力文字数が多すぎます。(最大：{0})";
        private static string MSG_COMM_105Value = "部品更新(洗面)で拡張子 .txt は、処理対象外です。インプットファイル「{0}」";
        private static string MSG_COMM_106Value = "設定ファイルから送付フラグが取得できませんでした。";
        private static string MSG_COMM_107Value = "設定ファイルから部材マスタ前回送付日時が取得できませんでした。";
        private static string MSG_COMM_108Value = "設定ファイルの部材マスタ前回送付日時が更新できませんでした。";
        private static string MSG_COMM_109Value = "フォルダ：{0}に展開マスタCSVを作成できませんでした。";
        private static string MSG_COMM_110Value = "設定ファイルの展開マスタ前回送付日時が更新できませんでした。";
        private static string MSG_COMM_111Value = "設定ファイルからFTP送信先情報を取得できませんでした。";
        private static string MSG_COMM_112Value = "FTP送信でエラーが発生しました。{0}";
        private static string MSG_COMM_113Value = "FTP送信後にファイル名が変更できませんでした。";
        private static string MSG_COMM_114Value = "業者マスタCSV({0})「{1}」が存在していません。";
        private static string MSG_COMM_115Value = "フォルダ：{0}に部材マスタCSVを作成できませんでした。";
        private static string MSG_COMM_116Value = "業者マスタCSV({0})が読み込めませんでした。";
        private static string MSG_COMM_117Value = "業者マスタCSV({0})のファイル形式(カンマ区切りCSV)が正しくありません。";
        private static string MSG_COMM_118Value = "{0}行目：1項目目の業者IDは必須です。";
        private static string MSG_COMM_119Value = "{0}行目：1項目目の業者IDは半角英数字(英字は大文字)を入力して下さい。";
        private static string MSG_COMM_120Value = "{0}行目：1項目目の業者IDは11文字以内で入力して下さい。";
        private static string MSG_COMM_121Value = "{0}行目：2項目目の業者名は必須です。";
        private static string MSG_COMM_122Value = "{0}行目：2項目目の業者名は256文字以内で入力して下さい。";
        private static string MSG_COMM_123Value = "{0}行目：3項目目の業者名(カナ)は必須です。";
        private static string MSG_COMM_124Value = "{0}行目：3項目目の業者名(カナ)は半角で入力して下さい。";
        private static string MSG_COMM_125Value = "{0}行目：3項目目の業者名(カナ)は256文字以内で入力して下さい。";
        private static string MSG_COMM_126Value = "業者マスタCSV({0})のデータチェックでエラーが発生しました。エラーファイルを確認して下さい。";
        private static string MSG_COMM_127Value = "業者マスタが削除できませんでした。{0}";
        private static string MSG_COMM_128Value = "業者マスタが登録できませんでした。{0}";
        private static string MSG_COMM_129Value = "{0}行目：4項目目の子図面配布フラグは空白または1を入力して下さい。";
        private static string MSG_COMM_130Value = "業者マスタCSV({0})に入力データがありませんでした。";
        private static string MSG_COMM_131Value = "インプットファイル「{0}」のフォーマット名(1行目)は更新対象のフォーマット名ではありません。";
        // Private Shared MSG_COMM_132Value As String = "業者マスタCSV(洗面)のファイル形式(カンマ区切りCSV)が正しくありません。"
        // Private Shared MSG_COMM_133Value As String = "業者マスタCSV(洗面)のデータチェックでエラーが発生しました。エラーファイルを確認して下さい。"
        private static string MSG_COMM_134Value = "工場IDは半角英数字(英字は大文字)で入力して下さい。";
        private static string MSG_COMM_135Value = "{0}は{1}文字以内で入力して下さい。";
        private static string MSG_COMM_136Value = "地区コードは半角英数字(英字は大文字)で入力して下さい。";
        private static string MSG_COMM_137Value = "地区コードは1文字で入力して下さい。";
        private static string MSG_COMM_138Value = "{0}が登録済です。";
        private static string MSG_COMM_139Value = "{0}が登録されていません。";
        private static string MSG_COMM_140Value = "{0}の登録でDB登録エラーが発生しました。";
        private static string MSG_COMM_141Value = "{0}の更新でDB更新エラーが発生しました。";
        private static string MSG_COMM_142Value = "{0}の削除でDB削除エラーが発生しました。";
        private static string MSG_COMM_143Value = "{0}の文字数が256文字を超えています。";
        private static string MSG_COMM_144Value = "{0}は半角英数記号で入力して下さい。";
        private static string MSG_COMM_145Value = "{0}は半角数字で入力して下さい。";
        private static string MSG_COMM_146Value = "{0}を超えています。";
        private static string MSG_COMM_147Value = "分類：{0}、{1}、{2}、{3}、{4}の組み合わせは、登録済です。";
        private static string MSG_COMM_148Value = "変更前と変更後が同じ分類名の場合は、更新できません。";
        private static string MSG_COMM_149Value = "更新対象データを使用している人がいるため、更新できません。しばらく待ってから再度更新して下さい。";
        private static string MSG_COMM_150Value = "前に不要が選択されているため、必要は選択できません。";
        private static string MSG_COMM_151Value = "整数部の入力文字数が多すぎます。(最大：{0})";
        private static string MSG_COMM_152Value = "{0}の検索でDB検索エラーが発生しました。";
        private static string MSG_COMM_153Value = "変更後の分類名は、登録済です。";
        private static string MSG_COMM_154Value = "分類：{0}、{1}、{2}、{3}、{4}の組み合わせが、存在していません。";
        private static string MSG_COMM_155Value = "品番：{0}の品番変更の工場部品履歴更新でDB更新エラーが発生しました。{1}";
        private static string MSG_COMM_156Value = "品番変更の新品番：{0}は、登録済みです。";
        private static string MSG_COMM_157Value = "対象部品品番一覧に入力データがありませんでした。";
        private static string MSG_COMM_158Value = "1行目の1項目目が空白のため、対象部品品番が読み込めません。";
        private static string MSG_COMM_159Value = "インポートファイルに入力データがありません。";
        private static string MSG_COMM_160Value = "対象部品品番一覧(*.xlsx,*.txt)を選択してください。";
        private static string MSG_COMM_161Value = "属性値のデータ数は属性名の項目数と一致にしてください。";
        private static string MSG_COMM_162Value = "検索件数は{0}件ですが、検索制限にて{1}件を表示しました。";
        private static string MSG_COMM_163Value = "業者配布履歴に変更前の業者が存在していません。";
        private static string MSG_COMM_164Value = "業者配布履歴の更新でDB更新が失敗しました。";
        private static string MSG_COMM_165Value = "他部門の変更通知番号です。";
        private static string MSG_COMM_166Value = "図面・ドキュメント履歴削除でDBエラーが発生しました。";
        private static string MSG_COMM_167Value = "インプットファイル「{0}」でBOM更新(洗面)処理が部門「{1}」で呼び出されました。";
        private static string MSG_COMM_168Value = "インプットファイル「{0}」でBOM更新(洗面)処理が存在しないユーザーID「{1}」で呼び出されました。";
        // 20210617 tomitat10追加
        private static string MSG_COMM_169Value = "インプットファイル「{0}」の部品更新でエラーが発生しました。(異常終了) {1}";
        private static string MSG_COMM_170Value = "インプットファイル「{0}」の部品属性チェックでエラーが発生しました。(異常終了) {1}";
        // 20210621 tomitat10追加
        private static string MSG_COMM_171Value = "{0}の部品更新が正常に終了しました。";
        private static string MSG_COMM_172Value = "{0}のBOM更新が正常に終了しました。";


        public static string MSG_COMM_001
        {
            get
            {
                return MSG_COMM_001Value;
            }
        }

        public static string MSG_COMM_002
        {
            get
            {
                return MSG_COMM_002Value;
            }
        }

        public static string MSG_COMM_003
        {
            get
            {
                return MSG_COMM_003Value;
            }
        }

        public static string MSG_COMM_004
        {
            get
            {
                return MSG_COMM_004Value;
            }
        }

        public static string MSG_COMM_005
        {
            get
            {
                return MSG_COMM_005Value;
            }
        }

        public static string MSG_COMM_006
        {
            get
            {
                return MSG_COMM_006Value;
            }
        }

        public static string MSG_COMM_007
        {
            get
            {
                return MSG_COMM_007Value;
            }
        }

        public static string MSG_COMM_008
        {
            get
            {
                return MSG_COMM_008Value;
            }
        }

        public static string MSG_COMM_009
        {
            get
            {
                return MSG_COMM_009Value;
            }
        }

        public static string MSG_COMM_011
        {
            get
            {
                return MSG_COMM_011Value;
            }
        }

        public static string MSG_COMM_012
        {
            get
            {
                return MSG_COMM_012Value;
            }
        }

        public static string MSG_COMM_013
        {
            get
            {
                return MSG_COMM_013Value;
            }
        }

        public static string MSG_COMM_014
        {
            get
            {
                return MSG_COMM_014Value;
            }
        }

        public static string MSG_COMM_015
        {
            get
            {
                return MSG_COMM_015Value;
            }
        }

        public static string MSG_COMM_016
        {
            get
            {
                return MSG_COMM_016Value;
            }
        }

        public static string MSG_COMM_017
        {
            get
            {
                return MSG_COMM_017Value;
            }
        }

        public static string MSG_COMM_018
        {
            get
            {
                return MSG_COMM_018Value;
            }
        }

        public static string MSG_COMM_019
        {
            get
            {
                return MSG_COMM_019Value;
            }
        }

        public static string MSG_COMM_020
        {
            get
            {
                return MSG_COMM_020Value;
            }
        }

        public static string MSG_COMM_021
        {
            get
            {
                return MSG_COMM_021Value;
            }
        }

        public static string MSG_COMM_022
        {
            get
            {
                return MSG_COMM_022Value;
            }
        }

        public static string MSG_COMM_023
        {
            get
            {
                return MSG_COMM_023Value;
            }
        }

        public static string MSG_COMM_024
        {
            get
            {
                return MSG_COMM_024Value;
            }
        }

        public static string MSG_COMM_025
        {
            get
            {
                return MSG_COMM_025Value;
            }
        }

        public static string MSG_COMM_026
        {
            get
            {
                return MSG_COMM_026Value;
            }
        }

        public static string MSG_COMM_027
        {
            get
            {
                return MSG_COMM_027Value;
            }
        }

        public static string MSG_COMM_028
        {
            get
            {
                return MSG_COMM_028Value;
            }
        }

        public static string MSG_COMM_029
        {
            get
            {
                return MSG_COMM_029Value;
            }
        }

        public static string MSG_COMM_030
        {
            get
            {
                return MSG_COMM_030Value;
            }
        }

        public static string MSG_COMM_031
        {
            get
            {
                return MSG_COMM_031Value;
            }
        }

        public static string MSG_COMM_032
        {
            get
            {
                return MSG_COMM_032Value;
            }
        }

        public static string MSG_COMM_033
        {
            get
            {
                return MSG_COMM_033Value;
            }
        }

        public static string MSG_COMM_034
        {
            get
            {
                return MSG_COMM_034Value;
            }
        }

        public static string MSG_COMM_035
        {
            get
            {
                return MSG_COMM_035Value;
            }
        }

        public static string MSG_COMM_036
        {
            get
            {
                return MSG_COMM_036Value;
            }
        }

        public static string MSG_COMM_037
        {
            get
            {
                return MSG_COMM_037Value;
            }
        }

        public static string MSG_COMM_038
        {
            get
            {
                return MSG_COMM_038Value;
            }
        }

        public static string MSG_COMM_039
        {
            get
            {
                return MSG_COMM_039Value;
            }
        }

        public static string MSG_COMM_040
        {
            get
            {
                return MSG_COMM_040Value;
            }
        }

        public static string MSG_COMM_041
        {
            get
            {
                return MSG_COMM_041Value;
            }
        }

        public static string MSG_COMM_042
        {
            get
            {
                return MSG_COMM_042Value;
            }
        }

        public static string MSG_COMM_043
        {
            get
            {
                return MSG_COMM_043Value;
            }
        }

        public static string MSG_COMM_044
        {
            get
            {
                return MSG_COMM_044Value;
            }
        }

        public static string MSG_COMM_045
        {
            get
            {
                return MSG_COMM_045Value;
            }
        }

        public static string MSG_COMM_046
        {
            get
            {
                return MSG_COMM_046Value;
            }
        }

        public static string MSG_COMM_047
        {
            get
            {
                return MSG_COMM_047Value;
            }
        }

        public static string MSG_COMM_048
        {
            get
            {
                return MSG_COMM_048Value;
            }
        }

        public static string MSG_COMM_049
        {
            get
            {
                return MSG_COMM_049Value;
            }
        }

        public static string MSG_COMM_050
        {
            get
            {
                return MSG_COMM_050Value;
            }
        }

        public static string MSG_COMM_051
        {
            get
            {
                return MSG_COMM_051Value;
            }
        }

        public static string MSG_COMM_052
        {
            get
            {
                return MSG_COMM_052Value;
            }
        }

        public static string MSG_COMM_053
        {
            get
            {
                return MSG_COMM_053Value;
            }
        }

        public static string MSG_COMM_054
        {
            get
            {
                return MSG_COMM_054Value;
            }
        }

        public static string MSG_COMM_055
        {
            get
            {
                return MSG_COMM_055Value;
            }
        }

        public static string MSG_COMM_056
        {
            get
            {
                return MSG_COMM_056Value;
            }
        }

        public static string MSG_COMM_057
        {
            get
            {
                return MSG_COMM_057Value;
            }
        }

        public static string MSG_COMM_058
        {
            get
            {
                return MSG_COMM_058Value;
            }
        }

        public static string MSG_COMM_059
        {
            get
            {
                return MSG_COMM_059Value;
            }
        }

        public static string MSG_COMM_060
        {
            get
            {
                return MSG_COMM_060Value;
            }
        }

        public static string MSG_COMM_061
        {
            get
            {
                return MSG_COMM_061Value;
            }
        }

        public static string MSG_COMM_062
        {
            get
            {
                return MSG_COMM_062Value;
            }
        }

        public static string MSG_COMM_063
        {
            get
            {
                return MSG_COMM_063Value;
            }
        }

        public static string MSG_COMM_064
        {
            get
            {
                return MSG_COMM_064Value;
            }
        }

        public static string MSG_COMM_065
        {
            get
            {
                return MSG_COMM_065Value;
            }
        }

        public static string MSG_COMM_066
        {
            get
            {
                return MSG_COMM_066Value;
            }
        }

        public static string MSG_COMM_067
        {
            get
            {
                return MSG_COMM_067Value;
            }
        }

        public static string MSG_COMM_068
        {
            get
            {
                return MSG_COMM_068Value;
            }
        }

        public static string MSG_COMM_069
        {
            get
            {
                return MSG_COMM_069Value;
            }
        }

        public static string MSG_COMM_070
        {
            get
            {
                return MSG_COMM_070Value;
            }
        }

        public static string MSG_COMM_071
        {
            get
            {
                return MSG_COMM_071Value;
            }
        }

        public static string MSG_COMM_072
        {
            get
            {
                return MSG_COMM_072Value;
            }
        }

        public static string MSG_COMM_073
        {
            get
            {
                return MSG_COMM_073Value;
            }
        }

        public static string MSG_COMM_074
        {
            get
            {
                return MSG_COMM_074Value;
            }
        }

        public static string MSG_COMM_075
        {
            get
            {
                return MSG_COMM_075Value;
            }
        }

        public static string MSG_COMM_076
        {
            get
            {
                return MSG_COMM_076Value;
            }
        }

        public static string MSG_COMM_077
        {
            get
            {
                return MSG_COMM_077Value;
            }
        }

        public static string MSG_COMM_078
        {
            get
            {
                return MSG_COMM_078Value;
            }
        }

        public static string MSG_COMM_079
        {
            get
            {
                return MSG_COMM_079Value;
            }
        }

        public static string MSG_COMM_080
        {
            get
            {
                return MSG_COMM_080Value;
            }
        }

        public static string MSG_COMM_081
        {
            get
            {
                return MSG_COMM_081Value;
            }
        }

        public static string MSG_COMM_082
        {
            get
            {
                return MSG_COMM_082Value;
            }
        }

        public static string MSG_COMM_083
        {
            get
            {
                return MSG_COMM_083Value;
            }
        }

        public static string MSG_COMM_084
        {
            get
            {
                return MSG_COMM_084Value;
            }
        }

        public static string MSG_COMM_085
        {
            get
            {
                return MSG_COMM_085Value;
            }
        }

        public static string MSG_COMM_086
        {
            get
            {
                return MSG_COMM_086Value;
            }
        }

        public static string MSG_COMM_087
        {
            get
            {
                return MSG_COMM_087Value;
            }
        }

        public static string MSG_COMM_089
        {
            get
            {
                return MSG_COMM_089Value;
            }
        }

        public static string MSG_COMM_090
        {
            get
            {
                return MSG_COMM_090Value;
            }
        }

        public static string MSG_COMM_091
        {
            get
            {
                return MSG_COMM_091Value;
            }
        }

        public static string MSG_COMM_092
        {
            get
            {
                return MSG_COMM_092Value;
            }
        }

        public static string MSG_COMM_093
        {
            get
            {
                return MSG_COMM_093Value;
            }
        }

        public static string MSG_COMM_094
        {
            get
            {
                return MSG_COMM_094Value;
            }
        }

        public static string MSG_COMM_095
        {
            get
            {
                return MSG_COMM_095Value;
            }
        }

        public static string MSG_COMM_096
        {
            get
            {
                return MSG_COMM_096Value;
            }
        }

        public static string MSG_COMM_097
        {
            get
            {
                return MSG_COMM_097Value;
            }
        }

        public static string MSG_COMM_098
        {
            get
            {
                return MSG_COMM_098Value;
            }
        }

        public static string MSG_COMM_099
        {
            get
            {
                return MSG_COMM_099Value;
            }
        }

        public static string MSG_COMM_100
        {
            get
            {
                return MSG_COMM_100Value;
            }
        }

        public static string MSG_COMM_101
        {
            get
            {
                return MSG_COMM_101Value;
            }
        }

        public static string MSG_COMM_102
        {
            get
            {
                return MSG_COMM_102Value;
            }
        }

        public static string MSG_COMM_103
        {
            get
            {
                return MSG_COMM_103Value;
            }
        }

        public static string MSG_COMM_104
        {
            get
            {
                return MSG_COMM_104Value;
            }
        }

        public static string MSG_COMM_105
        {
            get
            {
                return MSG_COMM_105Value;
            }
        }

        public static string MSG_COMM_106
        {
            get
            {
                return MSG_COMM_106Value;
            }
        }

        public static string MSG_COMM_107
        {
            get
            {
                return MSG_COMM_107Value;
            }
        }

        public static string MSG_COMM_108
        {
            get
            {
                return MSG_COMM_108Value;
            }
        }

        public static string MSG_COMM_109
        {
            get
            {
                return MSG_COMM_109Value;
            }
        }

        public static string MSG_COMM_110
        {
            get
            {
                return MSG_COMM_110Value;
            }
        }

        public static string MSG_COMM_111
        {
            get
            {
                return MSG_COMM_111Value;
            }
        }

        public static string MSG_COMM_112
        {
            get
            {
                return MSG_COMM_112Value;
            }
        }

        public static string MSG_COMM_113
        {
            get
            {
                return MSG_COMM_113Value;
            }
        }

        public static string MSG_COMM_114
        {
            get
            {
                return MSG_COMM_114Value;
            }
        }

        public static string MSG_COMM_115
        {
            get
            {
                return MSG_COMM_115Value;
            }
        }

        public static string MSG_COMM_116
        {
            get
            {
                return MSG_COMM_116Value;
            }
        }

        public static string MSG_COMM_117
        {
            get
            {
                return MSG_COMM_117Value;
            }
        }

        public static string MSG_COMM_118
        {
            get
            {
                return MSG_COMM_118Value;
            }
        }

        public static string MSG_COMM_119
        {
            get
            {
                return MSG_COMM_119Value;
            }
        }

        public static string MSG_COMM_120
        {
            get
            {
                return MSG_COMM_120Value;
            }
        }

        public static string MSG_COMM_121
        {
            get
            {
                return MSG_COMM_121Value;
            }
        }

        public static string MSG_COMM_122
        {
            get
            {
                return MSG_COMM_122Value;
            }
        }

        public static string MSG_COMM_123
        {
            get
            {
                return MSG_COMM_123Value;
            }
        }

        public static string MSG_COMM_124
        {
            get
            {
                return MSG_COMM_124Value;
            }
        }

        public static string MSG_COMM_125
        {
            get
            {
                return MSG_COMM_125Value;
            }
        }

        public static string MSG_COMM_126
        {
            get
            {
                return MSG_COMM_126Value;
            }
        }

        public static string MSG_COMM_127
        {
            get
            {
                return MSG_COMM_127Value;
            }
        }

        public static string MSG_COMM_128
        {
            get
            {
                return MSG_COMM_128Value;
            }
        }

        public static string MSG_COMM_129
        {
            get
            {
                return MSG_COMM_129Value;
            }
        }

        public static string MSG_COMM_130
        {
            get
            {
                return MSG_COMM_130Value;
            }
        }

        public static string MSG_COMM_131
        {
            get
            {
                return MSG_COMM_131Value;
            }
        }

        // Public Shared ReadOnly Property MSG_COMM_132() As String
        // Get
        // Return MSG_COMM_132Value
        // End Get
        // End Property

        // Public Shared ReadOnly Property MSG_COMM_133() As String
        // Get
        // Return MSG_COMM_133Value
        // End Get
        // End Property

        public static string MSG_COMM_134
        {
            get
            {
                return MSG_COMM_134Value;
            }
        }

        public static string MSG_COMM_135
        {
            get
            {
                return MSG_COMM_135Value;
            }
        }

        public static string MSG_COMM_136
        {
            get
            {
                return MSG_COMM_136Value;
            }
        }

        public static string MSG_COMM_137
        {
            get
            {
                return MSG_COMM_137Value;
            }
        }

        public static string MSG_COMM_138
        {
            get
            {
                return MSG_COMM_138Value;
            }
        }

        public static string MSG_COMM_139
        {
            get
            {
                return MSG_COMM_139Value;
            }
        }

        public static string MSG_COMM_140
        {
            get
            {
                return MSG_COMM_140Value;
            }
        }

        public static string MSG_COMM_141
        {
            get
            {
                return MSG_COMM_141Value;
            }
        }

        public static string MSG_COMM_142
        {
            get
            {
                return MSG_COMM_142Value;
            }
        }

        public static string MSG_COMM_143
        {
            get
            {
                return MSG_COMM_143Value;
            }
        }

        public static string MSG_COMM_144
        {
            get
            {
                return MSG_COMM_144Value;
            }
        }

        public static string MSG_COMM_145
        {
            get
            {
                return MSG_COMM_145Value;
            }
        }

        public static string MSG_COMM_146
        {
            get
            {
                return MSG_COMM_146Value;
            }
        }

        public static string MSG_COMM_147
        {
            get
            {
                return MSG_COMM_147Value;
            }
        }

        public static string MSG_COMM_148
        {
            get
            {
                return MSG_COMM_148Value;
            }
        }

        public static string MSG_COMM_149
        {
            get
            {
                return MSG_COMM_149Value;
            }
        }

        public static string MSG_COMM_150
        {
            get
            {
                return MSG_COMM_150Value;
            }
        }

        public static string MSG_COMM_151
        {
            get
            {
                return MSG_COMM_151Value;
            }
        }

        public static string MSG_COMM_152
        {
            get
            {
                return MSG_COMM_152Value;
            }
        }

        public static string MSG_COMM_153
        {
            get
            {
                return MSG_COMM_153Value;
            }
        }

        public static string MSG_COMM_154
        {
            get
            {
                return MSG_COMM_154Value;
            }
        }

        public static string MSG_COMM_155
        {
            get
            {
                return MSG_COMM_155Value;
            }
        }

        public static string MSG_COMM_156
        {
            get
            {
                return MSG_COMM_156Value;
            }
        }

        public static string MSG_COMM_157
        {
            get
            {
                return MSG_COMM_157Value;
            }
        }

        public static string MSG_COMM_158
        {
            get
            {
                return MSG_COMM_158Value;
            }
        }

        public static string MSG_COMM_159
        {
            get
            {
                return MSG_COMM_159Value;
            }
        }

        public static string MSG_COMM_160
        {
            get
            {
                return MSG_COMM_160Value;
            }
        }

        public static string MSG_COMM_161
        {
            get
            {
                return MSG_COMM_161Value;
            }
        }

        public static string MSG_COMM_162
        {
            get
            {
                return MSG_COMM_162Value;
            }
        }

        public static string MSG_COMM_163
        {
            get
            {
                return MSG_COMM_163Value;
            }
        }

        public static string MSG_COMM_164
        {
            get
            {
                return MSG_COMM_164Value;
            }
        }

        public static string MSG_COMM_165
        {
            get
            {
                return MSG_COMM_165Value;
            }
        }

        public static string MSG_COMM_166
        {
            get
            {
                return MSG_COMM_166Value;
            }
        }

        public static string MSG_COMM_167
        {
            get
            {
                return MSG_COMM_167Value;
            }
        }

        public static string MSG_COMM_168
        {
            get
            {
                return MSG_COMM_168Value;
            }
        }
        // 20210617 tomitat10 追加
        public static string MSG_COMM_169
        {
            get
            {
                return MSG_COMM_169Value;
            }
        }
        // 20210617 tomitat10 追加
        public static string MSG_COMM_170
        {
            get
            {
                return MSG_COMM_170Value;
            }
        }
        // 20210621 tomitat10 追加
        public static string MSG_COMM_171
        {
            get
            {
                return MSG_COMM_171Value;
            }
        }
        // 20210621 tomitat10 追加
        public static string MSG_COMM_172
        {
            get
            {
                return MSG_COMM_172Value;
            }
        }
    }

}
