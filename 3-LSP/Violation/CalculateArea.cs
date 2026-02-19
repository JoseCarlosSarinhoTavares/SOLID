namespace SOLID.LSP.Violation
{
    /// <summary>
    /// Demonstra um cenário de violação do Princípio da Substituição de Liskov (LSP).
    /// Um Square é tratado como Rectangle, causando comportamento inesperado.
    /// </summary>
    internal class CalculateArea
    {
        /// <summary>
        /// Exibe no console a área de um retângulo.
        /// Quando um Square é passado, o contrato do Rectangle é quebrado,
        /// evidenciando a violação do LSP.
        /// </summary>
        private static void ShowRectangleArea(Rectangle rectangle)
        {
            Console.Clear();
            Console.WriteLine("Cálculo da área do Retângulo");
            Console.WriteLine("----------------------------\n");

            Console.WriteLine($"{rectangle.Height} x {rectangle.Width}");
            Console.WriteLine($"Área: {rectangle.Area}\n");

            Console.WriteLine("EXPLICAÇÃO:");
            Console.WriteLine(" - O método espera um Retângulo, mas recebeu um Quadrado.");
            Console.WriteLine(" - Por isso o valor exibido é o do Quadrado, não o do Retângulo.");
            Console.WriteLine(" - Isso evidencia a violação do Princípio da Substituição de Liskov (LSP).");

        }

        /// <summary>
        /// Executa o cenário de violação do LSP
        /// recebendo os valores externamente.
        /// </summary>
        public static void Calculate(double height, double width)
        {
            // Square sendo usado como Rectangle (violação do LSP)
            var square = new Square
            {
                Height = height,
                Width = width
            };

            ShowRectangleArea(square);
        }
    }
}