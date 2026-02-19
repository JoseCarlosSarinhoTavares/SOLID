using System.Net.Mail;

namespace SOLID.SRP.Solution.ValueObjects
{
    internal class Mail
    {
        public string Address { get; }

        public Mail(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("E-mail inválido");

            try
            {
                _ = new MailAddress(address);
            }
            catch
            {
                throw new ArgumentException("E-mail inválido");
            }

            Address = address;
        }

        public bool Validate() => true;
    }
}