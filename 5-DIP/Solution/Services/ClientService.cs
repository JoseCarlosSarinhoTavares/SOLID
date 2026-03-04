using SOLID.DIP.Solution.Entities;
using SOLID.DIP.Solution.Interfaces;

namespace SOLID.DIP.Solution.Services
{
    /*
     * ClientService - Camada de Serviços (Solução DIP)
     * 
     * DIP - Dependency Inversion Principle (Princípio da Inversão de Dependência)
     * 
     * SOLUÇÃO APLICADA:
     * 
     * 1. Injeção de dependência via construtor:
     *    - IClientRepository (abstração)
     *    - IEmailServices (abstração)
     * 
     * 2. Benefícios obtidos:
     *    - FÁCIL de testar (pode mockar as dependências)
     *    - FÁCIL de trocar implementações (ex: SQLite → PostgreSQL)
     *    - Baixo acoplamento = código flexível
     *    -遵循 Open/Closed (novas implementações sem modificar esta classe)
     *    - Responsabilidades claramente separadas
     * 
     * 3. Como seria um teste unitário:
     *    - Mock<IClientRepository> mockRepo = new Mock<IClientRepository>();
     *    - Mock<IEmailServices> mockEmail = new Mock<IEmailServices>();
     *    - var service = new ClientService(mockRepo.Object, mockEmail.Object);
     *    - // Testa sem banco de dados real!
     * 
     * 4. Como trocar de implementação:
     *    - Quer usar MongoDB? Crie MongoClientRepository : IClientRepository
     *    - Quer usar SendGrid? Crie SendGridEmailServices : IEmailServices
     *    - Só muda na hora de criar (Program.cs), nada aqui!
     * 
     * RESUMO:
     * "Programar para abstrações, não para implementações"
     */
    internal class ClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IEmailServices _emailServices;

        public ClientService(IClientRepository clientRepository, IEmailServices emailServices)
        {
            _clientRepository = clientRepository;
            _emailServices = emailServices;
        }

        public string AddClient(Client client)
        {
            if (!client.Validate())
                return "Invalid data";

            _clientRepository.AddClient(client);

            _emailServices.Send("noreply@company.com", client.Email.Address, "Welcome!!!", "Congratulations! You are registered.");

            return "Client successfully registered!!!";
        }
    }
}
