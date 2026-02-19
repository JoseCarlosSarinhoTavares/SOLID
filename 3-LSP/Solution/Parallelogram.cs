namespace SOLID.LSP.Solution
{
    /// <summary>
    /// Classe base abstrata que representa um paralelogramo.
    /// A implementação respeita o Princípio da Substituição de Liskov (LSP),
    /// garantindo que as regras do objeto sejam definidas no construtor
    /// e não alteradas por subclasses.
    /// </summary>
    internal abstract class Parallelogram
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="Parallelogram"/>.
        /// </summary>
        /// <param name="height">Altura da forma geométrica.</param>
        /// <param name="width">Largura da forma geométrica.</param>
        protected Parallelogram(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public double Height { get; private set; }

        public double Width { get; private set; }

        public double CalculatedArea => Height * Width;
    }

}