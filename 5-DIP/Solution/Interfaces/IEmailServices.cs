namespace SOLID.DIP.Solution.Interfaces
{
    /*
     * IEmailServices - Interface para Serviços de E-mail
     * 
     * Esta é uma ABSTRAÇÃO (contrato) que define como o ClientService
     * se comunica com o serviço de envio de e-mails.
     * 
     * PORQUE É IMPORTANTE:
     * - ClientService não precisa saber QUAL serviço de e-mail é usado
     * - Pode ser SMTP, SendGrid, Mailgun, AWS SES, etc.
     * - Pode até ser um mock para testes!
     * 
     * O QUE DEFINE:
     * - Send() -> método para enviar e-mail
     * 
     * BENEFÍCIO PARA TESTES:
     * - Em testes unitários, podemos criar um Mock<IEmailServices>
     * - Assim garantimos que o e-mail foi "enviado" sem realmente enviar
     * - Muito importante para CI/CD e testes automatizados
     */
    internal interface IEmailServices
    {
        void Send(string from, string to, string subject, string body);
    }
}
