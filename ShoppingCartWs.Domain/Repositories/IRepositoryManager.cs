namespace ShoppingCartWS.Domain.Repositories
{
    public interface IRepositoryManager
    {
        ICustomerRepository CustomerRepository { get; }
        IOrderRepository OrderRepository { get; }
    }
}