using SOLID.SRP.Solution.ValueObjects;

namespace SOLID.SRP.Solution.Entities
{
    internal class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; } = null!;
        public Mail Mail { get; set; } = null!;
        public Cpf Cpf { get; set; } = null!;
        public DateTime DateRegistration { get; set; }

        public bool Validate()
        {
            return Mail.Validate() && Cpf.Validate();
        }
    }
}