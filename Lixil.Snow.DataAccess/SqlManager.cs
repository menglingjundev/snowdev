using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Lixil.Snow.DataAccess
{
    public class SqlManager: DataAccessBase
    {
        private static IConfiguration _configuration;

        private static NpgsqlConnection db;

        /// <summary>
        /// Configの設定情報を取得する
        /// </summary>
        /// <param name="configuration"></param>
        public static void Configure(IConfiguration configuration)
        {
            _configuration = configuration;

            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }
        /// <summary>
        /// 接続情報の取得する
        /// </summary>
        public static NpgsqlConnection GetConnection
        {
            get
            {
                var connectionString = _configuration.GetConnectionString("PostgreDB");
                db = new NpgsqlConnection(connectionString);
                db.Open();
                return db;
            }
        }

        public static NpgsqlTransaction BeginTransaction
        {
            get
            {
                var connectionString = _configuration.GetConnectionString("PostgreDB");
                db = new NpgsqlConnection(connectionString);
                db.Open();
                return db.BeginTransaction();
            }
        }

        /// <summary>
        /// 接続クローズ
        /// </summary>
        public void Close()
        {
            db.Close();
        }
    }
}