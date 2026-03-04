namespace SOLID.ISP.Solution.Interfaces
{
    /*
     * IClientRegistration - Interface Específica para Cliente
     * 
     * Esta interface contém APENAS os métodos que fazem sentido para um Cliente.
     * 
     * Herança de IRegistration:
     * - Cliente também precisa do método Save() (herdado de IRegistration)
     * 
     * Métodos específicos do Cliente:
     * - ValidateData() -> Cliente precisa validar CPF, email, etc.
     * - SendEmail() -> Cliente precisa receber email de boas-vindas
     * 
     * BENEFÍCIOS DO ISP AQUI:
     * 1. Interface pequena e específica
     * 2. Cliente só implementa o que realmente precisa
     * 3. Não há métodos desnecessários
     * 4. Se precisarmos adicionar um método só para cliente,
     *    adicionamos aqui, sem afetar outras classes
     */
    internal interface IClientRegistration : IRegistration
    {
        void ValidateData();
        void SendEmail();
    }
}
