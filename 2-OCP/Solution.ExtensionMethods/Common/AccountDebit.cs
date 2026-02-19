namespace SOLID.OCP.Solution.ExtensionMethods.Common
{
    internal class AccountDebit
    {
        public string AccountNumber { get; set; } = null!;
        public decimal Amount { get; set; }
        public string TransactionNumber { get; set; } = null!;

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