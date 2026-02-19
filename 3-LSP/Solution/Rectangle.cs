namespace SOLID.LSP.Solution
{
    /// <summary>
    /// Representa um retângulo.
    /// Especialização de <see cref="Parallelogram"/>,
    /// mantendo o contrato definido na classe base
    /// e respeitando o Princípio da Substituição de Liskov (LSP).
    /// </summary>
    internal class Rectangle : Parallelogram
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="height">Altura do retângulo.</param>
        /// <param name="width">Largura do retângulo.</param>
        public Rectangle(int height, int width) : base(height, width)
        {
        }
    }
}