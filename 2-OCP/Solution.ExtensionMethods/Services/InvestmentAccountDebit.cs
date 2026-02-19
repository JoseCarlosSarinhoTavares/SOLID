using SOLID.OCP.Solution.ExtensionMethods.Common;

namespace SOLID.OCP.Solution.ExtensionMethods.Services
{
    internal static class InvestmentAccountDebit
    {
        public static string DebitInvestmentAccount(this AccountDebit accountDebit)
        {
            // Regra: conta investimento só permite débito acima de um valor mínimo
            const decimal minimumAmount = 100;

            if (accountDebit.Amount < minimumAmount)
                throw new ArgumentException("Valor mínimo para débito em conta investimento é 100.");

            return accountDebit.FormatTransaction();
        }
    }
}