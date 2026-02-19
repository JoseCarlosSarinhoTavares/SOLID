namespace SOLID.LSP.Violation
{
    /// <summary>
    /// Viola o Princípio da Substituição de Liskov (LSP).
    /// Embora herde de Rectangle, não respeita seu contrato.
    /// </summary>
    internal class Square : Rectangle
    {
        // VIOLAÇÃO DO LSP:
        // Ao definir a altura, a largura também é alterada.
        // Isso quebra a expectativa de quem usa Rectangle.
        public override double Height { set { base.Height = base.Width = value; } }

        // VIOLAÇÃO DO LSP:
        // Ao definir a largura, a altura também é alterada.
        // Rectangle pressupõe independência entre as propriedades.
        public override double Width { set { base.Height = base.Width = value; } }
    }
}