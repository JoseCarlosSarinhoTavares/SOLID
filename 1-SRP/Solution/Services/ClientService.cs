using SOLID.SRP.Solution.DataAccess;
using SOLID.SRP.Solution.Entities;

namespace SOLID.SRP.Solution.Services
{
    internal class ClientService
    {
        public string AddClient(Client client)
        {
            if (!client.Validate())
                return "Dados inválidos";

            var _clientPersistence = new ClientDataAccess();
            _clientPersistence.AddClient(client);

            if (!MailServices.Send(
                    client.Mail.Address,
                    "Bem vindo!!!",
                    "Parabéns! Você está cadastrado.",
                    out var emailError))
            {
                return $"Cliente salvo, mas e-mail não enviado: {emailError}";
            }

            return "Cliente cadastrado com sucesso!!!";
        }
    }
}