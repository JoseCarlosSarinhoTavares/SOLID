using Microsoft.Data.Sqlite;
using SOLID.DIP.Violation.Entities;

namespace SOLID.DIP.Violation.DataAccess
{
    internal class ClientRepository
    {
        private const string ConnectionString = "Data Source=client.db";

        public void AddClient(Client client)
        {
            using var cn = new SqliteConnection(ConnectionString);
            cn.Open();

            var cmd = cn.CreateCommand();
            cmd.CommandText =
            """
            INSERT INTO CLIENTE (NAME, EMAIL, CPF, DATE_REGISTRATION)
            VALUES (@name, @email, @cpf, @dateRegistration);
            """;

            cmd.Parameters.AddWithValue("@name", client.Name);
            cmd.Parameters.AddWithValue("@email", client.Email.Address);
            cmd.Parameters.AddWithValue("@cpf", client.CPF.Number);
            cmd.Parameters.AddWithValue(
                "@dateRegistration",
                client.RegistrationDate.ToString("yyyy-MM-dd HH:mm:ss")
            );

            cmd.ExecuteNonQuery();
        }
    }
}