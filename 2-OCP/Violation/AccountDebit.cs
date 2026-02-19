using SOLID.OCP.Violation.Enums;

namespace SOLID.OCP.Violation
{
    internal class AccountDebit
    {
        // Violação OCP: método depende diretamente do enum EAccountType
        // Para adicionar um novo tipo de conta, este método PRECISA ser alterado
        public void Debit(decimal value, decimal balance, decimal limit, EAccountType accountType)
        {
            // Violação OCP: regra de Conta Corrente está hardcoded aqui
            // Nova regra = alteração de código existente
            if (accountType == EAccountType.CheckingAccount)
            {
                // Violação OCP: lógica específica de negócio acoplada ao if
                if (value > balance + limit)
                    throw new Exception("Saldo + limite insuficiente");

                balance -= value;
            }

            // Violação OCP: regra de Conta Poupança está hardcoded aqui
            // Inclusão de novo tipo (Investimento, Salário, etc.) quebra o OCP
            if (accountType == EAccountType.SavingsAccount)
            {
                // Violação OCP: múltiplas regras em um único método
                if (value > balance)
                    throw new Exception("Saldo insuficiente");

                balance -= value;
            }
        }
    }
}