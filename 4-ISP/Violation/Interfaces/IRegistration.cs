namespace SOLID.ISP.Violation.Interfaces
{
    /*
     * ISP - Interface Segregation Principle (Princípio da Segregação de Interfaces)
     * 
     * Definição:
     * "Uma classe não deve ser forçada a depender de métodos que ela não utiliza."
     * 
     * O que significa isso na prática?
     * - Interfaces devem ser pequenas e específicas
     * - É melhor ter várias interfaces pequenas do que uma interface grande
     * - Cada classe deve implementar apenas os métodos que realmente precisa
     * 
     * PROBLEMA NESTA INTERFACE:
     * Esta interface é muito genérica ("gorda").
     * Ela define 3 métodos que são aplicados a TODOS os tipos de cadastro.
     * Porém, nem todo cadastro precisa de todos os métodos!
     * 
     * Neste caso:
     * - ValidateData() faz sentido para qualquer entidade
     * - Save() faz sentido para qualquer entidade  
     * - SendEmail() NÃO faz sentido para produtos, apenas para clientes!
     * 
     * A interface força TODAS as classes a implementarem SendEmail(),
     * mesmo que essa funcionalidade não seja necessária para elas.
     */
    internal interface IRegistration
    {
        void ValidateData();
        void Save();
        void SendEmail(); 
    }
}
