namespace SOLID.LSP.Solution
{
    /// <summary>
    /// Representa um quadrado.
    /// Especialização de <see cref="Parallelogram"/> que
    /// valida sua regra de negócio no construtor,
    /// garantindo que todos os lados tenham o mesmo tamanho.
    /// Esta abordagem respeita o Princípio da Substituição de Liskov (LSP).
    /// </summary>
    internal class Square : Parallelogram
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="Square"/>.
        /// </summary>
        /// <param name="side">Valor do lado do quadrado.</param>
        /// <exception cref="ArgumentException">
        /// Lançada quando altura e largura possuem valores diferentes.
        /// </exception>
        public Square(int height, int width) : base(height, width)
        {
            // Garante a regra do quadrado no momento da criação
            if (height != width)
                throw new ArgumentException("Os dois lados do quadrado precisam ser iguais.");
        }
    }
}