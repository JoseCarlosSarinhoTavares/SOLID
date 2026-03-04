using SOLID.OCP.Solution.ExtensionMethods.Models;

namespace SOLID.OCP.Solution.ExtensionMethods.Services
{
    /*
     * SavingsAccountDebit - Extensão para Débito em Conta Poupança
     * 
     * OCP - Solução com Extension Methods
     * 
     * REGRA DE NEGÓCIO:
     * - Conta Poupança não permite saldo negativo
     * - Débito apenas se valor for positivo e <= saldo
     */
    internal static class SavingsAccountDebit
    {
        public static string DebitSavingsAccount(this AccountDebit accountDebit)
        {
            if (accountDebit.Amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            return accountDebit.FormatTransaction();
        }
    }
}
