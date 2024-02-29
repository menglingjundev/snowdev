using Lixil.Snow.DataAccess;
using Lixil.Snow.Utilities;
using System.Reflection;

namespace Lixil.Snow.BizLogic
{
    /// <summary>
    /// 配布実施
    /// </summary>
    /// <remarks>20181015 修(大連) 新規作成</remarks>
    public class P030305_BizLogic
    {
        //SQL文実行用
        private P030305_DataAccess da;

        public P030305_BizLogic()
        {
            da = new P030305_DataAccess();
        }

        /// <summary>
        /// 配布履歴更新
        /// </summary>
        /// <param name="kaiSyuBi">回収日</param>
        /// <param name="gyosyaInfoList">業者情報リスト</param>
        /// <param name="userID">ユーザーID</param>
        /// <param name="PGM">機能ID</param>
        /// <returns>登録結果</returns>
        /// <remarks>20181015 修(大連) 新規作成</remarks>
        public int UpdHaifuDetailList(string kaiSyuBi, List<string> gyosyaInfoList, string userID, string PGM)
        {
            Inspector.Add(MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + MethodBase.GetCurrentMethod().Name);

            var result = 0;

            foreach (var gyosyaInfo in gyosyaInfoList)
            {

                result = da.UpdHaifuDetailDate(kaiSyuBi, gyosyaInfo.Split(AppConst.COMMA)[0], gyosyaInfo.Split(AppConst.COMMA)[1], gyosyaInfo.Split(AppConst.COMMA)[2], gyosyaInfo.Split(AppConst.COMMA)[3], userID, PGM);

                if (result == 0)
                {
                    da.Close();
                    return result;
                }
            }

            da.Close();
            return result;
        }






    }
}
