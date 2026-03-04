namespace SOLID.DIP.Violation.Services
{
    internal class EmailServices
    {
        public static void Send(string from, string to, string subject, string body)
        {
            Console.WriteLine($"\n[E-mail simulado]");
            Console.WriteLine($"De: {from}");
            Console.WriteLine($"Para: {to}");
            Console.WriteLine($"Assunto: {subject}");
            Console.WriteLine($"Mensagem: {body}");
        }
    }
}
