using SOLID.DIP.Violation.Entities;
using SOLID.DIP.Violation.DataAccess;

namespace SOLID.DIP.Violation.Services
{
    /*
     * ClientService - Camada de Serviços (Violação do DIP)
     * 
     * DIP - Dependency Inversion Principle (Princípio da Inversão de Dependência)
     * 
     * Definição:
     * 1. Módulos de alto nível não devem depender de módulos de baixo nível.
     * 2. Ambos devem depender de abstrações.
     * 3. Abstrações não devem depender de detalhes.
     *    Detalhes devem depender de abstrações.
     * 
     * O QUE ESTÁ ERRADO NESTE CÓDIGO:
     * 
     * 1. Acoplamento concreto:
     *    - new ClientRepository() -> Dependência CONCRETA
     *    - EmailServices.Send() -> Método ESTÁTICO concreto
     * 
     * 2. Problemas causados:
     *    - DIFÍCIL de testar (não consegue mockar as dependências)
     *    - DIFÍCIL de trocar a implementação (ex: mudar de SQLite para PostgreSQL)
     *    - VIOLAÇÃO do Open/Closed (mudar dependência = modificar esta classe)
     *    - Alto acoplamento = código frágil
     * 
     * 3. Exemplo de problema:
     *    - Quer testar ClientService sem banco de dados?
     *      Não consegue! Precisa de um banco real.
     *    - Quer trocar EmailServices por outro serviço?
     *      Precisa modificar esta classe.
     * 
     * SOLUÇÃO (veja em Solution):
     * - Criar interfaces (abstrações)
     * - Injetar dependências via construtor
     * - ClientService depende de abstrações, não de implementações
     */
    internal class ClientService
    {
        public string AddClient(Client client)
        {
            if (!client.Validate())
                return "Invalid data";

            var clientRepository = new ClientRepository();
            clientRepository.AddClient(client);

            EmailServices.Send("client@client.com", client.Email.Address, "Welcome!!!", "Congratulations! You are registered.");

            return "Client successfully registered!!!";
        }
    }
}
