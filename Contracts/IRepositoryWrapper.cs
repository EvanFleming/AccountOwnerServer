namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IOwnerRepository Owner { get; }
        IAccountRepository Account { get; }

        //was void return type, changed to task in order to get rid of Compiler Error CS4008 in OwnerController Create, Update and Delete methods
        Task SaveAsync();
    }
}