using BurgerApp.DataAccess.Data;
using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BurgerApp.DataAccess.Repositories.Implementations;

public class OrderRepository : IRepository<Order>
{
    private BurgerAppDbContext _dbContext;

    public OrderRepository(BurgerAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Add(Order entity)
    {
        _dbContext.Orders.Add(entity);
        _dbContext.SaveChanges();
    }

    public async Task Delete(int id)
    {
        var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
        if (order is null) throw new Exception($"Order with id {id} does not exist");

        _dbContext.Orders.Remove(order);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<ICollection<Order>> GetAllAsync()
    {
        return _dbContext.Orders;
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
        if (order is null) throw new Exception($"Order with {id} was not found");

        return order;
    }

    public async Task UpdateAsync(Order entity)
    {
        _dbContext.Orders.Attach(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

}
