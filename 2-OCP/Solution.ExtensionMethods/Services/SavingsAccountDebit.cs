using SOLID.OCP.Solution.ExtensionMethods.Common;

namespace SOLID.OCP.Solution.ExtensionMethods.Services
{
    internal static class SavingsAccountDebit
    {
        public static string DebitSavingsAccount(this AccountDebit accountDebit)
        {
            /* Regra: conta poupança não pode ter saldo negativo
               Débito permitido somente se o valor for positivo*/
            if (accountDebit.Amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            return accountDebit.FormatTransaction();
        }
    }
}