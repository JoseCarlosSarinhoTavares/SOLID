using SOLID.OCP.Violation.Enums;

namespace SOLID.OCP.Violation.Services
{
    /*
     * AccountDebit - Serviço de Débito em Conta (Violação do OCP)
     * 
     * OCP - Open/Closed Principle (Princípio Aberto/Fechado)
     * 
     * Definição:
     * "Entidades de software devem estar abertas para extensão, mas fechadas para modificação."
     * 
     * O QUE ESTÁ VIOLANDO O OCP:
     * 
     * 1. IFs hardcoded:
     *    - Para adicionar um novo tipo de conta (ex: Conta Salário), você PRECISA
     *      modificar este método adicionando um novo "if"
     *    - Isso viola o princípio: "fechado para modificação"
     * 
     * 2. Acoplamento direto ao enum:
     *    - O método depende de EAccountType
     *    - Cada novo tipo de conta exige mudança no enum E TAMBÉM neste código
     * 
     * 3. Problemas causados:
     *    - Código instável: mudar uma conta pode quebrar outra
     *    - Difícil manutenção: quanto mais tipos, mais ifs
     *    - Testes difíceis: precisa testar todos os ifs
     *    - Risco de regressão: nova feature pode quebrar feature existente
     * 
     * EXEMPLO DO PROBLEMA:
     *    Se quiser adicionar "Conta Investimento", você precisa:
     *    1. Adicionar novo valor no enum EAccountType
     *    2. Adicionar novo if neste método
     *    3. Testar TODAS as contas existentes
     *    
     *    Isso é EXATAMENTE o que o OCP quer evitar!
     * 
     * SOLUÇÕES (veja em Solution):
     *    - Extension Methods: criar extensões por tipo de conta
     *    - Herança: criar classes específicas que herdam de abstrata
     *    - Ambas permitem ADICIONAR novo tipo sem modificar código existente
     */
    internal class AccountDebit
    {
        public void Debit(decimal value, decimal balance, decimal limit, EAccountType accountType)
        {
            if (accountType == EAccountType.CheckingAccount)
            {
                if (value > balance + limit)
                    throw new Exception("Saldo + limite insuficiente");

                balance -= value;
            }

            if (accountType == EAccountType.SavingsAccount)
            {
                if (value > balance)
                    throw new Exception("Saldo insuficiente");

                balance -= value;
            }
        }
    }
}
