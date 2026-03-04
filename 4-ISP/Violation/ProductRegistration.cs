using SOLID.ISP.Violation.Interfaces;

namespace SOLID.ISP.Violation
{
    /*
     * ProductRegistration - Cadastro de Produto
     * 
     * Esta classe representa o cadastro de um Produto no sistema.
     * Um produto, ao ser cadastrado, precisa:
     * 1. Validar seus dados (nome, preço, estoque, etc)
     * 2. Salvar no banco de dados
     * 
     * UM PRODUTO NÃO NECESSITA DE EMAIL!
     * Produtos não recebem emails de boas-vindas, confirmações, etc.
     * 
     * VIOLAÇÃO DO ISP - ANÁLISE:
     * ----------------------------------------
     * Esta classe é FORÇADA a implementar métodos que não faz sentido!
     * 
     * A interface IRegistration define 3 métodos:
     * - ValidateData() -> Faz sentido para produto ✓
     * - Save() -> Faz sentido para produto ✓
     * - SendEmail() -> NÃO faz sentido para produto! ✗
     * 
     * Problema: A interface é uma "interface gorda" (fat interface).
     * Ela força todas as classes que a implementam a terem TODOS os métodos,
     * mesmo quando alguns não são necessários.
     * 
     * Consequência:
     * - O método SendEmail() precisa ser implementado
     * - A única opção é lançar NotImplementedException
     * - Isso indica claramente um problema de design
     * - Código desnecessário e confuso
     * 
     * SOLUÇÃO:
     * Verificar a pasta "Solution" para ver como aplicar o ISP corretamente.
     * A solução é criar interfaces menores e específicas para cada necessidade.
     */
    internal class ProductRegistration : IRegistration
    {
        public void ValidateData()
        {
            Console.WriteLine("- Validando dados do produto...");
        }

        public void Save()
        {
            Console.WriteLine("- Salvando produto no banco de dados...");
        }

        public void SendEmail()
        {
            /*
             * VIOLAÇÃO EXPLÍCITA DO ISP!
             * 
             * Este método não faz sentido para produto.
             * Estamos-forçados a implementá-lo por causa da interface IRegistration.
             * 
             * Opções ruins:
             * 1. Deixar vazio (código confuso, parece que não faz nada)
             * 2. Lançar exceção (indica que algo está errado no design)
             * 
             * A solução correta seria ter uma interface SEPARADA para envios de email,
             * que apenas as classes necessárias iriam implementar.
             */
            throw new NotImplementedException("O produto não suporta o envio de e-mails.");
        }
    }
}
