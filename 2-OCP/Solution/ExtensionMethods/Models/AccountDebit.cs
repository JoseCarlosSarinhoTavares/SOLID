namespace SOLID.OCP.Solution.ExtensionMethods.Models
{
    /*
     * AccountDebit - Modelo de Débito em Conta (Solução OCP com Extension Methods)
     * 
     * OCP - Open/Closed Principle (Princípio Aberto/Fechado)
     * 
     * SOLUÇÃO: Extension Methods
     * 
     * COMO FUNCIONA:
     * - Esta classe contém apenas dados e lógica COMUM a todas as contas
     * - A lógica específica de cada tipo de conta é implementada como EXTENSÃO
     * - Para adicionar novo tipo de conta, você CRIA uma nova extensão
     * - ZERO alteração neste arquivo ou em outros arquivos existentes!
     * 
     * BENEFÍCIOS DO OCP AQUI:
     * 1. ABERTO para extensão:
     *    - Novo tipo de conta? Crie novo arquivo de extensão
     *    - Ex: SalaryAccountDebit.cs com extensão DebitSalaryAccount()
     * 
     * 2. FECHADO para modificação:
     *    - Não precisa modificar esta classe para adicionar nova conta
     *    - Não precisa modificar as extensões existentes
     * 
     * 3. Código estável:
     *    - Novas features não quebram features existentes
     *    - Cada extensão é independente
     * 
     * PADRÃO DE NOMENCLATURA:
     * - Models: dados e comportamentos comuns
     * - Services: extensões específicas por tipo de conta
     */
    internal class AccountDebit
    {
        public string AccountNumber { get; set; } = null!;
        public decimal Amount { get; set; }
        public string TransactionNumber { get; set; } = null!;

        public string FormatTransaction()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXZ0123456789";
            var random = new Random();

            TransactionNumber = new string(
                Enumerable.Repeat(chars, 15)
                    .Select(x => x[random.Next(x.Length)])
                    .ToArray()
            );

            return TransactionNumber;
        }
    }
}
