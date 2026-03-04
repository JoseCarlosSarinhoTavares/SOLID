using SOLID.ISP.Solution.Interfaces;

namespace SOLID.ISP.Solution
{
    /*
     * ClientRegistration - Cadastro de Cliente (Solução ISP)
     * 
     * Esta classe implementa a interface IClientRegistration.
     * 
     * O que a classe tem:
     * - ValidateData() -> Valida dados do cliente
     * - Save() -> Salva no banco de dados  
     * - SendEmail() -> Envia email de boas-vindas
     * 
     * POR QUE ESTÁ CORRETO (ISP):
     * A classe implementa IClientRegistration que herda de IRegistration.
     * 
     * IClientRegistration define:
     * - ValidateData() ✓ (faz sentido para cliente)
     * - SendEmail() ✓ (faz sentido para cliente)
     * 
     * IRegistration (herdado) define:
     * - Save() ✓ (faz sentido para qualquer entidade)
     * 
     * Todos os métodos são relevantes!
     * Nenhum método desnecessário é forçado a ser implementado.
     */
    internal class ClientRegistration : IClientRegistration, IRegistration
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
