using SOLID.SRP.Solution.DataAccess;
using SOLID.SRP.Solution.Services;
using SOLID.SRP.Solution.ValueObjects;
using SQLitePCL;

namespace SOLID.SRP
{
    internal class Program
    {
        private static void Main()
        {
            // Inicializa o provider nativo do SQLite
            Batteries.Init();

            // Inicializa a estrutura do banco (DDL)
            DatabaseInitializer.Initialize();

            Console.WriteLine("Escolha uma opção");
            Console.WriteLine("1 - SRP Violação");
            Console.WriteLine("2 - SRP Solução\n");

            var opcao = Console.ReadKey();

            switch (opcao.KeyChar)
            {
                case '1':
                    Console.WriteLine($" - SRP Violação");
                    var client = new Violation.Client
                    {
                        Name = "test",
                        Mail = "test@mail.com",
                        Cpf = "12345678901",
                        DateRegistration = DateTime.Now
                    };

                    Console.WriteLine($"\n{client.AddClient()}");
                    break;

                case '2':
                    Console.WriteLine($" - SRP Solução");
                    var clientSolution = new Solution.Entities.Client
                    {
                        Name = "test",
                        Mail = new Mail("test@mail.com"),
                        Cpf = new Cpf("12345678901"),
                        DateRegistration = DateTime.Now
                    };

                    var service = new ClientService();
                    var result = service.AddClient(clientSolution);

                    Console.WriteLine($"\n{result}");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}