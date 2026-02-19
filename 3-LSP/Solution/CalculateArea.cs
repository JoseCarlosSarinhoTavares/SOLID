namespace SOLID.LSP.Solution
{
    /// <summary>
    /// Classe responsável por demonstrar o cálculo de área
    /// utilizando a solução que respeita o Princípio da Substituição de Liskov (LSP).
    /// </summary>
    internal class CalculateArea
    {
        /// <summary>
        /// Exibe no console as áreas de diferentes paralelogramos.
        /// O método aceita qualquer objeto que herde de <see cref="Parallelogram"/>,
        /// sem quebrar comportamento, comprovando o respeito ao LSP.
        /// </summary>
        private static void ShowParallelogramAreas(Parallelogram square, Parallelogram rectangle)
        {
            Console.Clear();
            Console.WriteLine("Cálculo das Áreas");
            Console.WriteLine("-----------------\n");

            Console.WriteLine("Quadrado");
            Console.WriteLine($"{square.Height} x {square.Width}");
            Console.WriteLine($"Área: {square.CalculatedArea}\n");

            Console.WriteLine("Retângulo");
            Console.WriteLine($"{rectangle.Height} x {rectangle.Width}");
            Console.WriteLine($"Área: {rectangle.CalculatedArea}");
        }

        /// <summary>
        /// Executa o cenário de cálculo de área
        /// para diferentes formas geométricas,
        /// demonstrando substituição segura entre tipos.
        /// </summary>
        public static void Calculate(int squareSide, int rectangleHeight, int rectangleWidth)
        {
            var square = new Square(squareSide, squareSide);
            var rectangle = new Rectangle(rectangleHeight, rectangleWidth);

            ShowParallelogramAreas(square, rectangle);
        }
    }
}