namespace SOLID.OCP.Solution.Inheritance.Abstractions
{
    /*
     * AccountDebit - Classe Abstrata para Débito em Conta (Solução OCP com Herança)
     * 
     * OCP - Open/Closed Principle (Princípio Aberto/Fechado)
     * 
     * SOLUÇÃO: Herança (Inheritance)
     * 
     * COMO FUNCIONA:
     * - Esta é uma classe ABSTRATA (contrato base)
     * - Define o que é COMUM a todas as contas
     * - Cada tipo de conta herda e implementa sua própria lógica
     * 
     * BENEFÍCIOS DO OCP AQUI:
     * 1. ABERTO para extensão:
     *    - Novo tipo de conta? Crie nova classe herdando de AccountDebit
     *    - Ex: SalaryAccountDebit : AccountDebit
     * 
     * 2. FECHADO para modificação:
     *    - Não precisa modificar esta classe abstrata
     *    - Não precisa modificar as classes filhas existentes
     * 
     * 3. Polimorfismo:
     *    - Você pode tratar todas as contas da mesma forma
     *    - AccountDebit conta = new CurrentAccountDebit();
     * 
     * PADRÃO DE PROJETO:
     * - Template Method: Define o esqueleto do algoritmo
     * - Factory: pode criar instâncias baseado no tipo
     */
    internal abstract class AccountDebit
    {
        public string TransactionNumber { get; set; } = null!;

        public abstract string Debit(decimal amount, string account);

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
