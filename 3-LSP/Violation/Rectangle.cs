namespace SOLID.LSP.Violation
{
    /// <summary>
    /// Classe base que define o contrato de um retângulo.
    /// CONTRATO: Height e Width devem ser independentes.
    /// Alterar um não deve impactar o outro.
    /// </summary>
    internal class Rectangle
    {
        // Espera-se que a altura possa ser alterada
        // sem modificar a largura.
        public virtual double Height { get; set; }

        // Espera-se que a largura possa ser alterada
        // sem modificar a altura.
        public virtual double Width { get; set; }

        // Área calculada com base no contrato acima.
        public double Area => Height * Width;
    }
}