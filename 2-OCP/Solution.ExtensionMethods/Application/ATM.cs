using SOLID.OCP.Solution.ExtensionMethods.Common;
using SOLID.OCP.Solution.ExtensionMethods.Services;

namespace SOLID.OCP.Solution.ExtensionMethods.Application
{
    internal class ATM
    {
        public static void Operations()
        {
            OperationsMenu();

            var option = Console.ReadKey();
            var result = string.Empty;
            var accountDebit = DebitData();

            switch (option.KeyChar)
            {
                case '1':
                    Console.WriteLine("Efetuando operação em Conta Corretente");
                    result = accountDebit.DebitCurrentAccount();
                    break;

                case '2':
                    Console.WriteLine("Efetuando operação em Conta Poupança");
                    result = accountDebit.DebitSavingsAccount();
                    break;

                case '3':
                    Console.WriteLine("Efetuando operação em Conta Investimento");
                    result = accountDebit.DebitInvestmentAccount();
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Sucesso! Transação " + result);
            Console.ReadKey();
        }

        private static void OperationsMenu()
        {
            Console.Clear();
            Console.WriteLine("Caixa Eletrônico SOLID");
            Console.WriteLine("Escolha sua opção:");
            Console.WriteLine("");
            Console.WriteLine("1 - Saque Conta Corretente");
            Console.WriteLine("2 - Saque Conta Poupança");
            Console.WriteLine("3 - Saque Conta Investimento");
        }

        private static AccountDebit DebitData()
        {
            Console.WriteLine();
            Console.WriteLine("................................");
            Console.WriteLine();
            Console.WriteLine("Digite o número da conta:");
            var account = Console.ReadLine();

            Console.WriteLine("Digite o valor:");
            var amount = Convert.ToDecimal(Console.ReadLine());

            var accountDebit = new AccountDebit
            {
                AccountNumber = account,
                Amount = amount
            };

            return accountDebit;
        }
    }
}