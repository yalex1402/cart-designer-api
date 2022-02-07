namespace ShoppingCartWS.Services.ServicesContracts
{
    public interface IServicesManager
    {
        ICustomerService CustomerService {get;}
        IOrderService OrderService {get;}
    }
}