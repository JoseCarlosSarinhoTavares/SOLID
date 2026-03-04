namespace SOLID.ISP.Solution.Interfaces
{
    /*
     * IProductRegistration - Interface Específica para Produto
     * 
     * Esta interface contém APENAS os métodos que fazem sentido para um Produto.
     * 
     * Herança de IRegistration:
     * - Produto também precisa do método Save() (herdado de IRegistration)
     * 
     * Métodos específicos do Produto:
     * - ValidateData() -> Produto precisa validar nome, preço, estoque, etc.
     * 
     * OBSERVAÇÃO IMPORTANTE:
     * Não há SendEmail() aqui!
     * Produto não precisa de email, então a interface não obriga a implementá-lo.
     * 
     * É exatamente isso que o ISP prega:
     * "Uma classe não deve ser forçada a depender de métodos que não utiliza."
     * 
     * Produto NÃO precisa de SendEmail() -> NÃO existe na interface!
     */
    internal interface IProductRegistration : IRegistration
    {
        void ValidateData();
    }
}
