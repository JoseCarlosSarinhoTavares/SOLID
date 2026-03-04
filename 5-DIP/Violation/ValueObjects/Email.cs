namespace SOLID.DIP.Violation.ValueObjects
{
    internal class Email
    {
        public string Address { get; set; } = null!;

        public bool Validate()
        {
            return Address.Contains("@");
        }
    }
}