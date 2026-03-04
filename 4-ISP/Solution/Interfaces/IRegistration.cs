namespace SOLID.ISP.Solution.Interfaces
{
    /*
     * IRegistration - Interface Base Comum
     * 
     * Esta é a interface BASE, que contém apenas o que é COMUM a todos os cadastros.
     * 
     * PENSAMENTO DO ISP:
     * "Qual é o mínimo que toda entidade de cadastro precisa ter?"
     * 
     * Resposta: Apenas o método Save() (salvar no banco de dados).
     * Todas as entidades precisam ser salvas em algum lugar.
     * 
     * Esta interface é:
     * - Pequena (apenas 1 método)
     * - Genérica o suficiente (serve para qualquer tipo de cadastro)
     * - Não força classes a implementarem métodos desnecessários
     * 
     * Esta interface serve como CONTRATO BASE.
     * Interfaces específicas herdam dela quando precisam de mais funcionalidades.
     */
    internal interface IRegistration
    {
        void Save();
    }
}
