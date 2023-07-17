using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;
using BurgerApp.Services.Abstraction;

namespace BurgerApp.Services;

public class OrderService : IOrderService
{
    private IRepository<Order> _orderRepository;

    public OrderService(IRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IAsyncEnumerable<Order>> GetAllOrders()
    {
        return await _orderRepository.GetAllAsync();
    }

}
