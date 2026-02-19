namespace SOLID.LSP
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Escolha uma opção");
            Console.WriteLine("1 - LSP Violação");
            Console.WriteLine("2 - LSP Solução\n");

            var opcao = Console.ReadKey();

            switch (opcao.KeyChar)
            {
                case '1':
                    Console.WriteLine(" - LSP Violação");
                    Violation.CalculateArea.Calculate(10, 5);
                    break;

                case '2':
                    Console.WriteLine(" - LSP Solução");
                    Solution.CalculateArea.Calculate(5, 10, 5);
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}