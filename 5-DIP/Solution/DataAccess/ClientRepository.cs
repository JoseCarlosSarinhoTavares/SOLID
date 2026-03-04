using Microsoft.Data.Sqlite;
using SOLID.DIP.Solution.Entities;
using SOLID.DIP.Solution.Interfaces;

namespace SOLID.DIP.Solution.DataAccess
{
    /*
     * ClientRepository - Implementação de Repositório de Clientes
     * 
     * Esta é uma IMPLEMENTAÇÃO CONCRETA da interface IClientRepository.
     * 
     * PADRÃO DIP APLICADO:
     * - Módulo de baixo nível (DataAccess) depende de abstração (IClientRepository)
     * - A interface pertence ao domínio/Service (alto nível)
     * - A implementação pertence à infraestrutura (baixo nível)
     * 
     * COMO MUDAR O BANCO DE DADOS:
     * - Quer usar PostgreSQL? Crie:
     *   class PostgreClientRepository : IClientRepository
     * - Quer usar MongoDB? Crie:
     *   class MongoClientRepository : IClientRepository
     * - No Program.cs, troque:
     *   IClientRepository repo = new PostgreClientRepository();
     * - ZERO mudanças em ClientService!
     * 
     * DETALHE IMPORTANTE:
     * - Esta classe implements IClientRepository (contrato)
     * - Cumpre o princípio: "Detalhes dependem de abstrações"
     * - A abstração (interface) não sabe nada sobre SQLite, SQL, etc.
     * - Somente ESTA classe conhece os detalhes do banco
     */
    internal class ClientRepository : IClientRepository
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
