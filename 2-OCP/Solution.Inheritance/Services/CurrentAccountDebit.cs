using SOLID.OCP.Solution.Inheritance.Abstractions;

namespace SOLID.OCP.Solution.Inheritance.Services
{
    internal class CurrentAccountDebit : AccountDebit
    {
        public override string Debit(decimal amount, string account)
        {
            // Regra: conta corrente permite débito usando saldo + cheque especial
            const decimal overdraftLimit = 500;
            decimal balance = 1000;

            if (amount <= 0)
                throw new ArgumentException("O valor do débito deve ser maior que zero.");

            if (amount > balance + overdraftLimit)
                throw new InvalidOperationException("Saldo e limite insuficientes.");

            return FormatTransaction();
        }
    }
}