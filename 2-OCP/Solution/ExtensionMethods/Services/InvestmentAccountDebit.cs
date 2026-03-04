using SOLID.OCP.Solution.ExtensionMethods.Models;

namespace SOLID.OCP.Solution.ExtensionMethods.Services
{
    /*
     * InvestmentAccountDebit - Extensão para Débito em Conta Investimento
     * 
     * OCP - Solução com Extension Methods
     * 
     * REGRA DE NEGÓCIO:
     * - Conta Investimento tem valor mínimo para resgate
     * - Débito apenas se >= R$ 100,00
     */
    internal static class InvestmentAccountDebit
    {
        public static string DebitInvestmentAccount(this AccountDebit accountDebit)
        {
            const decimal minimumAmount = 100;

            if (accountDebit.Amount < minimumAmount)
                throw new ArgumentException("Valor mínimo para débito em conta investimento é 100.");

            return accountDebit.FormatTransaction();
        }
    }
}
