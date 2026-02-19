namespace SOLID.OCP.Violation.Enums
{
    // Violação OCP: enum representa tipos de conta que controlam comportamento
    // Sempre que surgir um novo tipo de conta, este enum PRECISA ser alterado
    internal enum EAccountType
    {
        CheckingAccount,
        SavingsAccount
    }
}