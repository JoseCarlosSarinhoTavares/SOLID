using System.Net;
using System.Net.Mail;

namespace SOLID.SRP.Solution.Services
{
    internal class MailServices
    {
        private const string SmtpUser = "seuemail@gmail.com";
        private const string SmtpPassword = "SENHA_DE_APP";

        public static bool Send(string to, string subject, string message, out string error)
        {
            error = string.Empty;

            try
            {
                using var mail = new MailMessage
                {
                    From = new MailAddress(SmtpUser),
                    Subject = subject,
                    Body = message
                };

                mail.To.Add(to);

                using var client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(SmtpUser, SmtpPassword),
                    Timeout = 10000
                };

                client.Send(mail);
                return true;
            }
            catch (SmtpFailedRecipientException)
            {
                error = "Destinatário inválido ou inexistente.";
                return false;
            }
            catch (SmtpException ex)
            {
                error = $"Erro de autenticação ou conexão SMTP: {ex.StatusCode}";
                return false;
            }
            catch (Exception ex)
            {
                error = $"Erro inesperado: {ex.Message}";
                return false;
            }
        }
    }
}