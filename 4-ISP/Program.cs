namespace SOLID.ISP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Escolha uma opção");
            Console.WriteLine("1 - ISP Violação");
            Console.WriteLine("2 - ISP Solução\n");

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
            Console.WriteLine($" - ISP Violação");
            Console.WriteLine();

            SOLID.ISP.Violation.Interfaces.IRegistration clientRegistration = new SOLID.ISP.Violation.ClientRegistration();
            Console.WriteLine("---------------------");
            Console.WriteLine(" Cadastro de Cliente:");
            Console.WriteLine("---------------------");
            clientRegistration.ValidateData();
            clientRegistration.Save();
            clientRegistration.SendEmail();

            Console.WriteLine();

            SOLID.ISP.Violation.Interfaces.IRegistration productRegistration = new SOLID.ISP.Violation.ProductRegistration();
            Console.WriteLine("---------------------");
            Console.WriteLine(" Cadastro de Produto:");
            Console.WriteLine("---------------------");
            productRegistration.ValidateData();
            productRegistration.Save();

            try
            {
                productRegistration.SendEmail();
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine($"- ERRO: {ex.Message}");
            }
        }

        static void ExecuteSolution()
        {
            Console.WriteLine($" - ISP Solução");
            Console.WriteLine();

            SOLID.ISP.Solution.Interfaces.IClientRegistration clientRegistration = new SOLID.ISP.Solution.ClientRegistration();
            SOLID.ISP.Solution.Interfaces.IRegistration clientSave = clientRegistration;
            Console.WriteLine("---------------------");
            Console.WriteLine(" Cadastro de Cliente:");
            Console.WriteLine("---------------------");
            clientRegistration.ValidateData();
            clientSave.Save();
            clientRegistration.SendEmail();

            Console.WriteLine();

            SOLID.ISP.Solution.Interfaces.IProductRegistration productRegistration = new SOLID.ISP.Solution.ProductRegistration();
            SOLID.ISP.Solution.Interfaces.IRegistration productSave = productRegistration;
            Console.WriteLine("---------------------");
            Console.WriteLine(" Cadastro de Produto:");
            Console.WriteLine("---------------------");
            productRegistration.ValidateData();
            productSave.Save();
        }
    }
}
