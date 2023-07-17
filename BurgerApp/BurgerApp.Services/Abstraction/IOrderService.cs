using BurgerApp.Domain.Models;

namespace BurgerApp.Services.Abstraction;

public interface IOrderService
{
    Task<IAsyncEnumerable<Order>> GetAllOrders();
}
