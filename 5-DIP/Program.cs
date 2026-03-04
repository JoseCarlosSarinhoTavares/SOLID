namespace SOLID.DIP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Escolha uma opção");
            Console.WriteLine("1 - DIP Violação");
            Console.WriteLine("2 - DIP Solução\n");

            var opcao = Console.ReadKey();

            switch (opcao.KeyChar)
            {
                case '1':
                    ExecuteViolation();
                    break;
                case '2':
                    ExecuteSolution();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            if (opcao.KeyChar != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void ExecuteViolation()
        {
            Console.WriteLine(" - DIP Violação");
            Console.WriteLine();

            Console.WriteLine("---------------------");
            Console.WriteLine(" Client Service:");
            Console.WriteLine("---------------------");

            SOLID.DIP.Violation.DataAccess.DatabaseInitializer.Initialize();

            var client = new SOLID.DIP.Violation.Entities.Client
            {
                Name = "Carlos Silva",
                Email = new Violation.ValueObjects.Email { Address = "carlos@email.com" },
                CPF = new Violation.ValueObjects.Cpf { Number = "12345678901" },
                RegistrationDate = DateTime.Now
            };

            var clientService = new SOLID.DIP.Violation.Services.ClientService();
            var result = clientService.AddClient(client);

            Console.WriteLine($"- Resultado: {result}");
            Console.WriteLine();
            Console.WriteLine("PROBLEMA: ClientService cria dependências concretas:");
            Console.WriteLine("- new ClientRepository()");
            Console.WriteLine("- EmailServices.Send()");
            Console.WriteLine();
            Console.WriteLine("Acoplamento direto! DIFÍCIL de testar e modificar.");
        }

        static void ExecuteSolution()
        {
            Console.WriteLine(" - DIP Solução");
            Console.WriteLine();

            Console.WriteLine("---------------------");
            Console.WriteLine(" Client Service:");
            Console.WriteLine("---------------------");

            SOLID.DIP.Solution.DataAccess.DatabaseInitializer.Initialize();

            var client = new SOLID.DIP.Solution.Entities.Client
            {
                Name = "Carlos Silva",
                Email = new Solution.ValueObjects.Email { Address = "carlos@email.com" },
                CPF = new Solution.ValueObjects.Cpf { Number = "12345678901" },
                RegistrationDate = DateTime.Now
            };

            Solution.Interfaces.IClientRepository clientRepository = new Solution.DataAccess.ClientRepository();
            Solution.Interfaces.IEmailServices emailServices = new Solution.Services.EmailServices();

            var clientService = new Solution.Services.ClientService(clientRepository, emailServices);
            var result = clientService.AddClient(client);

            Console.WriteLine($"- Resultado: {result}");
            Console.WriteLine();
            Console.WriteLine("SOLUÇÃO: ClientService depende de ABSTRAÇÕES:");
            Console.WriteLine("- IClientRepository (interface)");
            Console.WriteLine("- IEmailServices (interface)");
            Console.WriteLine();
            Console.WriteLine("Acoplamento fraco! FÁCIL de testar e modificar.");
        }
    }
}
