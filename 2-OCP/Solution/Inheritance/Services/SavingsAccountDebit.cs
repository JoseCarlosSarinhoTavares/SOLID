using SOLID.OCP.Solution.Inheritance.Abstractions;

namespace SOLID.OCP.Solution.Inheritance.Services
{
    internal class SavingsAccountDebit : AccountDebit
    {
        public override string Debit(decimal amount, string account)
        {
            /* Regra: conta poupança não pode ter saldo negativo
               Débito permitido somente se o valor for positivo*/
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            return FormatTransaction();
        }
    }
}