using Microsoft.Data.Sqlite;
using SOLID.SRP.Solution.Entities;

namespace SOLID.SRP.Solution.DataAccess
{
    internal class ClientDataAccess
    {
        private const string ConnectionString = "Data Source=client.db";

        public void AddClient(Client client)
        {
            using var cn = new SqliteConnection(ConnectionString);
            cn.Open();

            var cmd = cn.CreateCommand();
            cmd.CommandText =
            """
            INSERT INTO CLIENTE (NAME, MAIL, CPF, DATE_REGISTRATION)
            VALUES (@name, @mail, @cpf, @dateRegistration);
            """;

            cmd.Parameters.AddWithValue("@name", client.Name);
            cmd.Parameters.AddWithValue("@mail", client.Mail.Address);
            cmd.Parameters.AddWithValue("@cpf", client.Cpf.Number);
            cmd.Parameters.AddWithValue(
                "@dateRegistration",
                client.DateRegistration.ToString("yyyy-MM-dd HH:mm:ss")
            );

            cmd.ExecuteNonQuery();
        }
    }
}