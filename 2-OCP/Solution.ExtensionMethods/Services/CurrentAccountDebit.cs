using SOLID.OCP.Solution.ExtensionMethods.Common;

namespace SOLID.OCP.Solution.ExtensionMethods.Services
{
    internal static class CurrentAccountDebit
    {
        public static string DebitCurrentAccount(this AccountDebit accountDebit)
        {
            // Regra: conta corrente permite débito usando saldo + cheque especial
            const decimal overdraftLimit = 500;
            decimal balance = 1000;

            if (accountDebit.Amount <= 0)
                throw new ArgumentException("O valor do débito deve ser maior que zero.");

            if (accountDebit.Amount > balance + overdraftLimit)
                throw new InvalidOperationException("Saldo e limite insuficientes.");

            return accountDebit.FormatTransaction();
        }
    }
}
