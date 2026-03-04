using SOLID.OCP.Solution.Inheritance.Abstractions;

namespace SOLID.OCP.Solution.Inheritance.Services
{
    internal class InvestmentAccountDebit : AccountDebit
    {
        public override string Debit(decimal amount, string account)
        {
            // Regra: conta investimento só permite débito acima de um valor mínimo
            const decimal minimumAmount = 100;

            if (amount < minimumAmount)
                throw new ArgumentException("Valor mínimo para débito em conta investimento é 100.");

            return FormatTransaction();
        }
    }
}