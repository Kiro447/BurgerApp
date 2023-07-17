using BurgerApp.DataAccess.Data;
using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BurgerApp.DataAccess.Repositories.Implementations;

public class BurgerRepository : IRepository<Burger>
{
    private BurgerAppDbContext _dbContext;

    public BurgerRepository(BurgerAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Burger entity)
    {
        _dbContext.Add(entity);
        _dbContext.SaveChanges();
    }

    public async Task Delete(int id)
    {
        var burger = _dbContext.Burgers.FirstOrDefaultAsync(b => b.Id == id);
        if (burger is null) throw new Exception($"Burger with id {id} was not found");

        _dbContext.Remove(burger);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IAsyncEnumerable<Burger>> GetAllAsync()
    {
        return _dbContext.Burgers.AsAsyncEnumerable();
    }

    public async Task<Burger> GetByIdAsync(int id)
    {
        var burger = await _dbContext.Burgers.FirstOrDefaultAsync(x =>  x.Id == id);
        if (burger is null) throw new Exception($"Burger with id {id} was not found");
        return burger;
    }

    public async Task UpdateAsync(Burger entity)
    {
        _dbContext.Burgers.Attach(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
