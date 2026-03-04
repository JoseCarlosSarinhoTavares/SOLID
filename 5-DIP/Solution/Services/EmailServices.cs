using SOLID.DIP.Solution.Interfaces;

namespace SOLID.DIP.Solution.Services
{
    /*
     * EmailServices - Implementação de Serviço de E-mail
     * 
     * Esta é uma IMPLEMENTAÇÃO CONCRETA da interface IEmailServices.
     * 
     * PADRÃO DIP APLICADO:
     * - Implementa a abstração definida pelo módulo de alto nível
     * - Detail (envio de e-mail) depende de abstração (IEmailServices)
     * 
     * COMO TROCAR O SERVIÇO DE E-MAIL:
     * - Quer usar SendGrid? Crie SendGridEmailServices : IEmailServices
     * - Quer usar AWS SES? Crie SesEmailServices : IEmailServices
     * - Quer testar? Crie MockEmailServices : IEmailServices
     * - No Program.cs, troque a instância
     * - ZERO mudanças em ClientService!
     * 
     * OBSERVAÇÃO:
     * - Esta implementação é apenas um Mock (simulação)
     * - Imprime no console ao invés de enviar e-mail real
     * - Útil para desenvolvimento e testes
     * - Para produção, implemente o serviço real de SMTP/API
     */
    internal class EmailServices : IEmailServices
    {
        public void Send(string from, string to, string subject, string body)
        {
            Console.WriteLine($"\n[E-mail simulado]");
            Console.WriteLine($"De: {from}");
            Console.WriteLine($"Para: {to}");
            Console.WriteLine($"Assunto: {subject}");
            Console.WriteLine($"Mensagem: {body}");
        }
    }
}
