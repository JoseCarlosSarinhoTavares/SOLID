namespace SOLID.OCP.Solution.Inheritance.Abstractions
{
    internal abstract class AccountDebit
    {
        public string TransactionNumber { get; set; } = null!;

        public abstract string Debit(decimal amount, string account);

        public string FormatTransaction()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXZ0123456789";
            var random = new Random();

            TransactionNumber = new string(
                Enumerable.Repeat(chars, 15)
                    .Select(x => x[random.Next(x.Length)])
                    .ToArray()
            );

            return TransactionNumber;
        }
    }
}