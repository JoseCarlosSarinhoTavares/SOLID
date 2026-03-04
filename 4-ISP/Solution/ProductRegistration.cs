using SOLID.ISP.Solution.Interfaces;

namespace SOLID.ISP.Solution
{
    /*
     * ProductRegistration - Cadastro de Produto (Solução ISP)
     * 
     * Esta classe implementa a interface IProductRegistration.
     * 
     * O que a classe tem:
     * - ValidateData() -> Valida dados do produto
     * - Save() -> Salva no banco de dados
     * 
     * PORQUE ESTÁ CORRETO (ISP):
     * A classe implementa IProductRegistration que herda de IRegistration.
     * 
     * IProductRegistration define:
     * - ValidateData() ✓ (faz sentido para produto)
     * 
     * IRegistration (herdado) define:
     * - Save() ✓ (faz sentido para qualquer entidade)
     * 
     * COMPARANDO COM A VIOLAÇÃO:
     * 
     * ANTES (na pasta Violation):
     * - Interface IRegistration tinha SendEmail()
     * - ProductRegistration era forçada a implementar SendEmail()
     * - Resultado: throw NotImplementedException
     * 
     * DEPOIS (aqui):
     * - Interface IProductRegistration NÃO tem SendEmail()
     * - ProductRegistration só implementa o que precisa
     * - Nenhum método desnecessário!
     * - Código limpo e sem exceções desnecessárias
     * 
     * ISPCorreto implementado:
     * "Uma classe não deve ser forçada a depender de métodos que ela não utiliza."
     */
    internal class ProductRegistration : IProductRegistration, IRegistration
    {
        public void ValidateData()
        {
            Console.WriteLine("- Validando dados do produto...");
        }

        public void Save()
        {
            Console.WriteLine("- Salvando produto no banco de dados...");
        }
    }
}
