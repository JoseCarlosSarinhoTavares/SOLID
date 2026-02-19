namespace SOLID.SRP.Solution.ValueObjects
{
    internal class Cpf
    {
        public string Number { get; }

        public Cpf(string number)
        {
            if (string.IsNullOrWhiteSpace(number) || number.Length != 11)
                throw new ArgumentException("CPF inválido");

            Number = number;
        }

        public bool Validate() => true;
    }
}