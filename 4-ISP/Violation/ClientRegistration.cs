using SOLID.ISP.Violation.Interfaces;

namespace SOLID.ISP.Violation
{
    /*
     * ClientRegistration - Cadastro de Cliente
     * 
     * Esta classe representa o cadastro de um Cliente no sistema.
     * Um cliente, ao ser cadastrado, precisa:
     * 1. Validar seus dados (CPF, email, etc)
     * 2. Salvar no banco de dados
     * 3. Receber um email de boas-vindas
     * 
     * ANÁLISE DO ISP:
     * Nesta classe, NÃO há violação do princípio ISP.
     * 
     * A interface IRegistration possui 3 métodos:
     * - ValidateData() -> Faz sentido para cliente ✓
     * - Save() -> Faz sentido para cliente ✓
     * - SendEmail() -> Faz sentido para cliente ✓
     * 
     * Todos os métodos da interface são relevantes para esta classe.
     * O cliente realmente precisa enviar email de boas-vindas.
     */
    internal class ClientRegistration : IRegistration
    {
        public void ValidateData()
        {
            Console.WriteLine("- Validação do CPF e do e-mail...");
        }

        public void Save()
        {
            Console.WriteLine("- Salvando cliente no banco de dados...");
        }

        public void SendEmail()
        {
            Console.WriteLine("- Envio de e-mail de boas-vindas ao cliente...");
        }
    }
}
