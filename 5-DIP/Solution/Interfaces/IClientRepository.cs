using SOLID.DIP.Solution.Entities;

namespace SOLID.DIP.Solution.Interfaces
{
    /*
     * IClientRepository - Interface para Repositório de Clientes
     * 
     * Esta é uma ABSTRAÇÃO (contrato) que define como o ClientService
     * se comunica com a camada de persistência de dados.
     * 
     * PORQUE É IMPORTANTE:
     * - ClientService não precisa saber COMOS os dados são salvos
     * - Pode ser SQLite, PostgreSQL, MongoDB, arquivo texto, etc.
     * - A implementação pode mudar sem alterar o código do service
     * 
     * O QUE DEFINE:
     * - AddClient() -> método para salvar um cliente
     * 
     * DETALHE IMPORTANTE:
     * - Esta interface está no projeto de mais alto nível (Services)
     * - A implementação (ClientRepository) está em DataAccess (módulo de menor nível)
     * - Isso inverte a dependência! (daí o nome Dependency Inversion)
     */
    internal interface IClientRepository
    {
        void AddClient(Client client);
    }
}
