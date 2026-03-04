using SOLID.DIP.Violation.ValueObjects;

namespace SOLID.DIP.Violation.Entities
{
    internal class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; } = null!;
        public Email Email { get; set; } = null!;
        public Cpf CPF { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }

        public bool Validate()
        {
            return Email.Validate() && CPF.Validate();
        }
    }
}