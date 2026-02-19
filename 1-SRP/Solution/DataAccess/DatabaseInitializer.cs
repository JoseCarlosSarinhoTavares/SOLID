using Microsoft.Data.Sqlite;

namespace SOLID.SRP.Solution.DataAccess
{
    internal static class DatabaseInitializer
    {
        private const string ConnectionString = "Data Source=client.db";

        public static void Initialize()
        {
            using var cn = new SqliteConnection(ConnectionString);
            cn.Open();

            var cmd = cn.CreateCommand();
            cmd.CommandText =
            """
            CREATE TABLE IF NOT EXISTS CLIENTE (
                CLIENT_ID INTEGER PRIMARY KEY AUTOINCREMENT,
                NAME TEXT NOT NULL,
                MAIL TEXT NOT NULL,
                CPF TEXT NOT NULL,
                DATE_REGISTRATION TEXT NOT NULL
            );
            """;

            cmd.ExecuteNonQuery();
        }
    }
}