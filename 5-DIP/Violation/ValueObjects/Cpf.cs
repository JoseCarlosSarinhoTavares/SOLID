namespace SOLID.DIP.Violation.ValueObjects
{
    internal class Cpf
    {
        public string Number { get; set; } = null!;

        public bool Validate()
        {
            return Number.Length == 11;
        }
    }
}