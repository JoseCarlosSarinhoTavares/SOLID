using Microsoft.Data.Sqlite;
using System.Net;
using System.Net.Mail;

namespace SOLID.SRP.Violation
{
    internal class Client
    {
        // Responsabilidade OK: dados da entidade Cliente
        public int ClientId { get; set; }
        public string Name { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public DateTime DateRegistration { get; set; }

        // Violação SRP: detalhe de infraestrutura (string de conexão)
        private const string ConnectionString = "Data Source=client.db";

        public string AddClient()
        {
            // Violação SRP: validação de regras de negócio
            // Isso deveria estar em um Validator ou Service
            if (!Mail.Contains("@"))
                return "Cliente com mail inválido";

            if (Cpf.Length != 11)
                return "Cliente com Cpf inválido";

            // Violação SRP: acesso direto ao banco de dados (Data Access)
            using (var cn = new SqliteConnection(ConnectionString))
            {
                cn.Open();

                // Violação SRP: responsabilidade de criação de tabela (DDL)
                // Isso não deve ficar na entidade
                var createTableCmd = cn.CreateCommand();
                createTableCmd.CommandText =
                """
                CREATE TABLE IF NOT EXISTS CLIENTE (
                    CLIENT_ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    NAME TEXT NOT NULL,
                    MAIL TEXT NOT NULL,
                    Cpf TEXT NOT NULL,
                    DATE_REGISTRATION TEXT NOT NULL
                );
                """;
                createTableCmd.ExecuteNonQuery();

                // Violação SRP: persistência de dados (Repository)
                var insertCmd = cn.CreateCommand();
                insertCmd.CommandText =
                """
                INSERT INTO CLIENTE (NAME, MAIL, Cpf, DATE_REGISTRATION)
                VALUES (@name, @mail, @cpf, @dateRegistration);
                """;

                insertCmd.Parameters.AddWithValue("@name", Name);
                insertCmd.Parameters.AddWithValue("@mail", Mail);
                insertCmd.Parameters.AddWithValue("@cpf", Cpf);
                insertCmd.Parameters.AddWithValue(
                    "@dateRegistration",
                    DateRegistration.ToString("yyyy-MM-dd HH:mm:ss")
                );

                insertCmd.ExecuteNonQuery();
            }

            string emailStatus;

            try
            {
                // Violação SRP: responsabilidade de envio de e-mail
                // Deveria estar em um EmailService
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("test@gmail.com"),
                    Subject = "Bem vindo!!!",
                    Body = "Parabéns! Você está cadastrado."
                };

                mailMessage.To.Add(Mail);

                // Violação SRP: configuração de SMTP (infraestrutura)
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(
                        "test@gmail.com",
                        "SENHA_DE_APP"
                    ),
                    Timeout = 10000
                };

                smtp.Send(mailMessage);

                emailStatus = "E-mail enviado com sucesso.";
            }
            catch (SmtpException ex)
            {
                // Violação SRP: decisão de tratamento de erro de e-mail
                emailStatus = $"Cliente salvo, mas falha de autenticação no envio do e-mail.: {ex.StatusCode}";
            }
            catch (Exception ex)
            {
                // Violação SRP: tratamento genérico de erro de infraestrutura
                emailStatus = $"Cliente salvo, erro inesperado no e-mail: {ex.Message}";
            }

            return emailStatus;
        }
    }
}