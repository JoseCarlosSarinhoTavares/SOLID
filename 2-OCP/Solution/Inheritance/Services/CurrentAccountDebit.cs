using SOLID.OCP.Solution.Inheritance.Abstractions;

namespace SOLID.OCP.Solution.Inheritance.Services
{
    /*
     * CurrentAccountDebit - Implementação de Débito para Conta Corrente
     * 
     * OCP - Solução com Herança
     * 
     * COMO ADICIONAR NOVA CONTA:
     * 1. Crie novo arquivo: NovoTipoDebit.cs
     * 2. Herde: class NovoTipoDebit : AccountDebit
     * 3. Implemente: override string Debit(...)
     * 
     * ZERO alteração em arquivos existentes!
     * 
     * REGRA DE NEGÓCIO:
     * - Conta Corrente tem limite de cheque especial
     * - Permite saldo negativo até R$ 500,00
     */
    internal class CurrentAccountDebit : AccountDebit
    {
        public override string Debit(decimal amount, string account)
        {
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
