using SOLID.OCP.Solution.ExtensionMethods.Models;

namespace SOLID.OCP.Solution.ExtensionMethods.Services
{
    /*
     * CurrentAccountDebit - Extensão para Débito em Conta Corrente
     * 
     * OCP - Solução com Extension Methods
     * 
     * COMO ADICIONAR NOVA CONTA:
     * 1. Crie novo arquivo: NovoTipoDebit.cs
     * 2. Crie extensão: public static string DebitNovoTipo(this AccountDebit accountDebit)
     * 3. Implemente a regra de negócio específica
     * 4. Use no ATM.cs: accountDebit.DebitNovoTipo()
     * 
     * ZERO alteração em arquivos existentes!
     * 
     * REGRA DE NEGÓCIO:
     * - Conta Corrente tem limite de cheque especial
     * - Permite saldo negativo até o limite
     */
    internal static class CurrentAccountDebit
    {
        public static string DebitCurrentAccount(this AccountDebit accountDebit)
        {
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
