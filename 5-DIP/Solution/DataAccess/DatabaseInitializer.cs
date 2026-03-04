using Microsoft.Data.Sqlite;

namespace SOLID.DIP.Solution.DataAccess
{
    /*
     * DatabaseInitializer - Inicializador do Banco de Dados
     * 
     * Responsável por criar a estrutura inicial do banco de dados.
     * 
     * NOTA:
     * Esta classe é auxiliar para o exemplo didático.
     * Em projetos reais, utilize migrations (Entity Framework, FluentMigrator, etc.)
     */
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
                EMAIL TEXT NOT NULL,
                CPF TEXT NOT NULL,
                DATE_REGISTRATION TEXT NOT NULL
            );
            """;

            cmd.ExecuteNonQuery();
        }
    }
}
