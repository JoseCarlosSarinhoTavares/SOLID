using SOLID.OCP.Violation;
using SOLID.OCP.Violation.Enums;

namespace SOLID.OCP
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Escolha uma opção");
            Console.WriteLine("1 - OCP Violação");
            Console.WriteLine("2 - OCP Solução com Herança");
            Console.WriteLine("3 - OCP Solução com Métodos de Extensão\n");

            var opcao = Console.ReadKey();
            decimal DebitAmount = 500;

            switch (opcao.KeyChar)
            {
                case '1':
                    Console.WriteLine($" - OCP Violação");
                    var debitViolation = new AccountDebit();

                    debitViolation.Debit(
                        value: DebitAmount,
                        balance: 300,
                        limit: 300,
                        accountType: EAccountType.CheckingAccount
                    );

                    Console.WriteLine($"\nDébito de {DebitAmount:C} realizado!");
                    break;

                case '2':
                    Console.WriteLine(" - OCP Solução com Herança");

                    var accounts = new Dictionary<string, Solution.Inheritance.Abstractions.AccountDebit>
                    {
                        { "Conta Corrente",   new Solution.Inheritance.Services.CurrentAccountDebit() },
                        { "Conta Poupança",   new Solution.Inheritance.Services.SavingsAccountDebit() },
                        { "Conta Investimento", new Solution.Inheritance.Services.InvestmentAccountDebit() }
                    };

                    foreach (var debitAccount in accounts)
                    {
                        var transactionNumber = debitAccount.Value.Debit(
                            amount: DebitAmount,
                            account: "12345-6"
                        );
                        Console.WriteLine(
                            $"\nDébito realizado:\n {debitAccount.Key} | Valor: {DebitAmount:C} | Nº Transação: {transactionNumber}"
                        );
                    }
                    break;

                case '3':
                    Console.WriteLine(" - OCP Solução com Métodos de Extensão");
                    Solution.ExtensionMethods.Application.ATM.Operations();

                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}